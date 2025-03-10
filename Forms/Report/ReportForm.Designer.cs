namespace TourManagerment.Forms.Report
{
    partial class ReportForm
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
            reportGrid = new DataGridView();
            reportTypeComboBox = new ComboBox();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            generateButton = new Button();
            totalOrdersLabel = new Label();
            tourTypeComboBox = new ComboBox();
            totalRevenueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)reportGrid).BeginInit();
            SuspendLayout();
            // 
            // reportGrid
            // 
            reportGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportGrid.Dock = DockStyle.Top;
            reportGrid.Location = new Point(0, 0);
            reportGrid.Name = "reportGrid";
            reportGrid.RowHeadersWidth = 51;
            reportGrid.Size = new Size(800, 275);
            reportGrid.TabIndex = 0;
            // 
            // reportTypeComboBox
            // 
            reportTypeComboBox.FormattingEnabled = true;
            reportTypeComboBox.Location = new Point(30, 316);
            reportTypeComboBox.Name = "reportTypeComboBox";
            reportTypeComboBox.Size = new Size(300, 28);
            reportTypeComboBox.TabIndex = 1;
            // 
            // startDatePicker
            // 
            startDatePicker.CalendarFont = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startDatePicker.Format = DateTimePickerFormat.Custom;
            startDatePicker.Location = new Point(30, 362);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(154, 27);
            startDatePicker.TabIndex = 2;
            // 
            // endDatePicker
            // 
            endDatePicker.Format = DateTimePickerFormat.Short;
            endDatePicker.Location = new Point(190, 362);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(140, 27);
            endDatePicker.TabIndex = 3;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(346, 315);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(94, 29);
            generateButton.TabIndex = 4;
            generateButton.Text = "Xem";
            generateButton.UseVisualStyleBackColor = true;
            // 
            // totalOrdersLabel
            // 
            totalOrdersLabel.AutoSize = true;
            totalOrdersLabel.Location = new Point(546, 290);
            totalOrdersLabel.Name = "totalOrdersLabel";
            totalOrdersLabel.Size = new Size(120, 20);
            totalOrdersLabel.TabIndex = 5;
            totalOrdersLabel.Text = "totalOrdersLabel";
            totalOrdersLabel.Visible = false;
            // 
            // tourTypeComboBox
            // 
            tourTypeComboBox.FormattingEnabled = true;
            tourTypeComboBox.Location = new Point(30, 399);
            tourTypeComboBox.Name = "tourTypeComboBox";
            tourTypeComboBox.Size = new Size(300, 28);
            tourTypeComboBox.TabIndex = 6;
            // 
            // totalRevenueLabel
            // 
            totalRevenueLabel.AutoSize = true;
            totalRevenueLabel.Location = new Point(546, 319);
            totalRevenueLabel.Name = "totalRevenueLabel";
            totalRevenueLabel.Size = new Size(132, 20);
            totalRevenueLabel.TabIndex = 7;
            totalRevenueLabel.Text = "totalRevenueLabel";
            totalRevenueLabel.Visible = false;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(totalRevenueLabel);
            Controls.Add(tourTypeComboBox);
            Controls.Add(totalOrdersLabel);
            Controls.Add(generateButton);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Controls.Add(reportTypeComboBox);
            Controls.Add(reportGrid);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)reportGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView reportGrid;
        private ComboBox reportTypeComboBox;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Button generateButton;
        private Label totalOrdersLabel;
        private ComboBox tourTypeComboBox;
        private Label totalRevenueLabel;
    }
}