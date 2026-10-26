using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class HangHoaDAL
    {
        public DataTable LayTatCaHangHoa(bool chiLayDangHoatDong = true)
        {
            string sql = @"
SELECT 
    h.ma_hang, 
    h.ten_hang_hoa, 
    h.so_luong, 
    h.don_gia_nhap, 
    h.don_gia_ban, 
    h.thoi_gian_bao_hanh, 
    h.anh, 
    h.ghi_chu, 
    h.trang_thai_xoa,
    h.ma_loai, 
    l.ten_loai,
    h.ma_chat_lieu, 
    cl.ten_chat_lieu,
    h.ma_kich_thuoc, 
    kt.ten_kich_thuoc,
    h.ma_mau, 
    ms.ten_mau,
    h.ma_nuoc_san_xuat, 
    nsx.ten_nuoc_san_xuat,
    h.ma_hinh_dang, 
    hd.ten_hinh_dang,
    h.ma_nha_san_xuat, 
    nha_sx.ten_nha_san_xuat,
    h.ma_cong_dung, 
    cd.ten_cong_dung,
    h.ma_dac_diem, 
    dd.ten_dac_diem
FROM dbo.hang_hoa h
LEFT JOIN dbo.loai l ON h.ma_loai = l.ma_loai
LEFT JOIN dbo.chat_lieu cl ON h.ma_chat_lieu = cl.ma_chat_lieu
LEFT JOIN dbo.kich_thuoc kt ON h.ma_kich_thuoc = kt.ma_kich_thuoc
LEFT JOIN dbo.mau_sac ms ON h.ma_mau = ms.ma_mau
LEFT JOIN dbo.nuoc_san_xuat nsx ON h.ma_nuoc_san_xuat = nsx.ma_nuoc_san_xuat
LEFT JOIN dbo.hinh_dang hd ON h.ma_hinh_dang = hd.ma_hinh_dang
LEFT JOIN dbo.nha_san_xuat nha_sx ON h.ma_nha_san_xuat = nha_sx.ma_nha_san_xuat
LEFT JOIN dbo.cong_dung cd ON h.ma_cong_dung = cd.ma_cong_dung
LEFT JOIN dbo.dac_diem dd ON h.ma_dac_diem = dd.ma_dac_diem
WHERE h.trang_thai_xoa = @trang_thai_xoa
ORDER BY h.ma_hang;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@trang_thai_xoa", chiLayDangHoatDong ? 0 : 1)
            };
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTonTai(string maHang)
        {
            string sql = "SELECT COUNT(1) FROM dbo.hang_hoa WHERE ma_hang = @ma_hang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool ThemHangHoa(HangHoaDTO hh)
        {
            string sql = @"
INSERT INTO dbo.hang_hoa 
(ma_hang, ten_hang_hoa, so_luong, don_gia_ban, don_gia_nhap, thoi_gian_bao_hanh, anh, ghi_chu, trang_thai_xoa, 
 ma_loai, ma_mau, ma_cong_dung, ma_chat_lieu, ma_dac_diem, ma_hinh_dang, ma_kich_thuoc, ma_nha_san_xuat, ma_nuoc_san_xuat) 
VALUES 
(@ma_hang, @ten_hang_hoa, @so_luong, @don_gia_ban, @don_gia_nhap, @thoi_gian_bao_hanh, @anh, @ghi_chu, 0, 
 @ma_loai, @ma_mau, @ma_cong_dung, @ma_chat_lieu, @ma_dac_diem, @ma_hinh_dang, @ma_kich_thuoc, @ma_nha_san_xuat, @ma_nuoc_san_xuat)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", hh.MaHang),
                new SqlParameter("@ten_hang_hoa", hh.TenHangHoa),
                new SqlParameter("@so_luong", hh.SoLuong),
                new SqlParameter("@don_gia_ban", hh.DonGiaBan),
                new SqlParameter("@don_gia_nhap", hh.DonGiaNhap),
                new SqlParameter("@thoi_gian_bao_hanh", (object)hh.ThoiGianBaoHanh ?? DBNull.Value),
                new SqlParameter("@anh", (object)hh.Anh ?? DBNull.Value),
                new SqlParameter("@ghi_chu", (object)hh.GhiChu ?? DBNull.Value),
                new SqlParameter("@ma_loai", (object)hh.MaLoai ?? DBNull.Value),
                new SqlParameter("@ma_mau", (object)hh.MaMau ?? DBNull.Value),
                new SqlParameter("@ma_cong_dung", (object)hh.MaCongDung ?? DBNull.Value),
                new SqlParameter("@ma_chat_lieu", (object)hh.MaChatLieu ?? DBNull.Value),
                new SqlParameter("@ma_dac_diem", (object)hh.MaDacDiem ?? DBNull.Value),
                new SqlParameter("@ma_hinh_dang", (object)hh.MaHinhDang ?? DBNull.Value),
                new SqlParameter("@ma_kich_thuoc", (object)hh.MaKichThuoc ?? DBNull.Value),
                new SqlParameter("@ma_nha_san_xuat", (object)hh.MaNhaSanXuat ?? DBNull.Value),
                new SqlParameter("@ma_nuoc_san_xuat", (object)hh.MaNuocSanXuat ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhatHangHoa(HangHoaDTO hh)
        {
            string sql = @"
UPDATE dbo.hang_hoa 
SET ten_hang_hoa = @ten_hang_hoa, 
    don_gia_nhap = @don_gia_nhap, 
    don_gia_ban = @don_gia_ban, 
    thoi_gian_bao_hanh = @thoi_gian_bao_hanh, 
    anh = @anh, 
    ghi_chu = @ghi_chu, 
    ma_loai = @ma_loai, 
    ma_mau = @ma_mau, 
    ma_cong_dung = @ma_cong_dung, 
    ma_chat_lieu = @ma_chat_lieu, 
    ma_dac_diem = @ma_dac_diem, 
    ma_hinh_dang = @ma_hinh_dang, 
    ma_kich_thuoc = @ma_kich_thuoc, 
    ma_nha_san_xuat = @ma_nha_san_xuat, 
    ma_nuoc_san_xuat = @ma_nuoc_san_xuat 
WHERE ma_hang = @ma_hang";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", hh.MaHang),
                new SqlParameter("@ten_hang_hoa", hh.TenHangHoa),
                new SqlParameter("@don_gia_nhap", hh.DonGiaNhap),
                new SqlParameter("@don_gia_ban", hh.DonGiaBan),
                new SqlParameter("@thoi_gian_bao_hanh", (object)hh.ThoiGianBaoHanh ?? DBNull.Value),
                new SqlParameter("@anh", (object)hh.Anh ?? DBNull.Value),
                new SqlParameter("@ghi_chu", (object)hh.GhiChu ?? DBNull.Value),
                new SqlParameter("@ma_loai", (object)hh.MaLoai ?? DBNull.Value),
                new SqlParameter("@ma_mau", (object)hh.MaMau ?? DBNull.Value),
                new SqlParameter("@ma_cong_dung", (object)hh.MaCongDung ?? DBNull.Value),
                new SqlParameter("@ma_chat_lieu", (object)hh.MaChatLieu ?? DBNull.Value),
                new SqlParameter("@ma_dac_diem", (object)hh.MaDacDiem ?? DBNull.Value),
                new SqlParameter("@ma_hinh_dang", (object)hh.MaHinhDang ?? DBNull.Value),
                new SqlParameter("@ma_kich_thuoc", (object)hh.MaKichThuoc ?? DBNull.Value),
                new SqlParameter("@ma_nha_san_xuat", (object)hh.MaNhaSanXuat ?? DBNull.Value),
                new SqlParameter("@ma_nuoc_san_xuat", (object)hh.MaNuocSanXuat ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaMemHangHoa(string maHang)
        {
            string sql = "UPDATE dbo.hang_hoa SET trang_thai_xoa = 1 WHERE ma_hang = @ma_hang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool KhoiPhucHangHoa(string maHang)
        {
            string sql = "UPDATE dbo.hang_hoa SET trang_thai_xoa = 0 WHERE ma_hang = @ma_hang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhatTonKhoVaGia(string maHang, int soLuongThayDoi, decimal giaNhapMoi, SqlTransaction trans = null)
        {
            string sql;
            SqlParameter[] parameters;

            if (giaNhapMoi > 0)
            {
                decimal giaBanMoi = Math.Round((giaNhapMoi * 1.10m) / 10000m, MidpointRounding.AwayFromZero) * 10000m;
                sql = @"
UPDATE dbo.hang_hoa 
SET so_luong = so_luong + @so_luong, 
    don_gia_nhap = @don_gia_nhap, 
    don_gia_ban = @don_gia_ban 
WHERE ma_hang = @ma_hang";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma_hang", maHang),
                    new SqlParameter("@so_luong", soLuongThayDoi),
                    new SqlParameter("@don_gia_nhap", giaNhapMoi),
                    new SqlParameter("@don_gia_ban", giaBanMoi)
                };
            }
            else
            {
                sql = "UPDATE dbo.hang_hoa SET so_luong = so_luong + @so_luong WHERE ma_hang = @ma_hang";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma_hang", maHang),
                    new SqlParameter("@so_luong", soLuongThayDoi)
                };
            }

            return DatabaseHelper.ExecuteNonQuery(sql, parameters, trans) > 0;
        }

        public int LayTonKho(string maHang, SqlTransaction trans = null)
        {
            string sql = "SELECT so_luong FROM dbo.hang_hoa WHERE ma_hang = @ma_hang";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma_hang", maHang)
            };
            object val = DatabaseHelper.ExecuteScalar(sql, parameters, trans);
            if (val != null && int.TryParse(val.ToString(), out int tonKho))
            {
                return tonKho;
            }
            return 0;
        }

        public DataTable LayKichThuocTheoLoai(string maLoai)
        {
            string sql;
            SqlParameter[] parameters;

            if (string.IsNullOrWhiteSpace(maLoai))
            {
                sql = "SELECT ma_kich_thuoc AS Ma, ten_kich_thuoc AS Ten, ma_loai AS MaLoai FROM dbo.kich_thuoc ORDER BY ma_kich_thuoc";
                parameters = null;
            }
            else
            {
                sql = "SELECT ma_kich_thuoc AS Ma, ten_kich_thuoc AS Ten, ma_loai AS MaLoai FROM dbo.kich_thuoc WHERE ma_loai = @ma_loai ORDER BY ma_kich_thuoc";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma_loai", maLoai)
                };
            }

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public string SinhMaHangHoaMoi()
        {
            return DatabaseHelper.SinhMaTuDong("dbo.hang_hoa", "ma_hang", "HH");
        }
    }
}
