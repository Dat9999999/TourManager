namespace TourManagerment.Forms.Booking
{
    partial class TourOrderForm
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
            dataGridViewTourOrders = new DataGridView();
            btnCreate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTourOrders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTourOrders
            // 
            dataGridViewTourOrders.AllowUserToOrderColumns = true;
            dataGridViewTourOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTourOrders.Dock = DockStyle.Top;
            dataGridViewTourOrders.Location = new Point(0, 0);
            dataGridViewTourOrders.Name = "dataGridViewTourOrders";
            dataGridViewTourOrders.ReadOnly = true;
            dataGridViewTourOrders.RowHeadersWidth = 51;
            dataGridViewTourOrders.Size = new Size(800, 283);
            dataGridViewTourOrders.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 349);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(99, 39);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Thêm";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // TourOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreate);
            Controls.Add(dataGridViewTourOrders);
            Name = "TourOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TourOrderForm";
            Load += TourOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTourOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTourOrders;
        private Button btnCreate;
    }
}