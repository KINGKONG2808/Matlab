using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HECHUYENGIA.DTO;
using HECHUYENGIA.BUS;

namespace HECHUYENGIA
{
    public partial class frmQLSuKien : Form
    {
        SuKien_BUS sk = new SuKien_BUS();
        private int id;
        public frmQLSuKien()
        {
            InitializeComponent();
        }

        private void frmQLSuKien_Load(object sender, EventArgs e)
        {
            dataSuKien.DataSource = sk.loadsukien();
            
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dataSuKien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            id = e.RowIndex;
            if (id >= 0 && id < dataSuKien.Rows.Count)
            {
                this.txtTen.Text = dataSuKien.Rows[id].Cells[0].Value.ToString();
                this.txtMota.Text = dataSuKien.Rows[id].Cells[1].Value.ToString();
                this.txtNhom.Text = dataSuKien.Rows[id].Cells[2].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           // this.Close();
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            SuKien_DTO skDTO = new SuKien_DTO();
            skDTO.MaSuKien = txtTen.Text;
            skDTO.SuKien = txtMota.Text;
            skDTO.Nhom = txtNhom.Text;
            sk.them(skDTO);
            dataSuKien.DataSource = sk.loadsukien();
            this.txtTen.Text = "";
            this.txtMota.Text = "";
            this.txtNhom.Text = "";
            MessageBox.Show("Thêm sự kiện thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            SuKien_DTO skDTO = new SuKien_DTO();
            skDTO.MaSuKien = txtTen.Text;
            skDTO.SuKien = txtMota.Text;
            skDTO.Nhom = txtNhom.Text;
            sk.sua(skDTO);
            dataSuKien.DataSource = sk.loadsukien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String mask;
            mask = txtTen.Text;
            sk.xoa(mask);
            dataSuKien.DataSource = sk.loadsukien();
        }
        private void Xoa()
        {
            while (dataSuKien.Rows.Count > 0)
            {
                dataSuKien.Rows.RemoveAt(0);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Xoa();
            if (txtTimKiem.Text == "")
            {
                dataSuKien.DataSource = sk.loadsukien();
            }
            else
            {
                dataSuKien.DataSource = sk.timkiem(txtTimKiem.Text);
            }
        }
    }
}
