using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class clsLuongCN:clsKetNoi
    {
        clsCongNhan cn = new clsCongNhan();
        qlLuongSPDataContext dt;
        public clsLuongCN()
        {
            dt = getDataContext();
        }

        public IEnumerable<tblLuongCN> GetLCNThuocCN(string strIDCN)
        {
           // dt = getDataContext();
            IEnumerable<tblLuongCN> q = from n in dt.tblLuongCNs
                                        where n.IDCN.Equals(strIDCN)
                                        select n;
            return q;
        }
        //Kiểm tra tồn tại lương nhân viên
        public tblLuongCN CheckIfExistCN(string strIDCN)
        {
            //dt = getDataContext();
            tblLuongCN nvtemp = (from n in dt.tblLuongCNs
                                 where n.IDCN.Equals(strIDCN)//Lấy các phần tử có id = strIDNV
                                 select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Xóa lương công nhân
        public int DeleteLuongCongNhan(tblLuongCN lcn)
        {
            //dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(lcn.IDCN) != null)
                {
                    dt.tblLuongCNs.DeleteOnSubmit(lcn);
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không xóa được " + ex.Message);
            }
        }
        //Thêm lương công nhân
        public int insertLuongCongNhan(tblLuongCN n)
        {
           // dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(n.IDCN) != null)
                    return 0;
                else
                {
                    dt.tblLuongCNs.InsertOnSubmit(n);
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không thêm được " + ex.Message);
            }
        }
    }
}
