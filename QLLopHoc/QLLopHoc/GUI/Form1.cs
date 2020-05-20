using QLLopHoc.BUS;
using QLLopHoc.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLopHoc
{
    public partial class Home : Form
    {
        public DataTable khoa = KhoaBUS.loadAllDataCombox();

        public Home()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            dataGridView1.DataSource = LopBUS.loadAllDataLop();
            (dataGridView1.Columns["MaKhoa"] as DataGridViewComboBoxColumn).DataSource = khoa;
            (dataGridView1.Columns["MaKhoa"] as DataGridViewComboBoxColumn).DisplayMember = "TenKhoa";
            (dataGridView1.Columns["MaKhoa"] as DataGridViewComboBoxColumn).ValueMember = "MaKhoa";
        }

        public void loadCombox()
        {
            cbKhoa.DataSource = khoa;
            cbKhoa.DisplayMember = "TenKhoa";
            cbKhoa.ValueMember = "MaKhoa";
        }

        private void loadTimKiem(string maLop)
        {
            dataGridView1.DataSource = LopBUS.searchById(maLop);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            loadData();
            loadCombox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSoSV.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text.Equals("") || txtTenLop.Text.Equals("") || txtSoSV.Text.Equals(""))
            {
                MessageBox.Show("Yêu cầu nhập đủ các trường !!!");
                return;
            }
            try
            {
                LopDTO lopDTO = new LopDTO();
                lopDTO.MaLop = txtMaLop.Text;
                lopDTO.TenLop = txtTenLop.Text;
                lopDTO.Sosv = txtSoSV.Text;
                lopDTO.MaKhoa = cbKhoa.SelectedValue.ToString();
                LopBUS.addDataLop(lopDTO);
                loadData();
                MessageBox.Show("Thêm thành công !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Khóa chính bị trùng hoặc có lỗi xảy ra !!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chứ ?", "Cảnh báo !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                LopBUS.deleteDataLop(txtMaLop.Text);
                loadData();
                MessageBox.Show("Xóa thành công !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi xảy ra !!!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbMaLop.Checked)
                {
                    loadTimKiem(txtMaLopSearch.Text);
                }

                if (rbAll.Checked)
                {
                    loadData();
                }

                MessageBox.Show("Tìm kiếm thành công !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi xảy ra !!!");
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenLop.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoSV.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbKhoa.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
