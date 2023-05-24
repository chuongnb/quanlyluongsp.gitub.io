using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class clsNhanVienHC : clsKetNoi
    {
        qlLuongSPDataContext dt;

        // Hẳn là lấy data ra xài nhỉ :)
        public clsNhanVienHC()
        {
            dt = getDataContext();
        }

        // Lấy tất cả nhân viên hành chính trong table NhanVienHanhChinh
        public IEnumerable<tblNhanVienHanhChinh> GetAllNhanVien()
        {
            dt = getDataContext();
            IEnumerable<tblNhanVienHanhChinh> q = from n in dt.tblNhanVienHanhChinhs//Trong bảng
                                                  select n;//Lấy
            return q;
        }
        
        // Lấy nhân viên theo ID
        public tblNhanVienHanhChinh GetOneNV(string strIDNV)
        {
            //dt = getDataContext();
            tblNhanVienHanhChinh q = (from n in dt.tblNhanVienHanhChinhs //Trong bảng nhân viên hành chính
                                     where n.IDNV.Equals(strIDNV)// với điều kiện ID = ID cần lấy
                                     select n).FirstOrDefault();// Lấy thằng đầu tiên đủ điều kiện
            return q;
        }
        //Tìm kiếm nhân viên theo id chứa id cần tìm
        public IEnumerable<tblNhanVienHanhChinh> GetNVTheoIDKhongHoanChinh(string strIDTim)
        {
            //dt = getDataContext();
            IEnumerable<tblNhanVienHanhChinh> q = from n in dt.tblNhanVienHanhChinhs
                                                  //Nếu các kí tự đầu tiên của ID bằng chuỗi cần tìm
                                                  where n.IDNV.Substring(0,strIDTim.Length).Equals(strIDTim)
                                                  select n;
            return q;
        }

        //Lấy nhân viên theo tên
        public IEnumerable<tblNhanVienHanhChinh> GetNVTheoTen(string strTen)
        {
           // dt = getDataContext();
            IEnumerable<tblNhanVienHanhChinh> q = from n in dt.tblNhanVienHanhChinhs
                                                  //Nếu các kí tự đầu tiên của Tên bằng chuỗi cần tìm
                                                  where n.HoTen.Substring(0,strTen.Length).Equals(strTen)
                                                  select n;
            return q;
        }
        //Kiểm tra tồn tại nhân viên
        public tblNhanVienHanhChinh CheckIfExistNV(string strIDNV)
        {
           // dt = getDataContext();
            tblNhanVienHanhChinh nvtemp = (from n in dt.tblNhanVienHanhChinhs
                                  where n.IDNV.Equals(strIDNV)//Lấy các phần tử có id = strIDNV
                                  select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
                
        //Xóa nhân viên
        public int DeleteNhanVien(tblNhanVienHanhChinh nv)
        {
           // dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(nv.IDNV) != null)
                {
                    dt.tblNhanVienHanhChinhs.DeleteOnSubmit(nv);
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
                
        //Sửa Nhân viên
        public bool SuaNV(tblNhanVienHanhChinh nvSua)
        {
            //dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IQueryable<tblNhanVienHanhChinh> tam = (from n in dt.tblNhanVienHanhChinhs
                                               where n.IDNV.Equals(nvSua.IDNV)
                                               select n);
                tam.First().IDNV = nvSua.IDNV;
                tam.First().HoTen = nvSua.HoTen;
                tam.First().GioiTinh = nvSua.GioiTinh;
                tam.First().NgaySinh = nvSua.NgaySinh;
                tam.First().NgayBatDau = nvSua.NgayBatDau;
                tam.First().HeSoLuong = nvSua.HeSoLuong;
                tam.First().PhuCap = nvSua.PhuCap;
                tam.First().IDHopDong = nvSua.IDHopDong;
                dt.SubmitChanges();
                dt.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không sữa được " + ex.Message);
            }
        }
                
        //Thêm nhân viên
        public int insertNhanVien(tblNhanVienHanhChinh n)
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
                    dt.tblNhanVienHanhChinhs.InsertOnSubmit(n);
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
             
        //Sắp xếp tăng theo mã NV
        public IEnumerable<tblNhanVienHanhChinh> SXTangTheoIDNV()
        {
           // dt = getDataContext();
            IEnumerable<tblNhanVienHanhChinh> q;
            q = from n in dt.tblNhanVienHanhChinhs
                orderby n.IDNV
                select n;
            return q;
        }

        //Sắp xếp giảm theo mã NV
        public IEnumerable<tblNhanVienHanhChinh> SXGiamTheoIDNV()
        {
            IEnumerable<tblNhanVienHanhChinh> q;
            q = from n in dt.tblNhanVienHanhChinhs
                orderby n.IDNV descending
                select n;
            return q;
        }
    }
}
