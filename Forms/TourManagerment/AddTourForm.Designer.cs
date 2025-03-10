namespace TourManagerment.Forms.TourManagerment
{
    partial class AddTourForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbName = new TextBox();
            nudCost = new NumericUpDown();
            dtpStartDate = new DateTimePicker();
            cbType = new ComboBox();
            nudDuration = new NumericUpDown();
            cbTransportMethod = new ComboBox();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 46);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 94);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 1;
            label2.Text = "Giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 150);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 2;
            label3.Text = "Ngày khởi hành";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(163, 199);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 3;
            label4.Text = "Loại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(119, 253);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 4;
            label5.Text = "Thời lượng";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(119, 308);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 5;
            label6.Text = "Phương tiện";
            // 
            // tbName
            // 
            tbName.Location = new Point(242, 43);
            tbName.Name = "tbName";
            tbName.Size = new Size(424, 27);
            tbName.TabIndex = 6;
            // 
            // nudCost
            // 
            nudCost.Location = new Point(242, 92);
            nudCost.Name = "nudCost";
            nudCost.Size = new Size(424, 27);
            nudCost.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(242, 145);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(424, 27);
            dtpStartDate.TabIndex = 8;
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Items.AddRange(new object[] { "Cao cấp", "Tiêu chuẩn", "Tiết kiệm" });
            cbType.Location = new Point(242, 199);
            cbType.Name = "cbType";
            cbType.Size = new Size(424, 28);
            cbType.TabIndex = 9;
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(242, 253);
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(424, 27);
            nudDuration.TabIndex = 10;
            // 
            // cbTransportMethod
            // 
            cbTransportMethod.FormattingEnabled = true;
            cbTransportMethod.Items.AddRange(new object[] { "Xe", "Máy bay" });
            cbTransportMethod.Location = new Point(242, 305);
            cbTransportMethod.Name = "cbTransportMethod";
            cbTransportMethod.Size = new Size(424, 28);
            cbTransportMethod.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(346, 366);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // AddTourForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(cbTransportMethod);
            Controls.Add(nudDuration);
            Controls.Add(cbType);
            Controls.Add(dtpStartDate);
            Controls.Add(nudCost);
            Controls.Add(tbName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddTourForm";
            Text = "AddTourForm";
            Load += AddTourForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbName;
        private NumericUpDown nudCost;
        private DateTimePicker dtpStartDate;
        private ComboBox cbType;
        private NumericUpDown nudDuration;
        private ComboBox cbTransportMethod;
        private Button btnAdd;
    }
}