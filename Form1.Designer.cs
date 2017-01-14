namespace LogLauncher
{
    partial class Form1
    {
        private bool switches_startupPhase = true;

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
            this.dgv_c_hiddenlogName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logsizeMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_lastWritten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_c_logPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_v_Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openLogFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFolderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_hidearchiveLogs = new System.Windows.Forms.CheckBox();
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.p_Logging = new System.Windows.Forms.Panel();
            this.p_Client = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_cycleCCMEXEC = new System.Windows.Forms.Button();
            this.cb_client_Logging = new System.Windows.Forms.CheckBox();
            this.cb_client_debugLogging = new System.Windows.Forms.CheckBox();
            this.nud_client_logLevel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_client_logmaxHistory = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_client_logmaxSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.p_Site = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_cycleSMSEXEC = new System.Windows.Forms.Button();
            this.cb_site_siteLogging = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.num_provider_logsizeMb = new System.Windows.Forms.NumericUpDown();
            this.num_provider_sqlcacheloggingLevel = new System.Windows.Forms.NumericUpDown();
            this.num_provider_loggingLevel = new System.Windows.Forms.NumericUpDown();
            this.cb_site_sqlLogging = new System.Windows.Forms.CheckBox();
            this.cb_site_archiveLogs = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_Logging = new System.Windows.Forms.DataGridView();
            this.c_dgv_logging_componentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_dgv_logging_debugLogging = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_dgv_logging_Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_dgv_logging_loggingLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_dgv_logging_logmaxHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_dgv_logging_maxfileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_logSettings = new System.Windows.Forms.Button();
            this.cb_remoteServer = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diagnostics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colourpickerStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colourpickerEnd)).BeginInit();
            this.p_Logging.SuspendLayout();
            this.p_Client.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_client_logLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_client_logmaxHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_client_logmaxSize)).BeginInit();
            this.p_Site.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_provider_logsizeMb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_provider_sqlcacheloggingLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_provider_loggingLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logging)).BeginInit();
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
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "ss_Output";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(438, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(438, 17);
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
            this.dgv_c_logPath,
            this.dgv_v_Product});
            this.dgv_Logs.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_Logs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Logs.Location = new System.Drawing.Point(219, 12);
            this.dgv_Logs.Name = "dgv_Logs";
            this.dgv_Logs.ReadOnly = true;
            this.dgv_Logs.RowHeadersVisible = false;
            this.dgv_Logs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Logs.Size = new System.Drawing.Size(661, 564);
            this.dgv_Logs.StandardTab = true;
            this.dgv_Logs.TabIndex = 10;
            this.dgv_Logs.DoubleClick += new System.EventHandler(this.dgv_Logs_DoubleClick);
            this.dgv_Logs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Logs_KeyDown);
            // 
            // dgv_c_hiddenlogName
            // 
            this.dgv_c_hiddenlogName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_c_hiddenlogName.HeaderText = "FullName";
            this.dgv_c_hiddenlogName.Name = "dgv_c_hiddenlogName";
            this.dgv_c_hiddenlogName.ReadOnly = true;
            this.dgv_c_hiddenlogName.Visible = false;
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
            this.dgv_c_Class.HeaderText = "Class";
            this.dgv_c_Class.Name = "dgv_c_Class";
            this.dgv_c_Class.ReadOnly = true;
            this.dgv_c_Class.Width = 57;
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
            // dgv_v_Product
            // 
            this.dgv_v_Product.HeaderText = "Product";
            this.dgv_v_Product.Name = "dgv_v_Product";
            this.dgv_v_Product.ReadOnly = true;
            this.dgv_v_Product.Visible = false;
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
            // b_scanLogs
            // 
            this.b_scanLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_scanLogs.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.b_scanLogs.Location = new System.Drawing.Point(165, 467);
            this.b_scanLogs.Name = "b_scanLogs";
            this.b_scanLogs.Size = new System.Drawing.Size(45, 23);
            this.b_scanLogs.TabIndex = 6;
            this.b_scanLogs.Text = "Scan";
            this.b_scanLogs.UseVisualStyleBackColor = false;
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
            this.b_About.Text = "Help";
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
            this.dgv_Diagnostics.Size = new System.Drawing.Size(661, 564);
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
            this.b_refreshLogs.Location = new System.Drawing.Point(6, 495);
            this.b_refreshLogs.Name = "b_refreshLogs";
            this.b_refreshLogs.Size = new System.Drawing.Size(96, 23);
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
            this.b_launchconfigcustomLocations.Location = new System.Drawing.Point(117, 524);
            this.b_launchconfigcustomLocations.Name = "b_launchconfigcustomLocations";
            this.b_launchconfigcustomLocations.Size = new System.Drawing.Size(96, 23);
            this.b_launchconfigcustomLocations.TabIndex = 16;
            this.b_launchconfigcustomLocations.Text = "Custom Paths";
            this.b_launchconfigcustomLocations.UseVisualStyleBackColor = true;
            this.b_launchconfigcustomLocations.Click += new System.EventHandler(this.b_launchconfigcustomLocations_Click);
            // 
            // b_launchLogs
            // 
            this.b_launchLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_launchLogs.Location = new System.Drawing.Point(117, 495);
            this.b_launchLogs.Name = "b_launchLogs";
            this.b_launchLogs.Size = new System.Drawing.Size(96, 23);
            this.b_launchLogs.TabIndex = 17;
            this.b_launchLogs.Text = "Open Logs";
            this.b_launchLogs.UseVisualStyleBackColor = true;
            this.b_launchLogs.Click += new System.EventHandler(this.b_launchLogs_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // p_Logging
            // 
            this.p_Logging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Logging.Controls.Add(this.p_Client);
            this.p_Logging.Controls.Add(this.p_Site);
            this.p_Logging.Controls.Add(this.dgv_Logging);
            this.p_Logging.Location = new System.Drawing.Point(219, 12);
            this.p_Logging.Name = "p_Logging";
            this.p_Logging.Size = new System.Drawing.Size(661, 564);
            this.p_Logging.TabIndex = 19;
            this.p_Logging.Visible = false;
            // 
            // p_Client
            // 
            this.p_Client.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Client.Controls.Add(this.groupBox2);
            this.p_Client.Location = new System.Drawing.Point(304, 449);
            this.p_Client.Name = "p_Client";
            this.p_Client.Size = new System.Drawing.Size(354, 115);
            this.p_Client.TabIndex = 24;
            this.p_Client.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_cycleCCMEXEC);
            this.groupBox2.Controls.Add(this.cb_client_Logging);
            this.groupBox2.Controls.Add(this.cb_client_debugLogging);
            this.groupBox2.Controls.Add(this.nud_client_logLevel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nud_client_logmaxHistory);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nud_client_logmaxSize);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 115);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Logging";
            // 
            // b_cycleCCMEXEC
            // 
            this.b_cycleCCMEXEC.Location = new System.Drawing.Point(20, 79);
            this.b_cycleCCMEXEC.Name = "b_cycleCCMEXEC";
            this.b_cycleCCMEXEC.Size = new System.Drawing.Size(99, 23);
            this.b_cycleCCMEXEC.TabIndex = 9;
            this.b_cycleCCMEXEC.Text = "Cycle CCMEXEC";
            this.b_cycleCCMEXEC.UseVisualStyleBackColor = true;
            this.b_cycleCCMEXEC.Click += new System.EventHandler(this.b_cycleCCMEXEC_Click);
            // 
            // cb_client_Logging
            // 
            this.cb_client_Logging.AutoSize = true;
            this.cb_client_Logging.Location = new System.Drawing.Point(20, 20);
            this.cb_client_Logging.Name = "cb_client_Logging";
            this.cb_client_Logging.Size = new System.Drawing.Size(64, 17);
            this.cb_client_Logging.TabIndex = 4;
            this.cb_client_Logging.Text = "Logging";
            this.cb_client_Logging.UseVisualStyleBackColor = true;
            this.cb_client_Logging.CheckedChanged += new System.EventHandler(this.cb_client_debugLogging_CheckedChanged);
            // 
            // cb_client_debugLogging
            // 
            this.cb_client_debugLogging.AutoSize = true;
            this.cb_client_debugLogging.Location = new System.Drawing.Point(20, 52);
            this.cb_client_debugLogging.Name = "cb_client_debugLogging";
            this.cb_client_debugLogging.Size = new System.Drawing.Size(99, 17);
            this.cb_client_debugLogging.TabIndex = 8;
            this.cb_client_debugLogging.Text = "Debug Logging";
            this.cb_client_debugLogging.UseVisualStyleBackColor = true;
            this.cb_client_debugLogging.CheckedChanged += new System.EventHandler(this.cb_client_debugLogging_CheckedChanged_1);
            // 
            // nud_client_logLevel
            // 
            this.nud_client_logLevel.Location = new System.Drawing.Point(250, 19);
            this.nud_client_logLevel.Name = "nud_client_logLevel";
            this.nud_client_logLevel.Size = new System.Drawing.Size(63, 20);
            this.nud_client_logLevel.TabIndex = 1;
            this.nud_client_logLevel.ValueChanged += new System.EventHandler(this.nud_client_logLevel_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Log Max Size";
            // 
            // nud_client_logmaxHistory
            // 
            this.nud_client_logmaxHistory.Location = new System.Drawing.Point(250, 50);
            this.nud_client_logmaxHistory.Name = "nud_client_logmaxHistory";
            this.nud_client_logmaxHistory.Size = new System.Drawing.Size(63, 20);
            this.nud_client_logmaxHistory.TabIndex = 2;
            this.nud_client_logmaxHistory.ValueChanged += new System.EventHandler(this.nud_client_logmaxHistory_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Log Max History";
            // 
            // nud_client_logmaxSize
            // 
            this.nud_client_logmaxSize.Location = new System.Drawing.Point(250, 82);
            this.nud_client_logmaxSize.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nud_client_logmaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_client_logmaxSize.Name = "nud_client_logmaxSize";
            this.nud_client_logmaxSize.Size = new System.Drawing.Size(63, 20);
            this.nud_client_logmaxSize.TabIndex = 3;
            this.nud_client_logmaxSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_client_logmaxSize.ValueChanged += new System.EventHandler(this.nud_client_logmaxSize_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Log Level";
            // 
            // p_Site
            // 
            this.p_Site.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p_Site.Controls.Add(this.groupBox1);
            this.p_Site.Location = new System.Drawing.Point(3, 448);
            this.p_Site.Name = "p_Site";
            this.p_Site.Size = new System.Drawing.Size(298, 116);
            this.p_Site.TabIndex = 23;
            this.p_Site.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_cycleSMSEXEC);
            this.groupBox1.Controls.Add(this.cb_site_siteLogging);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.num_provider_logsizeMb);
            this.groupBox1.Controls.Add(this.num_provider_sqlcacheloggingLevel);
            this.groupBox1.Controls.Add(this.num_provider_loggingLevel);
            this.groupBox1.Controls.Add(this.cb_site_sqlLogging);
            this.groupBox1.Controls.Add(this.cb_site_archiveLogs);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 115);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site and Site Provider Logging";
            // 
            // b_cycleSMSEXEC
            // 
            this.b_cycleSMSEXEC.Location = new System.Drawing.Point(6, 82);
            this.b_cycleSMSEXEC.Name = "b_cycleSMSEXEC";
            this.b_cycleSMSEXEC.Size = new System.Drawing.Size(103, 23);
            this.b_cycleSMSEXEC.TabIndex = 10;
            this.b_cycleSMSEXEC.Text = "Cycle SMSEXEC";
            this.b_cycleSMSEXEC.UseVisualStyleBackColor = true;
            this.b_cycleSMSEXEC.Click += new System.EventHandler(this.b_cycleSMSEXEC_Click);
            // 
            // cb_site_siteLogging
            // 
            this.cb_site_siteLogging.AutoSize = true;
            this.cb_site_siteLogging.Location = new System.Drawing.Point(6, 20);
            this.cb_site_siteLogging.Name = "cb_site_siteLogging";
            this.cb_site_siteLogging.Size = new System.Drawing.Size(85, 17);
            this.cb_site_siteLogging.TabIndex = 13;
            this.cb_site_siteLogging.Text = "Site Logging";
            this.cb_site_siteLogging.UseVisualStyleBackColor = true;
            this.cb_site_siteLogging.CheckedChanged += new System.EventHandler(this.cb_site_siteLogging_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Provider Logging Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "SQL Cache Logging Level";
            // 
            // num_provider_logsizeMb
            // 
            this.num_provider_logsizeMb.Location = new System.Drawing.Point(249, 82);
            this.num_provider_logsizeMb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_provider_logsizeMb.Name = "num_provider_logsizeMb";
            this.num_provider_logsizeMb.Size = new System.Drawing.Size(42, 20);
            this.num_provider_logsizeMb.TabIndex = 22;
            this.num_provider_logsizeMb.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_provider_logsizeMb.ValueChanged += new System.EventHandler(this.num_provider_logsizeMb_ValueChanged);
            // 
            // num_provider_sqlcacheloggingLevel
            // 
            this.num_provider_sqlcacheloggingLevel.Location = new System.Drawing.Point(249, 49);
            this.num_provider_sqlcacheloggingLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_provider_sqlcacheloggingLevel.Name = "num_provider_sqlcacheloggingLevel";
            this.num_provider_sqlcacheloggingLevel.Size = new System.Drawing.Size(41, 20);
            this.num_provider_sqlcacheloggingLevel.TabIndex = 20;
            this.num_provider_sqlcacheloggingLevel.ValueChanged += new System.EventHandler(this.num_provider_sqlcacheloggingLevel_ValueChanged);
            // 
            // num_provider_loggingLevel
            // 
            this.num_provider_loggingLevel.Location = new System.Drawing.Point(249, 19);
            this.num_provider_loggingLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_provider_loggingLevel.Name = "num_provider_loggingLevel";
            this.num_provider_loggingLevel.Size = new System.Drawing.Size(41, 20);
            this.num_provider_loggingLevel.TabIndex = 17;
            this.num_provider_loggingLevel.ValueChanged += new System.EventHandler(this.num_provider_loggingLevel_ValueChanged);
            // 
            // cb_site_sqlLogging
            // 
            this.cb_site_sqlLogging.AutoSize = true;
            this.cb_site_sqlLogging.Location = new System.Drawing.Point(6, 39);
            this.cb_site_sqlLogging.Name = "cb_site_sqlLogging";
            this.cb_site_sqlLogging.Size = new System.Drawing.Size(88, 17);
            this.cb_site_sqlLogging.TabIndex = 14;
            this.cb_site_sqlLogging.Text = "SQL Logging";
            this.cb_site_sqlLogging.UseVisualStyleBackColor = true;
            this.cb_site_sqlLogging.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // cb_site_archiveLogs
            // 
            this.cb_site_archiveLogs.AutoSize = true;
            this.cb_site_archiveLogs.Location = new System.Drawing.Point(6, 59);
            this.cb_site_archiveLogs.Name = "cb_site_archiveLogs";
            this.cb_site_archiveLogs.Size = new System.Drawing.Size(88, 17);
            this.cb_site_archiveLogs.TabIndex = 15;
            this.cb_site_archiveLogs.Text = "Archive Logs";
            this.cb_site_archiveLogs.UseVisualStyleBackColor = true;
            this.cb_site_archiveLogs.CheckedChanged += new System.EventHandler(this.cb_site_archiveLogs_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Provider Log Size (Mb)";
            // 
            // dgv_Logging
            // 
            this.dgv_Logging.AllowUserToAddRows = false;
            this.dgv_Logging.AllowUserToDeleteRows = false;
            this.dgv_Logging.AllowUserToOrderColumns = true;
            this.dgv_Logging.AllowUserToResizeRows = false;
            this.dgv_Logging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Logging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Logging.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_dgv_logging_componentName,
            this.c_dgv_logging_debugLogging,
            this.c_dgv_logging_Enabled,
            this.c_dgv_logging_loggingLevel,
            this.c_dgv_logging_logmaxHistory,
            this.c_dgv_logging_maxfileSize});
            this.dgv_Logging.Location = new System.Drawing.Point(0, 0);
            this.dgv_Logging.MultiSelect = false;
            this.dgv_Logging.Name = "dgv_Logging";
            this.dgv_Logging.RowHeadersVisible = false;
            this.dgv_Logging.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Logging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Logging.ShowEditingIcon = false;
            this.dgv_Logging.Size = new System.Drawing.Size(660, 442);
            this.dgv_Logging.TabIndex = 11;
            this.dgv_Logging.Visible = false;
            this.dgv_Logging.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Logging_CellValueChanged);
            // 
            // c_dgv_logging_componentName
            // 
            this.c_dgv_logging_componentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_dgv_logging_componentName.HeaderText = "Component";
            this.c_dgv_logging_componentName.Name = "c_dgv_logging_componentName";
            this.c_dgv_logging_componentName.ReadOnly = true;
            this.c_dgv_logging_componentName.Width = 86;
            // 
            // c_dgv_logging_debugLogging
            // 
            this.c_dgv_logging_debugLogging.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_dgv_logging_debugLogging.HeaderText = "Debug";
            this.c_dgv_logging_debugLogging.Name = "c_dgv_logging_debugLogging";
            this.c_dgv_logging_debugLogging.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_dgv_logging_debugLogging.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_dgv_logging_debugLogging.Width = 64;
            // 
            // c_dgv_logging_Enabled
            // 
            this.c_dgv_logging_Enabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_dgv_logging_Enabled.HeaderText = "Enabled";
            this.c_dgv_logging_Enabled.Name = "c_dgv_logging_Enabled";
            this.c_dgv_logging_Enabled.Width = 52;
            // 
            // c_dgv_logging_loggingLevel
            // 
            this.c_dgv_logging_loggingLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_dgv_logging_loggingLevel.HeaderText = "Log Level";
            this.c_dgv_logging_loggingLevel.Name = "c_dgv_logging_loggingLevel";
            this.c_dgv_logging_loggingLevel.Width = 79;
            // 
            // c_dgv_logging_logmaxHistory
            // 
            this.c_dgv_logging_logmaxHistory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_dgv_logging_logmaxHistory.HeaderText = "Max History";
            this.c_dgv_logging_logmaxHistory.Name = "c_dgv_logging_logmaxHistory";
            this.c_dgv_logging_logmaxHistory.Width = 87;
            // 
            // c_dgv_logging_maxfileSize
            // 
            this.c_dgv_logging_maxfileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_dgv_logging_maxfileSize.HeaderText = "Max File Size";
            this.c_dgv_logging_maxfileSize.Name = "c_dgv_logging_maxfileSize";
            // 
            // b_logSettings
            // 
            this.b_logSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_logSettings.Location = new System.Drawing.Point(117, 551);
            this.b_logSettings.Name = "b_logSettings";
            this.b_logSettings.Size = new System.Drawing.Size(96, 23);
            this.b_logSettings.TabIndex = 20;
            this.b_logSettings.Text = "Log Settings";
            this.b_logSettings.UseVisualStyleBackColor = true;
            this.b_logSettings.Visible = false;
            this.b_logSettings.Click += new System.EventHandler(this.b_logSettings_Click);
            // 
            // cb_remoteServer
            // 
            this.cb_remoteServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_remoteServer.FormattingEnabled = true;
            this.cb_remoteServer.Location = new System.Drawing.Point(6, 469);
            this.cb_remoteServer.MaxDropDownItems = 10;
            this.cb_remoteServer.Name = "cb_remoteServer";
            this.cb_remoteServer.Size = new System.Drawing.Size(153, 21);
            this.cb_remoteServer.TabIndex = 21;
            // 
            // Form1
            // 
            this.AcceptButton = this.b_scanLogs;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 601);
            this.Controls.Add(this.cb_remoteServer);
            this.Controls.Add(this.p_Logging);
            this.Controls.Add(this.b_logSettings);
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
            this.p_Logging.ResumeLayout(false);
            this.p_Client.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_client_logLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_client_logmaxHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_client_logmaxSize)).EndInit();
            this.p_Site.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_provider_logsizeMb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_provider_sqlcacheloggingLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_provider_loggingLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logging)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_v_Product;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel p_Logging;
        private System.Windows.Forms.DataGridView dgv_Logging;
        private System.Windows.Forms.Button b_logSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_dgv_logging_componentName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_dgv_logging_debugLogging;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_dgv_logging_Enabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_dgv_logging_loggingLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_dgv_logging_logmaxHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_dgv_logging_maxfileSize;
        private System.Windows.Forms.Panel p_Client;
        private System.Windows.Forms.Panel p_Site;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_provider_logsizeMb;
        private System.Windows.Forms.CheckBox cb_site_siteLogging;
        private System.Windows.Forms.CheckBox cb_site_sqlLogging;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cb_site_archiveLogs;
        private System.Windows.Forms.NumericUpDown num_provider_loggingLevel;
        private System.Windows.Forms.NumericUpDown num_provider_sqlcacheloggingLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_client_Logging;
        private System.Windows.Forms.NumericUpDown nud_client_logmaxSize;
        private System.Windows.Forms.NumericUpDown nud_client_logmaxHistory;
        private System.Windows.Forms.NumericUpDown nud_client_logLevel;
        private System.Windows.Forms.CheckBox cb_client_debugLogging;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_cycleCCMEXEC;
        private System.Windows.Forms.Button b_cycleSMSEXEC;
        private System.Windows.Forms.ComboBox cb_remoteServer;
    }
}

