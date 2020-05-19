using QuanLyHang.BUS;
using QuanLyHang.DTO;
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

namespace QuanLyHang
{
    public partial class Form1 : Form
    {
        public DataTable loaiHang = LoaiHangBUS.loadAllDataCombox();

        public Form1()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            dataGridView1.DataSource = HangBUS.loadAllDataHang();
            (dataGridView1.Columns["MaLoai"] as DataGridViewComboBoxColumn).DataSource = loaiHang;
            (dataGridView1.Columns["MaLoai"] as DataGridViewComboBoxColumn).DisplayMember = "TenLoai";
            (dataGridView1.Columns["MaLoai"] as DataGridViewComboBoxColumn).ValueMember = "MaLoai";
        }

        public void loadCombox()
        {
            cbLoaiHang.DataSource = loaiHang;
            cbLoaiHang.DisplayMember = "TenLoai";
            cbLoaiHang.ValueMember = "MaLoai";
        }

        private void loadTimKiem(string maHang)
        {
            dataGridView1.DataSource = HangBUS.searchById(maHang);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbLoaiHang.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            loadCombox();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
               HangDTO hangDTO = new HangDTO();
            hangDTO.MaHang = txtMaHang.Text;
            hangDTO.TenHang = txtTenHang.Text;
            hangDTO.DonGia = Convert.ToSingle(txtDonGia.Text);
            hangDTO.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            hangDTO.MaLoai = cbLoaiHang.SelectedValue.ToString();
            HangBUS.editDataHang(hangDTO);
            loadData();
            MessageBox.Show("Sửa thành công !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi xảy ra !!!");
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
                HangBUS.deleteDataHang(txtMaHang.Text);
                loadData();
                MessageBox.Show("Xóa thành công !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi xảy ra !!!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text.Equals("") || txtTenHang.Text.Equals("") || txtDonGia.Text.Equals("") || txtSoLuong.Text.Equals(""))
            {
                MessageBox.Show("Yêu cầu nhập đủ các trường !!!");
                return;
            }
            try
            {
                HangDTO hangDTO = new HangDTO();
                hangDTO.MaHang = txtMaHang.Text;
                hangDTO.TenHang = txtTenHang.Text;
                hangDTO.DonGia = Convert.ToSingle(txtDonGia.Text);
                hangDTO.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                hangDTO.MaLoai = cbLoaiHang.SelectedValue.ToString();
                HangBUS.addDataHang(hangDTO);
                loadData();
                MessageBox.Show("Thêm thành công !!!");
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
                if (rbMaHang.Checked)
                {
                    loadTimKiem(txtMaHangSearch.Text);
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
    }
}
