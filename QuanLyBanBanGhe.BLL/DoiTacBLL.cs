using System;
using System.Data;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class DoiTacBLL
    {
        private readonly IDoiTacDAL dal;
        private static readonly Regex DienThoaiRegex = new Regex(@"^0\d{9}$");
        private static readonly Regex MaKhachRegex = new Regex(@"^KH\d{4}$");
        private static readonly Regex MaNccRegex = new Regex(@"^NCC\d{4}$");

        public DoiTacBLL() : this(new DoiTacDAL())
        {
        }

        public DoiTacBLL(IDoiTacDAL dal)
        {
            this.dal = dal;
        }

        public string SinhMaKhachHangMoi()
        {
            return dal.SinhMaKhachHangMoi();
        }

        public string SinhMaNhaCungCapMoi()
        {
            return dal.SinhMaNhaCungCapMoi();
        }

        public DataTable LayDanhSachKhachHang(bool chiLayDangHoatDong = true)
        {
            return dal.LayDanhSachKhachHang(chiLayDangHoatDong);
        }

        public DataTable TimKiemKhachHang(string maKhach, string tenKhach, string dienThoai, string diaChi, bool chiLayDangHoatDong = true)
        {
            return dal.TimKiemKhachHang(maKhach, tenKhach, dienThoai, diaChi, chiLayDangHoatDong);
        }

        public DataTable TimKiemNhaCungCap(string maNCC, string tenNCC, string dienThoai, string diaChi, bool chiLayDangHoatDong = true)
        {
            return dal.TimKiemNhaCungCap(maNCC, tenNCC, dienThoai, diaChi, chiLayDangHoatDong);
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            KiemTraHopLeKhachHang(kh);

            if (dal.KiemTraTonTaiKhachHang(kh.MaKhach))
            {
                throw new InvalidOperationException(string.Format("Mã khách hàng '{0}' đã tồn tại trong hệ thống!", kh.MaKhach));
            }

            if (dal.KiemTraTrungSoDienThoaiKhachHang(kh.DienThoai))
            {
                throw new InvalidOperationException(string.Format("Số điện thoại '{0}' đã tồn tại trong hệ thống!", kh.DienThoai));
            }

            return dal.ThemKhachHang(kh);
        }

        public bool CapNhatKhachHang(KhachHangDTO kh)
        {
            KiemTraHopLeKhachHang(kh);

            if (!dal.KiemTraTonTaiKhachHang(kh.MaKhach))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy khách hàng '{0}' để cập nhật!", kh.MaKhach));
            }

            if (dal.KiemTraTrungSoDienThoaiKhachHang(kh.DienThoai, kh.MaKhach))
            {
                throw new InvalidOperationException(string.Format("Số điện thoại '{0}' đã được sử dụng bởi một khách hàng khác!", kh.DienThoai));
            }

            return dal.CapNhatKhachHang(kh);
        }

        public bool XoaMemKhachHang(string maKhach)
        {
            if (string.IsNullOrWhiteSpace(maKhach))
            {
                throw new ArgumentException("Mã khách hàng cần xóa không được để trống!");
            }

            maKhach = maKhach.Trim();
            if (!dal.KiemTraTonTaiKhachHang(maKhach))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy khách hàng '{0}' để xóa!", maKhach));
            }

            int soPhieuBH = dal.DemPhieuBaoHanhChuaHoanTat(maKhach);
            if (soPhieuBH > 0)
            {
                throw new InvalidOperationException(string.Format(
                    "Không thể xóa khách hàng '{0}' vì hiện tại đang có {1} phiếu bảo hành đang tiếp nhận hoặc xử lý chưa hoàn tất!",
                    maKhach, soPhieuBH));
            }

            return dal.XoaMemKhachHang(maKhach);
        }

        public bool KhoiPhucKhachHang(string maKhach)
        {
            if (string.IsNullOrWhiteSpace(maKhach))
            {
                throw new ArgumentException("Mã khách hàng cần khôi phục không được để trống!");
            }

            maKhach = maKhach.Trim();
            if (!dal.KiemTraTonTaiKhachHang(maKhach))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy khách hàng '{0}' để khôi phục!", maKhach));
            }

            string sdt = dal.LaySoDienThoaiKhachHang(maKhach);
            if (!string.IsNullOrEmpty(sdt) && dal.KiemTraTrungSoDienThoaiKhachHang(sdt, maKhach))
            {
                throw new InvalidOperationException(string.Format("Không thể khôi phục khách hàng '{0}' vì số điện thoại '{1}' đang được sử dụng bởi khách hàng khác đang hoạt động!", maKhach, sdt));
            }

            return dal.KhoiPhucKhachHang(maKhach);
        }

        public DataTable LayDanhSachNhaCungCap(bool chiLayDangHoatDong = true)
        {
            return dal.LayDanhSachNhaCungCap(chiLayDangHoatDong);
        }

        public bool ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            KiemTraHopLeNhaCungCap(ncc);

            if (dal.KiemTraTonTaiNhaCungCap(ncc.MaNhaCungCap))
            {
                throw new InvalidOperationException(string.Format("Mã nhà cung cấp '{0}' đã tồn tại trong hệ thống!", ncc.MaNhaCungCap));
            }

            return dal.ThemNhaCungCap(ncc);
        }

        public bool CapNhatNhaCungCap(NhaCungCapDTO ncc)
        {
            KiemTraHopLeNhaCungCap(ncc);

            if (!dal.KiemTraTonTaiNhaCungCap(ncc.MaNhaCungCap))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhà cung cấp '{0}' để cập nhật!", ncc.MaNhaCungCap));
            }

            return dal.CapNhatNhaCungCap(ncc);
        }

        public bool XoaMemNhaCungCap(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp cần xóa không được để trống!");
            }

            maNCC = maNCC.Trim();
            if (!dal.KiemTraTonTaiNhaCungCap(maNCC))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhà cung cấp '{0}' để xóa!", maNCC));
            }

            return dal.XoaMemNhaCungCap(maNCC);
        }

        public bool KhoiPhucNhaCungCap(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp cần khôi phục không được để trống!");
            }

            maNCC = maNCC.Trim();
            if (!dal.KiemTraTonTaiNhaCungCap(maNCC))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhà cung cấp '{0}' để khôi phục!", maNCC));
            }

            return dal.KhoiPhucNhaCungCap(maNCC);
        }

        private void KiemTraHopLeKhachHang(KhachHangDTO kh)
        {
            if (kh == null)
            {
                throw new ArgumentNullException("Dữ liệu khách hàng không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(kh.MaKhach))
            {
                throw new ArgumentException("Mã khách hàng không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(kh.TenKhach))
            {
                throw new ArgumentException("Tên khách hàng không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(kh.DiaChi))
            {
                throw new ArgumentException("Địa chỉ khách hàng không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(kh.DienThoai) || !DienThoaiRegex.IsMatch(kh.DienThoai.Trim()))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ! Bắt buộc phải gồm 10 chữ số và bắt đầu bằng số 0 (ví dụ: 0912345678).");
            }

            kh.MaKhach = kh.MaKhach.Trim().ToUpper();
            if (!MaKhachRegex.IsMatch(kh.MaKhach))
            {
                throw new ArgumentException("Mã khách hàng phải theo định dạng KH kèm 4 chữ số (ví dụ: KH0001)!");
            }

            kh.TenKhach = kh.TenKhach.Trim();
            kh.DiaChi = kh.DiaChi.Trim();
            kh.DienThoai = kh.DienThoai.Trim();
        }

        private void KiemTraHopLeNhaCungCap(NhaCungCapDTO ncc)
        {
            if (ncc == null)
            {
                throw new ArgumentNullException("Dữ liệu nhà cung cấp không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(ncc.MaNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không được để trống!");
            }

            ncc.MaNhaCungCap = ncc.MaNhaCungCap.Trim().ToUpper();
            if (!MaNccRegex.IsMatch(ncc.MaNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp phải theo định dạng NCC kèm 4 chữ số (ví dụ: NCC0001)!");
            }

            if (string.IsNullOrWhiteSpace(ncc.TenNhaCungCap))
            {
                throw new ArgumentException("Tên nhà cung cấp không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(ncc.DiaChi))
            {
                throw new ArgumentException("Địa chỉ nhà cung cấp không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(ncc.DienThoai) || !DienThoaiRegex.IsMatch(ncc.DienThoai.Trim()))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ! Bắt buộc phải gồm 10 chữ số và bắt đầu bằng số 0 (ví dụ: 0912345678).");
            }

            ncc.MaNhaCungCap = ncc.MaNhaCungCap.Trim();
            ncc.TenNhaCungCap = ncc.TenNhaCungCap.Trim();
            ncc.DiaChi = ncc.DiaChi.Trim();
            ncc.DienThoai = ncc.DienThoai.Trim();
        }
    }
}
