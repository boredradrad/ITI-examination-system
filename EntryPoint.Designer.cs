namespace Examination_GUI
{
    partial class EntryPoint
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
            this.label1 = new System.Windows.Forms.Label();
            this.StdBtn = new System.Windows.Forms.Button();
            this.InstBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the ITI examination system";
            // 
            // StdBtn
            // 
            this.StdBtn.BackColor = System.Drawing.Color.White;
            this.StdBtn.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StdBtn.Location = new System.Drawing.Point(343, 136);
            this.StdBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StdBtn.Name = "StdBtn";
            this.StdBtn.Size = new System.Drawing.Size(217, 66);
            this.StdBtn.TabIndex = 3;
            this.StdBtn.Text = "Student";
            this.StdBtn.UseVisualStyleBackColor = false;
            this.StdBtn.Click += new System.EventHandler(this.StdBtn_Click);
            // 
            // InstBtn
            // 
            this.InstBtn.BackColor = System.Drawing.Color.White;
            this.InstBtn.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstBtn.Location = new System.Drawing.Point(98, 213);
            this.InstBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InstBtn.Name = "InstBtn";
            this.InstBtn.Size = new System.Drawing.Size(217, 66);
            this.InstBtn.TabIndex = 2;
            this.InstBtn.Text = "Instructor/Admin";
            this.InstBtn.UseVisualStyleBackColor = false;
            this.InstBtn.Click += new System.EventHandler(this.InstBtn_Click);
            // 
            // EntryPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.StdBtn);
            this.Controls.Add(this.InstBtn);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EntryPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntryPoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StdBtn;
        private System.Windows.Forms.Button InstBtn;
    }
}