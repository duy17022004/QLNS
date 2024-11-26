using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NHANVIEN
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();

            cmbAccountType.Items.Add("Admin");
            cmbAccountType.Items.Add("Nhân viên");
            cmbAccountType.SelectedIndex = 0; // Chọn mục mặc định là "Admin"
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //fTableManager f = new fTableManager();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();

            // Lấy dữ liệu từ TextBox và ComboBox
            string tk = txbUserName.Text.Trim();
            string mk = txbPassWord.Text.Trim();
            string selectedAccountType = cmbAccountType.SelectedItem.ToString();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tk))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo");
                txbUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo");
                txbPassWord.Focus();
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_NHANVIEN_NET;Integrated Security=True";

            try
            {
                // Sử dụng `using` để đảm bảo giải phóng tài nguyên
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Mở kết nối

                    // Câu truy vấn kiểm tra thông tin đăng nhập (sử dụng tham số để tránh SQL Injection)
                    string sql = "SELECT Loai_TKhoan FROM TaiKhoan WHERE Ten_TKhoan = @tk AND Mat_Khau = @mk";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Thêm tham số cho truy vấn
                        cmd.Parameters.AddWithValue("@tk", tk);
                        cmd.Parameters.AddWithValue("@mk", mk);

                        using (SqlDataReader dta = cmd.ExecuteReader())
                        {
                            // Kiểm tra kết quả truy vấn
                            if (dta.Read()) // Nếu có dòng kết quả trả về
                            {
                                string loaitk = dta["Loai_TKhoan"].ToString();

                                // So sánh loại tài khoản từ cơ sở dữ liệu với ComboBox
                                if (string.Equals(loaitk, selectedAccountType, StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Đăng nhập thành công! Loại tài khoản: " + loaitk, "Thông báo");

                                    // Mở form tương ứng với loại tài khoản
                                    if (loaitk == "Admin")
                                    {
                                        frmAdmin formAdmin = new frmAdmin();
                                        formAdmin.ShowDialog();
                                    }
                                    else if (loaitk == "Nhân viên")
                                    {
                                        frmEmployees formNhanVien = new frmEmployees();
                                        formNhanVien.ShowDialog();
                                    }

                                    this.Hide(); // Ẩn form đăng nhập
                                    this.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Loại tài khoản không khớp với thông tin đăng nhập!", "Thông báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo");
                                txbUserName.Clear();
                                txbPassWord.Clear();
                                txbUserName.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo");
            }
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
