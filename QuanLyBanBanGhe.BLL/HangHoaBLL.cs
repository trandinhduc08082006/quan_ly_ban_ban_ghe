using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class HangHoaBLL
    {
        private readonly HangHoaDAL dal;
        private static readonly Regex MaHangRegex = new Regex(@"^HH\d{4}$");

        public HangHoaBLL()
        {
            dal = new HangHoaDAL();
        }

        public string SinhMaHangHoaMoi()
        {
            return dal.SinhMaHangHoaMoi();
        }

        public DataTable LayTatCaHangHoa(bool chiLayDangHoatDong = true)
        {
            return dal.LayTatCaHangHoa(chiLayDangHoatDong);
        }

        public bool KiemTraTonTai(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang))
            {
                return false;
            }
            return dal.KiemTraTonTai(maHang.Trim());
        }

        public bool ThemHangHoa(HangHoaDTO hh)
        {
            KiemTraHopLe(hh);

            if (dal.KiemTraTonTai(hh.MaHang))
            {
                throw new InvalidOperationException(string.Format("Mã sản phẩm '{0}' đã tồn tại trong hệ thống!", hh.MaHang));
            }

            hh.DonGiaBan = Math.Round((hh.DonGiaNhap * 1.10m) / 10000m, MidpointRounding.AwayFromZero) * 10000m;

            return dal.ThemHangHoa(hh);
        }

        public bool CapNhatHangHoa(HangHoaDTO hh)
        {
            KiemTraHopLe(hh);

            if (!dal.KiemTraTonTai(hh.MaHang))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy sản phẩm '{0}' để cập nhật!", hh.MaHang));
            }

            hh.DonGiaBan = Math.Round((hh.DonGiaNhap * 1.10m) / 10000m, MidpointRounding.AwayFromZero) * 10000m;

            return dal.CapNhatHangHoa(hh);
        }

        public bool XoaMemHangHoa(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang))
            {
                throw new ArgumentException("Mã sản phẩm cần xóa không được để trống!");
            }

            maHang = maHang.Trim();
            if (!dal.KiemTraTonTai(maHang))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy sản phẩm '{0}' để xóa!", maHang));
            }

            int tonKho = dal.LayTonKho(maHang);
            if (tonKho > 0)
            {
                throw new InvalidOperationException(string.Format("Không thể xóa sản phẩm '{0}' vì hiện tại vẫn còn tồn kho {1} cái. Vui lòng thanh lý hoặc xuất hết hàng trước khi xóa!", maHang, tonKho));
            }

            return dal.XoaMemHangHoa(maHang);
        }

        public bool KhoiPhucHangHoa(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang))
            {
                throw new ArgumentException("Mã sản phẩm cần khôi phục không được để trống!");
            }

            maHang = maHang.Trim();
            if (!dal.KiemTraTonTai(maHang))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy sản phẩm '{0}' để khôi phục!", maHang));
            }

            return dal.KhoiPhucHangHoa(maHang);
        }

        public int LayTonKho(string maHang, SqlTransaction trans = null)
        {
            if (string.IsNullOrWhiteSpace(maHang))
            {
                return 0;
            }
            return dal.LayTonKho(maHang.Trim(), trans);
        }

        public bool CapNhatTonKhoVaGia(string maHang, int soLuongThayDoi, decimal giaNhapMoi, SqlTransaction trans = null)
        {
            if (string.IsNullOrWhiteSpace(maHang))
            {
                throw new ArgumentException("Mã sản phẩm không được để trống!");
            }
            return dal.CapNhatTonKhoVaGia(maHang.Trim(), soLuongThayDoi, giaNhapMoi, trans);
        }

        public DataTable LayKichThuocTheoLoai(string maLoai)
        {
            return dal.LayKichThuocTheoLoai(maLoai);
        }

        private void KiemTraHopLe(HangHoaDTO hh)
        {
            if (hh == null)
            {
                throw new ArgumentNullException("Dữ liệu sản phẩm không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaHang))
            {
                throw new ArgumentException("Mã sản phẩm không được để trống!");
            }

            hh.MaHang = hh.MaHang.Trim().ToUpper();
            if (!MaHangRegex.IsMatch(hh.MaHang))
            {
                throw new ArgumentException("Mã sản phẩm phải theo định dạng HH kèm 4 chữ số (ví dụ: HH0001)!");
            }

            if (string.IsNullOrWhiteSpace(hh.TenHangHoa))
            {
                throw new ArgumentException("Tên sản phẩm không được để trống!");
            }

            if (hh.DonGiaNhap < 0)
            {
                throw new ArgumentException("Đơn giá nhập không được nhỏ hơn 0!");
            }

            if (hh.ThoiGianBaoHanh.HasValue && hh.ThoiGianBaoHanh.Value < 0)
            {
                throw new ArgumentException("Thời gian bảo hành không được nhỏ hơn 0!");
            }

            if (hh.SoLuong < 0)
            {
                throw new ArgumentException("Số lượng tồn kho không được âm!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaLoai))
            {
                throw new ArgumentException("Vui lòng chọn loại bàn ghế!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaKichThuoc))
            {
                throw new ArgumentException("Vui lòng chọn kích thước sản phẩm!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaChatLieu))
            {
                throw new ArgumentException("Vui lòng chọn chất liệu sản phẩm!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaMau))
            {
                throw new ArgumentException("Vui lòng chọn màu sắc sản phẩm!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaNuocSanXuat))
            {
                throw new ArgumentException("Vui lòng chọn nước sản xuất!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaHinhDang))
            {
                throw new ArgumentException("Vui lòng chọn hình dáng sản phẩm!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaNhaSanXuat))
            {
                throw new ArgumentException("Vui lòng chọn nhà sản xuất!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaCongDung))
            {
                throw new ArgumentException("Vui lòng chọn công dụng sản phẩm!");
            }

            if (string.IsNullOrWhiteSpace(hh.MaDacDiem))
            {
                throw new ArgumentException("Vui lòng chọn đặc điểm sản phẩm!");
            }

            hh.MaHang = hh.MaHang.Trim();
            hh.TenHangHoa = hh.TenHangHoa.Trim();
            hh.MaLoai = hh.MaLoai.Trim();
            hh.MaKichThuoc = hh.MaKichThuoc.Trim();
            hh.MaChatLieu = hh.MaChatLieu.Trim();
            hh.MaMau = hh.MaMau.Trim();
            hh.MaNuocSanXuat = hh.MaNuocSanXuat.Trim();
            hh.MaHinhDang = hh.MaHinhDang.Trim();
            hh.MaNhaSanXuat = hh.MaNhaSanXuat.Trim();
            hh.MaCongDung = hh.MaCongDung.Trim();
            hh.MaDacDiem = hh.MaDacDiem.Trim();
        }
    }
}
