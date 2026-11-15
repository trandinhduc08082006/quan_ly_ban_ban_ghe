using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanBanGhe.GUI.Forms.BaoCao
{
    public partial class frmReportViewer : Form
    {
        public ReportViewer Viewer
        {
            get { return reportViewerControl; }
        }

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(string tieuDeForm) : this()
        {
            if (!string.IsNullOrWhiteSpace(tieuDeForm))
            {
                this.Text = tieuDeForm;
            }
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            reportViewerControl.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewerControl.ZoomMode = ZoomMode.Percent;
            reportViewerControl.ZoomPercent = 100;
            reportViewerControl.RefreshReport();
        }
    }
}
