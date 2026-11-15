namespace QuanLyBanBanGhe.GUI.Forms.BaoCao
{
    partial class frmReportViewer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.reportViewerControl = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            this.reportViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerControl.Location = new System.Drawing.Point(0, 0);
            this.reportViewerControl.Name = "reportViewerControl";
            this.reportViewerControl.ServerReport.BearerToken = null;
            this.reportViewerControl.Size = new System.Drawing.Size(1008, 729);
            this.reportViewerControl.TabIndex = 0;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.reportViewerControl);
            this.Name = "frmReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Báo Cáo - Microsoft ReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.ResumeLayout(false);
        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerControl;
    }
}
