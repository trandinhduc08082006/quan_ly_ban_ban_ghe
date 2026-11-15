using System;
using System.Windows.Forms;

namespace QuanLyBanBanGhe.GUI.Helpers
{
    public enum FormMode
    {
        View,
        Selected,
        Insert,
        Update
    }

    public static class UIHelper
    {
        public static void SetButtonState(FormMode mode, Button btnThem, Button btnSua, Button btnXoa, Button btnLuu, Button btnBoQua)
        {
            switch (mode)
            {
                case FormMode.View:
                    if (btnThem != null) btnThem.Enabled = true;
                    if (btnSua != null) btnSua.Enabled = false;
                    if (btnXoa != null) btnXoa.Enabled = false;
                    if (btnLuu != null) btnLuu.Enabled = false;
                    if (btnBoQua != null) btnBoQua.Enabled = false;
                    break;
                case FormMode.Selected:
                    if (btnThem != null) btnThem.Enabled = false;
                    if (btnSua != null) btnSua.Enabled = true;
                    if (btnXoa != null) btnXoa.Enabled = true;
                    if (btnLuu != null) btnLuu.Enabled = false;
                    if (btnBoQua != null) btnBoQua.Enabled = true;
                    break;
                case FormMode.Insert:
                case FormMode.Update:
                    if (btnThem != null) btnThem.Enabled = false;
                    if (btnSua != null) btnSua.Enabled = false;
                    if (btnXoa != null) btnXoa.Enabled = false;
                    if (btnLuu != null) btnLuu.Enabled = true;
                    if (btnBoQua != null) btnBoQua.Enabled = true;
                    break;
            }
        }

        public static void FormatCurrencyColumns(DataGridView dgv, params string[] columnNames)
        {
            foreach (string colName in columnNames)
            {
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].DefaultCellStyle.Format = "N0";
                    dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        public static void FormatIntegerColumns(DataGridView dgv, params string[] columnNames)
        {
            foreach (string colName in columnNames)
            {
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].DefaultCellStyle.Format = "N0";
                    dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void FormatDateTimeColumns(DataGridView dgv, params string[] columnNames)
        {
            foreach (string colName in columnNames)
            {
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void FormatDateColumns(DataGridView dgv, params string[] columnNames)
        {
            foreach (string colName in columnNames)
            {
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void XoaChonLuoi(DataGridView dgv)
        {
            if (dgv == null)
            {
                return;
            }

            dgv.ClearSelection();
            dgv.CurrentCell = null;

            if (dgv.IsHandleCreated)
            {
                dgv.BeginInvoke((MethodInvoker)delegate
                {
                    dgv.ClearSelection();
                    dgv.CurrentCell = null;
                });
            }
        }

        public static void GanXoaChonTuDong(DataGridView dgv)
        {
            if (dgv == null)
            {
                return;
            }

            dgv.DataBindingComplete += (s, e) =>
            {
                XoaChonLuoi(dgv);
            };
        }

        public static void ChiChoPhepNhapSo(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void ChiChoPhepNhapMa(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        public static void KhongChoPhepKhoangTrang(KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static string DocSoThanhChu(decimal tongTien)
        {
            if (tongTien <= 0)
            {
                return "Không đồng";
            }

            decimal so = Math.Truncate(tongTien);
            string[] chuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] donVi = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ", "tỷ tỷ", "nghìn tỷ tỷ", "triệu tỷ tỷ", "tỷ tỷ tỷ" };

            string ketQua = "";
            int cap = 0;

            while (so > 0)
            {
                int baSo = (int)(so % 1000);
                so = Math.Truncate(so / 1000);
                if (baSo > 0)
                {
                    bool dayDu = so > 0;
                    string chuBaSo = DocNhomBaSo(baSo, dayDu, chuSo);
                    string tenDonVi = LayTenDonVi(cap, donVi);
                    ketQua = (chuBaSo + " " + tenDonVi).Trim() + " " + ketQua;
                }
                cap++;
            }

            ketQua = ketQua.Trim();
            if (ketQua.Length > 0)
            {
                ketQua = char.ToUpper(ketQua[0]) + ketQua.Substring(1) + " đồng";
            }

            return ketQua;
        }

        private static string LayTenDonVi(int cap, string[] donVi)
        {
            if (cap < donVi.Length)
            {
                return donVi[cap];
            }

            int soLanTy = cap / 3;
            int du = cap % 3;
            string[] coBan = { "", "nghìn", "triệu" };
            string res = coBan[du];
            for (int i = 0; i < soLanTy; i++)
            {
                res += " tỷ";
            }
            return res.Trim();
        }

        private static string DocNhomBaSo(int n, bool dayDu, string[] chuSo)
        {
            int tram = n / 100;
            int chuc = (n % 100) / 10;
            int donVi = n % 10;
            string res = "";

            if (tram > 0)
            {
                res += chuSo[tram] + " trăm";
                if (chuc == 0 && donVi > 0)
                {
                    res += " lẻ";
                }
            }
            else if (dayDu)
            {
                res += "không trăm";
                if (chuc == 0 && donVi > 0)
                {
                    res += " lẻ";
                }
            }

            if (chuc > 1)
            {
                res += (res.Length > 0 ? " " : "") + chuSo[chuc] + " mươi";
                if (donVi == 1)
                {
                    res += " mốt";
                }
                else if (donVi == 5)
                {
                    res += " lăm";
                }
                else if (donVi > 0)
                {
                    res += " " + chuSo[donVi];
                }
            }
            else if (chuc == 1)
            {
                res += (res.Length > 0 ? " " : "") + "mười";
                if (donVi == 5)
                {
                    res += " lăm";
                }
                else if (donVi > 0)
                {
                    res += " " + chuSo[donVi];
                }
            }
            else if (donVi > 0)
            {
                res += (res.Length > 0 ? " " : "") + chuSo[donVi];
            }

            return res.Trim();
        }
    }
}
