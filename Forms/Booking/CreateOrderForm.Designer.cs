namespace TourManagerment.Forms.Booking
{
    partial class CreateOrderForm
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
            label2 = new Label();
            lblPhone = new Label();
            lblName = new Label();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtName = new TextBox();
            lblTours = new Label();
            btnCreate = new Button();
            lblId = new Label();
            SuspendLayout();
            // 
            // comboBoxTours
            // 
            comboBoxTours.FormattingEnabled = true;
            comboBoxTours.Location = new Point(262, 73);
            comboBoxTours.Name = "comboBoxTours";
            comboBoxTours.Size = new Size(277, 28);
            comboBoxTours.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 271);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 20;
            label2.Text = "Địa chỉ:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(262, 129);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 19;
            lblPhone.Text = "Số điện thoại:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(262, 205);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 20);
            lblName.TabIndex = 18;
            lblName.Text = "Họ và tên:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(262, 303);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(277, 27);
            txtAddress.TabIndex = 17;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(262, 161);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(277, 27);
            txtPhone.TabIndex = 16;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(262, 237);
            txtName.Name = "txtName";
            txtName.Size = new Size(277, 27);
            txtName.TabIndex = 15;
            // 
            // lblTours
            // 
            lblTours.AutoSize = true;
            lblTours.Location = new Point(262, 44);
            lblTours.Name = "lblTours";
            lblTours.Size = new Size(77, 20);
            lblTours.TabIndex = 21;
            lblTours.Text = "Chọn tour:";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(262, 365);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 22;
            btnCreate.Text = "Thêm";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreateOrder_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(545, 164);
            lblId.Name = "lblId";
            lblId.Size = new Size(29, 20);
            lblId.TabIndex = 23;
            lblId.Text = "id: ";
            lblId.Visible = false;
            // 
            // CreateOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblId);
            Controls.Add(btnCreate);
            Controls.Add(lblTours);
            Controls.Add(label2);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(comboBoxTours);
            Name = "CreateOrderForm";
            Text = "CreateOrderForm";
            Load += CreateOrderForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTours;
        private Label label2;
        private Label lblPhone;
        private Label lblName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtName;
        private Label lblTours;
        private Button btnCreate;
        private Label lblId;
    }
}