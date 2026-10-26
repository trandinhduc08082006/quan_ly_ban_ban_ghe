using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class ThuocTinhDAL
    {
        private string GetMaColumn(string tenBang)
        {
            switch (tenBang)
            {
                case "loai": return "ma_loai";
                case "kich_thuoc": return "ma_kich_thuoc";
                case "hinh_dang": return "ma_hinh_dang";
                case "chat_lieu": return "ma_chat_lieu";
                case "nuoc_san_xuat": return "ma_nuoc_san_xuat";
                case "mau_sac": return "ma_mau";
                case "nha_san_xuat": return "ma_nha_san_xuat";
                case "cong_dung": return "ma_cong_dung";
                case "dac_diem": return "ma_dac_diem";
                default: throw new ArgumentException("Bảng danh mục không hợp lệ: " + tenBang);
            }
        }

        public string LayPrefix(string tenBang)
        {
            switch (tenBang)
            {
                case "loai": return "L";
                case "kich_thuoc": return "KT";
                case "hinh_dang": return "HD";
                case "chat_lieu": return "CL";
                case "nuoc_san_xuat": return "NSX";
                case "mau_sac": return "MS";
                case "nha_san_xuat": return "CSX";
                case "cong_dung": return "CD";
                case "dac_diem": return "DD";
                default: throw new ArgumentException("Bảng danh mục không hợp lệ: " + tenBang);
            }
        }

        public string SinhMaThuocTinhMoi(string tenBang)
        {
            string maCol = GetMaColumn(tenBang);
            string prefix = LayPrefix(tenBang);
            return DatabaseHelper.SinhMaTuDong("dbo." + tenBang, maCol, prefix);
        }

        private string GetTenColumn(string tenBang)
        {
            switch (tenBang)
            {
                case "loai": return "ten_loai";
                case "kich_thuoc": return "ten_kich_thuoc";
                case "hinh_dang": return "ten_hinh_dang";
                case "chat_lieu": return "ten_chat_lieu";
                case "nuoc_san_xuat": return "ten_nuoc_san_xuat";
                case "mau_sac": return "ten_mau";
                case "nha_san_xuat": return "ten_nha_san_xuat";
                case "cong_dung": return "ten_cong_dung";
                case "dac_diem": return "ten_dac_diem";
                default: throw new ArgumentException("Bảng danh mục không hợp lệ: " + tenBang);
            }
        }

        public DataTable LayDanhSach(string tenBang)
        {
            string maCol = GetMaColumn(tenBang);
            string tenCol = GetTenColumn(tenBang);

            if (tenBang == "kich_thuoc")
            {
                string sql = "SELECT kt.ma_kich_thuoc AS Ma, kt.ten_kich_thuoc AS Ten, kt.ma_loai AS MaLoai FROM dbo.kich_thuoc kt ORDER BY kt.ma_kich_thuoc";
                return DatabaseHelper.ExecuteQuery(sql);
            }
            else
            {
                string sql = string.Format("SELECT {0} AS Ma, {1} AS Ten, NULL AS MaLoai FROM dbo.{2} ORDER BY {0}", maCol, tenCol, tenBang);
                return DatabaseHelper.ExecuteQuery(sql);
            }
        }

        public bool KiemTraTonTai(string tenBang, string ma)
        {
            string maCol = GetMaColumn(tenBang);
            string sql = string.Format("SELECT COUNT(1) FROM dbo.{0} WHERE {1} = @ma", tenBang, maCol);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma", ma)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sql, parameters));
            return count > 0;
        }

        public bool KiemTraRangBuocKhoaNgoai(string tenBang, string ma)
        {
            string maCol = GetMaColumn(tenBang);

            if (tenBang == "loai")
            {
                string sqlKichThuoc = "SELECT COUNT(1) FROM dbo.kich_thuoc WHERE ma_loai = @ma";
                SqlParameter[] pKT = new SqlParameter[] { new SqlParameter("@ma", ma) };
                int countKT = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKichThuoc, pKT));
                if (countKT > 0)
                {
                    return true;
                }
            }

            string sqlHangHoa = string.Format("SELECT COUNT(1) FROM dbo.hang_hoa WHERE {0} = @ma", maCol);
            SqlParameter[] pHangHoa = new SqlParameter[] { new SqlParameter("@ma", ma) };
            int countHangHoa = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlHangHoa, pHangHoa));
            return countHangHoa > 0;
        }

        public bool Them(string tenBang, ThuocTinhDTO item)
        {
            string maCol = GetMaColumn(tenBang);
            string tenCol = GetTenColumn(tenBang);

            if (tenBang == "kich_thuoc")
            {
                string sql = string.Format("INSERT INTO dbo.kich_thuoc ({0}, {1}, ma_loai) VALUES (@ma, @ten, @ma_loai)", maCol, tenCol);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", item.Ma),
                    new SqlParameter("@ten", item.Ten),
                    new SqlParameter("@ma_loai", (object)item.MaLoai ?? DBNull.Value)
                };
                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            else
            {
                string sql = string.Format("INSERT INTO dbo.{0} ({1}, {2}) VALUES (@ma, @ten)", tenBang, maCol, tenCol);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", item.Ma),
                    new SqlParameter("@ten", item.Ten)
                };
                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
        }

        public bool Sua(string tenBang, ThuocTinhDTO item)
        {
            string maCol = GetMaColumn(tenBang);
            string tenCol = GetTenColumn(tenBang);

            if (tenBang == "kich_thuoc")
            {
                string sql = string.Format("UPDATE dbo.kich_thuoc SET {0} = @ten, ma_loai = @ma_loai WHERE {1} = @ma", tenCol, maCol);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", item.Ma),
                    new SqlParameter("@ten", item.Ten),
                    new SqlParameter("@ma_loai", (object)item.MaLoai ?? DBNull.Value)
                };
                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            else
            {
                string sql = string.Format("UPDATE dbo.{0} SET {1} = @ten WHERE {2} = @ma", tenBang, tenCol, maCol);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", item.Ma),
                    new SqlParameter("@ten", item.Ten)
                };
                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
        }

        public bool Xoa(string tenBang, string ma)
        {
            if (tenBang == "loai")
            {
                string sqlKichThuoc = "SELECT COUNT(1) FROM dbo.kich_thuoc WHERE ma_loai = @ma";
                SqlParameter[] pKT = new SqlParameter[] { new SqlParameter("@ma", ma) };
                int countKT = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlKichThuoc, pKT));
                if (countKT > 0)
                {
                    throw new InvalidOperationException("Không thể xóa loại bàn ghế này vì đang được sử dụng trong danh mục kích thước!");
                }
            }

            string maCol = GetMaColumn(tenBang);
            string sqlHangHoa = string.Format("SELECT COUNT(1) FROM dbo.hang_hoa WHERE {0} = @ma", maCol);
            SqlParameter[] pHangHoa = new SqlParameter[] { new SqlParameter("@ma", ma) };
            int countHangHoa = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlHangHoa, pHangHoa));
            if (countHangHoa > 0)
            {
                throw new InvalidOperationException("Không thể xóa thuộc tính này vì đang được gắn với sản phẩm bàn ghế trong kho!");
            }

            string sql = string.Format("DELETE FROM dbo.{0} WHERE {1} = @ma", tenBang, maCol);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma", ma)
            };
            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
