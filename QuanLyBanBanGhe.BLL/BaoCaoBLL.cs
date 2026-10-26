using System;
using System.Data;
using QuanLyBanBanGhe.DAL;

namespace QuanLyBanBanGhe.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL dal;

        public BaoCaoBLL()
        {
            dal = new BaoCaoDAL();
        }

        public DataTable BaoCaoTop10BanChay(int nam)
        {
            KiemTraNamHopLe(nam);
            return dal.BaoCaoTop10BanChay(nam);
        }

        public DataTable BaoCaoNhapHang(int? thang, int? quy, int nam, string maNV)
        {
            if (thang.HasValue && (thang.Value < 1 || thang.Value > 12))
            {
                throw new ArgumentException("Tháng báo cáo phải từ 1 đến 12!");
            }
            if (quy.HasValue && (quy.Value < 1 || quy.Value > 4))
            {
                throw new ArgumentException("Quý báo cáo phải từ 1 đến 4!");
            }

            KiemTraNamHopLe(nam);
            return dal.BaoCaoNhapHang(thang, quy, nam, maNV);
        }

        public DataTable BaoCaoNhapHangTheoQuy(int quy, int nam, string maNV)
        {
            return BaoCaoNhapHang(null, quy, nam, maNV);
        }

        public DataTable BaoCaoBanHang(int? thang, int? quy, int nam, string maNV)
        {
            if (thang.HasValue && (thang.Value < 1 || thang.Value > 12))
            {
                throw new ArgumentException("Tháng báo cáo phải từ 1 đến 12!");
            }
            if (quy.HasValue && (quy.Value < 1 || quy.Value > 4))
            {
                throw new ArgumentException("Quý báo cáo phải từ 1 đến 4!");
            }

            KiemTraNamHopLe(nam);
            return dal.BaoCaoBanHang(thang, quy, nam, maNV);
        }

        public DataTable BaoCaoDoanhThuTheoThang(int thang, int nam)
        {
            return BaoCaoBanHang(thang, null, nam, null);
        }

        public DataTable BaoCaoNhanVienDoanhSo0(int nam)
        {
            KiemTraNamHopLe(nam);
            return dal.BaoCaoNhanVienDoanhSo0(nam);
        }

        public DataTable BaoCaoTop10NhanVienDoanhSoThap(int nam)
        {
            KiemTraNamHopLe(nam);
            return dal.BaoCaoTop10NhanVienDoanhSoThap(nam);
        }

        private void KiemTraNamHopLe(int nam)
        {
            if (nam < 2000 || nam > DateTime.Now.Year)
            {
                throw new ArgumentException("Năm báo cáo không hợp lệ!");
            }
        }
    }
}
