namespace DataMovementAnalyzer
{
    partial class frmPreferencescs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferencescs));
            this.txtNumberOfPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPollingFrequency = new System.Windows.Forms.TextBox();
            this.chkRunCustomQuery = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNumberOfPoints
            // 
            this.txtNumberOfPoints.Location = new System.Drawing.Point(113, 12);
            this.txtNumberOfPoints.Name = "txtNumberOfPoints";
            this.txtNumberOfPoints.Size = new System.Drawing.Size(107, 20);
            this.txtNumberOfPoints.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Points:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(145, 87);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(19, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Polling Frequency:";
            // 
            // txtPollingFrequency
            // 
            this.txtPollingFrequency.Location = new System.Drawing.Point(113, 38);
            this.txtPollingFrequency.Name = "txtPollingFrequency";
            this.txtPollingFrequency.Size = new System.Drawing.Size(107, 20);
            this.txtPollingFrequency.TabIndex = 4;
            // 
            // chkRunCustomQuery
            // 
            this.chkRunCustomQuery.AutoSize = true;
            this.chkRunCustomQuery.Location = new System.Drawing.Point(64, 64);
            this.chkRunCustomQuery.Name = "chkRunCustomQuery";
            this.chkRunCustomQuery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRunCustomQuery.Size = new System.Drawing.Size(115, 17);
            this.chkRunCustomQuery.TabIndex = 6;
            this.chkRunCustomQuery.Text = "Run Custom Query";
            this.chkRunCustomQuery.UseVisualStyleBackColor = true;
            // 
            // frmPreferencescs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(234, 122);
            this.Controls.Add(this.chkRunCustomQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPollingFrequency);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumberOfPoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 100);
            this.Name = "frmPreferencescs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPreferencescs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumberOfPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPollingFrequency;
        private System.Windows.Forms.CheckBox chkRunCustomQuery;
    }
}