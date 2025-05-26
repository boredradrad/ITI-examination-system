namespace Examination_GUI
{
    partial class FrmRep6
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.textBoxCrsId = new System.Windows.Forms.TextBox();
            this.labelCrsId = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.labelStId = new System.Windows.Forms.Label();
            this.textBoxStId = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 432);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "🔙";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(4, 44);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ServerReport.ReportPath = "C:\\SQLProject\\Report6.rdl";
            this.reportViewer1.Size = new System.Drawing.Size(958, 388);
            this.reportViewer1.TabIndex = 0;
            // 
            // textBoxCrsId
            // 
            this.textBoxCrsId.Location = new System.Drawing.Point(392, 471);
            this.textBoxCrsId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCrsId.Name = "textBoxCrsId";
            this.textBoxCrsId.Size = new System.Drawing.Size(120, 22);
            this.textBoxCrsId.TabIndex = 13;
            // 
            // labelCrsId
            // 
            this.labelCrsId.AutoSize = true;
            this.labelCrsId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrsId.Location = new System.Drawing.Point(187, 471);
            this.labelCrsId.Name = "labelCrsId";
            this.labelCrsId.Size = new System.Drawing.Size(160, 25);
            this.labelCrsId.TabIndex = 12;
            this.labelCrsId.Text = "Enter CourseID";
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(652, 482);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(144, 53);
            this.btnEnter.TabIndex = 11;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // labelStId
            // 
            this.labelStId.AutoSize = true;
            this.labelStId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStId.Location = new System.Drawing.Point(187, 523);
            this.labelStId.Name = "labelStId";
            this.labelStId.Size = new System.Drawing.Size(165, 25);
            this.labelStId.TabIndex = 12;
            this.labelStId.Text = "Enter StudentID";
            // 
            // textBoxStId
            // 
            this.textBoxStId.Location = new System.Drawing.Point(392, 523);
            this.textBoxStId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxStId.Name = "textBoxStId";
            this.textBoxStId.Size = new System.Drawing.Size(120, 22);
            this.textBoxStId.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(392, 471);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 24);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Visible = false;
            // 
            // FrmRep6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 571);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxStId);
            this.Controls.Add(this.labelStId);
            this.Controls.Add(this.textBoxCrsId);
            this.Controls.Add(this.labelCrsId);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRep6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report6";
            this.Load += new System.EventHandler(this.FrmRep6_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCrsId;
        private System.Windows.Forms.Label labelCrsId;
        private System.Windows.Forms.Button btnEnter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label labelStId;
        private System.Windows.Forms.TextBox textBoxStId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}