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
    public partial class frmAdmin : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_NHANVIEN_NET;Integrated Security=True";

        public frmAdmin()
        {
            InitializeComponent();

            cbaccount.Items.Add("Admin");
            cbaccount.Items.Add("Nhân viên");
            cbaccount.SelectedIndex = 0; // Chọn mục mặc định là "Admin"

            LoadData();
        }

        private void LoadData()
        {
            // Hàm này gọi các phương thức riêng biệt cho từng tab
            LoadChucVu();
            LoadTaiKhoan();
            LoadNhanVien();
            LoadPhongBan();
        }

        // Hàm load dữ liệu bảng Chức Vụ vào DataGridView
        private void LoadChucVu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ChucVu";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChucVu.DataSource = dt; // dgvChucVu là DataGridView hiển thị dữ liệu Chức Vụ
            }
        }

        // Hàm load dữ liệu bảng Tài Khoản vào DataGridView
        private void LoadTaiKhoan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TaiKhoan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTaiKhoan.DataSource = dt; // dgvTaiKhoan là DataGridView hiển thị dữ liệu Tài Khoản
            }
        }

        // Hàm load dữ liệu bảng Nhân Viên vào DataGridView
        private void LoadNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt; // dgvNhanVien là DataGridView hiển thị dữ liệu Nhân Viên
            }
        }

        private void LoadPhongBan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PhongBan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhongBan.DataSource = dt; // dgvPhongBan là DataGridView hiển thị dữ liệu Phòng Ban
            }
        }


        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            register r=new register();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }
    }
}
