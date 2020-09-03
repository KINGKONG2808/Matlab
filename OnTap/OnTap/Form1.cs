using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OnTap
{
    public partial class Form1 : Form
    {
        public static string filePath = "C:/Users/vuhung/source/repos/OnTap/OnTap/source.xml";
        XmlDocument doc = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void setNullText()
        {
            txtMaHD.Text = "";
            txtNgayBan.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
        }

        private void setData(XmlNodeList xmlNodeList)
        {
            int column = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                dataGridView1.Rows[column].Cells[0].Value = xmlNode.SelectSingleNode("@mahd").InnerText;
                dataGridView1.Rows[column].Cells[1].Value = xmlNode.SelectSingleNode("@ngayban").InnerText;
                dataGridView1.Rows[column].Cells[2].Value = xmlNode.SelectSingleNode("khachhang/tenkh").InnerText;
                dataGridView1.Rows[column].Cells[3].Value = xmlNode.SelectSingleNode("khachhang/diachi").InnerText;
                dataGridView1.Rows.Add();
                column += 1;
            }
        }

        public void loadData()
        {
            doc.Load(filePath);
            XmlNodeList xmlNodeList = doc.SelectNodes("/cuonhd/hoadon");
            setData(xmlNodeList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co chac chan ?", "Canh bao", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            } else
            {
                Application.Exit();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            setNullText();
        }

        private bool validate()
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Ma hoa don la truong bat buoc.", "Canh bao");
                return false;
            }
            if (txtNgayBan.Text == "")
            {
                MessageBox.Show("Ngay ban la truong bat buoc.", "Canh bao");
                return false;
            }
            if (txtTenKhach.Text == "")
            {
                MessageBox.Show("Ten khach hang la truong bat buoc.", "Canh bao");
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Dia chi la truong bat buoc.", "Canh bao");
                return false;
            }

            doc.Load(filePath);
            XmlNode xmlNode = doc.SelectSingleNode("/cuonhd/hoadon[@mahd='" + txtMaHD.Text.Trim() + "'and @ngayban='" + txtNgayBan.Text.Trim() + "']");
            if (xmlNode != null)
            {
                MessageBox.Show("Ma hoa don " + txtMaHD.Text + " da ton tai trong ngay " + txtNgayBan.Text, "Canh bao");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }
            XmlElement hoaDon = doc.CreateElement("hoadon");

            XmlAttribute maHd = doc.CreateAttribute("mahd");
            maHd.InnerText = txtMaHD.Text;
            XmlAttribute ngayBan = doc.CreateAttribute("ngayban");
            ngayBan.InnerText = txtNgayBan.Text;

            XmlElement khachHang = doc.CreateElement("khachhang");
            XmlElement tenKh = doc.CreateElement("tenkh");
            tenKh.InnerText = txtTenKhach.Text;
            khachHang.AppendChild(tenKh);
            XmlElement diaChi = doc.CreateElement("diachi");
            diaChi.InnerText = txtDiaChi.Text;
            khachHang.AppendChild(diaChi);

            hoaDon.Attributes.Append(maHd);
            hoaDon.Attributes.Append(ngayBan);
            hoaDon.AppendChild(khachHang);

            doc.DocumentElement.AppendChild(hoaDon);
            doc.Save(filePath);
            loadData();
            MessageBox.Show("Them hoa don thanh cong.");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            doc.Load(filePath);
            XmlNodeList xmlNodeList = doc.SelectNodes("/cuonhd/hoadon[@mahd='" + txtMaHD.Text.Trim() + "']");
            setData(xmlNodeList);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doc.Load(filePath);
            XmlNode xmlNode = doc.SelectSingleNode("/cuonhd/hoadon[@mahd='" + txtMaHD.Text.Trim() + "'and @ngayban='" + txtNgayBan.Text.Trim() + "']");
            if (xmlNode != null)
            {
                doc.DocumentElement.RemoveChild(xmlNode);
                doc.Save(filePath);
                loadData();
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Ma hoa don khong ton tai");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNgayBan.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTenKhach.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            setNullText();
            loadData();
        }
    }
}
