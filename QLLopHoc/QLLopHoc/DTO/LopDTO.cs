using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLopHoc.DTO
{
    class LopDTO
    {
        private string maLop;
        private string tenLop;
        private string sosv;
        private string maKhoa;

        public LopDTO()
        {
        }

        public LopDTO(string maLop, string tenLop, string sosv, string maKhoa)
        {
            this.MaLop = maLop;
            this.TenLop = tenLop;
            this.Sosv = sosv;
            this.MaKhoa = maKhoa;
        }

        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string Sosv { get => sosv; set => sosv = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
    }
}
