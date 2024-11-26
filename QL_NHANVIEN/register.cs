using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NHANVIEN
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void btnExti_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
            this.Close();
        }
    }
}
