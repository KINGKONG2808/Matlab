using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;


namespace HECHUYENGIA
{
    class SuyDienTien
    {
        private KetNoi kn = new KetNoi();
        List<Luat> binLuat = new List<Luat>();
        List<Luat> SAT = new List<Luat>();
        private int demLuat = 0;
        public void DocLuat()
        {
            // lấy ra tất cả bản ghi luật từ bảng tập luật
            string qr = "select LUAT from tb_luat";

            // đẩy dữ liệu get ra vào datatable
            DataTable tbLuat = kn.TaoBang(qr);

            // duyệt list datatable vừa get ra
            for (int i = 0; i < tbLuat.Rows.Count; i++)
            {
                // lấy ra dữ liệu theo từng dòng của datatable và chuyển nó về dạng string
                string buff = tbLuat.Rows[i][0].ToString();

                Luat luatTG = new Luat();
                // khởi tạo biến là ký tự cần loại bỏ khỏi chuỗi string
                char[] delimiterChars = { '>' };
                // loại bỏ ký tự được khởi tạo bên trên khỏi chuỗi string
                string[] tg = buff.Split(delimiterChars);

                // xét dữ liệu tập luật truyền vào bên trái

                // khởi tạo biến là ký tự cần loại bỏ khỏi chuỗi string
                char[] delimiterChars1 = { '^' };
                // loại bỏ ký tự được cấu hình ở phần tử đầu tiên của chuỗi
                string[] left = tg[0].Split(delimiterChars1);

                int j = 0;
                string buff1 = left[0];
                while (buff1 != null)
                {
                    luatTG.veTrai.Add(buff1);
                    j++;
                    try
                    {
                        buff1 = left[j];
                    }
                    catch { buff1 = null; };

                }

                j = 0;


                //ben phai
                char[] delimiterChars2 = {','};// cho nay thay , bang ^
                string[] right = tg[1].Split(delimiterChars2);

                buff1 = right[0];
                while (buff1 != null)
                {
                    luatTG.vePhai.Add(buff1);
                    j++;
                    try
                    {
                        buff1 = right[j];
                    }
                    catch { buff1 = null; };
                }

                binLuat.Add(luatTG);
                demLuat++;

            }
        }

        public string XuatLuat(List<Luat> mangLuat)
        {
            string tg = "";
            foreach (Luat r in mangLuat)
            {
                foreach (string s in r.veTrai)
                {
                    tg += s + "^";
                }
                tg += "->";
                foreach (string s in r.vePhai)
                {
                    tg += s + "^";
                }
                tg += "\n";

            }
            return tg;
        }

        public bool CheckIn(List<string> a, List<string> b)
        {
            int dem = 0;
            foreach (string tg1 in a)
            {
                foreach (string tg2 in b)
                {
                    if (tg1.Equals(tg2) == true)
                        dem++;
                }
            }
            if (dem == a.Count)
                return true;
            else
                return false;
        }

        public void TimTapSat(List<string> L,List<Luat> mangLuat)
        {
            foreach (Luat lTG in mangLuat)
            {
                if (CheckIn(lTG.veTrai, L) == true && !SAT.Contains(lTG))
                {
                    SAT.Add(lTG);
                }
            }
        }

        public bool SuyDien(List<string> left, List<string> right)
        {
            List<Luat> mangLuat = new List<Luat>();
            mangLuat = binLuat;
            List<string> KL = right;
            List<string> TG = left;
            TimTapSat(TG,mangLuat);
            while (SAT.Count > 0 && CheckIn(KL, TG) == false)
            {
                //lay luat r cuoi cung ra ap dung
                Luat r = SAT.ElementAt(0);
                mangLuat.Remove(r);
                SAT.RemoveAt(0);
                //them cai chua co vao TG
                foreach (string tg in r.vePhai)
                {
                    if (!TG.Contains(tg))
                    {
                        TG.Add(tg);
                        Console.WriteLine(tg);
                    }

                }

                TimTapSat(TG,mangLuat);
            }

            if (CheckIn(KL, TG) == false)
                return false;
            else
                return true;
        }
    }
}
