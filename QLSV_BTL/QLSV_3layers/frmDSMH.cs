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
    public partial class frmDSMH_ : Form
    {
        public frmDSMH_()
        {
            InitializeComponent();
        }

        private void dgvDSMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                var mamh = dgvDSMH.Rows[e.RowIndex].Cells["mamonhoc"].Value.ToString();
                new frmMonHoc(mamh).ShowDialog();
                LoadDSMH();
            }
        }
        private string tukhoa = "";

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            new frmMonHoc(null).ShowDialog();
            LoadDSMH();
        }

        private void LoadDSMH()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSMH.DataSource = new Database().SelectData("selectAllMonHoc",lstPara);
        }

        private void frmDSMH__Load(object sender, EventArgs e)
        {
            LoadDSMH();
            //dgvDSMH.Columns["mamonhoc"].HeaderText = "Mã MH";
            //dgvDSMH.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            //dgvDSMH.Columns["sotinchi"].HeaderText = "Số TC";

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            LoadDSMH();
        }

        private void dgvDSMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvDSMH.Columns["btnDelete"].Index)
                {
                    if (MessageBox.Show("Bạn chắc chắn xóa môn học: " + dgvDSMH.Rows[e.RowIndex].Cells["tenmonhoc"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var maMH = dgvDSMH.Rows[e.RowIndex].Cells["mamonhoc"].Value.ToString();
                        //MessageBox.Show(maGV);
                        var sql = "deleteMH";
                        var lstPara = new List<CustomParameter>()
                    {
                        new CustomParameter
                        {
                            key = "@mamonhoc",
                            value = maMH
                        }
                    };
                        var result = new Database().ExeCute(sql, lstPara);
                        if (result == 1)
                        {
                            MessageBox.Show("Xóa môn học thành công");
                            LoadDSMH();
                        }
                    }

                }


            }
        }
    }
}
