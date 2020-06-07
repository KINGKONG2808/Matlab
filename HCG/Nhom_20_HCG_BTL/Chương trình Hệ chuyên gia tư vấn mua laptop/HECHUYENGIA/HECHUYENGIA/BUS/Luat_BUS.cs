using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HECHUYENGIA.DTO;

namespace HECHUYENGIA
{
    class Luat_BUS
    {
        KetNoi kn = new KetNoi();
        public DataTable loadluat()
        {
            String sql = "select * from tb_luat";
            return kn.TaoBang(sql);
        }
        public DataTable loadsukien()
        {
            String sql = "select * from tb_sukien where MOTA not in(select MOTA from tb_sukien where NHOM='ketqua')";
            return kn.TaoBang(sql);
        }
        public void them(Luat_DTO sk)
        {
            String sql = "insert into tb_luat values('" + sk.MaLuat + "',N'" + sk.Luat + "')";
            kn.ThucHien(sql);

        }
        public void xoa(String luat)
        {
            String sql = "delete from tb_luat where LUAT ='" + luat + "'";
            kn.ThucHien(sql);


        }
        public void sua(Luat_DTO sk)
        {
            String sql = "update tb_luat set LUAT=N'" + sk.Luat + "' where MALUAT='" + sk.MaLuat + "' ";
            kn.ThucHien(sql);
        }
        public DataTable timkiem(String maluat)
        {
            String sql = "select * from tb_luat where MALUAT like'%" + maluat + "%'";
            return kn.TaoBang(sql);
        }
    }
}
