﻿namespace TourManagerment.Forms.CustomerManagement
{
    partial class CustomerForm
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
            dataGridViewCustomers = new DataGridView();
            btnCreate = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            BtnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.AllowUserToOrderColumns = true;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Dock = DockStyle.Top;
            dataGridViewCustomers.Location = new Point(0, 0);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.RowHeadersWidth = 51;
            dataGridViewCustomers.Size = new Size(800, 278);
            dataGridViewCustomers.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(21, 322);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(118, 47);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Thêm";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(156, 332);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(215, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(377, 330);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // BtnExport
            // 
            BtnExport.Location = new Point(670, 322);
            BtnExport.Name = "BtnExport";
            BtnExport.Size = new Size(118, 47);
            BtnExport.TabIndex = 4;
            BtnExport.Text = "Xuất Excel";
            BtnExport.UseVisualStyleBackColor = true;
            BtnExport.Click += BtnExport_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnExport);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnCreate);
            Controls.Add(dataGridViewCustomers);
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCustomers;
        private Button btnCreate;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button BtnExport;
    }
}