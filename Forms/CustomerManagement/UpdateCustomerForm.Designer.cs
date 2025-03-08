namespace TourManagerment.Forms.CustomerManagement
{
    partial class UpdateCustomerForm
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
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnSave = new Button();
            lblName = new Label();
            lblPhone = new Label();
            label2 = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(262, 117);
            txtName.Name = "txtName";
            txtName.Size = new Size(277, 27);
            txtName.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(262, 198);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(277, 27);
            txtPhone.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(262, 279);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(277, 27);
            txtAddress.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(262, 337);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(262, 85);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Họ và tên:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(262, 166);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Số điện thoại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 246);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 8;
            label2.Text = "Địa chỉ:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(362, 337);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UpdateCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(label2);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Name = "UpdateCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateCustomerForm";
            Load += UpdateCustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnSave;
        private Label lblName;
        private Label lblPhone;
        private Label label2;
        private Button btnCancel;
    }
}