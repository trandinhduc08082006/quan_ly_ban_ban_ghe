using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanBanGhe.DAL
{
    public class TimKiemDAL
    {
        public DataTable TimKiemHangHoa(
            string tuKhoa,
            string maLoai,
            string maKichThuoc,
            string maHinhDang,
            string maChatLieu,
            string maNuocSX,
            string maMau,
            string maNhaSX,
            string maCongDung,
            string maDacDiem)
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
    l.ten_loai,
    kt.ten_kich_thuoc,
    hd.ten_hinh_dang,
    cl.ten_chat_lieu,
    nsx.ten_nuoc_san_xuat,
    m.ten_mau,
    nhasx.ten_nha_san_xuat,
    cd.ten_cong_dung,
    dd.ten_dac_diem
FROM dbo.hang_hoa h
LEFT JOIN dbo.loai l ON h.ma_loai = l.ma_loai
LEFT JOIN dbo.kich_thuoc kt ON h.ma_kich_thuoc = kt.ma_kich_thuoc
LEFT JOIN dbo.hinh_dang hd ON h.ma_hinh_dang = hd.ma_hinh_dang
LEFT JOIN dbo.chat_lieu cl ON h.ma_chat_lieu = cl.ma_chat_lieu
LEFT JOIN dbo.nuoc_san_xuat nsx ON h.ma_nuoc_san_xuat = nsx.ma_nuoc_san_xuat
LEFT JOIN dbo.mau_sac m ON h.ma_mau = m.ma_mau
LEFT JOIN dbo.nha_san_xuat nhasx ON h.ma_nha_san_xuat = nhasx.ma_nha_san_xuat
LEFT JOIN dbo.cong_dung cd ON h.ma_cong_dung = cd.ma_cong_dung
LEFT JOIN dbo.dac_diem dd ON h.ma_dac_diem = dd.ma_dac_diem
WHERE h.trang_thai_xoa = 0
  AND (@tu_khoa IS NULL OR @tu_khoa = '' OR h.ma_hang LIKE '%' + @tu_khoa + '%' OR h.ten_hang_hoa LIKE '%' + @tu_khoa + '%')
  AND (@ma_loai IS NULL OR @ma_loai = '' OR h.ma_loai = @ma_loai)
  AND (@ma_kich_thuoc IS NULL OR @ma_kich_thuoc = '' OR h.ma_kich_thuoc = @ma_kich_thuoc)
  AND (@ma_hinh_dang IS NULL OR @ma_hinh_dang = '' OR h.ma_hinh_dang = @ma_hinh_dang)
  AND (@ma_chat_lieu IS NULL OR @ma_chat_lieu = '' OR h.ma_chat_lieu = @ma_chat_lieu)
  AND (@ma_nuoc_san_xuat IS NULL OR @ma_nuoc_san_xuat = '' OR h.ma_nuoc_san_xuat = @ma_nuoc_san_xuat)
  AND (@ma_mau IS NULL OR @ma_mau = '' OR h.ma_mau = @ma_mau)
  AND (@ma_nha_san_xuat IS NULL OR @ma_nha_san_xuat = '' OR h.ma_nha_san_xuat = @ma_nha_san_xuat)
  AND (@ma_cong_dung IS NULL OR @ma_cong_dung = '' OR h.ma_cong_dung = @ma_cong_dung)
  AND (@ma_dac_diem IS NULL OR @ma_dac_diem = '' OR h.ma_dac_diem = @ma_dac_diem)
ORDER BY h.ma_hang ASC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_khoa", string.IsNullOrWhiteSpace(tuKhoa) ? (object)DBNull.Value : tuKhoa.Trim()),
                new SqlParameter("@ma_loai", string.IsNullOrWhiteSpace(maLoai) ? (object)DBNull.Value : maLoai.Trim()),
                new SqlParameter("@ma_kich_thuoc", string.IsNullOrWhiteSpace(maKichThuoc) ? (object)DBNull.Value : maKichThuoc.Trim()),
                new SqlParameter("@ma_hinh_dang", string.IsNullOrWhiteSpace(maHinhDang) ? (object)DBNull.Value : maHinhDang.Trim()),
                new SqlParameter("@ma_chat_lieu", string.IsNullOrWhiteSpace(maChatLieu) ? (object)DBNull.Value : maChatLieu.Trim()),
                new SqlParameter("@ma_nuoc_san_xuat", string.IsNullOrWhiteSpace(maNuocSX) ? (object)DBNull.Value : maNuocSX.Trim()),
                new SqlParameter("@ma_mau", string.IsNullOrWhiteSpace(maMau) ? (object)DBNull.Value : maMau.Trim()),
                new SqlParameter("@ma_nha_san_xuat", string.IsNullOrWhiteSpace(maNhaSX) ? (object)DBNull.Value : maNhaSX.Trim()),
                new SqlParameter("@ma_cong_dung", string.IsNullOrWhiteSpace(maCongDung) ? (object)DBNull.Value : maCongDung.Trim()),
                new SqlParameter("@ma_dac_diem", string.IsNullOrWhiteSpace(maDacDiem) ? (object)DBNull.Value : maDacDiem.Trim())
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public DataTable TimKiemHoaDonNhap(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maNCC)
        {
            string sql = @"
SELECT 
    hd.so_hoa_don_nhap, 
    hd.thoi_gian_nhap, 
    ncc.ten_nha_cung_cap, 
    nv.ten_nhan_vien, 
    hd.tong_tien, 
    hd.trang_thai_giao_dich
FROM dbo.hoa_don_nhap hd
INNER JOIN dbo.nha_cung_cap ncc ON hd.ma_nha_cung_cap = ncc.ma_nha_cung_cap
INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
WHERE CAST(hd.thoi_gian_nhap AS DATE) BETWEEN @tu_ngay AND @den_ngay
  AND (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
  AND (@ma_nha_cung_cap IS NULL OR @ma_nha_cung_cap = '' OR hd.ma_nha_cung_cap = @ma_nha_cung_cap)
ORDER BY hd.thoi_gian_nhap DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_ngay", SqlDbType.Date) { Value = tuNgay.Date },
                new SqlParameter("@den_ngay", SqlDbType.Date) { Value = denNgay.Date },
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNhanVien) ? (object)DBNull.Value : maNhanVien.Trim()),
                new SqlParameter("@ma_nha_cung_cap", string.IsNullOrWhiteSpace(maNCC) ? (object)DBNull.Value : maNCC.Trim())
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }
    
        public DataTable TimKiemHoaDonBan(DateTime tuNgay, DateTime denNgay, string maNhanVien, string maKhach)
        {
            string sql = @"
SELECT 
    hd.so_hoa_don_ban, 
    hd.thoi_gian_ban, 
    kh.ten_khach, 
    kh.dien_thoai,
    nv.ten_nhan_vien, 
    hd.tong_tien, 
    hd.trang_thai_giao_dich
FROM dbo.hoa_don_ban hd
INNER JOIN dbo.khach_hang kh ON hd.ma_khach = kh.ma_khach
INNER JOIN dbo.nhan_vien nv ON hd.ma_nhan_vien = nv.ma_nhan_vien
WHERE CAST(hd.thoi_gian_ban AS DATE) BETWEEN @tu_ngay AND @den_ngay
  AND (@ma_nhan_vien IS NULL OR @ma_nhan_vien = '' OR hd.ma_nhan_vien = @ma_nhan_vien)
  AND (@ma_khach IS NULL OR @ma_khach = '' OR hd.ma_khach = @ma_khach)
ORDER BY hd.thoi_gian_ban DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tu_ngay", SqlDbType.Date) { Value = tuNgay.Date },
                new SqlParameter("@den_ngay", SqlDbType.Date) { Value = denNgay.Date },
                new SqlParameter("@ma_nhan_vien", string.IsNullOrWhiteSpace(maNhanVien) ? (object)DBNull.Value : maNhanVien.Trim()),
                new SqlParameter("@ma_khach", string.IsNullOrWhiteSpace(maKhach) ? (object)DBNull.Value : maKhach.Trim())
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }
}
}
