namespace TourManagerment.Forms.Booking
{
    partial class ViewTourOrder
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
            lblOrderId = new Label();
            lblCreationDate = new Label();
            lblStatus = new Label();
            lblCustomerName = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblTourName = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            SuspendLayout();
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Location = new Point(275, 36);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(25, 20);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Id:";
            // 
            // lblCreationDate
            // 
            lblCreationDate.AutoSize = true;
            lblCreationDate.Location = new Point(275, 84);
            lblCreationDate.Name = "lblCreationDate";
            lblCreationDate.Size = new Size(73, 20);
            lblCreationDate.TabIndex = 1;
            lblCreationDate.Text = "Ngày tạo:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(275, 134);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng thái:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(275, 187);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(89, 20);
            lblCustomerName.TabIndex = 4;
            lblCustomerName.Text = "Khách hàng:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(275, 232);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Số điện thoại:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(275, 275);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(58, 20);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Địa chỉ:";
            // 
            // lblTourName
            // 
            lblTourName.AutoSize = true;
            lblTourName.Location = new Point(275, 321);
            lblTourName.Name = "lblTourName";
            lblTourName.Size = new Size(41, 20);
            lblTourName.TabIndex = 7;
            lblTourName.Text = "Tour:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(275, 361);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(102, 20);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(275, 395);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(103, 20);
            lblEndDate.TabIndex = 9;
            lblEndDate.Text = "Ngày kết thúc:";
            // 
            // ViewTourOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblTourName);
            Controls.Add(lblAddress);
            Controls.Add(lblPhone);
            Controls.Add(lblCustomerName);
            Controls.Add(lblStatus);
            Controls.Add(lblCreationDate);
            Controls.Add(lblOrderId);
            Name = "ViewTourOrder";
            Text = "ViewTourOrder";
            Load += ViewTourOrder_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderId;
        private Label lblCreationDate;
        private Label lblStatus;
        private Label lblCustomerName;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblTourName;
        private Label lblStartDate;
        private Label lblEndDate;
    }
}