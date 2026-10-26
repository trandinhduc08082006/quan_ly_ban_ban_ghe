using System;

namespace QuanLyBanBanGhe.DTO
{
    public class PhieuBaoHanhDTO
    {
        public string MaPhieuBaoHanh { get; set; }
        public string SoHoaDonBan { get; set; }
        public string MaHang { get; set; }
        public string MaKhach { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public DateTime? NgayHenTra { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public string MoTaLoi { get; set; }
        public string BienPhapXuLy { get; set; }
        public decimal ChiPhi { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThaiXoa { get; set; }

        public string TenHangHoa { get; set; }
        public string TenKhach { get; set; }
        public string DienThoaiKhach { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? ThoiGianBan { get; set; }
        public int? ThoiGianBaoHanh { get; set; }
        public DateTime? HanBaoHanh { get; set; }
        public bool ConHanBaoHanh { get; set; }

        public PhieuBaoHanhDTO()
        {
            NgayTiepNhan = DateTime.Now;
            ChiPhi = 0;
            TrangThai = "TiepNhan";
            TrangThaiXoa = false;
        }
    }
}
