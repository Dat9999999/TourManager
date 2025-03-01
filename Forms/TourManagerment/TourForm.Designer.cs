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
            ((System.ComponentModel.ISupportInitialize)dgvTourList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 22);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 1;
            label1.Text = "Loại tour";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 67);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 2;
            label2.Text = "phương tiện";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(660, 49);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // cbTourType
            // 
            cbTourType.FormattingEnabled = true;
            cbTourType.Items.AddRange(new object[] { "Cao cấp", "Tiêu chuẩn", "Tiết kiệm" });
            cbTourType.Location = new Point(148, 21);
            cbTourType.Name = "cbTourType";
            cbTourType.Size = new Size(188, 28);
            cbTourType.TabIndex = 8;
            // 
            // cbVehicle
            // 
            cbVehicle.FormattingEnabled = true;
            cbVehicle.Items.AddRange(new object[] { "Xe máy", "Máy bay" });
            cbVehicle.Location = new Point(148, 66);
            cbVehicle.Name = "cbVehicle";
            cbVehicle.Size = new Size(188, 28);
            cbVehicle.TabIndex = 9;
            // 
            // rb1
            // 
            rb1.AutoSize = true;
            rb1.Location = new Point(361, 22);
            rb1.Name = "rb1";
            rb1.Size = new Size(99, 24);
            rb1.TabIndex = 10;
            rb1.TabStop = true;
            rb1.Text = "Dưới $200";
            rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            rb2.AutoSize = true;
            rb2.Location = new Point(361, 65);
            rb2.Name = "rb2";
            rb2.Size = new Size(100, 24);
            rb2.TabIndex = 11;
            rb2.TabStop = true;
            rb2.Text = "$400-$800";
            rb2.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            rb3.AutoSize = true;
            rb3.Location = new Point(504, 22);
            rb3.Name = "rb3";
            rb3.Size = new Size(100, 24);
            rb3.TabIndex = 12;
            rb3.TabStop = true;
            rb3.Text = "$200-$400";
            rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            rb4.AutoSize = true;
            rb4.Location = new Point(504, 63);
            rb4.Name = "rb4";
            rb4.Size = new Size(94, 24);
            rb4.TabIndex = 13;
            rb4.TabStop = true;
            rb4.Text = "Trên $800";
            rb4.UseVisualStyleBackColor = true;
            // 
            // dgvTourList
            // 
            dgvTourList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTourList.Location = new Point(74, 169);
            dgvTourList.Name = "dgvTourList";
            dgvTourList.RowHeadersWidth = 51;
            dgvTourList.Size = new Size(701, 225);
            dgvTourList.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 134);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 15;
            label3.Text = "Danh sách tour:";
            // 
            // TourForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 483);
            Controls.Add(label3);
            Controls.Add(dgvTourList);
            Controls.Add(rb4);
            Controls.Add(rb3);
            Controls.Add(rb2);
            Controls.Add(rb1);
            Controls.Add(cbVehicle);
            Controls.Add(cbTourType);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TourForm";
            Text = "TourForm";
            ((System.ComponentModel.ISupportInitialize)dgvTourList).EndInit();
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
    }
}