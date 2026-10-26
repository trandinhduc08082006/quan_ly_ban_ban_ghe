using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class HoaDonNhapBLL
    {
        private readonly HoaDonNhapDAL dal;
        private readonly HangHoaDAL hangHoaDAL;

        public HoaDonNhapBLL()
        {
            dal = new HoaDonNhapDAL();
            hangHoaDAL = new HangHoaDAL();
        }

        public DataTable LayDanhSachHoaDonNhap()
        {
            return dal.LayDanhSachHoaDonNhap();
        }

        public DataTable LayChiTietHoaDonNhap(string soHDN)
        {
            if (string.IsNullOrWhiteSpace(soHDN))
            {
                throw new ArgumentException("Số hóa đơn nhập không được để trống!");
            }
            return dal.LayChiTietHoaDonNhap(soHDN.Trim());
        }

        public DataTable LayHoaDonNhapTheoMa(string soHDN)
        {
            if (string.IsNullOrWhiteSpace(soHDN))
            {
                throw new ArgumentException("Số hóa đơn nhập không được để trống!");
            }
            return dal.LayHoaDonNhapTheoMa(soHDN.Trim());
        }

        public bool LuuHoaDonNhap(HoaDonNhapDTO hdn, List<ChiTietHDNhapDTO> chiTietList)
        {
            KiemTraHopLeHoaDon(hdn, chiTietList);

            if (dal.KiemTraTonTai(hdn.SoHoaDonNhap))
            {
                throw new InvalidOperationException(string.Format("Số hóa đơn nhập '{0}' đã tồn tại trong hệ thống!", hdn.SoHoaDonNhap));
            }

            return dal.LuuHoaDonNhap(hdn, chiTietList);
        }

        public bool HuyHoaDonNhap(string soHDN)
        {
            if (string.IsNullOrWhiteSpace(soHDN))
            {
                throw new ArgumentException("Số hóa đơn nhập cần hủy không được để trống!");
            }

            soHDN = soHDN.Trim();

            DataTable dtHDN = dal.LayHoaDonNhapTheoMa(soHDN);
            if (dtHDN.Rows.Count == 0)
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy hóa đơn nhập '{0}' trong hệ thống!", soHDN));
            }

            string trangThai = dtHDN.Rows[0]["trang_thai_giao_dich"]?.ToString();
            if (!string.Equals(trangThai, "HoanThanh", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Chỉ được phép hủy các hóa đơn đang ở trạng thái Hoàn thành!");
            }

            DataTable dtCT = dal.LayChiTietHoaDonNhap(soHDN);
            foreach (DataRow r in dtCT.Rows)
            {
                string maHang = r["ma_hang"].ToString();
                string tenHang = r["ten_hang_hoa"]?.ToString() ?? maHang;
                int soLuongNhap = Convert.ToInt32(r["so_luong"]);
                int tonKhoHienTai = hangHoaDAL.LayTonKho(maHang);

                if (tonKhoHienTai < soLuongNhap)
                {
                    throw new InvalidOperationException(string.Format(
                        "Không thể hủy hóa đơn! Mặt hàng '{0}' hiện chỉ còn tồn kho {1} cái, nhỏ hơn số lượng đã nhập ({2} cái) do đã được xuất bán.",
                        tenHang, tonKhoHienTai, soLuongNhap));
                }
            }

            return dal.HuyHoaDonNhap(soHDN);
        }

        private void KiemTraHopLeHoaDon(HoaDonNhapDTO hdn, List<ChiTietHDNhapDTO> chiTietList)
        {
            if (hdn == null)
            {
                throw new ArgumentNullException("Dữ liệu hóa đơn nhập không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(hdn.SoHoaDonNhap))
            {
                throw new ArgumentException("Số hóa đơn nhập không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(hdn.MaNhaCungCap))
            {
                throw new ArgumentException("Vui lòng chọn nhà cung cấp cho phiếu nhập!");
            }

            if (string.IsNullOrWhiteSpace(hdn.MaNhanVien))
            {
                throw new ArgumentException("Mã nhân viên lập hóa đơn không được để trống!");
            }

            if (chiTietList == null || chiTietList.Count == 0)
            {
                throw new ArgumentException("Hóa đơn nhập phải chứa ít nhất 1 mặt hàng!");
            }

            decimal tongTien = 0;

            foreach (ChiTietHDNhapDTO ct in chiTietList)
            {
                if (string.IsNullOrWhiteSpace(ct.MaHang))
                {
                    throw new ArgumentException("Mã hàng hóa trong chi tiết không được để trống!");
                }

                if (ct.SoLuong <= 0)
                {
                    throw new ArgumentException("Số lượng nhập của từng mặt hàng phải lớn hơn 0!");
                }

                if (ct.DonGia <= 0)
                {
                    throw new ArgumentException("Đơn giá nhập của từng mặt hàng phải lớn hơn 0!");
                }

                if (ct.GiamGia < 0 || ct.GiamGia > 100)
                {
                    throw new ArgumentException("Tỷ lệ giảm giá phải nằm trong khoảng từ 0% đến 100%!");
                }

                ct.ThanhTien = Math.Round(ct.SoLuong * ct.DonGia * (1 - ct.GiamGia / 100m), 2);
                tongTien += ct.ThanhTien;
            }

            hdn.TongTien = tongTien;
            hdn.SoHoaDonNhap = hdn.SoHoaDonNhap.Trim();
            hdn.MaNhaCungCap = hdn.MaNhaCungCap.Trim();
            hdn.MaNhanVien = hdn.MaNhanVien.Trim();
        }
    }
}
