using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanBanGhe.GUI.Helpers
{
    public static class ExcelExportHelper
    {
        private static object GetCellValue(DataGridViewRow row, string colName1, string colName2, int fallbackIndex)
        {
            if (row.DataGridView.Columns.Contains(colName1))
            {
                return row.Cells[colName1].Value;
            }
            if (row.DataGridView.Columns.Contains(colName2))
            {
                return row.Cells[colName2].Value;
            }
            if (fallbackIndex >= 0 && fallbackIndex < row.Cells.Count)
            {
                return row.Cells[fallbackIndex].Value;
            }
            return string.Empty;
        }

        public static void ExportToExcel(DataGridView dgv, string tieuDe)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = tieuDe.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Excel.Application app = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                Excel.Range range = null;

                try
                {
                    app = new Excel.Application();
                    app.Visible = false;
                    app.DisplayAlerts = false;

                    wb = app.Workbooks.Add(Type.Missing);
                    ws = (Excel.Worksheet)wb.ActiveSheet;
                    ws.Name = "BaoCao";

                    int visibleColCount = 0;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            visibleColCount++;
                        }
                    }

                    ws.Range[ws.Cells[1, 1], ws.Cells[1, visibleColCount]].Merge();
                    range = ws.Cells[1, 1];
                    range.Value2 = tieuDe.ToUpper();
                    range.Font.Size = 16;
                    range.Font.Bold = true;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ws.Range[ws.Cells[2, 1], ws.Cells[2, visibleColCount]].Merge();
                    range = ws.Cells[2, 1];
                    range.Value2 = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    range.Font.Size = 11;
                    range.Font.Italic = true;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    int colIndex = 1;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            ws.Cells[4, colIndex] = dgv.Columns[i].HeaderText;
                            colIndex++;
                        }
                    }

                    Excel.Range headerRange = ws.Range[ws.Cells[4, 1], ws.Cells[4, visibleColCount]];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    for (int r = 0; r < dgv.Rows.Count; r++)
                    {
                        colIndex = 1;
                        for (int c = 0; c < dgv.Columns.Count; c++)
                        {
                            if (dgv.Columns[c].Visible)
                            {
                                object val = dgv.Rows[r].Cells[c].Value;
                                ws.Cells[r + 5, colIndex] = val != null ? val.ToString() : string.Empty;
                                colIndex++;
                            }
                        }
                    }

                    Excel.Range dataRange = ws.Range[ws.Cells[4, 1], ws.Cells[dgv.Rows.Count + 4, visibleColCount]];
                    dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ws.Columns.AutoFit();

                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (ws != null)
                    {
                        Marshal.ReleaseComObject(ws);
                        ws = null;
                    }
                    if (wb != null)
                    {
                        wb.Close(false);
                        Marshal.ReleaseComObject(wb);
                        wb = null;
                    }
                    if (app != null)
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                        app = null;
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void InHoaDonBan(string soHDB, string ngayBan, string tenKhach, string dienThoai, string diaChi, string tenNhanVien, DataGridView dgvChiTiet, decimal tongTien)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "HoaDonBan_" + soHDB + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Excel.Application app = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                try
                {
                    app = new Excel.Application();
                    app.Visible = false;
                    app.DisplayAlerts = false;
                    wb = app.Workbooks.Add(Type.Missing);
                    ws = (Excel.Worksheet)wb.ActiveSheet;
                    ws.Name = "HoaDonBanHang";

                    ws.Range["A1", "F1"].Merge();
                    ws.Range["A1"].Value2 = "HÓA ĐƠN BÁN HÀNG BÀN GHẾ";
                    ws.Range["A1"].Font.Size = 16;
                    ws.Range["A1"].Font.Bold = true;
                    ws.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ws.Range["A3"].Value2 = "Số HĐ: " + soHDB;
                    ws.Range["D3"].Value2 = "Ngày bán: " + ngayBan;
                    ws.Range["A4"].Value2 = "Khách hàng: " + tenKhach;
                    ws.Range["D4"].Value2 = "Điện thoại: " + dienThoai;
                    ws.Range["A5"].Value2 = "Địa chỉ: " + diaChi;
                    ws.Range["D5"].Value2 = "Nhân viên: " + tenNhanVien;

                    string[] headers = new string[] { "STT", "Tên Hàng Hóa", "Số Lượng", "Đơn Giá", "Giảm Giá (%)", "Thành Tiền" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cells[7, i + 1] = headers[i];
                    }
                    Excel.Range headerRange = ws.Range["A7", "F7"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    int row = 8;
                    for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                    {
                        if (dgvChiTiet.Rows[i].IsNewRow) continue;
                        ws.Cells[row, 1] = i + 1;
                        ws.Cells[row, 2] = GetCellValue(dgvChiTiet.Rows[i], "ten_hang_hoa", "colTenHang", 1);
                        ws.Cells[row, 3] = GetCellValue(dgvChiTiet.Rows[i], "so_luong", "colSoLuong", 2);
                        ws.Cells[row, 4] = GetCellValue(dgvChiTiet.Rows[i], "don_gia", "colDonGia", 3);
                        ws.Cells[row, 5] = GetCellValue(dgvChiTiet.Rows[i], "giam_gia", "colGiamGia", 4);
                        ws.Cells[row, 6] = GetCellValue(dgvChiTiet.Rows[i], "thanh_tien", "colThanhTien", 5);
                        row++;
                    }

                    ws.Cells[row, 5] = "TỔNG CỘNG:";
                    ws.Cells[row, 5].Font.Bold = true;
                    ws.Cells[row, 6] = tongTien;
                    ws.Cells[row, 6].Font.Bold = true;

                    Excel.Range borderRange = ws.Range[ws.Cells[7, 1], ws.Cells[row, 6]];
                    borderRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ws.Columns.AutoFit();

                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất hóa đơn bán ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (ws != null)
                    {
                        Marshal.ReleaseComObject(ws);
                        ws = null;
                    }
                    if (wb != null)
                    {
                        wb.Close(false);
                        Marshal.ReleaseComObject(wb);
                        wb = null;
                    }
                    if (app != null)
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                        app = null;
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void InHoaDonNhap(string soHDN, string ngayNhap, string tenNCC, string dienThoai, string diaChi, string tenNhanVien, DataGridView dgvChiTiet, decimal tongTien)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "HoaDonNhap_" + soHDN + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Excel.Application app = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                try
                {
                    app = new Excel.Application();
                    app.Visible = false;
                    app.DisplayAlerts = false;
                    wb = app.Workbooks.Add(Type.Missing);
                    ws = (Excel.Worksheet)wb.ActiveSheet;
                    ws.Name = "HoaDonNhapHang";

                    ws.Range["A1", "F1"].Merge();
                    ws.Range["A1"].Value2 = "HÓA ĐƠN NHẬP HÀNG BÀN GHẾ";
                    ws.Range["A1"].Font.Size = 16;
                    ws.Range["A1"].Font.Bold = true;
                    ws.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ws.Range["A3"].Value2 = "Số HĐN: " + soHDN;
                    ws.Range["D3"].Value2 = "Ngày nhập: " + ngayNhap;
                    ws.Range["A4"].Value2 = "Nhà cung cấp: " + tenNCC;
                    ws.Range["D4"].Value2 = "Điện thoại: " + dienThoai;
                    ws.Range["A5"].Value2 = "Địa chỉ: " + diaChi;
                    ws.Range["D5"].Value2 = "Nhân viên nhận: " + tenNhanVien;

                    string[] headers = new string[] { "STT", "Tên Hàng Hóa", "Số Lượng", "Đơn Giá Nhập", "Giảm Giá (%)", "Thành Tiền" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cells[7, i + 1] = headers[i];
                    }
                    Excel.Range headerRange = ws.Range["A7", "F7"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    int row = 8;
                    for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                    {
                        if (dgvChiTiet.Rows[i].IsNewRow) continue;
                        ws.Cells[row, 1] = i + 1;
                        ws.Cells[row, 2] = GetCellValue(dgvChiTiet.Rows[i], "ten_hang_hoa", "colTenHang", 1);
                        ws.Cells[row, 3] = GetCellValue(dgvChiTiet.Rows[i], "so_luong", "colSoLuong", 2);
                        ws.Cells[row, 4] = GetCellValue(dgvChiTiet.Rows[i], "don_gia", "colDonGia", 3);
                        object giamGiaVal = GetCellValue(dgvChiTiet.Rows[i], "giam_gia", "colGiamGia", -1);
                        ws.Cells[row, 5] = giamGiaVal != null && !string.IsNullOrEmpty(giamGiaVal.ToString()) ? giamGiaVal : 0;
                        ws.Cells[row, 6] = GetCellValue(dgvChiTiet.Rows[i], "thanh_tien", "colThanhTien", 4);
                        row++;
                    }

                    ws.Cells[row, 5] = "TỔNG CỘNG:";
                    ws.Cells[row, 5].Font.Bold = true;
                    ws.Cells[row, 6] = tongTien;
                    ws.Cells[row, 6].Font.Bold = true;

                    Excel.Range borderRange = ws.Range[ws.Cells[7, 1], ws.Cells[row, 6]];
                    borderRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    ws.Columns.AutoFit();

                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất hóa đơn nhập ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (ws != null)
                    {
                        Marshal.ReleaseComObject(ws);
                        ws = null;
                    }
                    if (wb != null)
                    {
                        wb.Close(false);
                        Marshal.ReleaseComObject(wb);
                        wb = null;
                    }
                    if (app != null)
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                        app = null;
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public static void ExportBaoCao4ToExcel(DataGridView dgv1, DataGridView dgv2, int nam)
        {
            ExportBaoCao4ToExcel(dgv1, dgv2, nam.ToString());
        }

        public static void ExportBaoCao4ToExcel(DataGridView dgv1, DataGridView dgv2, string nam)
        {
            if (dgv1.Rows.Count == 0 && dgv2.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "BaoCao_NhanVien_DoanhSo_" + nam + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Excel.Application app = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                try
                {
                    app = new Excel.Application();
                    app.Visible = false;
                    app.DisplayAlerts = false;
                    wb = app.Workbooks.Add(Type.Missing);
                    ws = (Excel.Worksheet)wb.ActiveSheet;
                    ws.Name = "BaoCao4";

                    ws.Range["A1", "F1"].Merge();
                    ws.Range["A1"].Value2 = "BÁO CÁO NHÂN VIÊN DOANH SỐ THẤP TRONG NĂM " + nam;
                    ws.Range["A1"].Font.Size = 16;
                    ws.Range["A1"].Font.Bold = true;
                    ws.Range["A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    int currentRow = 3;

                    ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, 6]].Merge();
                    ws.Cells[currentRow, 1] = "1. DANH SÁCH TẤT CẢ NHÂN VIÊN CÓ DOANH SỐ = 0";
                    ws.Cells[currentRow, 1].Font.Bold = true;
                    ws.Cells[currentRow, 1].Font.Size = 13;
                    currentRow++;

                    int colIdx = 1;
                    for (int i = 0; i < dgv1.Columns.Count; i++)
                    {
                        if (dgv1.Columns[i].Visible)
                        {
                            ws.Cells[currentRow, colIdx] = dgv1.Columns[i].HeaderText;
                            colIdx++;
                        }
                    }
                    Excel.Range h1 = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, colIdx - 1]];
                    h1.Font.Bold = true;
                    h1.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    currentRow++;

                    int startR1 = currentRow;
                    for (int r = 0; r < dgv1.Rows.Count; r++)
                    {
                        if (dgv1.Rows[r].IsNewRow) continue;
                        colIdx = 1;
                        for (int c = 0; c < dgv1.Columns.Count; c++)
                        {
                            if (dgv1.Columns[c].Visible)
                            {
                                ws.Cells[currentRow, colIdx] = dgv1.Rows[r].Cells[c].Value;
                                colIdx++;
                            }
                        }
                        currentRow++;
                    }
                    if (currentRow > startR1)
                    {
                        Excel.Range b1 = ws.Range[ws.Cells[startR1 - 1, 1], ws.Cells[currentRow - 1, colIdx - 1]];
                        b1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }

                    currentRow += 2;

                    ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, 6]].Merge();
                    ws.Cells[currentRow, 1] = "2. TOP 10 NHÂN VIÊN CÓ DOANH SỐ THẤP NHẤT (> 0)";
                    ws.Cells[currentRow, 1].Font.Bold = true;
                    ws.Cells[currentRow, 1].Font.Size = 13;
                    currentRow++;

                    colIdx = 1;
                    for (int i = 0; i < dgv2.Columns.Count; i++)
                    {
                        if (dgv2.Columns[i].Visible)
                        {
                            ws.Cells[currentRow, colIdx] = dgv2.Columns[i].HeaderText;
                            colIdx++;
                        }
                    }
                    Excel.Range h2 = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, colIdx - 1]];
                    h2.Font.Bold = true;
                    h2.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    currentRow++;

                    int startR2 = currentRow;
                    for (int r = 0; r < dgv2.Rows.Count; r++)
                    {
                        if (dgv2.Rows[r].IsNewRow) continue;
                        colIdx = 1;
                        for (int c = 0; c < dgv2.Columns.Count; c++)
                        {
                            if (dgv2.Columns[c].Visible)
                            {
                                ws.Cells[currentRow, colIdx] = dgv2.Rows[r].Cells[c].Value;
                                colIdx++;
                            }
                        }
                        currentRow++;
                    }
                    if (currentRow > startR2)
                    {
                        Excel.Range b2 = ws.Range[ws.Cells[startR2 - 1, 1], ws.Cells[currentRow - 1, colIdx - 1]];
                        b2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }

                    ws.Columns.AutoFit();
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất file Excel Báo cáo 4 thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (ws != null)
                    {
                        Marshal.ReleaseComObject(ws);
                        ws = null;
                    }
                    if (wb != null)
                    {
                        wb.Close(false);
                        Marshal.ReleaseComObject(wb);
                        wb = null;
                    }
                    if (app != null)
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                        app = null;
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}
