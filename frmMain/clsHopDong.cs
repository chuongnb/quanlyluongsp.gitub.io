using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class clsHopDong:clsKetNoi
    {
        qlLuongSPDataContext dt;

        // Hẳn là lấy data ra xài nhỉ :)
        public clsHopDong()
        {
            dt = getDataContext();
        }

        // Lấy tất cả công nhân trong table CongNhan
        public IEnumerable<tblHopDong> GetAllHD()
        {
            //dt = getDataContext();
            IEnumerable<tblHopDong> q = from n in dt.tblHopDongs
                                        select n;
            return q;
        }
    }
}
