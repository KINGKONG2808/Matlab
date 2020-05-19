using QuanLyHang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHang.BUS
{
    class LoaiHangBUS
    {
        public static DataTable loadAllDataCombox()
        {
            return DataConnection.fillDataTable("select * from LoaiHang");
        }
    }
}
