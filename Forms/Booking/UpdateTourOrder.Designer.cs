
namespace TourManagerment.Forms.Booking
{
    partial class UpdateTourOrder
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
            comboBoxTours = new ComboBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            comboBoxStatus = new ComboBox();
            button1 = new Button();
            lblId = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // comboBoxTours
            // 
            comboBoxTours.FormattingEnabled = true;
            comboBoxTours.Location = new Point(281, 64);
            comboBoxTours.Name = "comboBoxTours";
            comboBoxTours.Size = new Size(239, 28);
            comboBoxTours.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(281, 204);
            txtName.Name = "txtName";
            txtName.Size = new Size(239, 27);
            txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(281, 131);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(239, 27);
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(281, 276);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(239, 27);
            txtAddress.TabIndex = 3;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Pending", "Complete" });
            comboBoxStatus.Location = new Point(281, 348);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(239, 28);
            comboBoxStatus.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(281, 394);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(527, 134);
            lblId.Name = "lblId";
            lblId.Size = new Size(29, 20);
            lblId.TabIndex = 6;
            lblId.Text = "id: ";
            lblId.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 28);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 7;
            label1.Text = "Tour:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 102);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 8;
            label2.Text = "Số điện thoại:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(281, 173);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 9;
            label3.Text = "Họ và tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(281, 242);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 10;
            label4.Text = "Địa chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(281, 313);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 11;
            label5.Text = "Trạng thái:";
            // 
            // UpdateTourOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblId);
            Controls.Add(button1);
            Controls.Add(comboBoxStatus);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(comboBoxTours);
            Name = "UpdateTourOrder";
            Text = "UpdateTourOrder";
            Load += UpdateTourOrder_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ComboBox comboBoxTours;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private ComboBox comboBoxStatus;
        private Button button1;
        private Label lblId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}