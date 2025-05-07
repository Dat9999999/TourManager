namespace TourManagerment.Forms
{
    partial class TourForm
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
            label1 = new Label();
            label2 = new Label();
            btnSearch = new Button();
            cbTourType = new ComboBox();
            cbVehicle = new ComboBox();
            rb1 = new RadioButton();
            rb2 = new RadioButton();
            rb3 = new RadioButton();
            rb4 = new RadioButton();
            dgvTourList = new DataGridView();
            label3 = new Label();
            btnAddTour = new Button();
            btnReload = new Button();
            grbBudget = new GroupBox();
            btnAddFromExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTourList).BeginInit();
            grbBudget.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(395, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 1;
            label1.Text = "Loại tour";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 11);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 2;
            label2.Text = "phương tiện";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(681, 34);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbTourType
            // 
            cbTourType.FormattingEnabled = true;
            cbTourType.Items.AddRange(new object[] { "Cao cấp", "Tiêu chuẩn", "Tiết kiệm" });
            cbTourType.Location = new Point(395, 34);
            cbTourType.Name = "cbTourType";
            cbTourType.Size = new Size(270, 28);
            cbTourType.TabIndex = 8;
            // 
            // cbVehicle
            // 
            cbVehicle.FormattingEnabled = true;
            cbVehicle.Items.AddRange(new object[] { "Xe", "Máy bay", "Xe khách", "Tàu hỏa" });
            cbVehicle.Location = new Point(74, 34);
            cbVehicle.Name = "cbVehicle";
            cbVehicle.Size = new Size(293, 28);
            cbVehicle.TabIndex = 9;
            // 
            // rb1
            // 
            rb1.AutoSize = true;
            rb1.Location = new Point(16, 26);
            rb1.Name = "rb1";
            rb1.Size = new Size(109, 24);
            rb1.TabIndex = 10;
            rb1.TabStop = true;
            rb1.Text = "Dưới 1 triệu";
            rb1.UseVisualStyleBackColor = true;
            rb1.CheckedChanged += rb1_CheckedChanged;
            // 
            // rb2
            // 
            rb2.AutoSize = true;
            rb2.Location = new Point(16, 62);
            rb2.Name = "rb2";
            rb2.Size = new Size(142, 24);
            rb2.TabIndex = 11;
            rb2.TabStop = true;
            rb2.Text = "Từ 5 đến 10 triệu";
            rb2.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            rb3.AutoSize = true;
            rb3.Location = new Point(161, 26);
            rb3.Name = "rb3";
            rb3.Size = new Size(134, 24);
            rb3.TabIndex = 12;
            rb3.TabStop = true;
            rb3.Text = "Từ 1 đến 5 triệu";
            rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            rb4.AutoSize = true;
            rb4.Location = new Point(167, 64);
            rb4.Name = "rb4";
            rb4.Size = new Size(112, 24);
            rb4.TabIndex = 13;
            rb4.TabStop = true;
            rb4.Text = "Trên 10 triệu";
            rb4.UseVisualStyleBackColor = true;
            // 
            // dgvTourList
            // 
            dgvTourList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTourList.Location = new Point(74, 183);
            dgvTourList.Name = "dgvTourList";
            dgvTourList.RowHeadersWidth = 51;
            dgvTourList.Size = new Size(701, 225);
            dgvTourList.TabIndex = 14;
            dgvTourList.CellContentClick += dgvTourList_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 150);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 15;
            label3.Text = "Danh sách tour:";
            // 
            // btnAddTour
            // 
            btnAddTour.Location = new Point(681, 414);
            btnAddTour.Name = "btnAddTour";
            btnAddTour.Size = new Size(94, 29);
            btnAddTour.TabIndex = 16;
            btnAddTour.Text = "Thêm";
            btnAddTour.UseVisualStyleBackColor = true;
            btnAddTour.Click += btnAddTour_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(74, 414);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(111, 29);
            btnReload.TabIndex = 17;
            btnReload.Text = "Load lại form";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // grbBudget
            // 
            grbBudget.Controls.Add(rb1);
            grbBudget.Controls.Add(rb2);
            grbBudget.Controls.Add(rb3);
            grbBudget.Controls.Add(rb4);
            grbBudget.Location = new Point(395, 68);
            grbBudget.Name = "grbBudget";
            grbBudget.Size = new Size(302, 92);
            grbBudget.TabIndex = 18;
            grbBudget.TabStop = false;
            grbBudget.Text = "Ngân sách";
            // 
            // btnAddFromExcel
            // 
            btnAddFromExcel.Location = new Point(191, 414);
            btnAddFromExcel.Name = "btnAddFromExcel";
            btnAddFromExcel.Size = new Size(94, 29);
            btnAddFromExcel.TabIndex = 19;
            btnAddFromExcel.Text = "Thêm excel";
            btnAddFromExcel.UseVisualStyleBackColor = true;
            btnAddFromExcel.Click += btnAddFromExcel_Click;
            // 
            // TourForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 483);
            Controls.Add(btnAddFromExcel);
            Controls.Add(grbBudget);
            Controls.Add(btnReload);
            Controls.Add(btnAddTour);
            Controls.Add(label3);
            Controls.Add(dgvTourList);
            Controls.Add(cbVehicle);
            Controls.Add(cbTourType);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TourForm";
            Text = "TourForm";
            Load += TourForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTourList).EndInit();
            grbBudget.ResumeLayout(false);
            grbBudget.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Button btnSearch;
        private ComboBox cbTourType;
        private ComboBox cbVehicle;
        private RadioButton rb1;
        private RadioButton rb2;
        private RadioButton rb3;
        private RadioButton rb4;
        private DataGridView dgvTourList;
        private Label label3;
        private Button btnAddTour;
        private Button btnReload;
        private GroupBox grbBudget;
        private Button btnAddFromExcel;
    }
}