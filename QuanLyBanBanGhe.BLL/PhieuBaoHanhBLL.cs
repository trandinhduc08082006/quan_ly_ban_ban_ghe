using System;
using System.Data;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class PhieuBaoHanhBLL
    {
        private readonly PhieuBaoHanhDAL dal;
        private static readonly Regex MaPhieuRegex = new Regex(@"^BH\d{4}$");

        public PhieuBaoHanhBLL()
        {
            dal = new PhieuBaoHanhDAL();
        }

        public string SinhMaMoi()
        {
            return dal.SinhMaPhieuBaoHanhMoi();
        }

        public DataTable LayTatCa(bool daXoa = false)
        {
            return dal.LayTatCa(daXoa);
        }

        public DataTable LayTheoMa(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                return null;
            }
            return dal.LayTheoMa(maPhieu.Trim());
        }

        public DataTable LayDanhSachHangHoaTheoHoaDon(string soHDB)
        {
            if (string.IsNullOrWhiteSpace(soHDB))
            {
                return null;
            }
            return dal.LayDanhSachHangHoaTheoHoaDon(soHDB.Trim());
        }

        public DataTable LayDanhSachHoaDonHopLe()
        {
            return dal.LayDanhSachHoaDonHopLe();
        }

        public bool KiemTraTonTai(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                return false;
            }
            return dal.KiemTraTonTai(maPhieu.Trim());
        }

        public bool Them(PhieuBaoHanhDTO dto)
        {
            KiemTraHopLe(dto);

            if (dal.KiemTraTonTai(dto.MaPhieuBaoHanh))
            {
                throw new InvalidOperationException(string.Format("Mã phiếu bảo hành '{0}' đã tồn tại trong hệ thống!", dto.MaPhieuBaoHanh));
            }

            return dal.Them(dto);
        }

        public bool Sua(PhieuBaoHanhDTO dto)
        {
            KiemTraHopLe(dto);

            if (!dal.KiemTraTonTai(dto.MaPhieuBaoHanh))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy phiếu bảo hành '{0}' để cập nhật!", dto.MaPhieuBaoHanh));
            }

            return dal.Sua(dto);
        }

        public bool XoaMem(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                throw new ArgumentException("Mã phiếu bảo hành không được để trống!");
            }

            if (!dal.KiemTraTonTai(maPhieu))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy phiếu bảo hành '{0}' để xóa!", maPhieu));
            }

            return dal.XoaMem(maPhieu.Trim());
        }

        public bool KhoiPhuc(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                throw new ArgumentException("Mã phiếu bảo hành không được để trống!");
            }

            maPhieu = maPhieu.Trim();
            if (!dal.KiemTraTonTai(maPhieu))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy phiếu bảo hành '{0}' để khôi phục!", maPhieu));
            }

            DataTable dt = dal.LayTheoMa(maPhieu);
            if (dt != null && dt.Rows.Count > 0)
            {
                string soHDB = dt.Rows[0]["so_hoa_don_ban"]?.ToString();
                string trangThaiHDB = dt.Rows[0]["trang_thai_hoa_don_ban"]?.ToString();

                if (string.Equals(trangThaiHDB, "DaHuy", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(string.Format(
                        "Không thể khôi phục phiếu bảo hành '{0}' vì hóa đơn bán liên quan '{1}' đã bị hủy giao dịch!",
                        maPhieu, soHDB));
                }
            }

            return dal.KhoiPhuc(maPhieu);
        }

        public DataTable TimKiem(string tuKhoa, string trangThai, bool daXoa = false)
        {
            return dal.TimKiem(tuKhoa, trangThai, daXoa);
        }

        public bool KiemTraConHanBaoHanh(DateTime thoiGianBan, int? thoiGianBaoHanhThang, DateTime ngayTiepNhan)
        {
            if (!thoiGianBaoHanhThang.HasValue || thoiGianBaoHanhThang.Value <= 0)
            {
                return false;
            }
            DateTime hanBaoHanh = thoiGianBan.AddMonths(thoiGianBaoHanhThang.Value);
            return ngayTiepNhan <= hanBaoHanh;
        }

        private void KiemTraHopLe(PhieuBaoHanhDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "Thông tin phiếu bảo hành không được null!");
            }

            if (string.IsNullOrWhiteSpace(dto.MaPhieuBaoHanh))
            {
                throw new ArgumentException("Mã phiếu bảo hành không được để trống!");
            }

            dto.MaPhieuBaoHanh = dto.MaPhieuBaoHanh.Trim().ToUpper();
            if (!MaPhieuRegex.IsMatch(dto.MaPhieuBaoHanh))
            {
                throw new ArgumentException("Mã phiếu bảo hành phải có định dạng BHxxxx (ví dụ: BH0001, BH0002)!");
            }

            if (string.IsNullOrWhiteSpace(dto.SoHoaDonBan))
            {
                throw new ArgumentException("Vui lòng chọn số hóa đơn bán hàng!");
            }

            string trangThaiHDB = dal.LayTrangThaiHoaDonBan(dto.SoHoaDonBan.Trim());
            if (string.Equals(trangThaiHDB, "DaHuy", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(string.Format("Hóa đơn bán '{0}' đã bị hủy giao dịch, không thể lập hoặc sửa phiếu bảo hành!", dto.SoHoaDonBan));
            }

            if (string.IsNullOrWhiteSpace(dto.MaHang))
            {
                throw new ArgumentException("Vui lòng chọn mặt hàng cần bảo hành!");
            }

            if (string.IsNullOrWhiteSpace(dto.MaKhach))
            {
                throw new ArgumentException("Thông tin khách hàng không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(dto.MaNhanVien))
            {
                throw new ArgumentException("Nhân viên tiếp nhận không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(dto.MoTaLoi))
            {
                throw new ArgumentException("Mô tả lỗi của sản phẩm không được để trống!");
            }

            if (dto.ChiPhi < 0)
            {
                throw new ArgumentException("Chi phí bảo hành không được là số âm!");
            }

            if (dto.NgayHenTra.HasValue && dto.NgayHenTra.Value.Date < dto.NgayTiepNhan.Date)
            {
                throw new ArgumentException("Ngày hẹn trả không được trước ngày tiếp nhận bảo hành!");
            }

            if (dto.NgayTraThucTe.HasValue && dto.NgayTraThucTe.Value.Date < dto.NgayTiepNhan.Date)
            {
                throw new ArgumentException("Ngày trả thực tế không được trước ngày tiếp nhận bảo hành!");
            }
        }
    }
}
