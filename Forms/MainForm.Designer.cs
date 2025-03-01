namespace TourManagerment
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
            btnShowTourForm = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnShowTourForm
            // 
            btnShowTourForm.Location = new Point(12, 166);
            btnShowTourForm.Name = "btnShowTourForm";
            btnShowTourForm.Size = new Size(185, 29);
            btnShowTourForm.TabIndex = 0;
            btnShowTourForm.Text = "Quản lý Tour du lịch";
            btnShowTourForm.UseVisualStyleBackColor = true;
            btnShowTourForm.Click += btnShowTourForm_Click;
            // 
            // button2
            // 
            button2.Location = new Point(360, 111);
            button2.Name = "button2";
            button2.Size = new Size(8, 8);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(btnShowTourForm);
            Name = "MainForm";
            Text = "Trang Chủ";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnShowTourForm;
        private Button button2;
    }
}
