using System;
using System.Data;
using QuanLyBanBanGhe.DAL;

namespace QuanLyBanBanGhe.BLL
{
    public class TimKiemBLL
    {
        private readonly TimKiemDAL dal;

        public TimKiemBLL()
        {
            dal = new TimKiemDAL();
        }

        public DataTable TimKiemHangHoa(
            string tuKhoa,
            string maLoai,
            string maKichThuoc,
            string maHinhDang,
            string maChatLieu,
            string maNuocSX,
            string maMau,
            string maNhaSX,
            string maCongDung,
            string maDacDiem)
        {
            return dal.TimKiemHangHoa(tuKhoa, maLoai, maKichThuoc, maHinhDang, maChatLieu, maNuocSX, maMau, maNhaSX, maCongDung, maDacDiem);
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
