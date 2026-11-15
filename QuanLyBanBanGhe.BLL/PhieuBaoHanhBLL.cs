using System;
using System.Data;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class PhieuBaoHanhBLL
    {
        private readonly IBaoHanhDAL dal;
        private static readonly Regex MaPhieuRegex = new Regex(@"^BH\d{4}$");

        public PhieuBaoHanhBLL() : this(new PhieuBaoHanhDAL())
        {
        }

        public PhieuBaoHanhBLL(IBaoHanhDAL dal)
        {
            this.dal = dal;
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

            DataTable dt = dal.LayTheoMa(dto.MaPhieuBaoHanh);
            if (dt != null && dt.Rows.Count > 0)
            {
                string trangThaiCu = dt.Rows[0]["trang_thai"]?.ToString() ?? "TiepNhan";
                if (!KiemTraChuyenDoiTrangThaiHopLe(trangThaiCu, dto.TrangThai))
                {
                    if (trangThaiCu == "DaTra" || trangThaiCu == "TuChoi")
                    {
                        throw new InvalidOperationException("Phiếu bảo hành đã kết thúc chu trình (Đã trả khách hoặc Từ chối bảo hành), không thể chỉnh sửa!");
                    }
                    throw new InvalidOperationException(string.Format("Không thể chuyển đổi trạng thái từ '{0}' sang '{1}'!", trangThaiCu, dto.TrangThai));
                }
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

        public bool KiemTraTrangThaiHopLe(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai)) return false;
            switch (trangThai.Trim())
            {
                case "TiepNhan":
                case "DangXuLy":
                case "DaXong":
                case "DaTra":
                case "TuChoi":
                    return true;
                default:
                    return false;
            }
        }

        public bool KiemTraChuyenDoiTrangThaiHopLe(string trangThaiCu, string trangThaiMoi)
        {
            if (string.Equals(trangThaiCu, trangThaiMoi, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            switch (trangThaiCu)
            {
                case "TiepNhan":
                    return trangThaiMoi == "DangXuLy" || trangThaiMoi == "DaXong" || trangThaiMoi == "TuChoi";
                case "DangXuLy":
                    return trangThaiMoi == "DaXong" || trangThaiMoi == "TuChoi";
                case "DaXong":
                    return trangThaiMoi == "DaTra";
                case "DaTra":
                case "TuChoi":
                    return false;
                default:
                    return false;
            }
        }

        public bool CapNhatTrangThai(string maPhieu, string trangThaiMoi, decimal? chiPhi = null, string bienPhapXuLy = null)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                throw new ArgumentException("Mã phiếu bảo hành không được để trống!");
            }

            maPhieu = maPhieu.Trim();
            if (string.IsNullOrWhiteSpace(trangThaiMoi) || !KiemTraTrangThaiHopLe(trangThaiMoi))
            {
                throw new ArgumentException(string.Format("Trạng thái bảo hành mới '{0}' không hợp lệ!", trangThaiMoi));
            }

            trangThaiMoi = trangThaiMoi.Trim();

            DataTable dt = dal.LayTheoMa(maPhieu);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy phiếu bảo hành '{0}' để cập nhật trạng thái!", maPhieu));
            }

            DataRow r = dt.Rows[0];
            bool daXoa = r["trang_thai_xoa"] != DBNull.Value && Convert.ToBoolean(r["trang_thai_xoa"]);
            if (daXoa)
            {
                throw new InvalidOperationException(string.Format("Phiếu bảo hành '{0}' đã bị xóa tạm, không thể cập nhật trạng thái!", maPhieu));
            }

            string trangThaiCu = r["trang_thai"]?.ToString() ?? "TiepNhan";
            if (!KiemTraChuyenDoiTrangThaiHopLe(trangThaiCu, trangThaiMoi))
            {
                if (trangThaiCu == "DaTra" || trangThaiCu == "TuChoi")
                {
                    throw new InvalidOperationException("Phiếu bảo hành đã kết thúc chu trình (Đã trả khách hoặc Từ chối bảo hành), không thể thay đổi trạng thái!");
                }
                throw new InvalidOperationException(string.Format("Không thể chuyển đổi trạng thái từ '{0}' sang '{1}'!", trangThaiCu, trangThaiMoi));
            }

            decimal chiPhiCu = r["chi_phi"] != DBNull.Value ? Convert.ToDecimal(r["chi_phi"]) : 0;
            decimal chiPhiCapNhat = chiPhi.HasValue ? chiPhi.Value : chiPhiCu;

            if (chiPhiCapNhat < 0)
            {
                throw new ArgumentException("Chi phí bảo hành không được là số âm!");
            }

            string bienPhapCapNhat = bienPhapXuLy ?? r["bien_phap_xu_ly"]?.ToString();

            return dal.CapNhatTrangThaiVaChiPhi(maPhieu, trangThaiMoi, chiPhiCapNhat, bienPhapCapNhat);
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

            if (string.IsNullOrWhiteSpace(dto.TrangThai))
            {
                dto.TrangThai = "TiepNhan";
            }
            else
            {
                dto.TrangThai = dto.TrangThai.Trim();
            }

            if (!KiemTraTrangThaiHopLe(dto.TrangThai))
            {
                throw new ArgumentException(string.Format("Trạng thái bảo hành '{0}' không hợp lệ! Các trạng thái hợp lệ gồm: TiepNhan, DangXuLy, DaXong, DaTra, TuChoi.", dto.TrangThai));
            }

            if (string.Equals(dto.TrangThai, "DaTra", StringComparison.OrdinalIgnoreCase) && !dto.NgayTraThucTe.HasValue)
            {
                dto.NgayTraThucTe = DateTime.Today;
            }

            DataTable dtHang = dal.LayDanhSachHangHoaTheoHoaDon(dto.SoHoaDonBan.Trim());
            if (dtHang == null || dtHang.Rows.Count == 0)
            {
                throw new InvalidOperationException(string.Format("Hóa đơn bán '{0}' không tồn tại, chưa hoàn thành hoặc không có mặt hàng nào!", dto.SoHoaDonBan));
            }

            DataRow hangHopLe = null;
            foreach (DataRow r in dtHang.Rows)
            {
                if (string.Equals(r["ma_hang"]?.ToString()?.Trim(), dto.MaHang.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    hangHopLe = r;
                    break;
                }
            }

            if (hangHopLe == null)
            {
                throw new InvalidOperationException(string.Format("Mặt hàng '{0}' không thuộc chi tiết của hóa đơn bán '{1}'!", dto.MaHang, dto.SoHoaDonBan));
            }

            string maKhachHDB = hangHopLe["ma_khach"]?.ToString()?.Trim();
            if (!string.Equals(maKhachHDB, dto.MaKhach.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(string.Format("Khách hàng '{0}' không khớp với khách hàng '{1}' của hóa đơn bán '{2}'!", dto.MaKhach, maKhachHDB, dto.SoHoaDonBan));
            }

            DateTime thoiGianBan = Convert.ToDateTime(hangHopLe["thoi_gian_ban"]);
            int? thoiGianBHThang = hangHopLe["thoi_gian_bao_hanh"] != DBNull.Value ? (int?)Convert.ToInt32(hangHopLe["thoi_gian_bao_hanh"]) : null;

            bool conHan = KiemTraConHanBaoHanh(thoiGianBan, thoiGianBHThang, dto.NgayTiepNhan);
            if (!conHan)
            {
                if (string.Equals(dto.TrangThai, "TuChoi", StringComparison.OrdinalIgnoreCase))
                {
                }
                else if (dto.ChiPhi > 0)
                {
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Sản phẩm '{0}' đã hết hạn bảo hành! Chỉ được phép lập phiếu từ chối bảo hành ('TuChoi') hoặc tiếp nhận sửa chữa dịch vụ ngoài bảo hành có tính phí (chi phí > 0).", dto.MaHang));
                }
            }
        }
    }
}
