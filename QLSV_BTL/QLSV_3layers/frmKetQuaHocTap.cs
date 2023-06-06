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
    public partial class frmKetQuaHocTap : Form
    {
        public frmKetQuaHocTap(string msv) //truyền mã sinh viên
        {
            this.msv = msv;//gán lại mã sinh viên được truyền qua
            InitializeComponent();
        }
        private string msv;

        private void frmKetQuaHocTap_Load(object sender, EventArgs e)
        {
            LoadKQHT();//khi form được load chạy luôn hàm tra cứu kết quả học tập

            //customize lại tên cột của datagridview dgvKQHT
            dgvKQHT.Columns["mamonhoc"].HeaderText = "Mã học phần";
            dgvKQHT.Columns["tenmonhoc"].HeaderText = "Tên học phần";
            dgvKQHT.Columns["lanhoc"].HeaderText = "Lần học";
            dgvKQHT.Columns["gvien"].HeaderText = "Giáo viên";
            dgvKQHT.Columns["diemthilan1"].HeaderText = "Điểm lần 1";
            dgvKQHT.Columns["diemthilan2"].HeaderText = "Điểm lần 2";
        }
        private void LoadKQHT()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = msv//mã sinh viên đã được truyền vào form như code ở trên
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTuKhoa.Text//mã sinh viên đã được truyền vào form như code ở trên
            });
            dgvKQHT.DataSource = new Database().SelectData("tracuudiem", lstPara);
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadKQHT();//gọi hàm LoadKQHT() khi button được click
        }
    }
}
