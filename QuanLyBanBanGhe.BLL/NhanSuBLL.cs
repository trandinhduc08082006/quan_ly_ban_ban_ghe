using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.BLL.Helpers;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class NhanSuBLL
    {
        private readonly NhanSuDAL dal;
        private static readonly Regex DienThoaiRegex = new Regex(@"^0\d{9}$");
        private static readonly Regex MatKhauRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
        private static readonly Regex MaNVRegex = new Regex(@"^NV\d{4}$");

        public NhanSuBLL()
        {
            dal = new NhanSuDAL();
        }

        public string SinhMaNhanVienMoi()
        {
            return dal.SinhMaNhanVienMoi();
        }

        public DataTable LayDanhSachCongViec()
        {
            return dal.LayDanhSachCongViec();
        }

        public DataTable LayDanhSachNhanVien(bool chiLayDangHoatDong = true)
        {
            return dal.LayDanhSachNhanVien(chiLayDangHoatDong);
        }

        public bool KiemTraTonTaiNhanVien(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
            {
                return false;
            }
            return dal.KiemTraTonTaiNhanVien(maNV.Trim());
        }

        public bool KiemTraTonTaiTaiKhoan(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                return false;
            }
            return dal.KiemTraTonTaiTaiKhoan(tenDangNhap.Trim());
        }

        public bool ThemNhanVien(NhanVienDTO nv, TaiKhoanDTO tk = null, string matKhauTho = null)
        {
            KiemTraHopLeNhanVien(nv);

            if (dal.KiemTraTonTaiNhanVien(nv.MaNhanVien))
            {
                throw new InvalidOperationException(string.Format("Mã nhân viên '{0}' đã tồn tại trong hệ thống!", nv.MaNhanVien));
            }

            bool coTaoTaiKhoan = tk != null && !string.IsNullOrWhiteSpace(tk.TenDangNhap);

            if (coTaoTaiKhoan)
            {
                tk.TenDangNhap = tk.TenDangNhap.Trim();
                if (dal.KiemTraTonTaiTaiKhoan(tk.TenDangNhap))
                {
                    throw new InvalidOperationException(string.Format("Tên đăng nhập '{0}' đã được sử dụng!", tk.TenDangNhap));
                }

                if (string.IsNullOrWhiteSpace(matKhauTho))
                {
                    matKhauTho = SecurityHelper.TaoMatKhauMacDinh(nv.TenNhanVien);
                }
                else
                {
                    if (!MatKhauRegex.IsMatch(matKhauTho))
                    {
                        throw new ArgumentException("Mật khẩu phải có tối thiểu 8 ký tự, gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt!");
                    }
                }

                tk.MatKhau = SecurityHelper.HashPassword(matKhauTho);
                tk.MaNhanVien = nv.MaNhanVien;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            dal.ThemNhanVien(nv, trans);
                            dal.ThemTaiKhoan(tk, trans);
                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            else
            {
                return dal.ThemNhanVien(nv);
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nv, TaiKhoanDTO tk = null, string matKhauTho = null)
        {
            KiemTraHopLeNhanVien(nv);

            if (!dal.KiemTraTonTaiNhanVien(nv.MaNhanVien))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhân viên '{0}' để cập nhật!", nv.MaNhanVien));
            }

            bool coThongTinTaiKhoan = tk != null && !string.IsNullOrWhiteSpace(tk.TenDangNhap);

            if (coThongTinTaiKhoan)
            {
                tk.TenDangNhap = tk.TenDangNhap.Trim();
                bool daCoTaiKhoan = dal.KiemTraNhanVienCoTaiKhoan(nv.MaNhanVien);

                if (!daCoTaiKhoan)
                {
                    if (dal.KiemTraTonTaiTaiKhoan(tk.TenDangNhap))
                    {
                        throw new InvalidOperationException(string.Format("Tên đăng nhập '{0}' đã được sử dụng!", tk.TenDangNhap));
                    }

                    if (string.IsNullOrWhiteSpace(matKhauTho))
                    {
                        matKhauTho = SecurityHelper.TaoMatKhauMacDinh(nv.TenNhanVien);
                    }
                    else
                    {
                        if (!MatKhauRegex.IsMatch(matKhauTho))
                        {
                            throw new ArgumentException("Mật khẩu phải có tối thiểu 8 ký tự, gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt!");
                        }
                    }

                    tk.MatKhau = SecurityHelper.HashPassword(matKhauTho);
                    tk.MaNhanVien = nv.MaNhanVien;

                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                dal.CapNhatNhanVien(nv, trans);
                                dal.ThemTaiKhoan(tk, trans);
                                trans.Commit();
                                return true;
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                dal.CapNhatNhanVien(nv, trans);
                                dal.CapNhatQuyenVaTrangThaiTaiKhoan(tk.TenDangNhap, tk.Quyen, tk.TrangThaiHoatDong, trans);
                                trans.Commit();
                                return true;
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            else
            {
                return dal.CapNhatNhanVien(nv);
            }
        }

        public bool XoaMemNhanVien(string maNV, string maNVDangDangNhap)
        {
            if (string.IsNullOrWhiteSpace(maNV))
            {
                throw new ArgumentException("Mã nhân viên cần xóa không được để trống!");
            }

            maNV = maNV.Trim();

            if (string.Equals(maNV, maNVDangDangNhap, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Không thể xóa tài khoản của chính mình đang đăng nhập!");
            }

            if (string.Equals(maNV, "NV0001", StringComparison.OrdinalIgnoreCase) || string.Equals(maNV, "NV0002", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Không thể xóa nhân viên Quản trị viên chính hệ thống (NV0001, NV0002)!");
            }

            if (!dal.KiemTraTonTaiNhanVien(maNV))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhân viên '{0}' để xóa!", maNV));
            }

            return dal.XoaMemNhanVien(maNV);
        }

        public bool KhoiPhucNhanVien(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
            {
                throw new ArgumentException("Mã nhân viên cần khôi phục không được để trống!");
            }

            maNV = maNV.Trim();
            if (!dal.KiemTraTonTaiNhanVien(maNV))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhân viên '{0}' để khôi phục!", maNV));
            }

            return dal.KhoiPhucNhanVien(maNV);
        }

        public string ResetMatKhau(string tenDangNhap, string hoTenNhanVien, string matKhauMoiTho)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống!");
            }

            tenDangNhap = tenDangNhap.Trim();
            if (!dal.KiemTraTonTaiTaiKhoan(tenDangNhap))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy tài khoản '{0}' trong hệ thống!", tenDangNhap));
            }

            string matKhauKetQua;

            if (string.IsNullOrWhiteSpace(matKhauMoiTho))
            {
                if (string.IsNullOrWhiteSpace(hoTenNhanVien))
                {
                    DataTable dt = dal.LayThongTinDangNhap(tenDangNhap);
                    if (dt.Rows.Count > 0)
                    {
                        hoTenNhanVien = dt.Rows[0]["ten_nhan_vien"]?.ToString();
                    }
                }
                matKhauKetQua = SecurityHelper.TaoMatKhauMacDinh(hoTenNhanVien);
            }
            else
            {
                matKhauMoiTho = matKhauMoiTho.Trim();
                if (!MatKhauRegex.IsMatch(matKhauMoiTho))
                {
                    throw new ArgumentException("Mật khẩu mới phải có tối thiểu 8 ký tự, gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt!");
                }
                matKhauKetQua = matKhauMoiTho;
            }

            string matKhauBam = SecurityHelper.HashPassword(matKhauKetQua);
            dal.ResetMatKhau(tenDangNhap, matKhauBam);

            return matKhauKetQua;
        }

        public bool DoiTrangThaiTaiKhoan(string tenDangNhap, bool hoatDong)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống!");
            }

            return dal.DoiTrangThaiTaiKhoan(tenDangNhap.Trim(), hoatDong);
        }

        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                throw new ArgumentException("Tên đăng nhập và mật khẩu không được để trống!");
            }

            tenDangNhap = tenDangNhap.Trim();
            DataTable dt = dal.LayThongTinDangNhap(tenDangNhap);
            if (dt.Rows.Count == 0)
            {
                throw new InvalidOperationException("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }

            DataRow row = dt.Rows[0];
            string matKhauBamCSDL = row["mat_khau"]?.ToString() ?? string.Empty;
            string matKhauBamNhap = SecurityHelper.HashPassword(matKhau);

            if (!string.Equals(matKhauBamCSDL, matKhauBamNhap, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }

            bool trangThaiHoatDong = Convert.ToBoolean(row["trang_thai_hoat_dong"]);
            bool trangThaiXoa = Convert.ToBoolean(row["trang_thai_xoa"]);

            if (!trangThaiHoatDong || trangThaiXoa)
            {
                throw new InvalidOperationException("Tài khoản của bạn đã bị khóa hoặc nhân sự không còn hoạt động, vui lòng liên hệ Quản lý!");
            }

            return new TaiKhoanDTO
            {
                TenDangNhap = row["ten_dang_nhap"]?.ToString(),
                Quyen = row["quyen"]?.ToString(),
                MaNhanVien = row["ma_nhan_vien"]?.ToString(),
                TenNhanVien = row["ten_nhan_vien"]?.ToString(),
                TrangThaiHoatDong = trangThaiHoatDong
            };
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi, string xacNhanMatKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                throw new ArgumentException("Vui lòng nhập mật khẩu cũ!");
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                throw new ArgumentException("Vui lòng nhập mật khẩu mới!");
            }

            if (!string.Equals(matKhauMoi, xacNhanMatKhau))
            {
                throw new ArgumentException("Xác nhận mật khẩu mới không trùng khớp với mật khẩu mới!");
            }

            if (!MatKhauRegex.IsMatch(matKhauMoi))
            {
                throw new ArgumentException("Mật khẩu mới phải có tối thiểu 8 ký tự, gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt!");
            }

            DataTable dt = dal.LayThongTinDangNhap(tenDangNhap.Trim());
            if (dt.Rows.Count == 0)
            {
                throw new InvalidOperationException("Không tìm thấy thông tin tài khoản!");
            }

            string matKhauBamCSDL = dt.Rows[0]["mat_khau"]?.ToString() ?? string.Empty;
            string matKhauCuBam = SecurityHelper.HashPassword(matKhauCu);

            if (!string.Equals(matKhauBamCSDL, matKhauCuBam, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Mật khẩu cũ không chính xác!");
            }

            string matKhauMoiBam = SecurityHelper.HashPassword(matKhauMoi);
            return dal.ResetMatKhau(tenDangNhap.Trim(), matKhauMoiBam);
        }

        private void KiemTraHopLeNhanVien(NhanVienDTO nv)
        {
            if (nv == null)
            {
                throw new ArgumentNullException("Dữ liệu nhân viên không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(nv.MaNhanVien))
            {
                throw new ArgumentException("Mã nhân viên không được để trống!");
            }

            nv.MaNhanVien = nv.MaNhanVien.Trim().ToUpper();
            if (!MaNVRegex.IsMatch(nv.MaNhanVien))
            {
                throw new ArgumentException("Mã nhân viên phải theo định dạng NV kèm 4 chữ số (ví dụ: NV0001)!");
            }

            if (string.IsNullOrWhiteSpace(nv.TenNhanVien))
            {
                throw new ArgumentException("Tên nhân viên không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(nv.DienThoai) || !DienThoaiRegex.IsMatch(nv.DienThoai.Trim()))
            {
                throw new ArgumentException("Số điện thoại không hợp lệ! Bắt buộc phải gồm 10 chữ số và bắt đầu bằng số 0 (ví dụ: 0912345678).");
            }

            if (string.IsNullOrWhiteSpace(nv.DiaChi))
            {
                throw new ArgumentException("Địa chỉ nhân viên không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(nv.MaCongViec))
            {
                throw new ArgumentException("Vui lòng chọn công việc / chức vụ cho nhân viên!");
            }

            if (nv.NgaySinh.HasValue)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - nv.NgaySinh.Value.Year;
                if (nv.NgaySinh.Value.Date > today.AddYears(-age))
                {
                    age--;
                }
                if (age < 18)
                {
                    throw new ArgumentException("Nhân viên phải từ đủ 18 tuổi trở lên!");
                }
            }

            nv.MaNhanVien = nv.MaNhanVien.Trim();
            nv.TenNhanVien = nv.TenNhanVien.Trim();
            nv.DienThoai = nv.DienThoai.Trim();
            nv.DiaChi = nv.DiaChi.Trim();
            nv.MaCongViec = nv.MaCongViec.Trim();
        }
    }
}
