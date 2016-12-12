namespace LogLauncher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tv_Logs = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_Logs = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openLogFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFolderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_hidearchiveLogs = new System.Windows.Forms.CheckBox();
            this.tb_remoteServer = new System.Windows.Forms.TextBox();
            this.b_scanLogs = new System.Windows.Forms.Button();
            this.cb_Monitor = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_openLogsMulti = new System.Windows.Forms.CheckBox();
            this.b_About = new System.Windows.Forms.Button();
            this.openLogFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b_debugWindow = new System.Windows.Forms.Button();
            this.dgv_Diagnostics = new System.Windows.Forms.DataGridView();
            this.c_dgvDiag_Diagnostics = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_refreshLogs = new System.Windows.Forms.Button();
            this.nup_Delay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_colourpickerStart = new System.Windows.Forms.PictureBox();
            this.pb_colourpickerEnd = new System.Windows.Forms.PictureBox();
            this.b_launchconfigcustomLocations = new System.Windows.Forms.Button();
            this.b_launchLogs = new System.Windows.Forms.Button();
            this.dgv_c_hiddenlogName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logsizeMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_lastWritten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diagnostics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colourpickerStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colourpickerEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // tv_Logs
            // 
            this.tv_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_Logs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tv_Logs.Location = new System.Drawing.Point(12, 12);
            this.tv_Logs.Name = "tv_Logs";
            this.tv_Logs.Size = new System.Drawing.Size(201, 370);
            this.tv_Logs.TabIndex = 0;
            this.tv_Logs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Logs_AfterSelect);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(851, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "ss_Output";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(418, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(418, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // dgv_Logs
            // 
            this.dgv_Logs.AllowUserToAddRows = false;
            this.dgv_Logs.AllowUserToDeleteRows = false;
            this.dgv_Logs.AllowUserToResizeRows = false;
            this.dgv_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Logs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgv_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Logs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_c_hiddenlogName,
            this.dgv_c_logName,
            this.dgv_c_Class,
            this.dgv_c_Type,
            this.dgv_c_logSize,
            this.dgv_c_logsizeMB,
            this.dgv_c_lastWritten,
            this.dgv_c_logPath});
            this.dgv_Logs.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_Logs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Logs.Location = new System.Drawing.Point(219, 12);
            this.dgv_Logs.Name = "dgv_Logs";
            this.dgv_Logs.ReadOnly = true;
            this.dgv_Logs.RowHeadersVisible = false;
            this.dgv_Logs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Logs.Size = new System.Drawing.Size(620, 564);
            this.dgv_Logs.StandardTab = true;
            this.dgv_Logs.TabIndex = 10;
            this.dgv_Logs.DoubleClick += new System.EventHandler(this.dgv_Logs_DoubleClick);
            this.dgv_Logs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Logs_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogFolderToolStripMenuItem1,
            this.openLogFolderToolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 48);
            this.contextMenuStrip1.Text = "Open log folder";
            // 
            // openLogFolderToolStripMenuItem1
            // 
            this.openLogFolderToolStripMenuItem1.Name = "openLogFolderToolStripMenuItem1";
            this.openLogFolderToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.openLogFolderToolStripMenuItem1.Text = "Open log folder";
            this.openLogFolderToolStripMenuItem1.Click += new System.EventHandler(this.openLogFolderToolStripMenuItem1_Click);
            // 
            // openLogFolderToolStripMenuItem2
            // 
            this.openLogFolderToolStripMenuItem2.Name = "openLogFolderToolStripMenuItem2";
            this.openLogFolderToolStripMenuItem2.Size = new System.Drawing.Size(168, 22);
            this.openLogFolderToolStripMenuItem2.Text = "Open Log or Logs";
            this.openLogFolderToolStripMenuItem2.Click += new System.EventHandler(this.openLogFolderToolStripMenuItem2_Click);
            // 
            // cb_hidearchiveLogs
            // 
            this.cb_hidearchiveLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_hidearchiveLogs.AutoSize = true;
            this.cb_hidearchiveLogs.Location = new System.Drawing.Point(6, 413);
            this.cb_hidearchiveLogs.Name = "cb_hidearchiveLogs";
            this.cb_hidearchiveLogs.Size = new System.Drawing.Size(113, 17);
            this.cb_hidearchiveLogs.TabIndex = 3;
            this.cb_hidearchiveLogs.Text = "Hide Archive Logs";
            this.cb_hidearchiveLogs.UseVisualStyleBackColor = true;
            this.cb_hidearchiveLogs.CheckedChanged += new System.EventHandler(this.cb_hidearchiveLogs_CheckedChanged);
            // 
            // tb_remoteServer
            // 
            this.tb_remoteServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_remoteServer.Location = new System.Drawing.Point(4, 470);
            this.tb_remoteServer.Name = "tb_remoteServer";
            this.tb_remoteServer.Size = new System.Drawing.Size(209, 20);
            this.tb_remoteServer.TabIndex = 5;
            // 
            // b_scanLogs
            // 
            this.b_scanLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_scanLogs.Location = new System.Drawing.Point(6, 495);
            this.b_scanLogs.Name = "b_scanLogs";
            this.b_scanLogs.Size = new System.Drawing.Size(96, 23);
            this.b_scanLogs.TabIndex = 6;
            this.b_scanLogs.Text = "Scan for Logs";
            this.b_scanLogs.UseVisualStyleBackColor = true;
            this.b_scanLogs.Click += new System.EventHandler(this.b_scanLogs_Click);
            // 
            // cb_Monitor
            // 
            this.cb_Monitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Monitor.AutoSize = true;
            this.cb_Monitor.Location = new System.Drawing.Point(6, 390);
            this.cb_Monitor.Name = "cb_Monitor";
            this.cb_Monitor.Size = new System.Drawing.Size(83, 17);
            this.cb_Monitor.TabIndex = 1;
            this.cb_Monitor.Text = "Monitor logs";
            this.cb_Monitor.UseVisualStyleBackColor = true;
            this.cb_Monitor.CheckedChanged += new System.EventHandler(this.cb_Monitor_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Device";
            // 
            // cb_openLogsMulti
            // 
            this.cb_openLogsMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_openLogsMulti.AutoSize = true;
            this.cb_openLogsMulti.Checked = true;
            this.cb_openLogsMulti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_openLogsMulti.Location = new System.Drawing.Point(6, 437);
            this.cb_openLogsMulti.Name = "cb_openLogsMulti";
            this.cb_openLogsMulti.Size = new System.Drawing.Size(191, 17);
            this.cb_openLogsMulti.TabIndex = 4;
            this.cb_openLogsMulti.Text = "Open multiple logs in one CMTrace";
            this.cb_openLogsMulti.UseVisualStyleBackColor = true;
            this.cb_openLogsMulti.CheckedChanged += new System.EventHandler(this.cb_openLogsMulti_CheckedChanged);
            // 
            // b_About
            // 
            this.b_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_About.Location = new System.Drawing.Point(6, 551);
            this.b_About.Name = "b_About";
            this.b_About.Size = new System.Drawing.Size(96, 23);
            this.b_About.TabIndex = 8;
            this.b_About.Text = "About";
            this.b_About.UseVisualStyleBackColor = true;
            this.b_About.Click += new System.EventHandler(this.b_About_Click);
            // 
            // openLogFolderToolStripMenuItem
            // 
            this.openLogFolderToolStripMenuItem.Name = "openLogFolderToolStripMenuItem";
            this.openLogFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openLogFolderToolStripMenuItem.Text = "Open Log folder";
            // 
            // b_debugWindow
            // 
            this.b_debugWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_debugWindow.Location = new System.Drawing.Point(6, 524);
            this.b_debugWindow.Name = "b_debugWindow";
            this.b_debugWindow.Size = new System.Drawing.Size(96, 23);
            this.b_debugWindow.TabIndex = 9;
            this.b_debugWindow.Text = "Debug Window";
            this.b_debugWindow.UseVisualStyleBackColor = true;
            this.b_debugWindow.Click += new System.EventHandler(this.b_debugWindow_Click);
            // 
            // dgv_Diagnostics
            // 
            this.dgv_Diagnostics.AllowUserToAddRows = false;
            this.dgv_Diagnostics.AllowUserToDeleteRows = false;
            this.dgv_Diagnostics.AllowUserToOrderColumns = true;
            this.dgv_Diagnostics.AllowUserToResizeColumns = false;
            this.dgv_Diagnostics.AllowUserToResizeRows = false;
            this.dgv_Diagnostics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Diagnostics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Diagnostics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_dgvDiag_Diagnostics});
            this.dgv_Diagnostics.Location = new System.Drawing.Point(219, 12);
            this.dgv_Diagnostics.Name = "dgv_Diagnostics";
            this.dgv_Diagnostics.ReadOnly = true;
            this.dgv_Diagnostics.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Diagnostics.RowHeadersVisible = false;
            this.dgv_Diagnostics.ShowEditingIcon = false;
            this.dgv_Diagnostics.Size = new System.Drawing.Size(620, 564);
            this.dgv_Diagnostics.TabIndex = 11;
            this.dgv_Diagnostics.TabStop = false;
            this.dgv_Diagnostics.Visible = false;
            // 
            // c_dgvDiag_Diagnostics
            // 
            this.c_dgvDiag_Diagnostics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_dgvDiag_Diagnostics.HeaderText = "Diagnostics";
            this.c_dgvDiag_Diagnostics.Name = "c_dgvDiag_Diagnostics";
            this.c_dgvDiag_Diagnostics.ReadOnly = true;
            // 
            // b_refreshLogs
            // 
            this.b_refreshLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_refreshLogs.Location = new System.Drawing.Point(108, 551);
            this.b_refreshLogs.Name = "b_refreshLogs";
            this.b_refreshLogs.Size = new System.Drawing.Size(106, 23);
            this.b_refreshLogs.TabIndex = 7;
            this.b_refreshLogs.Text = "Refresh Logs";
            this.b_refreshLogs.UseVisualStyleBackColor = true;
            this.b_refreshLogs.Click += new System.EventHandler(this.b_refreshLogs_Click);
            // 
            // nup_Delay
            // 
            this.nup_Delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nup_Delay.Location = new System.Drawing.Point(95, 389);
            this.nup_Delay.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nup_Delay.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nup_Delay.Name = "nup_Delay";
            this.nup_Delay.Size = new System.Drawing.Size(42, 20);
            this.nup_Delay.TabIndex = 2;
            this.nup_Delay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nup_Delay.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "seconds";
            // 
            // pb_colourpickerStart
            // 
            this.pb_colourpickerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_colourpickerStart.Location = new System.Drawing.Point(191, 392);
            this.pb_colourpickerStart.Name = "pb_colourpickerStart";
            this.pb_colourpickerStart.Size = new System.Drawing.Size(19, 17);
            this.pb_colourpickerStart.TabIndex = 14;
            this.pb_colourpickerStart.TabStop = false;
            this.pb_colourpickerStart.Click += new System.EventHandler(this.pb_colourpickerStart_Click);
            // 
            // pb_colourpickerEnd
            // 
            this.pb_colourpickerEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_colourpickerEnd.Location = new System.Drawing.Point(191, 415);
            this.pb_colourpickerEnd.Name = "pb_colourpickerEnd";
            this.pb_colourpickerEnd.Size = new System.Drawing.Size(19, 17);
            this.pb_colourpickerEnd.TabIndex = 15;
            this.pb_colourpickerEnd.TabStop = false;
            this.pb_colourpickerEnd.Click += new System.EventHandler(this.pb_colourpickerEnd_Click);
            // 
            // b_launchconfigcustomLocations
            // 
            this.b_launchconfigcustomLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_launchconfigcustomLocations.Location = new System.Drawing.Point(108, 524);
            this.b_launchconfigcustomLocations.Name = "b_launchconfigcustomLocations";
            this.b_launchconfigcustomLocations.Size = new System.Drawing.Size(106, 23);
            this.b_launchconfigcustomLocations.TabIndex = 16;
            this.b_launchconfigcustomLocations.Text = "Custom Paths";
            this.b_launchconfigcustomLocations.UseVisualStyleBackColor = true;
            this.b_launchconfigcustomLocations.Click += new System.EventHandler(this.b_launchconfigcustomLocations_Click);
            // 
            // b_launchLogs
            // 
            this.b_launchLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_launchLogs.Location = new System.Drawing.Point(108, 497);
            this.b_launchLogs.Name = "b_launchLogs";
            this.b_launchLogs.Size = new System.Drawing.Size(106, 21);
            this.b_launchLogs.TabIndex = 17;
            this.b_launchLogs.Text = "Launch Logs";
            this.b_launchLogs.UseVisualStyleBackColor = true;
            this.b_launchLogs.Click += new System.EventHandler(this.b_launchLogs_Click);
            // 
            // dgv_c_hiddenlogName
            // 
            this.dgv_c_hiddenlogName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_hiddenlogName.HeaderText = "FullName";
            this.dgv_c_hiddenlogName.Name = "dgv_c_hiddenlogName";
            this.dgv_c_hiddenlogName.ReadOnly = true;
            this.dgv_c_hiddenlogName.Visible = false;
            this.dgv_c_hiddenlogName.Width = 57;
            // 
            // dgv_c_logName
            // 
            this.dgv_c_logName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_logName.HeaderText = "Log Name";
            this.dgv_c_logName.Name = "dgv_c_logName";
            this.dgv_c_logName.ReadOnly = true;
            this.dgv_c_logName.Width = 81;
            // 
            // dgv_c_Class
            // 
            this.dgv_c_Class.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_Class.HeaderText = "Product";
            this.dgv_c_Class.Name = "dgv_c_Class";
            this.dgv_c_Class.ReadOnly = true;
            this.dgv_c_Class.Width = 69;
            // 
            // dgv_c_Type
            // 
            this.dgv_c_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_Type.HeaderText = "Type";
            this.dgv_c_Type.Name = "dgv_c_Type";
            this.dgv_c_Type.ReadOnly = true;
            this.dgv_c_Type.Width = 56;
            // 
            // dgv_c_logSize
            // 
            this.dgv_c_logSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_logSize.HeaderText = "Size (Bytes)";
            this.dgv_c_logSize.Name = "dgv_c_logSize";
            this.dgv_c_logSize.ReadOnly = true;
            this.dgv_c_logSize.Width = 87;
            // 
            // dgv_c_logsizeMB
            // 
            this.dgv_c_logsizeMB.HeaderText = "Size (MB)";
            this.dgv_c_logsizeMB.Name = "dgv_c_logsizeMB";
            this.dgv_c_logsizeMB.ReadOnly = true;
            // 
            // dgv_c_lastWritten
            // 
            this.dgv_c_lastWritten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_lastWritten.HeaderText = "Last Modified";
            this.dgv_c_lastWritten.Name = "dgv_c_lastWritten";
            this.dgv_c_lastWritten.ReadOnly = true;
            this.dgv_c_lastWritten.Width = 95;
            // 
            // dgv_c_logPath
            // 
            this.dgv_c_logPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_c_logPath.HeaderText = "Path";
            this.dgv_c_logPath.Name = "dgv_c_logPath";
            this.dgv_c_logPath.ReadOnly = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.b_scanLogs;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 601);
            this.Controls.Add(this.b_launchLogs);
            this.Controls.Add(this.b_launchconfigcustomLocations);
            this.Controls.Add(this.pb_colourpickerEnd);
            this.Controls.Add(this.pb_colourpickerStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nup_Delay);
            this.Controls.Add(this.b_refreshLogs);
            this.Controls.Add(this.b_debugWindow);
            this.Controls.Add(this.b_About);
            this.Controls.Add(this.cb_openLogsMulti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Monitor);
            this.Controls.Add(this.b_scanLogs);
            this.Controls.Add(this.tb_remoteServer);
            this.Controls.Add(this.cb_hidearchiveLogs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tv_Logs);
            this.Controls.Add(this.dgv_Logs);
            this.Controls.Add(this.dgv_Diagnostics);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "Form1";
            this.Text = "Log Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diagnostics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colourpickerStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colourpickerEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Logs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView dgv_Logs;
        private System.Windows.Forms.CheckBox cb_hidearchiveLogs;
        private System.Windows.Forms.TextBox tb_remoteServer;
        private System.Windows.Forms.Button b_scanLogs;
        private System.Windows.Forms.CheckBox cb_Monitor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_openLogsMulti;
        private System.Windows.Forms.Button b_About;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem1;
        private System.Windows.Forms.Button b_debugWindow;
        private System.Windows.Forms.DataGridView dgv_Diagnostics;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_dgvDiag_Diagnostics;
        private System.Windows.Forms.Button b_refreshLogs;
        private System.Windows.Forms.NumericUpDown nup_Delay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pb_colourpickerStart;
        private System.Windows.Forms.PictureBox pb_colourpickerEnd;
        private System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem2;
        private System.Windows.Forms.Button b_launchconfigcustomLocations;
        private System.Windows.Forms.Button b_launchLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_hiddenlogName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_logName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_logSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_logsizeMB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_lastWritten;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_c_logPath;
    }
}

