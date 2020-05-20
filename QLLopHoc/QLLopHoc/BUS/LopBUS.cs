using QLLopHoc.DAL;
using QLLopHoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLopHoc.BUS
{
    class LopBUS
    {
        public static DataTable loadAllDataLop()
        {
            return DataConnection.fillDataTable("select * from Lop");
        }

        public static DataTable searchById(string maLop)
        {
            return DataConnection.fillDataTable("select * from Lop where MaLop = '" + maLop + "'");
        }

        public static void addDataLop(LopDTO lopDTO)
        {
            DataConnection.excuteNonQuery("insert into Lop values ('" + lopDTO.MaLop + "', '" + lopDTO.TenLop + "', '" + lopDTO.Sosv + "', '"+ lopDTO.MaKhoa + "')");
        }

        /*public static void editDataLop(LopDTO lopDTO)
        {
            DataConnection.excuteNonQuery("update Lop set TenLop = '" + lopDTO.TenLop + "', SoSV = '" + lopDTO.Sosv + "', MaKhoa = '" + lopDTO.MaKhoa + "'");
        }*/

        public static void deleteDataLop(string maLop)
        {
            DataConnection.excuteNonQuery("delete from Lop where MaLop = '" + maLop + "'");
        }
    }
}
