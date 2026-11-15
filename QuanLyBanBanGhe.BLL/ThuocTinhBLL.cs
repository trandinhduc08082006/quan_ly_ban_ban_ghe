using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using QuanLyBanBanGhe.DAL;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.BLL
{
    public class ThuocTinhBLL
    {
        private readonly IThuocTinhDAL dal;

        public ThuocTinhBLL() : this(new ThuocTinhDAL())
        {
        }

        public ThuocTinhBLL(IThuocTinhDAL dal)
        {
            this.dal = dal;
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

            if (dal.KiemTraTrungTen(tenBang, item.Ten, null, item.MaLoai))
            {
                throw new InvalidOperationException(string.Format("Tên thuộc tính '{0}' đã tồn tại trong danh mục!", item.Ten));
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

            if (dal.KiemTraTrungTen(tenBang, item.Ten, item.Ma, item.MaLoai))
            {
                throw new InvalidOperationException(string.Format("Tên thuộc tính '{0}' đã tồn tại trong danh mục!", item.Ten));
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

            if (dal.KiemTraRangBuocKhoaNgoai(tenBang, ma))
            {
                if (tenBang == "loai")
                {
                    throw new InvalidOperationException("Không thể xóa loại bàn ghế này vì đang được sử dụng trong danh mục kích thước hoặc sản phẩm bàn ghế trong kho!");
                }
                throw new InvalidOperationException("Không thể xóa thuộc tính này vì đang được gắn với sản phẩm bàn ghế trong kho!");
            }

            try
            {
                return dal.Xoa(tenBang, ma);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException("Không thể xóa thuộc tính này vì đang có dữ liệu hàng hóa liên kết trong hệ thống!");
            }
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
