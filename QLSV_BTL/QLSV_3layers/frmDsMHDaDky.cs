using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmDsMHDaDky : Form
    {
        private string masv;
        public frmDsMHDaDky(string masv)
        {
            this.masv = masv;
            InitializeComponent();
        }

        private void frmDsMHDaDky_Load(object sender, EventArgs e)
        {
            LoadMonDky();
        }
        private void LoadMonDky()
        {
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@masinhvien",
                    value = masv
                }
            };
            dgvDSMHDky.DataSource = new Database().SelectData("monDaDKy", lst);
        }

        private void btnDkyMoi_Click(object sender, EventArgs e)
        {
            new frmDangkyMonhoc(masv).ShowDialog();
            LoadMonDky();
        }
    }
}
