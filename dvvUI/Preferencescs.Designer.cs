namespace DataMovementAnalyzer
{
    partial class Preferencescs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferencescs));
            this.txtNumberOfPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPollingFrequency = new System.Windows.Forms.TextBox();
            this.chkRunCustomQuery = new System.Windows.Forms.CheckBox();
            this.tabPrefs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Graphing = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbTopColumnsLog = new System.Windows.Forms.RadioButton();
            this.rdbTopColumnsLinear = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbRPSLog = new System.Windows.Forms.RadioButton();
            this.rdbRPSLinear = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTotalRowsLog = new System.Windows.Forms.RadioButton();
            this.rdbTotalRowsLinear = new System.Windows.Forms.RadioButton();
            this.chkTop5 = new System.Windows.Forms.CheckBox();
            this.tabPrefs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Graphing.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumberOfPoints
            // 
            this.txtNumberOfPoints.Location = new System.Drawing.Point(166, 3);
            this.txtNumberOfPoints.Name = "txtNumberOfPoints";
            this.txtNumberOfPoints.Size = new System.Drawing.Size(81, 20);
            this.txtNumberOfPoints.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Points: (e.g. 200):";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(198, 189);
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
            this.btnCancel.Location = new System.Drawing.Point(117, 189);
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
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Polling Frequency (secs):";
            // 
            // txtPollingFrequency
            // 
            this.txtPollingFrequency.Location = new System.Drawing.Point(166, 31);
            this.txtPollingFrequency.Name = "txtPollingFrequency";
            this.txtPollingFrequency.Size = new System.Drawing.Size(81, 20);
            this.txtPollingFrequency.TabIndex = 4;
            // 
            // chkRunCustomQuery
            // 
            this.chkRunCustomQuery.AutoSize = true;
            this.chkRunCustomQuery.Location = new System.Drawing.Point(61, 67);
            this.chkRunCustomQuery.Name = "chkRunCustomQuery";
            this.chkRunCustomQuery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRunCustomQuery.Size = new System.Drawing.Size(115, 17);
            this.chkRunCustomQuery.TabIndex = 6;
            this.chkRunCustomQuery.Text = "Run Custom Query";
            this.chkRunCustomQuery.UseVisualStyleBackColor = true;
            // 
            // tabPrefs
            // 
            this.tabPrefs.Controls.Add(this.tabPage1);
            this.tabPrefs.Controls.Add(this.Graphing);
            this.tabPrefs.Location = new System.Drawing.Point(12, 12);
            this.tabPrefs.Name = "tabPrefs";
            this.tabPrefs.SelectedIndex = 0;
            this.tabPrefs.Size = new System.Drawing.Size(261, 171);
            this.tabPrefs.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkTop5);
            this.tabPage1.Controls.Add(this.txtPollingFrequency);
            this.tabPage1.Controls.Add(this.chkRunCustomQuery);
            this.tabPage1.Controls.Add(this.txtNumberOfPoints);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(253, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Graphing
            // 
            this.Graphing.Controls.Add(this.groupBox3);
            this.Graphing.Controls.Add(this.groupBox2);
            this.Graphing.Controls.Add(this.groupBox1);
            this.Graphing.Location = new System.Drawing.Point(4, 22);
            this.Graphing.Name = "Graphing";
            this.Graphing.Padding = new System.Windows.Forms.Padding(3);
            this.Graphing.Size = new System.Drawing.Size(253, 145);
            this.Graphing.TabIndex = 1;
            this.Graphing.Text = "Graphing";
            this.Graphing.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbTopColumnsLog);
            this.groupBox3.Controls.Add(this.rdbTopColumnsLinear);
            this.groupBox3.Location = new System.Drawing.Point(6, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 40);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Top Columns Scale";
            // 
            // rdbTopColumnsLog
            // 
            this.rdbTopColumnsLog.AutoSize = true;
            this.rdbTopColumnsLog.Location = new System.Drawing.Point(156, 17);
            this.rdbTopColumnsLog.Name = "rdbTopColumnsLog";
            this.rdbTopColumnsLog.Size = new System.Drawing.Size(79, 17);
            this.rdbTopColumnsLog.TabIndex = 1;
            this.rdbTopColumnsLog.TabStop = true;
            this.rdbTopColumnsLog.Text = "Logarithmic";
            this.rdbTopColumnsLog.UseVisualStyleBackColor = true;
            // 
            // rdbTopColumnsLinear
            // 
            this.rdbTopColumnsLinear.AutoSize = true;
            this.rdbTopColumnsLinear.Location = new System.Drawing.Point(6, 17);
            this.rdbTopColumnsLinear.Name = "rdbTopColumnsLinear";
            this.rdbTopColumnsLinear.Size = new System.Drawing.Size(54, 17);
            this.rdbTopColumnsLinear.TabIndex = 0;
            this.rdbTopColumnsLinear.TabStop = true;
            this.rdbTopColumnsLinear.Text = "Linear";
            this.rdbTopColumnsLinear.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbRPSLog);
            this.groupBox2.Controls.Add(this.rdbRPSLinear);
            this.groupBox2.Location = new System.Drawing.Point(6, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 40);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RPS Scale";
            // 
            // rdbRPSLog
            // 
            this.rdbRPSLog.AutoSize = true;
            this.rdbRPSLog.Location = new System.Drawing.Point(156, 17);
            this.rdbRPSLog.Name = "rdbRPSLog";
            this.rdbRPSLog.Size = new System.Drawing.Size(79, 17);
            this.rdbRPSLog.TabIndex = 1;
            this.rdbRPSLog.TabStop = true;
            this.rdbRPSLog.Text = "Logarithmic";
            this.rdbRPSLog.UseVisualStyleBackColor = true;
            // 
            // rdbRPSLinear
            // 
            this.rdbRPSLinear.AutoSize = true;
            this.rdbRPSLinear.Location = new System.Drawing.Point(6, 17);
            this.rdbRPSLinear.Name = "rdbRPSLinear";
            this.rdbRPSLinear.Size = new System.Drawing.Size(54, 17);
            this.rdbRPSLinear.TabIndex = 0;
            this.rdbRPSLinear.TabStop = true;
            this.rdbRPSLinear.Text = "Linear";
            this.rdbRPSLinear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTotalRowsLog);
            this.groupBox1.Controls.Add(this.rdbTotalRowsLinear);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Rows Scale";
            // 
            // rdbTotalRowsLog
            // 
            this.rdbTotalRowsLog.AutoSize = true;
            this.rdbTotalRowsLog.Location = new System.Drawing.Point(156, 17);
            this.rdbTotalRowsLog.Name = "rdbTotalRowsLog";
            this.rdbTotalRowsLog.Size = new System.Drawing.Size(79, 17);
            this.rdbTotalRowsLog.TabIndex = 1;
            this.rdbTotalRowsLog.TabStop = true;
            this.rdbTotalRowsLog.Text = "Logarithmic";
            this.rdbTotalRowsLog.UseVisualStyleBackColor = true;
            // 
            // rdbTotalRowsLinear
            // 
            this.rdbTotalRowsLinear.AutoSize = true;
            this.rdbTotalRowsLinear.Location = new System.Drawing.Point(6, 17);
            this.rdbTotalRowsLinear.Name = "rdbTotalRowsLinear";
            this.rdbTotalRowsLinear.Size = new System.Drawing.Size(54, 17);
            this.rdbTotalRowsLinear.TabIndex = 0;
            this.rdbTotalRowsLinear.TabStop = true;
            this.rdbTotalRowsLinear.Text = "Linear";
            this.rdbTotalRowsLinear.UseVisualStyleBackColor = true;
            this.rdbTotalRowsLinear.CheckedChanged += new System.EventHandler(this.rdbTotalRowsLinear_CheckedChanged);
            // 
            // chkTop5
            // 
            this.chkTop5.AutoSize = true;
            this.chkTop5.Location = new System.Drawing.Point(53, 90);
            this.chkTop5.Name = "chkTop5";
            this.chkTop5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTop5.Size = new System.Drawing.Size(123, 17);
            this.chkTop5.TabIndex = 7;
            this.chkTop5.Text = "Show \'Top 5\' graphs";
            this.chkTop5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTop5.UseVisualStyleBackColor = true;
            // 
            // Preferencescs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(281, 219);
            this.ControlBox = false;
            this.Controls.Add(this.tabPrefs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 100);
            this.Name = "Preferencescs";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPreferencescs_Load);
            this.tabPrefs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Graphing.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumberOfPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPollingFrequency;
        private System.Windows.Forms.CheckBox chkRunCustomQuery;
        private System.Windows.Forms.TabControl tabPrefs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage Graphing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbTopColumnsLog;
        private System.Windows.Forms.RadioButton rdbTopColumnsLinear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbRPSLog;
        private System.Windows.Forms.RadioButton rdbRPSLinear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTotalRowsLog;
        private System.Windows.Forms.RadioButton rdbTotalRowsLinear;
        private System.Windows.Forms.CheckBox chkTop5;
    }
}