namespace TourManagerment.Forms.ScheduleManagement
{
    partial class ViewTourScheduleForm
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
            txtCustomer = new Label();
            txtTour = new Label();
            txtTourStatus = new Label();
            txtTimeStatus = new Label();
            txtOrder = new Label();
            txtInvoice = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtCustomer
            // 
            txtCustomer.AutoSize = true;
            txtCustomer.Location = new Point(245, 115);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(89, 20);
            txtCustomer.TabIndex = 0;
            txtCustomer.Text = "txtCustomer";
            txtCustomer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTour
            // 
            txtTour.AutoSize = true;
            txtTour.Location = new Point(245, 155);
            txtTour.Name = "txtTour";
            txtTour.Size = new Size(55, 20);
            txtTour.TabIndex = 1;
            txtTour.Text = "txtTour";
            txtTour.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTourStatus
            // 
            txtTourStatus.AutoSize = true;
            txtTourStatus.Location = new Point(245, 195);
            txtTourStatus.Name = "txtTourStatus";
            txtTourStatus.Size = new Size(95, 20);
            txtTourStatus.TabIndex = 2;
            txtTourStatus.Text = "txtTourStatus";
            txtTourStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTimeStatus
            // 
            txtTimeStatus.AutoSize = true;
            txtTimeStatus.Location = new Point(245, 235);
            txtTimeStatus.Name = "txtTimeStatus";
            txtTimeStatus.Size = new Size(99, 20);
            txtTimeStatus.TabIndex = 3;
            txtTimeStatus.Text = "txtTimeStatus";
            txtTimeStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtOrder
            // 
            txtOrder.AutoSize = true;
            txtOrder.Location = new Point(245, 275);
            txtOrder.Name = "txtOrder";
            txtOrder.Size = new Size(64, 20);
            txtOrder.TabIndex = 4;
            txtOrder.Text = "txtOrder";
            txtOrder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtInvoice
            // 
            txtInvoice.AutoSize = true;
            txtInvoice.Location = new Point(245, 315);
            txtInvoice.Name = "txtInvoice";
            txtInvoice.Size = new Size(73, 20);
            txtInvoice.TabIndex = 5;
            txtInvoice.Text = "txtInvoice";
            txtInvoice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 115);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 6;
            label1.Text = "Thông tin khách hàng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 155);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 7;
            label2.Text = "Thông tin tour:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 195);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 8;
            label3.Text = "Trạng thái tour:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 235);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 9;
            label4.Text = "Thời gian:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(85, 275);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 10;
            label5.Text = "Thông tin đặt tour:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(85, 315);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 11;
            label6.Text = "Hóa đơn:";
            // 
            // ViewTourScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtInvoice);
            Controls.Add(txtOrder);
            Controls.Add(txtTimeStatus);
            Controls.Add(txtTourStatus);
            Controls.Add(txtTour);
            Controls.Add(txtCustomer);
            Name = "ViewTourScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewTourScheduleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtCustomer;
        private Label txtTour;
        private Label txtTourStatus;
        private Label txtTimeStatus;
        private Label txtOrder;
        private Label txtInvoice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}