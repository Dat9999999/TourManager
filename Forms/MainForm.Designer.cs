﻿namespace TourManagerment
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnManageTour = new Button();
            lblRole = new Label();
            btnLogout = new Button();
            btnReport = new Button();
            SuspendLayout();
            // 
            // btnManageTour
            // 
            btnManageTour.Location = new Point(47, 70);
            btnManageTour.Name = "btnManageTour";
            btnManageTour.Size = new Size(185, 29);
            btnManageTour.TabIndex = 0;
            btnManageTour.Text = "Quản lý Tour du lịch";
            btnManageTour.UseVisualStyleBackColor = true;
            btnManageTour.Visible = false;
            btnManageTour.Click += btnShowTourForm_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(314, 79);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(0, 20);
            lblRole.TabIndex = 1;
            lblRole.Click += lblRole_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(47, 364);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(123, 48);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReport
            // 
            btnReport.Location = new Point(47, 329);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(94, 29);
            btnReport.TabIndex = 3;
            btnReport.Text = "Báo cáo ";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReport);
            Controls.Add(btnLogout);
            Controls.Add(lblRole);
            Controls.Add(btnManageTour);
            Name = "MainForm";
            Text = "Trang Chủ";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnManageTour;
        private Label lblRole;
        private Button btnLogout;
        private Button btnReport;
    }
}
