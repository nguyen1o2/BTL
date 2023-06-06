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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private string taikhoan;
        private string loaitk;
        private void frmMain_Load(object sender, EventArgs e)
        {
            var fn = new frmDangnhap();
            fn.ShowDialog();//cho load form đăng nhập khi formmain đc gọi

            //sau khi form đăng nhập đc tắt, lấy tài khoản đã đăng nhập
            taikhoan = fn.tendangnhap;
            loaitk = fn.loaitk;
            if(loaitk.Equals("admin"))
            {
                //nếu là admin
                //ẩn 2 menu chấm điểm và đăng ký môn học
                //chỉ để lại menu quản lý
                chamDiemToolStripMenuItem.Visible = false;
                chucNangToolStripMenuItem.Visible = false;
            }else
            {
                //nếu không phải admin thì ẩn menu quản lý
                quanLyToolStripMenuItem.Visible = false;
                if(loaitk.Equals("gv"))//nếu là giáo viên
                {
                    //ẩn menu đăng ký học -> cái này chỉ dành riêng cho sinh viên
                    chucNangToolStripMenuItem.Visible = false;





                }else//chỉ còn lại trường hợp là sinh viên
                {
                    chamDiemToolStripMenuItem.Visible = false;//ẩn menu chấm điểm<-chức năng của gv



                }
            }

            frmWelcome f = new frmWelcome();
            AddForm(f);
        }

        private void AddForm(Form f)
        {
            this.pnlContent.Controls.Clear(); 
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void giaoVienToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDSGV f = new frmDSGV();
            AddForm(f);
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSSV f = new frmDSSV();
            AddForm(f);
        }

        private void monHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSMH_ f = new frmDSMH_();
            AddForm(f);
        }

       

        private void lopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDsLopHoc f = new frmDsLopHoc();
            AddForm(f);
        }

        private void dangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDsMHDaDky(taikhoan);
            AddForm(f);
        }

        private void traCuuDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            var f = new frmKetQuaHocTap(taikhoan);//truyền tài khoản đăng nhập  = mã sinh viên
            AddForm(f);
        }

        private void quanLyLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmQuanLyLop(taikhoan);//truyền tài khoản đăng nhập  = mã sinh viên
            AddForm(f);
        }
    }
}
