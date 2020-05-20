using QLLopHoc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLopHoc.BUS
{
    class KhoaBUS
    {
        public static DataTable loadAllDataCombox()
        {
            return DataConnection.fillDataTable("select * from Khoa");
        }
    }
}
