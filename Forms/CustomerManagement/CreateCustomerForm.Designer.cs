namespace TourManagerment.Forms.CustomerManagement
{
    partial class CreateCustomerForm
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
            btnSave = new Button();
            label2 = new Label();
            lblPhone = new Label();
            lblName = new Label();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(262, 339);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Thêm";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 232);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 14;
            label2.Text = "Địa chỉ:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(262, 157);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 13;
            lblPhone.Text = "Số điện thoại:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(262, 82);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 20);
            lblName.TabIndex = 12;
            lblName.Text = "Họ và tên:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(262, 264);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(277, 27);
            txtAddress.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(262, 189);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(277, 27);
            txtPhone.TabIndex = 10;
            // 
            // txtName
            // 
            txtName.Location = new Point(262, 114);
            txtName.Name = "txtName";
            txtName.Size = new Size(277, 27);
            txtName.TabIndex = 9;
            // 
            // CreateCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(btnSave);
            Name = "CreateCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSave;
        private Label label2;
        private Label lblPhone;
        private Label lblName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtName;
    }
}