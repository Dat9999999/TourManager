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
            btnSearch = new Button();
            txtSearch = new TextBox();
            cbStatusFilter = new ComboBox();
            label1 = new Label();
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
            // btnSearch
            // 
            btnSearch.Location = new Point(348, 353);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(127, 355);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(215, 27);
            txtSearch.TabIndex = 4;
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Location = new Point(448, 353);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(151, 28);
            cbStatusFilter.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(448, 327);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 7;
            label1.Text = "Trạng thái:";
            // 
            // TourOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(cbStatusFilter);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnCreate);
            Controls.Add(dataGridViewTourOrders);
            Name = "TourOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TourOrderForm";
            Load += TourOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTourOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTourOrders;
        private Button btnCreate;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox cbStatusFilter;
        private Label label1;
    }
}