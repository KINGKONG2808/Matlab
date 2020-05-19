using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUANLYBANHANGcustom
{
    public partial class QuanLyBanHang : Form
    {
        /*private String connectionString = @"Data Source=VUHUNGA49E;Initial Catalog=QUANLYBANHANGcustom;Integrated Security=True";
        private SqlConnection connection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataTable dataTable = null;
        private SqlCommand cmd = null;*/


        public QuanLyBanHang()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //connection = new SqlConnection(connectionString);
            loadCombo();
            loadData();
        }

        private void loadData()
        {
            /*dataAdapter = new SqlDataAdapter("select * from SanPham", connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;*/

            dbDataContext data = new dbDataContext();
            var sp = from sanPham in data.SanPhams select sanPham;
            dataGridView1.DataSource = sp;
        }
        private void loadCombo()
        {
            /*dataAdapter = new SqlDataAdapter("Select * from LoaiSP", connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cbKindOfProduct.DataSource = dataTable;
            cbKindOfProduct.DisplayMember = "ten_loai";
            cbKindOfProduct.ValueMember = "ma_loai";*/

            dbDataContext data = new dbDataContext();
            var lsp = from loaiSanPham in data.LoaiSPs select loaiSanPham;
            cbKindOfProduct.DataSource = lsp;
            cbKindOfProduct.DisplayMember = "ten_loai";
            cbKindOfProduct.ValueMember = "ma_loai";
        }
        private void loadTimKiem(int loai)
        {
            /*dataAdapter = new SqlDataAdapter("select * from SanPham where ma_loai = " + loai, connection);
            dataTable = new DataTable();
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;*/

            dbDataContext data = new dbDataContext();
            var search = from s in data.SanPhams where s.ma_loai == loai select new { s.ma_sp, s.ten_sp, s.ma_loai, s.don_gia };
            dataGridView1.DataSource = search;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCodeProduct.Text.Equals("") || txtUnitPrice.Text.Equals("") || txtNameProduct.Text.Equals(""))
            {
                MessageBox.Show("Not enough of data!!!");
                return;
            }
            try
            {
                /*connection = new SqlConnection(connectionString);
                connection.Open();
                String sql = "exec nhap '" + txtCodeProduct.Text + "', '" + txtNameProduct.Text + "', " + Convert.ToInt32(cbKindOfProduct.SelectedValue) + "," + Convert.ToSingle(txtUnitPrice.Text);
                cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                loadData();
                MessageBox.Show("Add complete !!!");*/

                dbDataContext data = new dbDataContext();
                SanPham addProduct = new SanPham();
                addProduct.ma_sp = txtCodeProduct.Text;
                addProduct.ten_sp = txtNameProduct.Text;
                addProduct.ma_loai = Convert.ToInt32(cbKindOfProduct.SelectedValue);
                addProduct.don_gia = Convert.ToSingle(txtUnitPrice.Text);
                data.SanPhams.InsertOnSubmit(addProduct);
                data.SubmitChanges();
                loadData();
                MessageBox.Show("Add complete !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            try
            {
                /*connection = new SqlConnection(connectionString);
                connection.Open();
                String sql = "Delete From SanPham where ma_sp = '" + txtCodeProduct.Text + "'";
                cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                loadData();
                MessageBox.Show("Delete complete !!!");*/

                dbDataContext data = new dbDataContext();
                var deleteProduct = from sp in data.SanPhams where sp.ma_sp == txtCodeProduct.Text select sp;
                foreach(var i in deleteProduct)
                {
                    data.SanPhams.DeleteOnSubmit(i);
                    data.SubmitChanges();
                }
                loadData();
                MessageBox.Show("Delete complete !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                /*connection = new SqlConnection(connectionString);
                connection.Open();
                String sql = "Update SanPham set ten_sp = '" + txtNameProduct.Text + "', ma_loai = " + Convert.ToInt32(cbKindOfProduct.SelectedValue) + ", don_gia =" + Convert.ToSingle(txtUnitPrice.Text) + " where ma_sp ='" + txtCodeProduct.Text + "'";
                MessageBox.Show(sql);
                cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                loadData();
                MessageBox.Show("Edit complete !!!");*/

                dbDataContext data = new dbDataContext();
                var updateProduct = data.SanPhams.Single(sp => sp.ma_sp == txtCodeProduct.Text);
                updateProduct.ten_sp = txtNameProduct.Text;
                updateProduct.ma_loai = Convert.ToInt32(cbKindOfProduct.SelectedValue);
                updateProduct.don_gia = Convert.ToSingle(txtUnitPrice.Text);
                data.SubmitChanges();
                loadData();
                MessageBox.Show("Edit complete !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                /*connection = new SqlConnection(connectionString);
                connection.Open();*/
                loadTimKiem(Convert.ToInt32(cbKindOfProduct.SelectedValue));
                if (dataGridView1.Rows.Count < 2)
                {
                    MessageBox.Show("The product is not exists !!!");
                    return;
                }
                MessageBox.Show("Find all, see that !!!");

            }
            catch (SqlException)
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*int row = e.RowIndex;
            txtCodeProduct.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtNameProduct.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            cbKindOfProduct.SelectedValue = dataGridView1.Rows[row].Cells[2].Value.ToString();
            txtUnitPrice.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();*/
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtCodeProduct.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNameProduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            /* use for open connection normal
            cbKindOfProduct.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();*/
            // use for LINQ to SQL
            cbKindOfProduct.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value;
            txtUnitPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
