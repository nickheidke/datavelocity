namespace DataMovementAnalyzer
{
    partial class DataVelocityVisualizer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataVelocityVisualizer));
            this.objTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.lblRPS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMinRPS = new System.Windows.Forms.Label();
            this.lblMinRowCount = new System.Windows.Forms.Label();
            this.lblMaxRPS = new System.Windows.Forms.Label();
            this.lblMaxRowCount = new System.Windows.Forms.Label();
            this.zgcTotalRows = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.obTabTotals = new System.Windows.Forms.TabPage();
            this.tableGraphs = new System.Windows.Forms.TableLayoutPanel();
            this.zgcRPS = new ZedGraph.ZedGraphControl();
            this.objTabTop10 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.zgcAllTables = new ZedGraph.ZedGraphControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvTableList = new System.Windows.Forms.DataGridView();
            this.objAnalysis = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRunEndTime = new System.Windows.Forms.TextBox();
            this.txtEstimatedCompletionTime = new System.Windows.Forms.TextBox();
            this.txtRunStartTime = new System.Windows.Forms.TextBox();
            this.txtEstimatedRunTimeLeft = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtAverageRPSNZ = new System.Windows.Forms.TextBox();
            this.txtAverageRPS = new System.Windows.Forms.TextBox();
            this.txtAverageRowCountNZ = new System.Windows.Forms.TextBox();
            this.txtAverageRowCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTotalRowsRemoved = new System.Windows.Forms.TextBox();
            this.txtTotalRowsAdded = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalRowsMoved = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.objTabQueryResults = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCustom = new System.Windows.Forms.DataGridView();
            this.objTabQuery = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveCustom = new System.Windows.Forms.Button();
            this.txtCustomQuery = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.obTabTotals.SuspendLayout();
            this.tableGraphs.SuspendLayout();
            this.objTabTop10.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).BeginInit();
            this.objAnalysis.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.objTabQueryResults.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustom)).BeginInit();
            this.objTabQuery.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // objTimer
            // 
            this.objTimer.Interval = 10000;
            this.objTimer.Tick += new System.EventHandler(this.objTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editConnectionToolStripMenuItem,
            this.mnuExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editConnectionToolStripMenuItem
            // 
            this.editConnectionToolStripMenuItem.Name = "editConnectionToolStripMenuItem";
            this.editConnectionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.editConnectionToolStripMenuItem.Text = "Edit Connection";
            this.editConnectionToolStripMenuItem.Click += new System.EventHandler(this.editConnectionToolStripMenuItem_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(159, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Enabled = false;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.Enabled = false;
            this.txtDBName.Location = new System.Drawing.Point(103, 19);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(150, 20);
            this.txtDBName.TabIndex = 2;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(10, 22);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(87, 13);
            this.lblDBName.TabIndex = 3;
            this.lblDBName.Text = "Database Name:";
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Location = new System.Drawing.Point(6, 21);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(100, 13);
            this.lblRowCount.TabIndex = 5;
            this.lblRowCount.Text = "Current Row Count:";
            // 
            // lblRPS
            // 
            this.lblRPS.AutoSize = true;
            this.lblRPS.Location = new System.Drawing.Point(6, 43);
            this.lblRPS.Name = "lblRPS";
            this.lblRPS.Size = new System.Drawing.Size(96, 13);
            this.lblRPS.TabIndex = 7;
            this.lblRPS.Text = "Current Rows/sec:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.lblDBName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 54);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMinRPS);
            this.groupBox2.Controls.Add(this.lblMinRowCount);
            this.groupBox2.Controls.Add(this.lblMaxRPS);
            this.groupBox2.Controls.Add(this.lblMaxRowCount);
            this.groupBox2.Controls.Add(this.lblRowCount);
            this.groupBox2.Controls.Add(this.lblRPS);
            this.groupBox2.Location = new System.Drawing.Point(267, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 62);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // lblMinRPS
            // 
            this.lblMinRPS.AutoSize = true;
            this.lblMinRPS.Location = new System.Drawing.Point(413, 43);
            this.lblMinRPS.Name = "lblMinRPS";
            this.lblMinRPS.Size = new System.Drawing.Size(79, 13);
            this.lblMinRPS.TabIndex = 14;
            this.lblMinRPS.Text = "Min Rows/sec:";
            // 
            // lblMinRowCount
            // 
            this.lblMinRowCount.AutoSize = true;
            this.lblMinRowCount.Location = new System.Drawing.Point(413, 21);
            this.lblMinRowCount.Name = "lblMinRowCount";
            this.lblMinRowCount.Size = new System.Drawing.Size(83, 13);
            this.lblMinRowCount.TabIndex = 13;
            this.lblMinRowCount.Text = "Min Row Count:";
            // 
            // lblMaxRPS
            // 
            this.lblMaxRPS.AutoSize = true;
            this.lblMaxRPS.Location = new System.Drawing.Point(218, 43);
            this.lblMaxRPS.Name = "lblMaxRPS";
            this.lblMaxRPS.Size = new System.Drawing.Size(82, 13);
            this.lblMaxRPS.TabIndex = 10;
            this.lblMaxRPS.Text = "Max Rows/sec:";
            // 
            // lblMaxRowCount
            // 
            this.lblMaxRowCount.AutoSize = true;
            this.lblMaxRowCount.Location = new System.Drawing.Point(218, 21);
            this.lblMaxRowCount.Name = "lblMaxRowCount";
            this.lblMaxRowCount.Size = new System.Drawing.Size(86, 13);
            this.lblMaxRowCount.TabIndex = 8;
            this.lblMaxRowCount.Text = "Max Row Count:";
            // 
            // zgcTotalRows
            // 
            this.zgcTotalRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcTotalRows.Location = new System.Drawing.Point(3, 3);
            this.zgcTotalRows.Name = "zgcTotalRows";
            this.zgcTotalRows.ScrollGrace = 0D;
            this.zgcTotalRows.ScrollMaxX = 0D;
            this.zgcTotalRows.ScrollMaxY = 0D;
            this.zgcTotalRows.ScrollMaxY2 = 0D;
            this.zgcTotalRows.ScrollMinX = 0D;
            this.zgcTotalRows.ScrollMinY = 0D;
            this.zgcTotalRows.ScrollMinY2 = 0D;
            this.zgcTotalRows.Size = new System.Drawing.Size(854, 239);
            this.zgcTotalRows.TabIndex = 10;
            this.zgcTotalRows.UseExtendedPrintDialog = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(880, 596);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tabControl2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl2, 2);
            this.tabControl2.Controls.Add(this.obTabTotals);
            this.tabControl2.Controls.Add(this.objTabTop10);
            this.tabControl2.Controls.Add(this.objAnalysis);
            this.tabControl2.Controls.Add(this.objTabQueryResults);
            this.tabControl2.Controls.Add(this.objTabQuery);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 71);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(874, 522);
            this.tabControl2.TabIndex = 13;
            // 
            // obTabTotals
            // 
            this.obTabTotals.Controls.Add(this.tableGraphs);
            this.obTabTotals.Location = new System.Drawing.Point(4, 22);
            this.obTabTotals.Name = "obTabTotals";
            this.obTabTotals.Padding = new System.Windows.Forms.Padding(3);
            this.obTabTotals.Size = new System.Drawing.Size(866, 496);
            this.obTabTotals.TabIndex = 0;
            this.obTabTotals.Text = "Totals Graphs";
            this.obTabTotals.UseVisualStyleBackColor = true;
            // 
            // tableGraphs
            // 
            this.tableGraphs.ColumnCount = 1;
            this.tableGraphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGraphs.Controls.Add(this.zgcRPS, 0, 1);
            this.tableGraphs.Controls.Add(this.zgcTotalRows, 0, 0);
            this.tableGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableGraphs.Location = new System.Drawing.Point(3, 3);
            this.tableGraphs.Name = "tableGraphs";
            this.tableGraphs.RowCount = 2;
            this.tableGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGraphs.Size = new System.Drawing.Size(860, 490);
            this.tableGraphs.TabIndex = 11;
            // 
            // zgcRPS
            // 
            this.zgcRPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcRPS.Location = new System.Drawing.Point(3, 248);
            this.zgcRPS.Name = "zgcRPS";
            this.zgcRPS.ScrollGrace = 0D;
            this.zgcRPS.ScrollMaxX = 0D;
            this.zgcRPS.ScrollMaxY = 0D;
            this.zgcRPS.ScrollMaxY2 = 0D;
            this.zgcRPS.ScrollMinX = 0D;
            this.zgcRPS.ScrollMinY = 0D;
            this.zgcRPS.ScrollMinY2 = 0D;
            this.zgcRPS.Size = new System.Drawing.Size(854, 239);
            this.zgcRPS.TabIndex = 11;
            this.zgcRPS.UseExtendedPrintDialog = true;
            // 
            // objTabTop10
            // 
            this.objTabTop10.Controls.Add(this.tableLayoutPanel3);
            this.objTabTop10.Location = new System.Drawing.Point(4, 22);
            this.objTabTop10.Name = "objTabTop10";
            this.objTabTop10.Padding = new System.Windows.Forms.Padding(3);
            this.objTabTop10.Size = new System.Drawing.Size(866, 496);
            this.objTabTop10.TabIndex = 1;
            this.objTabTop10.Text = "Extras";
            this.objTabTop10.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.75862F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.24138F));
            this.tableLayoutPanel3.Controls.Add(this.zgcAllTables, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(860, 490);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // zgcAllTables
            // 
            this.zgcAllTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgcAllTables.Location = new System.Drawing.Point(3, 3);
            this.zgcAllTables.Name = "zgcAllTables";
            this.zgcAllTables.ScrollGrace = 0D;
            this.zgcAllTables.ScrollMaxX = 0D;
            this.zgcAllTables.ScrollMaxY = 0D;
            this.zgcAllTables.ScrollMaxY2 = 0D;
            this.zgcAllTables.ScrollMinX = 0D;
            this.zgcAllTables.ScrollMinY = 0D;
            this.zgcAllTables.ScrollMinY2 = 0D;
            this.zgcAllTables.Size = new System.Drawing.Size(619, 484);
            this.zgcAllTables.TabIndex = 11;
            this.zgcAllTables.UseExtendedPrintDialog = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvTableList);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(628, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 484);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Table List";
            // 
            // dgvTableList
            // 
            this.dgvTableList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTableList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTableList.EnableHeadersVisualStyles = false;
            this.dgvTableList.Location = new System.Drawing.Point(3, 16);
            this.dgvTableList.Name = "dgvTableList";
            this.dgvTableList.RowHeadersVisible = false;
            this.dgvTableList.Size = new System.Drawing.Size(223, 465);
            this.dgvTableList.TabIndex = 2;
            // 
            // objAnalysis
            // 
            this.objAnalysis.Controls.Add(this.flowLayoutPanel1);
            this.objAnalysis.Location = new System.Drawing.Point(4, 22);
            this.objAnalysis.Name = "objAnalysis";
            this.objAnalysis.Size = new System.Drawing.Size(866, 496);
            this.objAnalysis.TabIndex = 5;
            this.objAnalysis.Text = "Analysis";
            this.objAnalysis.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox6);
            this.flowLayoutPanel1.Controls.Add(this.groupBox7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(866, 496);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRunEndTime);
            this.groupBox3.Controls.Add(this.txtEstimatedCompletionTime);
            this.groupBox3.Controls.Add(this.txtRunStartTime);
            this.groupBox3.Controls.Add(this.txtEstimatedRunTimeLeft);
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 168);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Timings";
            // 
            // txtRunEndTime
            // 
            this.txtRunEndTime.Location = new System.Drawing.Point(155, 100);
            this.txtRunEndTime.Name = "txtRunEndTime";
            this.txtRunEndTime.Size = new System.Drawing.Size(123, 20);
            this.txtRunEndTime.TabIndex = 8;
            // 
            // txtEstimatedCompletionTime
            // 
            this.txtEstimatedCompletionTime.Location = new System.Drawing.Point(155, 72);
            this.txtEstimatedCompletionTime.Name = "txtEstimatedCompletionTime";
            this.txtEstimatedCompletionTime.Size = new System.Drawing.Size(123, 20);
            this.txtEstimatedCompletionTime.TabIndex = 7;
            // 
            // txtRunStartTime
            // 
            this.txtRunStartTime.Location = new System.Drawing.Point(155, 16);
            this.txtRunStartTime.Name = "txtRunStartTime";
            this.txtRunStartTime.Size = new System.Drawing.Size(123, 20);
            this.txtRunStartTime.TabIndex = 6;
            // 
            // txtEstimatedRunTimeLeft
            // 
            this.txtEstimatedRunTimeLeft.Location = new System.Drawing.Point(155, 44);
            this.txtEstimatedRunTimeLeft.Name = "txtEstimatedRunTimeLeft";
            this.txtEstimatedRunTimeLeft.Size = new System.Drawing.Size(123, 20);
            this.txtEstimatedRunTimeLeft.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(150, 143);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Run Start Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Run End Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estimated Run Time Left:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estimated Completion Time: ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtAverageRPSNZ);
            this.groupBox6.Controls.Add(this.txtAverageRPS);
            this.groupBox6.Controls.Add(this.txtAverageRowCountNZ);
            this.groupBox6.Controls.Add(this.txtAverageRowCount);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Location = new System.Drawing.Point(293, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 168);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Averages";
            // 
            // txtAverageRPSNZ
            // 
            this.txtAverageRPSNZ.Location = new System.Drawing.Point(166, 100);
            this.txtAverageRPSNZ.Name = "txtAverageRPSNZ";
            this.txtAverageRPSNZ.Size = new System.Drawing.Size(100, 20);
            this.txtAverageRPSNZ.TabIndex = 7;
            // 
            // txtAverageRPS
            // 
            this.txtAverageRPS.Location = new System.Drawing.Point(166, 72);
            this.txtAverageRPS.Name = "txtAverageRPS";
            this.txtAverageRPS.Size = new System.Drawing.Size(100, 20);
            this.txtAverageRPS.TabIndex = 6;
            // 
            // txtAverageRowCountNZ
            // 
            this.txtAverageRowCountNZ.Location = new System.Drawing.Point(166, 44);
            this.txtAverageRowCountNZ.Name = "txtAverageRowCountNZ";
            this.txtAverageRowCountNZ.Size = new System.Drawing.Size(100, 20);
            this.txtAverageRowCountNZ.TabIndex = 5;
            // 
            // txtAverageRowCount
            // 
            this.txtAverageRowCount.Location = new System.Drawing.Point(166, 16);
            this.txtAverageRowCount.Name = "txtAverageRowCount";
            this.txtAverageRowCount.Size = new System.Drawing.Size(100, 20);
            this.txtAverageRowCount.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Average Row Count (nonzero):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Average Row Count:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Average RPS (nonzero):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Average RPS:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.txtTotalRowsRemoved);
            this.groupBox7.Controls.Add(this.txtTotalRowsAdded);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txtTotalRowsMoved);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(569, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(248, 168);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Totals";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(10, 96);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 66);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "*Note:\r\nThese figures are derived by seeing the difference in rows between each p" +
    "olling period. They do not represent the true number of inserts/deletes to the d" +
    "atabase.";
            // 
            // txtTotalRowsRemoved
            // 
            this.txtTotalRowsRemoved.Location = new System.Drawing.Point(129, 72);
            this.txtTotalRowsRemoved.Name = "txtTotalRowsRemoved";
            this.txtTotalRowsRemoved.Size = new System.Drawing.Size(113, 20);
            this.txtTotalRowsRemoved.TabIndex = 5;
            // 
            // txtTotalRowsAdded
            // 
            this.txtTotalRowsAdded.Location = new System.Drawing.Point(129, 44);
            this.txtTotalRowsAdded.Name = "txtTotalRowsAdded";
            this.txtTotalRowsAdded.Size = new System.Drawing.Size(113, 20);
            this.txtTotalRowsAdded.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Total Rows Removed*:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Total Rows Added*:";
            // 
            // txtTotalRowsMoved
            // 
            this.txtTotalRowsMoved.Location = new System.Drawing.Point(129, 16);
            this.txtTotalRowsMoved.Name = "txtTotalRowsMoved";
            this.txtTotalRowsMoved.Size = new System.Drawing.Size(113, 20);
            this.txtTotalRowsMoved.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Rows Moved*:";
            // 
            // objTabQueryResults
            // 
            this.objTabQueryResults.Controls.Add(this.groupBox4);
            this.objTabQueryResults.Location = new System.Drawing.Point(4, 22);
            this.objTabQueryResults.Name = "objTabQueryResults";
            this.objTabQueryResults.Size = new System.Drawing.Size(866, 496);
            this.objTabQueryResults.TabIndex = 4;
            this.objTabQueryResults.Text = "Custom Results";
            this.objTabQueryResults.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvCustom);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(866, 496);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Custom Query Results";
            // 
            // dgvCustom
            // 
            this.dgvCustom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustom.EnableHeadersVisualStyles = false;
            this.dgvCustom.Location = new System.Drawing.Point(3, 16);
            this.dgvCustom.Name = "dgvCustom";
            this.dgvCustom.Size = new System.Drawing.Size(860, 477);
            this.dgvCustom.TabIndex = 0;
            // 
            // objTabQuery
            // 
            this.objTabQuery.Controls.Add(this.tableLayoutPanel5);
            this.objTabQuery.Location = new System.Drawing.Point(4, 22);
            this.objTabQuery.Name = "objTabQuery";
            this.objTabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.objTabQuery.Size = new System.Drawing.Size(866, 496);
            this.objTabQuery.TabIndex = 3;
            this.objTabQuery.Text = "Custom Query";
            this.objTabQuery.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox3, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(860, 490);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(3, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(854, 33);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSaveCustom, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCustomQuery, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.5618F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.438202F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(854, 445);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnSaveCustom
            // 
            this.btnSaveCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCustom.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSaveCustom.Location = new System.Drawing.Point(771, 414);
            this.btnSaveCustom.Margin = new System.Windows.Forms.Padding(8);
            this.btnSaveCustom.Name = "btnSaveCustom";
            this.btnSaveCustom.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCustom.TabIndex = 1;
            this.btnSaveCustom.Text = "Save";
            this.btnSaveCustom.UseVisualStyleBackColor = true;
            this.btnSaveCustom.Click += new System.EventHandler(this.btnSaveCustom_Click);
            // 
            // txtCustomQuery
            // 
            this.txtCustomQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomQuery.Location = new System.Drawing.Point(3, 3);
            this.txtCustomQuery.Name = "txtCustomQuery";
            this.txtCustomQuery.Size = new System.Drawing.Size(848, 397);
            this.txtCustomQuery.TabIndex = 2;
            this.txtCustomQuery.Text = "";
            // 
            // DataVelocityVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(880, 620);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(888, 650);
            this.Name = "DataVelocityVisualizer";
            this.Text = "Data Velocity Visualizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.obTabTotals.ResumeLayout(false);
            this.tableGraphs.ResumeLayout(false);
            this.objTabTop10.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).EndInit();
            this.objAnalysis.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.objTabQueryResults.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustom)).EndInit();
            this.objTabQuery.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer objTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Label lblRPS;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMaxRPS;
        private System.Windows.Forms.Label lblMaxRowCount;
        private System.Windows.Forms.ToolStripMenuItem editConnectionToolStripMenuItem;
        private ZedGraph.ZedGraphControl zgcTotalRows;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblMinRPS;
        private System.Windows.Forms.Label lblMinRowCount;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage obTabTotals;
        private System.Windows.Forms.TabPage objTabTop10;
        private System.Windows.Forms.TableLayoutPanel tableGraphs;
        private ZedGraph.ZedGraphControl zgcRPS;
        private ZedGraph.ZedGraphControl zgcAllTables;
        private System.Windows.Forms.TabPage objTabQuery;
        private System.Windows.Forms.TabPage objTabQueryResults;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvCustom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvTableList;
        private System.Windows.Forms.TabPage objAnalysis;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRunEndTime;
        private System.Windows.Forms.TextBox txtEstimatedCompletionTime;
        private System.Windows.Forms.TextBox txtRunStartTime;
        private System.Windows.Forms.TextBox txtEstimatedRunTimeLeft;
        private System.Windows.Forms.TextBox txtAverageRPSNZ;
        private System.Windows.Forms.TextBox txtAverageRPS;
        private System.Windows.Forms.TextBox txtAverageRowCountNZ;
        private System.Windows.Forms.TextBox txtAverageRowCount;
        private System.Windows.Forms.TextBox txtTotalRowsMoved;
        private System.Windows.Forms.TextBox txtTotalRowsRemoved;
        private System.Windows.Forms.TextBox txtTotalRowsAdded;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSaveCustom;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox txtCustomQuery;
    }
}

