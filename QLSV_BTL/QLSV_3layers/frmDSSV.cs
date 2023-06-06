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
    public partial class frmDSSV : Form
    {
        public frmDSSV()
        {
            InitializeComponent();
        }

        private string tukhoa="";
        private void frmDSSV_Load(object sender, EventArgs e)
        {
            LoadDSSV();//gọi tới hàm load sinh viên khi form đc load
        }

        private void LoadDSSV()
        {
            //load toàn bộ danh sách sinh viên khi form được load

            //khai báo list customparameter --> xem part 3 để hiểu rõ hơn
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvSinhVien.DataSource = new Database().SelectData("SelectAllSinhVien",lstPara);

            //đặt tên cột
            dgvSinhVien.Columns["masinhvien"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["hoten"].HeaderText = "Họ tên";
            dgvSinhVien.Columns["nsinh"].HeaderText = "Ngày sinh";
            dgvSinhVien.Columns["gt"].HeaderText = "Giới tính";
            dgvSinhVien.Columns["quequan"].HeaderText = "Quê quán";
            dgvSinhVien.Columns["diachi"].HeaderText = "Địa chỉ";
            dgvSinhVien.Columns["email"].HeaderText = "Email";
            dgvSinhVien.Columns["dienthoai"].HeaderText = "Điện thoại";
        }

        private void dgvSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ý tưởng: khi double click vào sinh viên trên datagridview
            //sẽ hiện ra form cập nhật thông tin sinh viên
            //để cập nhật được sinh viên
            //ta cần lấy được mã sinh viên
            if(e.RowIndex>=0)
            {
                var msv = dgvSinhVien.Rows[e.RowIndex].Cells["masinhvien"].Value.ToString();
                //cần truyền mã sinh viên này vào form sinh viên
                new frmSinhVien(msv).ShowDialog();

                //sau khi form frmSinhVien đc đóng lại
                //cần load lại danh sách sinh viên
                LoadDSSV();
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            new frmSinhVien(null).ShowDialog();//nếu thêm mới sinh viên -> mã sinh viên = null
            LoadDSSV();//load lại danh sách sinh viên khi thêm thành công <-> form frmSinhVien đc đóng
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTukhoa.Text;
            LoadDSSV();
        }
    }
}
