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
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewSchedules);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScheduleForm";
            Load += ScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSchedules;
    }
}