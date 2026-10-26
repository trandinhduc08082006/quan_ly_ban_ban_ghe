using System;
using System.Data;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class ThuocTinhBLL
    {
        private readonly ThuocTinhDAL dal;

        public ThuocTinhBLL()
        {
            dal = new ThuocTinhDAL();
        }

        public string SinhMaThuocTinhMoi(string tenBang)
        {
            if (string.IsNullOrWhiteSpace(tenBang))
            {
                throw new ArgumentException("Tên bảng danh mục không được để trống!");
            }
            return dal.SinhMaThuocTinhMoi(tenBang);
        }

        public DataTable LayDanhSach(string tenBang)
        {
            if (string.IsNullOrWhiteSpace(tenBang))
            {
                throw new ArgumentException("Tên bảng danh mục không được để trống!");
            }
            return dal.LayDanhSach(tenBang);
        }

        public bool Them(string tenBang, ThuocTinhDTO item)
        {
            KiemTraHopLe(tenBang, item);

            if (dal.KiemTraTonTai(tenBang, item.Ma))
            {
                throw new InvalidOperationException(string.Format("Mã '{0}' đã tồn tại trong danh mục!", item.Ma));
            }

            return dal.Them(tenBang, item);
        }

        public bool Sua(string tenBang, ThuocTinhDTO item)
        {
            KiemTraHopLe(tenBang, item);

            if (!dal.KiemTraTonTai(tenBang, item.Ma))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy mã '{0}' để cập nhật!", item.Ma));
            }

            return dal.Sua(tenBang, item);
        }

        public bool Xoa(string tenBang, string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
            {
                throw new ArgumentException("Mã thuộc tính cần xóa không được để trống!");
            }

            ma = ma.Trim();
            if (!dal.KiemTraTonTai(tenBang, ma))
            {
                throw new InvalidOperationException(string.Format("Không tìm thấy mã '{0}' để xóa!", ma));
            }

            return dal.Xoa(tenBang, ma);
        }

        private void KiemTraHopLe(string tenBang, ThuocTinhDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Dữ liệu thuộc tính không được rỗng!");
            }

            if (string.IsNullOrWhiteSpace(item.Ma))
            {
                throw new ArgumentException("Mã thuộc tính không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(item.Ten))
            {
                throw new ArgumentException("Tên thuộc tính không được để trống!");
            }

            string prefix = dal.LayPrefix(tenBang);
            item.Ma = item.Ma.Trim().ToUpper();
            string pattern = "^" + prefix + @"\d{4}$";
            if (!Regex.IsMatch(item.Ma, pattern))
            {
                throw new ArgumentException(string.Format("Mã {0} phải theo định dạng {1} kèm 4 chữ số (ví dụ: {1}0001)!", tenBang, prefix));
            }

            item.Ten = item.Ten.Trim();

            if (tenBang == "kich_thuoc")
            {
                if (string.IsNullOrWhiteSpace(item.MaLoai))
                {
                    throw new ArgumentException("Vui lòng chọn loại bàn ghế liên kết cho kích thước!");
                }
                item.MaLoai = item.MaLoai.Trim();
            }
        }
    }
}
