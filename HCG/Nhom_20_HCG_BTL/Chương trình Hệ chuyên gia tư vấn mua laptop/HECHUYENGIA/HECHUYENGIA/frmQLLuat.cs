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
    public partial class frmQLLuat : Form
    {
        Luat_BUS xl = new Luat_BUS();
        private int id;
        public frmQLLuat()
        {
            InitializeComponent();
        }

        private void fmrQLLuat_Load(object sender, EventArgs e)
        {
            dataLuat.DataSource = xl.loadluat();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dataLuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            id = e.RowIndex;
            if (id >= 0 && id < dataLuat.Rows.Count)
            {
                this.txtMaLuat.Text = dataLuat.Rows[id].Cells[0].Value.ToString();
                this.txtLuat.Text = dataLuat.Rows[id].Cells[1].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Luat_DTO luat = new Luat_DTO();
            luat.MaLuat = txtMaLuat.Text;
            luat.Luat = txtLuat.Text;
            //luat.Nhom = txtNhom.Text;
            xl.them(luat);
            dataLuat.DataSource = xl.loadluat();
            this.txtMaLuat.Text = "";
            this.txtLuat.Text = "";
            
            //MessageBox.Show("Thêm sự kiện thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Luat_DTO luat = new Luat_DTO();
            luat.MaLuat = txtMaLuat.Text;
            luat.Luat = txtLuat.Text;
            xl.sua(luat);
            dataLuat.DataSource = xl.loadluat();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maLuat;
            maLuat = txtMaLuat.Text;
            xl.xoa(maLuat);
            dataLuat.DataSource = xl.loadluat();
        }
    }
}
