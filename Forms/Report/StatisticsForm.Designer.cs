namespace TourManagerment.Forms.Report
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            pnlRight = new Panel();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnLoadChart = new Button();
            btnGenerateReport = new Button();
            CboReportType = new ComboBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Location = new Point(34, 23);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(503, 341);
            pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.Location = new Point(568, 23);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(425, 341);
            pnlRight.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(618, 397);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(184, 27);
            dtpStartDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(823, 394);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(170, 27);
            dtpEndDate.TabIndex = 3;
            // 
            // btnLoadChart
            // 
            btnLoadChart.Location = new Point(618, 431);
            btnLoadChart.Name = "btnLoadChart";
            btnLoadChart.Size = new Size(94, 29);
            btnLoadChart.TabIndex = 4;
            btnLoadChart.Text = "Xem";
            btnLoadChart.UseVisualStyleBackColor = true;
            btnLoadChart.Click += btnLoadChart_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(34, 442);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(94, 29);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "Xem";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += BtnGenerateReport_Click;
            // 
            // CboReportType
            // 
            CboReportType.FormattingEnabled = true;
            CboReportType.Location = new Point(34, 396);
            CboReportType.Name = "CboReportType";
            CboReportType.Size = new Size(188, 28);
            CboReportType.TabIndex = 8;
            CboReportType.SelectedIndexChanged += CboReportType_SelectedIndexChanged;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(246, 394);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(182, 27);
            dtpStart.TabIndex = 9;
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(246, 431);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(182, 27);
            dtpEnd.TabIndex = 10;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 483);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(CboReportType);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnLoadChart);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "StatisticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StatisticsForm";
            Load += StatisticsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Panel pnlRight;
        private DateTimePicker dtpEndDate;
        internal DateTimePicker dtpStartDate;
        private Button btnLoadChart;
        private Button btnGenerateReport;
        private ComboBox CboReportType;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
    }
}