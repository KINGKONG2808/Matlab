using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHang.DTO
{
    class HangDTO
    {
        private string maHang;
        private string tenHang;
        private float donGia;
        private int soLuong;
        private string maLoai;

        public HangDTO()
        {
        }

        public HangDTO(string maHang, string tenHang, float donGia, int soLuong, string maLoai)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.maLoai = maLoai;
        }

        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
    }
}
