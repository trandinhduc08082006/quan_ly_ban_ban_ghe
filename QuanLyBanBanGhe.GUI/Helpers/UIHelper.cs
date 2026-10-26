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
    }
}
