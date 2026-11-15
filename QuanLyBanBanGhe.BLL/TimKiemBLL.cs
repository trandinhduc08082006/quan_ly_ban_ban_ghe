using System;
using System.Data;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DAL.Interfaces;

namespace QuanLyBanBanGhe.BLL
{
    public class TimKiemBLL
    {
        private readonly ITimKiemDAL dal;

        public TimKiemBLL() : this(new TimKiemDAL())
        {
        }

        public TimKiemBLL(ITimKiemDAL dal)
        {
            this.dal = dal;
        }

        public DataTable TimKiemHoaDonNhap(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maNCC)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException("Từ ngày không được lớn hơn đến ngày!");
            }

            return dal.TimKiemHoaDonNhap(tuNgay, denNgay, maNhanVien, maNCC);
        }
    
        public DataTable TimKiemHoaDonBan(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maKhach)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException("Từ ngày không được lớn hơn đến ngày!");
            }

            return dal.TimKiemHoaDonBan(tuNgay, denNgay, maNhanVien, maKhach);
        }
    }
}
