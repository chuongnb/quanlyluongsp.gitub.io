using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class clsLuongHC:clsKetNoi
    {
        qlLuongSPDataContext dt;

        // Hẳn là lấy data ra xài nhỉ :)
        public clsLuongHC()
        {
            dt = getDataContext();
        }

        // Lấy lương HC thuộc nhân viên
        public tblLuongHC GetLuongThuocNV(string strIDNV)
        {
            //dt = getDataContext();
            tblLuongHC q = (from n in dt.tblLuongHCs //trong bảng lương hành chính
                            where n.IDNV.Equals(strIDNV)//với id = id cần lấy thông tin
                            select n).FirstOrDefault();//lấy.thằng đầu tiên
            return q;
        }
        //Kiểm tra tồn tại lương nhân viên
        public tblLuongHC CheckIfExistNV(string strIDNV)
        {
          //  dt = getDataContext();
            tblLuongHC nvtemp = (from n in dt.tblLuongHCs
                                 where n.IDNV.Equals(strIDNV)//Lấy các phần tử có id = strIDNV
                                 select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Xóa lương nhân viên
        public int DeleteLuongNhanVien(tblLuongHC lhc)
        {
          //  dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(lhc.IDNV) != null)
                {
                    dt.tblLuongHCs.DeleteOnSubmit(lhc);
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                //throw new Exception("Lỗi không xóa được " + ex.Message);
                return -1;
            }
        }
        //Thêm lương nhân viên
        public int insertLuongNhanVien(tblLuongHC n)
        {
           // dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(n.IDNV) != null)
                    return 0;
                else
                {
                    dt.tblLuongHCs.InsertOnSubmit(n);
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
