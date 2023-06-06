using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien(string msv)
        {
            this.msv = msv;//truyền lại mã sinh viên khi form chạy
            InitializeComponent();
        }
        private string msv;

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(msv))//nếu msv không có => thêm mới sinh viên
            {
                this.Text = "Thêm mới sinh viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin sinh viên";
                //lấy thông tin chi tiết của 1 sinh viên dựa vào msv
                //msv là mã sinh viên đã được truyền từ form dssv (part 4)
                var r = new Database().Select("selectSV '"+msv+"'");
                //MessageBox.Show(r[0].ToString()); //load thành công
                //set các giá trị vào component của form

                txtHo.Text = r["ho"].ToString();
                txtTendem.Text = r["tendem"].ToString();
                txtTen.Text = r["ten"].ToString();
                mtbNgaysinh.Text = r["ngsinh"].ToString();
                if(int.Parse(r["gioitinh"].ToString()) == 1)
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }

                txtQuequan.Text = r["quequan"].ToString();
                txtDiachi.Text = r["diachi"].ToString();
                txtDienthoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //button btnLuu sẽ xử lý 1 trong 2 tình huống
            //trường hợp 1: nếu mã sinh viên không có giá trị -> thêm mới sinh viên
            //trường hợp 2: nếu mã sinh viên có giá trị -> cập nhật thông tin sinh viên

            /*ý tưởng
                -- cho dù thêm mới hay cập nhật
                -- thì đều cần các giá trị như: họ, tên đệm, tên, ngày sinh, giới tính
                    quê quán, địa chỉ, điện thoại, email => các giá trị này dùng cho cả 2 trường hợp
                -- riêng cập nhật sinh viên, cần quan tâm tới mã sinh viên        
            */

            string sql = "";
            string ho = txtHo.Text;
            string tendem = txtTendem.Text;
            string ten = txtTen.Text;
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaysinh.Text,"dd/MM/yyyy",CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaysinh.Select();//trỏ chuột về mtbNgaysinh
                return;//không thực hiện các câu lệnh phía dưới
            }
            //vì ngày sinh ở masketbox, chúng ta set theo dạng dd/mm/yyy
            //nhưng trong csdl lại lưu dưới dạng yyyy-mm-dd
            //=> chúng ta cần chuyển từ dd/mm/yyyy sang yyyy-mm-dd


            string gioitinh = rbtNam.Checked ? "1" : "0";//đây là toán tử 2 ngôi
            //nếu radiobutton Nam đc check thì chọn giá trị 1
            //ngược lại chọn giá trị 0 -> phù hợp với giá trị đã được lưu ở csdl

            string quequan = txtQuequan.Text;
            string diachi = txtDiachi.Text;
            string dienthoai = txtDienthoai.Text;
            string email = txtEmail.Text;

            //khai báo một danh sách tham sô = class CustomParameter -> đã được khai báo ở part 3
            List<CustomParameter> lstPara = new List<CustomParameter>();
           if(string.IsNullOrEmpty(msv))//nếu thêm mới sinh viên
            {
                sql = "ThemMoiSV";//gọi tới procedure thêm mới sinh viên
               
            }
            else//nếu cập nhật sinh viên
            {
                sql = "updateSV";//gọi tới procedure cập nhật sinh viên
                lstPara.Add(new CustomParameter()
                {
                    key = "@masinhvien",
                    value = msv
                });
            }

            lstPara.Add(new CustomParameter() {
                key = "@ho",
                value = ho
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tendem",
                value = tendem
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ten",
                value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                value = gioitinh
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@quequan",
                value = quequan
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                value = diachi
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@dienthoai",
                value = dienthoai
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@email",
                value = email
            });


            var rs = new Database().ExeCute(sql,lstPara);//truyền 2 tham số là câu lệnh sql
            //và danh sách các tham số
            if(rs == 1)//nếu thuwcjt hi thành công
            {
                if(string.IsNullOrEmpty(msv))//nếu thêm mới
                {
                    MessageBox.Show("Thêm mới sinh viên thành công");
                }else//nếu cập nhật
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công");
                }
                this.Dispose();//đóng form sau khi thêm mới/cập nhật thành công
            }else//nếu không thành công
            {
                MessageBox.Show("Thực thi thất bại");
            }

        }
    }
}
