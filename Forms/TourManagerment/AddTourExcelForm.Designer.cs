namespace TourManagerment.Forms.TourManagerment
{
    partial class AddTourExcelForm
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
            dgvTours = new DataGridView();
            btnSelectFile = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTours).BeginInit();
            SuspendLayout();
            // 
            // dgvTours
            // 
            dgvTours.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTours.Location = new Point(7, 12);
            dgvTours.Name = "dgvTours";
            dgvTours.ReadOnly = true;
            dgvTours.RowHeadersWidth = 51;
            dgvTours.Size = new Size(785, 377);
            dgvTours.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(694, 409);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(94, 29);
            btnSelectFile.TabIndex = 1;
            btnSelectFile.Text = "Chọn file";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += BtnSelectFile_Click;
            // 
            // btnAdd
            // 
            btnAdd.Enabled = false;
            btnAdd.Location = new Point(594, 409);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm vào";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // AddTourExcelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(btnSelectFile);
            Controls.Add(dgvTours);
            Name = "AddTourExcelForm";
            Text = "Nhập Tour Du Lịch Từ Excel";
            ((System.ComponentModel.ISupportInitialize)dgvTours).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTours;
        private Button btnSelectFile;
        private Button btnAdd;
    }
}