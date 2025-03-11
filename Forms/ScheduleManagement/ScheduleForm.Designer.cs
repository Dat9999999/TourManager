namespace TourManagerment.Forms.ScheduleManagement
{
    partial class ScheduleForm
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
            dataGridViewSchedules = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            cboTourStatus = new ComboBox();
            cboInvoiceInfo = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSchedules
            // 
            dataGridViewSchedules.AllowUserToOrderColumns = true;
            dataGridViewSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSchedules.Dock = DockStyle.Top;
            dataGridViewSchedules.Location = new Point(0, 0);
            dataGridViewSchedules.Name = "dataGridViewSchedules";
            dataGridViewSchedules.ReadOnly = true;
            dataGridViewSchedules.RowHeadersWidth = 51;
            dataGridViewSchedules.Size = new Size(800, 267);
            dataGridViewSchedules.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(233, 339);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 341);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(215, 27);
            txtSearch.TabIndex = 6;
            // 
            // cboTourStatus
            // 
            cboTourStatus.FormattingEnabled = true;
            cboTourStatus.Location = new Point(333, 339);
            cboTourStatus.Name = "cboTourStatus";
            cboTourStatus.Size = new Size(151, 28);
            cboTourStatus.TabIndex = 8;
            // 
            // cboInvoiceInfo
            // 
            cboInvoiceInfo.FormattingEnabled = true;
            cboInvoiceInfo.Location = new Point(490, 339);
            cboInvoiceInfo.Name = "cboInvoiceInfo";
            cboInvoiceInfo.Size = new Size(151, 28);
            cboInvoiceInfo.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 316);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 10;
            label1.Text = "Trạng thái";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(490, 316);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 11;
            label2.Text = "Thanh toán";
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboInvoiceInfo);
            Controls.Add(cboTourStatus);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridViewSchedules);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScheduleForm";
            Load += ScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewSchedules;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox cboTourStatus;
        private ComboBox cboInvoiceInfo;
        private Label label1;
        private Label label2;
    }
}