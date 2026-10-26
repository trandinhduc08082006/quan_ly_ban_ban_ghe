using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class HoaDonBanBLL
    {
        private readonly HoaDonBanDAL dal;
        private readonly HangHoaDAL hangHoaDAL;

        public HoaDonBanBLL()
        {
            dal = new HoaDonBanDAL();
            hangHoaDAL = new HangHoaDAL();
        }

        public DataTable LayDanhSachHoaDonBan()
        {
            return dal.LayDanhSachHoaDonBan();
        }

        public DataTable LayChiTietHoaDonBan(string soHDB)
        {
            if (string.IsNullOrWhiteSpace(soHDB))
            {
                throw new ArgumentException("Số hóa đơn bán không được để trống!");
            }
            return dal.LayChiTietHoaDonBan(soHDB.Trim());
        }

        public DataTable LayHoaDonBanTheoMa(string soHDB)
        {
            if (string.IsNullOrWhiteSpace(soHDB))
            {
                throw new ArgumentException("Số hóa đơn bán không được để trống!");
            }
            return dal.LayHoaDonBanTheoMa(soHDB.Trim());
        }

        public int LayTonKho(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang))
            {
                return 0;
            }
            return hangHoaDAL.LayTonKho(maHang.Trim());
        }

        public bool LuuHoaDonBan(HoaDonBanDTO hdb, List<ChiTietHDBanDTO> chiTietList)
        {
            KiemTraHopLeHoaDon(hdb, chiTietList);

            if (dal.KiemTraTonTai(hdb.SoHoaDonBan))
            {
                throw new InvalidOperationException(string.Format("Số hóa đơn bán '{0}' đã tồn tại trong hệ thống!", hdb.SoHoaDonBan));
            }

            foreach (ChiTietHDBanDTO ct in chiTietList)
            {
                int tonKho = hangHoaDAL.LayTonKho(ct.MaHang);
                if (ct.SoLuong > tonKho)
                {
                    string tenHang = !string.IsNullOrWhiteSpace(ct.TenHangHoa) ? ct.TenHangHoa : ct.MaHang;
                    throw new InvalidOperationException(string.Format(
                        "Không đủ hàng trong kho để xuất bán! Mặt hàng '{0}' hiện chỉ còn tồn {1} cái, nhưng yêu cầu bán {2} cái.",
                        tenHang, tonKho, ct.SoLuong));
                }
            }

            return dal.LuuHoaDonBan(hdb, chiTietList);
        }

        public bool HuyHoaDonBan(string soHDB)
        {
            if (string.IsNullOrWhiteSpace(soHDB))
            {
                throw new ArgumentException("Số hóa đơn bán cần hủy không được để trống!");
            }

            soHDB = soHDB.Trim();

            DataTable dtHDB = dal.LayHoaDonBanTheoMa(soHDB);
            if (dtHDB.Rows.Count == 0)
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy hóa đơn bán '{0}' trong hệ thống!", soHDB));
            }

            string trangThai = dtHDB.Rows[0]["trang_thai_giao_dich"]?.ToString();
            if (!string.Equals(trangThai, "HoanThanh", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Chỉ được phép hủy các hóa đơn đang ở trạng thái Hoàn thành!");
            }

            int soLuongPBH = dal.DemSoPhieuBaoHanh(soHDB);
            if (soLuongPBH > 0)
            {
                throw new InvalidOperationException(string.Format(
                    "Không thể hủy hóa đơn bán '{0}' vì đang có {1} phiếu bảo hành liên kết! Vui lòng hủy hoặc xử lý các phiếu bảo hành liên quan trước.",
                    soHDB, soLuongPBH));
            }

            return dal.HuyHoaDonBan(soHDB);
        }

        private void KiemTraHopLeHoaDon(HoaDonBanDTO hdb, List<ChiTietHDBanDTO> chiTietList)
        {
            if (hdb == null)
            {
                throw new ArgumentNullException("Dữ liệu hóa đơn bán không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(hdb.SoHoaDonBan))
            {
                throw new ArgumentException("Số hóa đơn bán không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(hdb.MaKhach))
            {
                throw new ArgumentException("Vui lòng chọn khách hàng cho phiếu bán!");
            }

            if (string.IsNullOrWhiteSpace(hdb.MaNhanVien))
            {
                throw new ArgumentException("Mã nhân viên lập hóa đơn không được để trống!");
            }

            if (chiTietList == null || chiTietList.Count == 0)
            {
                throw new ArgumentException("Hóa đơn bán phải chứa ít nhất 1 mặt hàng!");
            }

            decimal tongTien = 0;

            foreach (ChiTietHDBanDTO ct in chiTietList)
            {
                if (string.IsNullOrWhiteSpace(ct.MaHang))
                {
                    throw new ArgumentException("Mã hàng hóa trong chi tiết không được để trống!");
                }

                if (ct.SoLuong <= 0)
                {
                    throw new ArgumentException("Số lượng bán của từng mặt hàng phải lớn hơn 0!");
                }

                if (ct.DonGia <= 0)
                {
                    throw new ArgumentException("Đơn giá bán của từng mặt hàng phải lớn hơn 0!");
                }

                if (ct.GiamGia < 0 || ct.GiamGia > 100)
                {
                    throw new ArgumentException("Tỷ lệ giảm giá phải nằm trong khoảng từ 0% đến 100%!");
                }

                ct.ThanhTien = Math.Round(ct.SoLuong * ct.DonGia * (1 - ct.GiamGia / 100m), 2);
                tongTien += ct.ThanhTien;
            }

            hdb.TongTien = tongTien;
            hdb.SoHoaDonBan = hdb.SoHoaDonBan.Trim();
            hdb.MaKhach = hdb.MaKhach.Trim();
            hdb.MaNhanVien = hdb.MaNhanVien.Trim();
        }
    }
}
