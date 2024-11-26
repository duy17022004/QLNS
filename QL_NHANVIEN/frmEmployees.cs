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
    public partial class frmEmployees : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_NHANVIEN_NET;Integrated Security=True";
        public frmEmployees()
        {
            InitializeComponent();

            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhanVien2.DataSource = dt; // dgvNhanVien là DataGridView hiển thị dữ liệu Nhân Viên
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            register r = new register();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }
    }
}
