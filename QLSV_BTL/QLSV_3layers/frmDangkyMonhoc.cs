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
    public partial class frmDangkyMonhoc : Form
    {
        public frmDangkyMonhoc(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }

        private string msv;

        private void frmDKyMHoc_Load(object sender, EventArgs e)
        {
            LoadDSLH();
            //custom lại tên cột
            dgvDSLH.Columns["malophoc"].HeaderText = "Mã lớp";
            dgvDSLH.Columns["tenmonhoc"].HeaderText = "Tên học phần";
            dgvDSLH.Columns["sotinchi"].HeaderText = "Số TC";
            dgvDSLH.Columns["gvien"].HeaderText = "Giáo viên";

            //cột mã môn học dùng để lấy thông tin đăng ký môn học
            //như part 17, để đăng ký môn học cần có 2 thông tin: mã sinh viên và mã môn học
            //không cần thiết phải hiển thị -> cho ẩn cột này đi
            dgvDSLH.Columns["mamonhoc"].Visible = false;
        }
        private void LoadDSLH()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = msv
            });
            dgvDSLH.DataSource = new Database().SelectData("dsLopChuaDKy",lstPara);
        }

        private void dgvDSLH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ý tưởng
            //khi doubl click vào 1 dòng sẽ hiện lên hộp thoại xác nhận đăng ký môn học
            if(dgvDSLH.Rows[e.RowIndex].Index>=0)//chỉ số hàng của datagridview bắt đầu từ 0
            {
                if(
                    DialogResult.Yes == 
                    MessageBox.Show(
                                    "Bạn muốn đăng ký học phần [" + dgvDSLH.Rows[e.RowIndex].Cells["tenmonhoc"].Value.ToString()+"]?",
                                    "Xác nhận đăng ký",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                    )
                 )
                {
                    List<CustomParameter> lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter() {
                          key = "@masinhvien",
                          value =msv                      
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@malophoc",
                        value = dgvDSLH.Rows[e.RowIndex].Cells["malophoc"].Value.ToString()
                    });

                    var rs = new Database().ExeCute("[dkyhoc]", lstPara);
                    if ( rs== -1)
                    {
                        MessageBox.Show("Học phần này bạn đã đăng ký","Cảnh báo!!!!");
                        return;
                    }
                    if (rs == 1)
                    {
                        MessageBox.Show("Đã đăng ký học phần thành công", "SUCCESS!!!!");
                        LoadDSLH();
                    }
                }
                
            }
        }
    }
}
