using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyBanBanGhe.GUI.Forms.BaoCao;

namespace QuanLyBanBanGhe.GUI.Helpers
{
    public static class RdlcReportHelper
    {
        public static string TimDuongDanBaoCao(string tenFileRdlc)
        {
            string duongDan1 = Path.Combine(Application.StartupPath, "Reports", tenFileRdlc);
            if (File.Exists(duongDan1))
            {
                return duongDan1;
            }

            string duongDan2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", tenFileRdlc);
            if (File.Exists(duongDan2))
            {
                return duongDan2;
            }

            string duongDan3 = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Reports", tenFileRdlc));
            if (File.Exists(duongDan3))
            {
                return duongDan3;
            }

            return duongDan1;
        }

        public static void HienThiBaoCao(string tenFileRdlc, string tenDataSource, object duLieu, IEnumerable<ReportParameter> parameters = null, string tieuDeForm = "Xem Báo Cáo")
        {
            List<ReportDataSource> listDs = new List<ReportDataSource>();
            if (!string.IsNullOrWhiteSpace(tenDataSource) && duLieu != null)
            {
                listDs.Add(new ReportDataSource(tenDataSource, duLieu));
            }
            HienThiBaoCaoNhieuNguon(tenFileRdlc, listDs, parameters, tieuDeForm);
        }

        public static void HienThiBaoCaoNhieuNguon(string tenFileRdlc, IEnumerable<ReportDataSource> dataSources, IEnumerable<ReportParameter> parameters = null, string tieuDeForm = "Xem Báo Cáo")
        {
            string duongDanBaoCao = TimDuongDanBaoCao(tenFileRdlc);
            if (!File.Exists(duongDanBaoCao))
            {
                MessageBox.Show(
                    string.Format("Không tìm thấy tệp mẫu báo cáo:\n{0}", duongDanBaoCao),
                    "Lỗi nạp báo cáo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (frmReportViewer frm = new frmReportViewer(tieuDeForm))
            {
                try
                {
                    frm.Viewer.Reset();
                    frm.Viewer.LocalReport.ReportPath = duongDanBaoCao;
                    frm.Viewer.LocalReport.DataSources.Clear();

                    if (dataSources != null)
                    {
                        foreach (ReportDataSource rds in dataSources)
                        {
                            frm.Viewer.LocalReport.DataSources.Add(rds);
                        }
                    }

                    if (parameters != null)
                    {
                        frm.Viewer.LocalReport.SetParameters(parameters);
                    }

                    frm.Viewer.SetDisplayMode(DisplayMode.PrintLayout);
                    frm.Viewer.ZoomMode = ZoomMode.Percent;
                    frm.Viewer.ZoomPercent = 100;
                    frm.Viewer.RefreshReport();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Lỗi hiển thị báo cáo: {0}", ex.Message),
                        "Lỗi Báo Cáo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
