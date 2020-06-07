using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HECHUYENGIA.DTO;

namespace HECHUYENGIA.BUS
{
    class SuKien_BUS
    {
        KetNoi kn = new KetNoi();
        public DataTable loadsukien()
        {
            String sql = "select * from tb_sukien";
            return kn.TaoBang(sql);
        }
        public void them(SuKien_DTO sk)
        {
            String sql = "insert into tb_sukien values('" + sk.MaSuKien + "',N'" + sk.SuKien + "','"+sk.Nhom+"')";
            kn.ThucHien(sql);

        }
        public void xoa(String mask)
        {
            String sql = "delete from tb_sukien where MASUKIEN ='" + mask + "'";
            kn.ThucHien(sql);


        }
        public void sua(SuKien_DTO sk)
        {
            String sql = "update tb_sukien set MOTA=N'" + sk.SuKien + "',NHOM=N'"+ sk.Nhom+"' where MASUKIEN='" + sk.MaSuKien + "' ";
            kn.ThucHien(sql);
        }
        public DataTable timkiem(String sukien)
        {
            String sql = "select * from tb_sukien where MOTA like'%" + sukien + "%'";
            return kn.TaoBang(sql);
        }
    }
}
