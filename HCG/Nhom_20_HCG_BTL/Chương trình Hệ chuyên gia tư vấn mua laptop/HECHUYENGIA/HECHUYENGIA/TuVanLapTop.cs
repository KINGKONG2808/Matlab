using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HECHUYENGIA
{
    public partial class TuVanLapTop : Form
    {
        List<string> GT = new List<string>();
        List<string> KL = new List<string>();
        KetNoi kn = new KetNoi();
        public TuVanLapTop()
        {
            InitializeComponent();
        }

        void LoadKL()
        {
            string qr = "select MASUKIEN from tb_sukien where NHOM='ketluan'";
            DataTable dt = kn.TaoBang(qr);
            foreach (DataRow r in dt.Rows)
            {
                KL.Add(r[0].ToString());
            }
        }
        private void FormLoad(object sender, EventArgs e)
        {
            LoadKL();
            string qr = "select MASUKIEN,MOTA from tb_sukien where NHOM='gia' ";
            DataTable tbGia = kn.TaoBang(qr);
            cbbGia.DataSource = tbGia;
            cbbGia.DisplayMember = "MOTA";
            cbbGia.ValueMember = "MASUKIEN";

            qr = "select MASUKIEN,MOTA from tb_sukien where NHOM='hang' ";
            DataTable tbLoai = kn.TaoBang(qr);
            cbLoai.DataSource = tbLoai;
            cbLoai.DisplayMember = "MOTA";
            cbLoai.ValueMember = "MASUKIEN";

            qr = "select MASUKIEN,MOTA from tb_sukien where NHOM='RAM' ";
            DataTable tbRam = kn.TaoBang(qr);
            cbRam.DataSource = tbRam;
            cbRam.DisplayMember = "MOTA";
            cbRam.ValueMember = "MASUKIEN";

            qr = "select MASUKIEN,MOTA from tb_sukien where NHOM='chip' ";
            DataTable tbChip = kn.TaoBang(qr);
            cbChips.DataSource = tbChip;
            cbChips.DisplayMember = "MOTA";
            cbChips.ValueMember = "MASUKIEN";
        }

        private void cbbGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Deleteall()
        {
            while (GT.Count > 0)
            {
                GT.RemoveAt(0);
            }
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            Deleteall();
            txtKQ.Text = "";
            GT.Add(cbbGia.SelectedValue.ToString());
            GT.Add(cbLoai.SelectedValue.ToString());
            GT.Add(cbRam.SelectedValue.ToString());
            GT.Add(cbChips.SelectedValue.ToString());

            SuyDienTien sd=new SuyDienTien();
            sd.DocLuat();
            int dem = 0;
            foreach (string s in KL)
            {
                List<string> KLTG = new List<string>();
                KLTG.Add(s);
                if (sd.SuyDien(GT, KLTG) == true)
                {
                    string qr = "select MOTA from tb_sukien where MASUKIEN='"+s+"'";
                    DataTable dt = kn.TaoBang(qr);
                    txtKQ.Text += dt.Rows[0][0].ToString();
                    txtKQ.Text += "\n";
                    dem++;
                }
            }
            if (dem == 0)
            {
                txtKQ.Text = "khong co laptop phu hop";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
                "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLuat_Click(object sender, EventArgs e)
        {
            frmQLLuat frmLuat = new frmQLLuat();
            frmLuat.ShowDialog();
        }

        private void btnSuKien_Click(object sender, EventArgs e)
        {
            frmQLSuKien frmSuKien = new frmQLSuKien();
            frmSuKien.ShowDialog();
        }
    }
}
