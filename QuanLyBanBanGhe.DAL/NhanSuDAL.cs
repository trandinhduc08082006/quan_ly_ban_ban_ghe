using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class NhanSuDAL
    {
        public DataTable LayDanhSachCongViec(bool chiLayDangHoatDong = true)
        {
            string sql = @"
SELECT ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa 
FROM dbo.cong_viec 
WHERE trang_thai_xoa = @trang_thai_xoa 
ORDER BY ma_cong_viec ASC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool ThemCongViec(CongViecDTO cv)
        {
            string sql = @"
INSERT INTO dbo.cong_viec (ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa) 
VALUES (@ma_cong_viec, @ten_cong_viec, @muc_luong, 0)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", cv.MaCongViec),
                new SqlParameter("@ten_cong_viec", cv.TenCongViec),
                new SqlParameter("@muc_luong", cv.MucLuong)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool SuaCongViec(CongViecDTO cv)
        {
            string sql = @"
UPDATE dbo.cong_viec 
SET ten_cong_viec = @ten_cong_viec, 
    muc_luong = @muc_luong 
WHERE ma_cong_viec = @ma_cong_viec";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", cv.MaCongViec),
                new SqlParameter("@ten_cong_viec", cv.TenCongViec),
                new SqlParameter("@muc_luong", cv.MucLuong)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaMemCongViec(string maCongViec)
        {
            string sql = "UPDATE dbo.cong_viec SET trang_thai_xoa = 1 WHERE ma_cong_viec = @ma_cong_viec";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool KhoiPhucCongViec(string maCongViec)
        {
            string sql = "UPDATE dbo.cong_viec SET trang_thai_xoa = 0 WHERE ma_cong_viec = @ma_cong_viec";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public CongViecDTO LayCongViecTheoMa(string maCongViec)
        {
            string sql = "SELECT ma_cong_viec, ten_cong_viec, muc_luong, trang_thai_xoa FROM dbo.cong_viec WHERE ma_cong_viec = @ma_cong_viec";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new CongViecDTO
                {
                    MaCongViec = r["ma_cong_viec"].ToString(),
                    TenCongViec = r["ten_cong_viec"].ToString(),
                    MucLuong = r["muc_luong"] != DBNull.Value ? Convert.ToDecimal(r["muc_luong"]) : 0,
                    TrangThaiXoa = Convert.ToBoolean(r["trang_thai_xoa"])
                };
            }
            return null;
        }

        public bool KiemTraTonTaiCongViec(string maCongViec)
        {
            string sql = "SELECT COUNT(1) FROM dbo.cong_viec WHERE ma_cong_viec = @ma_cong_viec";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool KiemTraCongViecDangDuocSuDung(string maCongViec)
        {
            string sql = "SELECT COUNT(1) FROM dbo.nhan_vien WHERE ma_cong_viec = @ma_cong_viec AND trang_thai_xoa = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_cong_viec", maCongViec)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool KiemTraTrungTenCongViec(string tenCongViec, string maCongViecLoaiTru = null)
        {
            string sql = "SELECT COUNT(1) FROM dbo.cong_viec WHERE LOWER(ten_cong_viec) = LOWER(@ten_cong_viec) AND trang_thai_xoa = 0";
            if (!string.IsNullOrEmpty(maCongViecLoaiTru))
            {
                sql += " AND ma_cong_viec <> @ma_cong_viec";
            }
            System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>
            {
                new SqlParameter("@ten_cong_viec", tenCongViec.Trim())
            };
            if (!string.IsNullOrEmpty(maCongViecLoaiTru))
            {
                parameters.Add(new SqlParameter("@ma_cong_viec", maCongViecLoaiTru.Trim()));
            }
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters.ToArray()));
            return count > 0;
        }

        public string SinhMaCongViecTuDong()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.cong_viec", "ma_cong_viec", "CV");
        }

        public DataTable LayDanhSachNhanVien(bool chiLayDangHoatDong = true)
        {
            string sql = @"
SELECT 
    nv.ma_nhan_vien, 
    nv.ten_nhan_vien, 
    nv.gioi_tinh, 
    nv.ngay_sinh, 
    nv.dien_thoai, 
    nv.dia_chi, 
    nv.trang_thai_xoa,
    nv.ma_cong_viec, 
    cv.ten_cong_viec, 
    cv.muc_luong,
    tk.ten_dang_nhap, 
    tk.quyen, 
    tk.trang_thai_hoat_dong
FROM dbo.nhan_vien nv
LEFT JOIN dbo.cong_viec cv ON nv.ma_cong_viec = cv.ma_cong_viec
LEFT JOIN dbo.tai_khoan tk ON nv.ma_nhan_vien = tk.ma_nhan_vien
WHERE nv.trang_thai_xoa = @trang_thai_xoa
ORDER BY nv.ma_nhan_vien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTonTaiNhanVien(string maNV)
        {
            string sql = "SELECT COUNT(1) FROM dbo.nhan_vien WHERE ma_nhan_vien = @ma_nhan_vien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public NhanVienDTO LayNhanVienTheoMa(string maNV)
        {
            string sql = @"
SELECT ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec 
FROM dbo.nhan_vien 
WHERE ma_nhan_vien = @ma_nhan_vien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new NhanVienDTO
                {
                    MaNhanVien = r["ma_nhan_vien"].ToString(),
                    TenNhanVien = r["ten_nhan_vien"].ToString(),
                    GioiTinh = r["gioi_tinh"] != DBNull.Value ? r["gioi_tinh"].ToString() : null,
                    NgaySinh = r["ngay_sinh"] != DBNull.Value ? Convert.ToDateTime(r["ngay_sinh"]) : (DateTime?)null,
                    DienThoai = r["dien_thoai"] != DBNull.Value ? r["dien_thoai"].ToString() : null,
                    DiaChi = r["dia_chi"] != DBNull.Value ? r["dia_chi"].ToString() : null,
                    TrangThaiXoa = Convert.ToBoolean(r["trang_thai_xoa"]),
                    MaCongViec = r["ma_cong_viec"] != DBNull.Value ? r["ma_cong_viec"].ToString() : null
                };
            }
            return null;
        }

        public bool ThemNhanVien(NhanVienDTO nv, SqlTransaction trans = null)
        {
            string sql = @"
INSERT INTO dbo.nhan_vien (ma_nhan_vien, ten_nhan_vien, gioi_tinh, ngay_sinh, dien_thoai, dia_chi, trang_thai_xoa, ma_cong_viec)
VALUES (@ma_nhan_vien, @ten_nhan_vien, @gioi_tinh, @ngay_sinh, @dien_thoai, @dia_chi, 0, @ma_cong_viec)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", nv.MaNhanVien),
                new SqlParameter("@ten_nhan_vien", nv.TenNhanVien),
                new SqlParameter("@gioi_tinh", (object)nv.GioiTinh ?? DBNull.Value),
                new SqlParameter("@ngay_sinh", nv.NgaySinh.HasValue ? (object)nv.NgaySinh.Value : DBNull.Value),
                new SqlParameter("@dien_thoai", (object)nv.DienThoai ?? DBNull.Value),
                new SqlParameter("@dia_chi", (object)nv.DiaChi ?? DBNull.Value),
                new SqlParameter("@ma_cong_viec", (object)nv.MaCongViec ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters, trans) > 0;
        }

        public bool CapNhatNhanVien(NhanVienDTO nv, SqlTransaction trans = null)
        {
            string sql = @"
UPDATE dbo.nhan_vien 
SET ten_nhan_vien = @ten_nhan_vien, 
    gioi_tinh = @gioi_tinh, 
    ngay_sinh = @ngay_sinh, 
    dien_thoai = @dien_thoai, 
    dia_chi = @dia_chi, 
    ma_cong_viec = @ma_cong_viec 
WHERE ma_nhan_vien = @ma_nhan_vien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", nv.MaNhanVien),
                new SqlParameter("@ten_nhan_vien", nv.TenNhanVien),
                new SqlParameter("@gioi_tinh", (object)nv.GioiTinh ?? DBNull.Value),
                new SqlParameter("@ngay_sinh", nv.NgaySinh.HasValue ? (object)nv.NgaySinh.Value : DBNull.Value),
                new SqlParameter("@dien_thoai", (object)nv.DienThoai ?? DBNull.Value),
                new SqlParameter("@dia_chi", (object)nv.DiaChi ?? DBNull.Value),
                new SqlParameter("@ma_cong_viec", (object)nv.MaCongViec ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters, trans) > 0;
        }

        public bool XoaMemNhanVien(string maNV)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlNV = "UPDATE dbo.nhan_vien SET trang_thai_xoa = 1 WHERE ma_nhan_vien = @ma_nhan_vien";
                        SqlParameter[] pNV = new SqlParameter[]
                        {
                            new SqlParameter("@ma_nhan_vien", maNV)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlNV, pNV, trans);

                        string sqlTK = "UPDATE dbo.tai_khoan SET trang_thai_hoat_dong = 0 WHERE ma_nhan_vien = @ma_nhan_vien";
                        SqlParameter[] pTK = new SqlParameter[]
                        {
                            new SqlParameter("@ma_nhan_vien", maNV)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlTK, pTK, trans);

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

        public bool KhoiPhucNhanVien(string maNV)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlNV = "UPDATE dbo.nhan_vien SET trang_thai_xoa = 0 WHERE ma_nhan_vien = @ma_nhan_vien";
                        SqlParameter[] pNV = new SqlParameter[]
                        {
                            new SqlParameter("@ma_nhan_vien", maNV)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlNV, pNV, trans);

                        string sqlTK = "UPDATE dbo.tai_khoan SET trang_thai_hoat_dong = 1 WHERE ma_nhan_vien = @ma_nhan_vien";
                        SqlParameter[] pTK = new SqlParameter[]
                        {
                            new SqlParameter("@ma_nhan_vien", maNV)
                        };
                        DatabaseHelper.ExecuteNonQuery(sqlTK, pTK, trans);

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

        public bool KiemTraTonTaiTaiKhoan(string tenDangNhap)
        {
            string sql = "SELECT COUNT(1) FROM dbo.tai_khoan WHERE ten_dang_nhap = @ten_dang_nhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool KiemTraNhanVienCoTaiKhoan(string maNV)
        {
            string sql = "SELECT COUNT(1) FROM dbo.tai_khoan WHERE ma_nhan_vien = @ma_nhan_vien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public string LayTenDangNhapTheoMaNV(string maNV)
        {
            string sql = "SELECT ten_dang_nhap FROM dbo.tai_khoan WHERE ma_nhan_vien = @ma_nhan_vien";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", maNV)
            };
            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return result != null ? result.ToString() : string.Empty;
        }

        public bool ThemTaiKhoan(TaiKhoanDTO tk, SqlTransaction trans = null)
        {
            string sql = @"
INSERT INTO dbo.tai_khoan (ten_dang_nhap, mat_khau, quyen, trang_thai_hoat_dong, ma_nhan_vien)
VALUES (@ten_dang_nhap, @mat_khau, @quyen, @trang_thai_hoat_dong, @ma_nhan_vien)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tk.TenDangNhap),
                new SqlParameter("@mat_khau", tk.MatKhau),
                new SqlParameter("@quyen", tk.Quyen),
                new SqlParameter("@trang_thai_hoat_dong", tk.TrangThaiHoatDong),
                new SqlParameter("@ma_nhan_vien", tk.MaNhanVien)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters, trans) > 0;
        }

        public bool CapNhatQuyenVaTrangThaiTaiKhoan(string tenDangNhap, string quyen, bool hoatDong, SqlTransaction trans = null)
        {
            string sql = @"
UPDATE dbo.tai_khoan 
SET quyen = @quyen, 
    trang_thai_hoat_dong = @trang_thai_hoat_dong 
WHERE ten_dang_nhap = @ten_dang_nhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap),
                new SqlParameter("@quyen", quyen),
                new SqlParameter("@trang_thai_hoat_dong", hoatDong)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters, trans) > 0;
        }

        public bool DoiTrangThaiTaiKhoan(string tenDangNhap, bool hoatDong)
        {
            string sql = "UPDATE dbo.tai_khoan SET trang_thai_hoat_dong = @trang_thai_hoat_dong WHERE ten_dang_nhap = @ten_dang_nhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap),
                new SqlParameter("@trang_thai_hoat_dong", hoatDong)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool ResetMatKhau(string tenDangNhap, string matKhauBam)
        {
            string sql = "UPDATE dbo.tai_khoan SET mat_khau = @mat_khau WHERE ten_dang_nhap = @ten_dang_nhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap),
                new SqlParameter("@mat_khau", matKhauBam)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public DataTable LayThongTinDangNhap(string tenDangNhap)
        {
            string sql = @"
SELECT 
    tk.ten_dang_nhap,
    tk.mat_khau,
    tk.quyen,
    tk.trang_thai_hoat_dong,
    tk.ma_nhan_vien,
    nv.ten_nhan_vien,
    nv.trang_thai_xoa
FROM dbo.tai_khoan tk
INNER JOIN dbo.nhan_vien nv ON tk.ma_nhan_vien = nv.ma_nhan_vien
WHERE tk.ten_dang_nhap = @ten_dang_nhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_dang_nhap", tenDangNhap)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public string SinhMaNhanVienMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.nhan_vien", "ma_nhan_vien", "NV");
        }
    }
}
