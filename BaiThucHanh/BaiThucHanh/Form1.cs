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

namespace BaiThucHanh
{
    public partial class Form1 : Form
    {
        public static int count = 0;
        XmlDocument doc = new XmlDocument();
        public static string filePath = "C:/Users/vuhung/source/repos/BaiThucHanh/BaiThucHanh/data.xml";

        public Form1()
        {
            InitializeComponent();
        }

        public DataSet getData()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(filePath);
            return dataSet;
        }

        public void loadCombox()
        {
            cboMasv.DataSource = getData().Tables["sinhvien"];
            cboMasv.DisplayMember = "masv";
            cboMonHoc.DataSource = getData().Tables["sinhvien"];
            cboMonHoc.DisplayMember = "monhoc";
        }

        public void loadData()
        {
            loadCombox();
            dataGridView.DataSource = getData().Tables["sinhvien"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            doc.Load(filePath);
            XmlElement stt = doc.CreateElement("stt");
            stt.InnerText = (count+=1).ToString();
            XmlElement hoTen = doc.CreateElement("hoten");
            hoTen.InnerText = txtHoTen.Text;
            XmlElement diemLan1 = doc.CreateElement("diemlan1");
            diemLan1.InnerText = txtDiemLan1.Text;
            XmlElement diemLan2 = doc.CreateElement("diemlan2");
            diemLan2.InnerText = txtDiemLan2.Text;
            XmlAttribute maSv = doc.CreateAttribute("masv");
            maSv.InnerText = cboMasv.Text;
            XmlAttribute monHoc = doc.CreateAttribute("monhoc");
            monHoc.InnerText = cboMonHoc.Text;

            XmlElement sinhVien = doc.CreateElement("sinhvien");
            sinhVien.AppendChild(stt);
            sinhVien.AppendChild(hoTen);
            sinhVien.AppendChild(diemLan1);
            sinhVien.AppendChild(diemLan2);
            sinhVien.SetAttributeNode(maSv);
            sinhVien.SetAttributeNode(monHoc);
            doc.DocumentElement.AppendChild(sinhVien);
            doc.Save(filePath);
            loadData();
            MessageBox.Show("Luu thanh cong");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            doc.Load(filePath);
            XmlNode xmlNode = doc.SelectSingleNode("/bangdiem/sinhvien[@masv='" + cboMasv.Text.Trim() + "'and @monhoc='" + cboMonHoc.Text.Trim() + "']");
            if (xmlNode != null)
            {
                xmlNode.ChildNodes[0].InnerText = (count++).ToString();
                xmlNode.ChildNodes[1].InnerText = txtHoTen.Text;
                xmlNode.ChildNodes[2].InnerText = txtDiemLan1.Text;
                xmlNode.ChildNodes[3].InnerText = txtDiemLan2.Text;
                xmlNode.Attributes[1].InnerText = cboMonHoc.Text;
                doc.Save(filePath);
                loadData();
                MessageBox.Show("Sua thanh cong");
            } else
            {
                MessageBox.Show("Ma sinh vien khong ton tai");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            doc.Load(filePath);
            XmlNode xmlNode = doc.SelectSingleNode("/bangdiem/sinhvien[@masv='" + cboMasv.Text.Trim() + "'and @monhoc='" + cboMonHoc.Text.Trim() + "']");
            if (xmlNode != null)
            {
                doc.DocumentElement.RemoveChild(xmlNode);
                doc.Save(filePath);
                loadData();
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Ma sinh vien khong ton tai");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ban co chac muon thoat ?", "Canh bao", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            } else
            {
                this.Close();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtDiemLan1.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            txtDiemLan2.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            cboMasv.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            cboMonHoc.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
