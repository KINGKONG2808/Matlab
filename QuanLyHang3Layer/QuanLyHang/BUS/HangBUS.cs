using QuanLyHang.DAL;
using QuanLyHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHang.BUS
{
    class HangBUS
    {
        public static DataTable loadAllDataHang()
        {
            return DataConnection.fillDataTable("select * from Hang");
        }

        public static DataTable searchById(string maHang)
        {
            return DataConnection.fillDataTable("select * from Hang where MaHang = '" + maHang + "'");
        }

        public static void addDataHang(HangDTO hangDTO)
        {
            DataConnection.excuteNonQuery("insert into Hang values ('" + hangDTO.MaHang + "', '" + hangDTO.TenHang + "', " + hangDTO.DonGia + ", " + hangDTO.SoLuong + ", '" + hangDTO.MaLoai + "')");
        }

        public static void editDataHang(HangDTO hangDTO)
        {
            DataConnection.excuteNonQuery("update Hang set TenHang = '" + hangDTO.TenHang + "', DonGia = " + hangDTO.DonGia + ", SoLuong = " + hangDTO.SoLuong + ", MaLoai = '" + hangDTO.MaLoai + "' where MaHang = '" + hangDTO.MaHang + "'");
        }

        public static void deleteDataHang(string maHang)
        {
            DataConnection.excuteNonQuery("delete from Hang where MaHang = '" + maHang + "'");
        }
    }
}
