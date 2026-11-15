using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanBanGhe.DAL.Interfaces;
using QuanLyBanBanGhe.DTO;

namespace QuanLyBanBanGhe.DAL
{
    public class ThuocTinhDAL : BaseDAL, IThuocTinhDAL
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

        public DataTable LayDanhSach(string tenBang)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", tenBang)
            };
            return DatabaseHelper.ExecuteReaderSP("sp_ThuocTinh_LayDanhSach", parameters);
        }

        public bool KiemTraTonTai(string tenBang, string ma)
        {
            string maCol = GetMaColumn(tenBang);
            return base.KiemTraTonTai(tenBang, maCol, ma);
        }

        public bool KiemTraTrungTen(string tenBang, string ten, string maBoQua = null, string maLoai = null)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", tenBang),
                new SqlParameter("@ten", ten),
                new SqlParameter("@ma_bo_qua", (object)maBoQua ?? DBNull.Value),
                new SqlParameter("@ma_loai", (object)maLoai ?? DBNull.Value)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_ThuocTinh_KiemTraTrungTen", parameters)) > 0;
        }

        public bool KiemTraRangBuocKhoaNgoai(string tenBang, string ma)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", tenBang),
                new SqlParameter("@ma", ma)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalarSP("sp_ThuocTinh_KiemTraRangBuocKhoaNgoai", parameters)) > 0;
        }

        public bool Them(string tenBang, ThuocTinhDTO item)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", tenBang),
                new SqlParameter("@ma", item.Ma),
                new SqlParameter("@ten", item.Ten),
                new SqlParameter("@ma_loai", (object)item.MaLoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_ThuocTinh_Them", parameters) > 0;
        }

        public bool Sua(string tenBang, ThuocTinhDTO item)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", tenBang),
                new SqlParameter("@ma", item.Ma),
                new SqlParameter("@ten", item.Ten),
                new SqlParameter("@ma_loai", (object)item.MaLoai ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_ThuocTinh_Sua", parameters) > 0;
        }

        public bool Xoa(string tenBang, string ma)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten_bang", tenBang),
                new SqlParameter("@ma", ma)
            };
            return DatabaseHelper.ExecuteNonQuerySP("sp_ThuocTinh_Xoa", parameters) > 0;
        }

        public bool ThemThuocTinh(string tenBang, string ma, string ten, string maLoai = null)
        {
            return Them(tenBang, new ThuocTinhDTO { Ma = ma, Ten = ten, MaLoai = maLoai });
        }

        public bool SuaThuocTinh(string tenBang, string ma, string ten, string maLoai = null)
        {
            return Sua(tenBang, new ThuocTinhDTO { Ma = ma, Ten = ten, MaLoai = maLoai });
        }

        public bool XoaThuocTinh(string tenBang, string ma)
        {
            return Xoa(tenBang, ma);
        }
    }
}
