namespace TourManagerment.Forms.TourManagerment
{
    partial class EditTourForm
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
            btnAdd = new Button();
            cbTransportMethod = new ComboBox();
            nudDuration = new NumericUpDown();
            cbType = new ComboBox();
            dtpStartDate = new DateTimePicker();
            nudCost = new NumericUpDown();
            tbName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(369, 372);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 25;
            btnAdd.Text = "Sửa";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // cbTransportMethod
            // 
            cbTransportMethod.FormattingEnabled = true;
            cbTransportMethod.Location = new Point(265, 311);
            cbTransportMethod.Name = "cbTransportMethod";
            cbTransportMethod.Size = new Size(424, 28);
            cbTransportMethod.TabIndex = 24;
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(265, 259);
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(424, 27);
            nudDuration.TabIndex = 23;
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(265, 205);
            cbType.Name = "cbType";
            cbType.Size = new Size(424, 28);
            cbType.TabIndex = 22;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(265, 151);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(424, 27);
            dtpStartDate.TabIndex = 21;
            // 
            // nudCost
            // 
            nudCost.Location = new Point(265, 98);
            nudCost.Name = "nudCost";
            nudCost.Size = new Size(424, 27);
            nudCost.TabIndex = 20;
            // 
            // tbName
            // 
            tbName.Location = new Point(265, 49);
            tbName.Name = "tbName";
            tbName.Size = new Size(424, 27);
            tbName.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(142, 314);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 18;
            label6.Text = "Phương tiện";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(142, 259);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 17;
            label5.Text = "Thời lượng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(186, 205);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 16;
            label4.Text = "Loại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 156);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 15;
            label3.Text = "Ngày khởi hành";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 100);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 14;
            label2.Text = "Giá";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(173, 52);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 13;
            label1.Text = "Tên ";
            // 
            // EditTourForm
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
            Name = "EditTourForm";
            Text = "EditTourForm";
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private ComboBox cbTransportMethod;
        private NumericUpDown nudDuration;
        private ComboBox cbType;
        private DateTimePicker dtpStartDate;
        private NumericUpDown nudCost;
        private TextBox tbName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}