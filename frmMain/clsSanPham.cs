using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class clsSanPham:clsKetNoi
    {
        qlLuongSPDataContext dt;

        // Hẳn là lấy data ra xài nhỉ :)
        public clsSanPham()
        {
            dt = getDataContext();
        }

        // Lấy tất cả công nhân trong table CongNhan
        public IEnumerable<tblSanPham> GetAllSP()
        {
            dt = getDataContext();
            IEnumerable<tblSanPham> q = from n in dt.tblSanPhams
                                         select n;
            return q;
        }
    }
}
