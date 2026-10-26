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

        public DataTable LayDanhSachCongViec(bool chiLayDangHoatDong = true)
        {
            return dal.LayDanhSachCongViec(chiLayDangHoatDong);
        }

        public string SinhMaCongViecTuDong()
        {
            return dal.SinhMaCongViecTuDong();
        }

        public bool ThemCongViec(CongViecDTO cv)
        {
            return ThemCongViec(cv, "QuanLy");
        }

        public bool ThemCongViec(CongViecDTO cv, string quyenNguoiDung)
        {
            if (!string.IsNullOrEmpty(quyenNguoiDung) && !string.Equals(quyenNguoiDung, "QuanLy", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Chỉ có tài khoản quyền Quản lý mới được phép thêm công việc!");
            }

            if (cv == null)
            {
                throw new ArgumentNullException("Dữ liệu công việc không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(cv.TenCongViec))
            {
                throw new ArgumentException("Tên công việc không được để trống!");
            }

            if (cv.MucLuong < 0)
            {
                throw new ArgumentException("Mức lương cơ bản không được âm!");
            }

            cv.TenCongViec = cv.TenCongViec.Trim();

            if (dal.KiemTraTrungTenCongViec(cv.TenCongViec))
            {
                throw new InvalidOperationException(string.Format("Tên công việc '{0}' đã tồn tại trong hệ thống!", cv.TenCongViec));
            }

            if (string.IsNullOrWhiteSpace(cv.MaCongViec))
            {
                cv.MaCongViec = SinhMaCongViecTuDong();
            }
            else
            {
                cv.MaCongViec = cv.MaCongViec.Trim().ToUpper();
                if (dal.KiemTraTonTaiCongViec(cv.MaCongViec))
                {
                    throw new InvalidOperationException(string.Format("Mã công việc '{0}' đã tồn tại trong hệ thống!", cv.MaCongViec));
                }
            }

            return dal.ThemCongViec(cv);
        }

        public bool SuaCongViec(CongViecDTO cv)
        {
            return SuaCongViec(cv, "QuanLy");
        }

        public bool SuaCongViec(CongViecDTO cv, string quyenNguoiDung)
        {
            if (!string.IsNullOrEmpty(quyenNguoiDung) && !string.Equals(quyenNguoiDung, "QuanLy", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Chỉ có tài khoản quyền Quản lý mới được phép sửa công việc!");
            }

            if (cv == null)
            {
                throw new ArgumentNullException("Dữ liệu công việc không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(cv.MaCongViec))
            {
                throw new ArgumentException("Mã công việc không được để trống!");
            }

            cv.MaCongViec = cv.MaCongViec.Trim().ToUpper();

            if (!dal.KiemTraTonTaiCongViec(cv.MaCongViec))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy công việc '{0}' để cập nhật!", cv.MaCongViec));
            }

            if (string.IsNullOrWhiteSpace(cv.TenCongViec))
            {
                throw new ArgumentException("Tên công việc không được để trống!");
            }

            if (cv.MucLuong < 0)
            {
                throw new ArgumentException("Mức lương cơ bản không được âm!");
            }

            cv.TenCongViec = cv.TenCongViec.Trim();

            if (dal.KiemTraTrungTenCongViec(cv.TenCongViec, cv.MaCongViec))
            {
                throw new InvalidOperationException(string.Format("Tên công việc '{0}' đã tồn tại trong hệ thống!", cv.TenCongViec));
            }

            return dal.SuaCongViec(cv);
        }

        public bool XoaMemCongViec(string maCongViec)
        {
            return XoaMemCongViec(maCongViec, "QuanLy");
        }

        public bool XoaMemCongViec(string maCongViec, string quyenNguoiDung)
        {
            if (!string.IsNullOrEmpty(quyenNguoiDung) && !string.Equals(quyenNguoiDung, "QuanLy", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Chỉ có tài khoản quyền Quản lý mới được phép xóa công việc!");
            }

            if (string.IsNullOrWhiteSpace(maCongViec))
            {
                throw new ArgumentException("Mã công việc cần xóa không được để trống!");
            }

            maCongViec = maCongViec.Trim().ToUpper();

            if (!dal.KiemTraTonTaiCongViec(maCongViec))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy công việc '{0}' để xóa!", maCongViec));
            }

            if (maCongViec == "CV0001")
            {
                throw new InvalidOperationException("Không thể xóa công việc mặc định của hệ thống (CV0001)!");
            }

            if (dal.KiemTraCongViecDangDuocSuDung(maCongViec))
            {
                throw new InvalidOperationException("Không thể xóa công việc này vì đang có nhân viên đảm nhận. Vui lòng chuyển công việc cho nhân viên trước!");
            }

            return dal.XoaMemCongViec(maCongViec);
        }

        public bool KhoiPhucCongViec(string maCongViec)
        {
            return KhoiPhucCongViec(maCongViec, "QuanLy");
        }

        public bool KhoiPhucCongViec(string maCongViec, string quyenNguoiDung)
        {
            if (!string.IsNullOrEmpty(quyenNguoiDung) && !string.Equals(quyenNguoiDung, "QuanLy", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Chỉ có tài khoản quyền Quản lý mới được phép khôi phục công việc!");
            }

            if (string.IsNullOrWhiteSpace(maCongViec))
            {
                throw new ArgumentException("Mã công việc cần khôi phục không được để trống!");
            }

            maCongViec = maCongViec.Trim().ToUpper();

            CongViecDTO cv = dal.LayCongViecTheoMa(maCongViec);
            if (cv == null)
            {
                throw new InvalidOperationException("Không tìm thấy công việc cần khôi phục!");
            }

            if (dal.KiemTraTrungTenCongViec(cv.TenCongViec, maCongViec))
            {
                throw new InvalidOperationException(string.Format("Không thể khôi phục vì đã tồn tại công việc đang hoạt động có cùng tên '{0}'!", cv.TenCongViec));
            }

            return dal.KhoiPhucCongViec(maCongViec);
        }

        public bool KiemTraCongViecDangDuocSuDung(string maCongViec)
        {
            if (string.IsNullOrWhiteSpace(maCongViec))
            {
                return false;
            }
            return dal.KiemTraCongViecDangDuocSuDung(maCongViec.Trim());
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

                if (string.Equals(tk.TenDangNhap, "admin", StringComparison.OrdinalIgnoreCase) || string.Equals(tk.TenDangNhap, "admin_phu", StringComparison.OrdinalIgnoreCase))
                {
                    if (!tk.TrangThaiHoatDong)
                    {
                        throw new InvalidOperationException("Không thể vô hiệu hóa 2 tài khoản Quản trị viên hệ thống (admin, admin_phu)!");
                    }
                    if (!string.Equals(tk.Quyen, "QuanLy", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException("Không thể đổi quyền Quản lý của 2 tài khoản Quản trị viên hệ thống (admin, admin_phu)!");
                    }
                }

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
                throw new InvalidOperationException("Không thể xóa 2 tài khoản Quản trị viên hệ thống (admin, admin_phu)!");
            }

            string tenDangNhap = dal.LayTenDangNhapTheoMaNV(maNV);
            if (string.Equals(tenDangNhap, "admin", StringComparison.OrdinalIgnoreCase) || string.Equals(tenDangNhap, "admin_phu", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Không thể xóa 2 tài khoản Quản trị viên hệ thống (admin, admin_phu)!");
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
            NhanVienDTO nv = dal.LayNhanVienTheoMa(maNV);
            if (nv == null)
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy nhân viên '{0}' để khôi phục!", maNV));
            }

            if (!string.IsNullOrWhiteSpace(nv.MaCongViec))
            {
                CongViecDTO cv = dal.LayCongViecTheoMa(nv.MaCongViec);
                if (cv == null || cv.TrangThaiXoa)
                {
                    string tenCV = cv != null ? cv.TenCongViec : "Không xác định";
                    throw new InvalidOperationException(string.Format("Không thể khôi phục nhân viên '{0}' vì công việc '{1}' ({2}) đã bị xóa khỏi hệ thống. Vui lòng khôi phục công việc trước!", nv.TenNhanVien, tenCV, nv.MaCongViec));
                }
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

            tenDangNhap = tenDangNhap.Trim();

            if (!hoatDong && (string.Equals(tenDangNhap, "admin", StringComparison.OrdinalIgnoreCase) || string.Equals(tenDangNhap, "admin_phu", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Không thể vô hiệu hóa 2 tài khoản Quản trị viên hệ thống (admin, admin_phu)!");
            }

            return dal.DoiTrangThaiTaiKhoan(tenDangNhap, hoatDong);
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

            CongViecDTO cvPhanCong = dal.LayCongViecTheoMa(nv.MaCongViec.Trim());
            if (cvPhanCong == null)
            {
                throw new ArgumentException(string.Format("Công việc có mã '{0}' không tồn tại trong hệ thống!", nv.MaCongViec));
            }

            if (cvPhanCong.TrangThaiXoa)
            {
                throw new InvalidOperationException(string.Format("Công việc '{0}' ({1}) hiện đang ở trạng thái đã xóa! Vui lòng chọn công việc khác.", cvPhanCong.TenCongViec, cvPhanCong.MaCongViec));
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
