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
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Ziplogs = new System.Windows.Forms.ToolStripMenuItem();
            this.openZIPFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspb_Monitoring = new System.Windows.Forms.ToolStripProgressBar();
            this.tspb_zipfileCount = new System.Windows.Forms.ToolStripProgressBar();
            this.tspb_zipfileProgress = new System.Windows.Forms.ToolStripProgressBar();
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
            this.tsmi_openlogorLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_openLogFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_zipselectedlogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_openzipFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_Diagnostics = new System.Windows.Forms.DataGridView();
            this.c_dgvDiag_Diagnostics = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel_Logging = new System.Windows.Forms.Panel();
            this.dgv_Logging = new System.Windows.Forms.DataGridView();
            this.c_dgv_logging_componentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_dgv_logging_debugLogging = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_dgv_logging_Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_dgv_logging_loggingLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_dgv_logging_logmaxHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_dgv_logging_maxfileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label6 = new System.Windows.Forms.Label();
            this.cb_site_sqlLogging = new System.Windows.Forms.CheckBox();
            this.cb_site_siteLogging = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_site_archiveLogs = new System.Windows.Forms.CheckBox();
            this.num_provider_logsizeMb = new System.Windows.Forms.NumericUpDown();
            this.num_provider_sqlcacheloggingLevel = new System.Windows.Forms.NumericUpDown();
            this.num_provider_loggingLevel = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem5 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rt_Home = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rb_scanLogs = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.rcb_remoteServer = new System.Windows.Forms.RibbonComboBox();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rcb_hidearchiveLogs = new System.Windows.Forms.RibbonCheckBox();
            this.rcc_sortbyModified = new System.Windows.Forms.RibbonCheckBox();
            this.rcc_ignoreCRASHDUMP = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rb_openLogs = new System.Windows.Forms.RibbonButton();
            this.rb_refreshLogs = new System.Windows.Forms.RibbonButton();
            this.rb_zipLogs = new System.Windows.Forms.RibbonButton();
            this.rtb_zipselectedLogs = new System.Windows.Forms.RibbonTextBox();
            this.rtb_zipselectedNode = new System.Windows.Forms.RibbonTextBox();
            this.rtb_openzipFolder = new System.Windows.Forms.RibbonTextBox();
            this.rtb_configurezipFolder = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.rb_showLogs = new System.Windows.Forms.RibbonButton();
            this.rb_customPaths = new System.Windows.Forms.RibbonButton();
            this.rb_Logging = new System.Windows.Forms.RibbonButton();
            this.rb_debugWindow = new System.Windows.Forms.RibbonButton();
            this.rb_supportCenter = new System.Windows.Forms.RibbonButton();
            this.rb_Help = new System.Windows.Forms.RibbonButton();
            this.rt_Monitoring = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rb_Monitor = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.rup_Duration = new System.Windows.Forms.RibbonUpDown();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.rcc_Newest = new System.Windows.Forms.RibbonColorChooser();
            this.rcc_Oldest = new System.Windows.Forms.RibbonColorChooser();
            this.rt_Trace = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.rtb_tracerPath = new System.Windows.Forms.RibbonTextBox();
            this.rb_tracerFind = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.rcb_MultiMerge = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.rtb_zipoutputDirectory = new System.Windows.Forms.RibbonTextBox();
            this.rb_zipoutputdirectorySelect = new System.Windows.Forms.RibbonButton();
            this.ribbonOrbRecentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem2 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem3 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem4 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem5 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonOrbMenuItem2 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.panel_Logs = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pb_pinSlider = new System.Windows.Forms.PictureBox();
            this.pb_snapOut = new System.Windows.Forms.PictureBox();
            this.rtb_Help = new System.Windows.Forms.RichTextBox();
            this.b_deleteLocation = new System.Windows.Forms.Button();
            this.b_addupdateLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_recurseFolder = new System.Windows.Forms.ComboBox();
            this.tb_logProduct = new System.Windows.Forms.TextBox();
            this.tb_logCategory = new System.Windows.Forms.TextBox();
            this.tb_fileMask = new System.Windows.Forms.TextBox();
            this.tb_customLocation = new System.Windows.Forms.TextBox();
            this.dgv_customLocations = new System.Windows.Forms.DataGridView();
            this.c_cust_customLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_fileMask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_recurseFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_logClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_logProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Help = new System.Windows.Forms.Panel();
            this.panel_customLocations = new System.Windows.Forms.Panel();
            this.panel_Diagnostics = new System.Windows.Forms.Panel();
            this.ribbonOrbMenuItem3 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbRecentItem6 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem7 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem8 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem9 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbMenuItem4 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator6 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator7 = new System.Windows.Forms.RibbonSeparator();
            this.tsmi_monitorNode = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diagnostics)).BeginInit();
            this.panel_Logging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logging)).BeginInit();
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
            this.panel_Logs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pinSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_snapOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customLocations)).BeginInit();
            this.panel_Help.SuspendLayout();
            this.panel_customLocations.SuspendLayout();
            this.panel_Diagnostics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_Logs
            // 
            this.tv_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_Logs.BackColor = System.Drawing.SystemColors.Info;
            this.tv_Logs.ContextMenuStrip = this.contextMenuStrip2;
            this.tv_Logs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_Logs.Location = new System.Drawing.Point(3, 0);
            this.tv_Logs.Name = "tv_Logs";
            this.tv_Logs.Size = new System.Drawing.Size(209, 503);
            this.tv_Logs.TabIndex = 0;
            this.tv_Logs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Logs_AfterSelect);
            this.tv_Logs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Logs_NodeMouseClick);
            this.tv_Logs.Click += new System.EventHandler(this.tv_Logs_Click);
            this.tv_Logs.MouseEnter += new System.EventHandler(this.tv_Logs_MouseEnter);
            this.tv_Logs.MouseLeave += new System.EventHandler(this.tv_Logs_MouseLeave);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Ziplogs,
            this.openZIPFolderToolStripMenuItem,
            this.tsmi_monitorNode});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(211, 92);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // tsmi_Ziplogs
            // 
            this.tsmi_Ziplogs.Name = "tsmi_Ziplogs";
            this.tsmi_Ziplogs.Size = new System.Drawing.Size(210, 22);
            this.tsmi_Ziplogs.Text = "Zip Logs in selected Node";
            this.tsmi_Ziplogs.Click += new System.EventHandler(this.tsmi_Ziplogs_Click);
            // 
            // openZIPFolderToolStripMenuItem
            // 
            this.openZIPFolderToolStripMenuItem.Name = "openZIPFolderToolStripMenuItem";
            this.openZIPFolderToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.openZIPFolderToolStripMenuItem.Text = "Open ZIP Folder";
            this.openZIPFolderToolStripMenuItem.Click += new System.EventHandler(this.tsmi_openzipFolder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tspb_Monitoring,
            this.tspb_zipfileCount,
            this.tspb_zipfileProgress,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1011, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "ss_Output";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(498, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspb_Monitoring
            // 
            this.tspb_Monitoring.Name = "tspb_Monitoring";
            this.tspb_Monitoring.Size = new System.Drawing.Size(100, 16);
            this.tspb_Monitoring.Step = 1;
            this.tspb_Monitoring.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspb_Monitoring.ToolTipText = "Monitoring in progress ...";
            this.tspb_Monitoring.Visible = false;
            this.tspb_Monitoring.Click += new System.EventHandler(this.tspb_Monitoring_Click);
            this.tspb_Monitoring.DoubleClick += new System.EventHandler(this.tspb_Monitoring_DoubleClick);
            // 
            // tspb_zipfileCount
            // 
            this.tspb_zipfileCount.Name = "tspb_zipfileCount";
            this.tspb_zipfileCount.Size = new System.Drawing.Size(100, 16);
            this.tspb_zipfileCount.Visible = false;
            // 
            // tspb_zipfileProgress
            // 
            this.tspb_zipfileProgress.Name = "tspb_zipfileProgress";
            this.tspb_zipfileProgress.Size = new System.Drawing.Size(100, 16);
            this.tspb_zipfileProgress.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(498, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // dgv_Logs
            // 
            this.dgv_Logs.AllowUserToAddRows = false;
            this.dgv_Logs.AllowUserToDeleteRows = false;
            this.dgv_Logs.AllowUserToOrderColumns = true;
            this.dgv_Logs.AllowUserToResizeRows = false;
            this.dgv_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Logs.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.dgv_Logs.Location = new System.Drawing.Point(3, 0);
            this.dgv_Logs.Name = "dgv_Logs";
            this.dgv_Logs.ReadOnly = true;
            this.dgv_Logs.RowHeadersVisible = false;
            this.dgv_Logs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_Logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Logs.Size = new System.Drawing.Size(784, 503);
            this.dgv_Logs.StandardTab = true;
            this.dgv_Logs.TabIndex = 10;
            this.dgv_Logs.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgv_Logs_ColumnDisplayIndexChanged);
            this.dgv_Logs.SelectionChanged += new System.EventHandler(this.dgv_Logs_SelectionChanged);
            this.dgv_Logs.Click += new System.EventHandler(this.dgv_Logs_Click);
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
            this.tsmi_openlogorLogs,
            this.tsmi_openLogFolder,
            this.tsmi_zipselectedlogs,
            this.tsmi_openzipFolder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 92);
            this.contextMenuStrip1.Text = "Open log folder";
            // 
            // tsmi_openlogorLogs
            // 
            this.tsmi_openlogorLogs.Name = "tsmi_openlogorLogs";
            this.tsmi_openlogorLogs.Size = new System.Drawing.Size(168, 22);
            this.tsmi_openlogorLogs.Text = "Open Log or Logs";
            this.tsmi_openlogorLogs.Click += new System.EventHandler(this.openLogFolderToolStripMenuItem2_Click);
            // 
            // tsmi_openLogFolder
            // 
            this.tsmi_openLogFolder.Name = "tsmi_openLogFolder";
            this.tsmi_openLogFolder.Size = new System.Drawing.Size(168, 22);
            this.tsmi_openLogFolder.Text = "Open log folder";
            this.tsmi_openLogFolder.Click += new System.EventHandler(this.openLogFolderToolStripMenuItem1_Click);
            // 
            // tsmi_zipselectedlogs
            // 
            this.tsmi_zipselectedlogs.Name = "tsmi_zipselectedlogs";
            this.tsmi_zipselectedlogs.Size = new System.Drawing.Size(168, 22);
            this.tsmi_zipselectedlogs.Text = "Zip Selected Logs";
            this.tsmi_zipselectedlogs.Click += new System.EventHandler(this.tsmi_zipselectedlogs_Click);
            // 
            // tsmi_openzipFolder
            // 
            this.tsmi_openzipFolder.Name = "tsmi_openzipFolder";
            this.tsmi_openzipFolder.Size = new System.Drawing.Size(168, 22);
            this.tsmi_openzipFolder.Text = "Open ZIP Folder";
            this.tsmi_openzipFolder.Click += new System.EventHandler(this.tsmi_openzipFolder_Click);
            // 
            // openLogFolderToolStripMenuItem
            // 
            this.openLogFolderToolStripMenuItem.Name = "openLogFolderToolStripMenuItem";
            this.openLogFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openLogFolderToolStripMenuItem.Text = "Open Log folder";
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
            this.dgv_Diagnostics.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_Diagnostics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Diagnostics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_dgvDiag_Diagnostics});
            this.dgv_Diagnostics.Location = new System.Drawing.Point(5, 3);
            this.dgv_Diagnostics.Name = "dgv_Diagnostics";
            this.dgv_Diagnostics.ReadOnly = true;
            this.dgv_Diagnostics.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_Diagnostics.RowHeadersVisible = false;
            this.dgv_Diagnostics.ShowEditingIcon = false;
            this.dgv_Diagnostics.Size = new System.Drawing.Size(1001, 500);
            this.dgv_Diagnostics.TabIndex = 11;
            this.dgv_Diagnostics.TabStop = false;
            // 
            // c_dgvDiag_Diagnostics
            // 
            this.c_dgvDiag_Diagnostics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_dgvDiag_Diagnostics.HeaderText = "Diagnostics";
            this.c_dgvDiag_Diagnostics.Name = "c_dgvDiag_Diagnostics";
            this.c_dgvDiag_Diagnostics.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "6";
            // 
            // panel_Logging
            // 
            this.panel_Logging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Logging.Controls.Add(this.dgv_Logging);
            this.panel_Logging.Controls.Add(this.p_Client);
            this.panel_Logging.Controls.Add(this.p_Site);
            this.panel_Logging.Location = new System.Drawing.Point(2, 108);
            this.panel_Logging.Name = "panel_Logging";
            this.panel_Logging.Size = new System.Drawing.Size(1009, 509);
            this.panel_Logging.TabIndex = 19;
            this.panel_Logging.Visible = false;
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
            this.dgv_Logging.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.dgv_Logging.Size = new System.Drawing.Size(1006, 360);
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
            // p_Client
            // 
            this.p_Client.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Client.Controls.Add(this.groupBox2);
            this.p_Client.Location = new System.Drawing.Point(388, 361);
            this.p_Client.Name = "p_Client";
            this.p_Client.Size = new System.Drawing.Size(618, 127);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 115);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Logging";
            // 
            // b_cycleCCMEXEC
            // 
            this.b_cycleCCMEXEC.Location = new System.Drawing.Point(20, 79);
            this.b_cycleCCMEXEC.Name = "b_cycleCCMEXEC";
            this.b_cycleCCMEXEC.Size = new System.Drawing.Size(150, 23);
            this.b_cycleCCMEXEC.TabIndex = 9;
            this.b_cycleCCMEXEC.Text = "Restart CCMEXEC Service";
            this.b_cycleCCMEXEC.UseVisualStyleBackColor = true;
            this.b_cycleCCMEXEC.Click += new System.EventHandler(this.b_cycleCCMEXEC_Click);
            // 
            // cb_client_Logging
            // 
            this.cb_client_Logging.AutoSize = true;
            this.cb_client_Logging.Location = new System.Drawing.Point(20, 22);
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
            this.nud_client_logLevel.Location = new System.Drawing.Point(290, 19);
            this.nud_client_logLevel.Name = "nud_client_logLevel";
            this.nud_client_logLevel.Size = new System.Drawing.Size(63, 20);
            this.nud_client_logLevel.TabIndex = 1;
            this.nud_client_logLevel.ValueChanged += new System.EventHandler(this.nud_client_logLevel_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Log Max Size";
            // 
            // nud_client_logmaxHistory
            // 
            this.nud_client_logmaxHistory.Location = new System.Drawing.Point(290, 50);
            this.nud_client_logmaxHistory.Name = "nud_client_logmaxHistory";
            this.nud_client_logmaxHistory.Size = new System.Drawing.Size(63, 20);
            this.nud_client_logmaxHistory.TabIndex = 2;
            this.nud_client_logmaxHistory.ValueChanged += new System.EventHandler(this.nud_client_logmaxHistory_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Log Max History";
            // 
            // nud_client_logmaxSize
            // 
            this.nud_client_logmaxSize.Location = new System.Drawing.Point(290, 82);
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
            this.label3.Location = new System.Drawing.Point(202, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Log Level";
            // 
            // p_Site
            // 
            this.p_Site.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p_Site.Controls.Add(this.groupBox1);
            this.p_Site.Location = new System.Drawing.Point(3, 361);
            this.p_Site.Name = "p_Site";
            this.p_Site.Size = new System.Drawing.Size(379, 128);
            this.p_Site.TabIndex = 23;
            this.p_Site.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_cycleSMSEXEC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cb_site_sqlLogging);
            this.groupBox1.Controls.Add(this.cb_site_siteLogging);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cb_site_archiveLogs);
            this.groupBox1.Controls.Add(this.num_provider_logsizeMb);
            this.groupBox1.Controls.Add(this.num_provider_sqlcacheloggingLevel);
            this.groupBox1.Controls.Add(this.num_provider_loggingLevel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 115);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site and Site Provider Logging";
            // 
            // b_cycleSMSEXEC
            // 
            this.b_cycleSMSEXEC.Location = new System.Drawing.Point(7, 82);
            this.b_cycleSMSEXEC.Name = "b_cycleSMSEXEC";
            this.b_cycleSMSEXEC.Size = new System.Drawing.Size(148, 23);
            this.b_cycleSMSEXEC.TabIndex = 10;
            this.b_cycleSMSEXEC.Text = "Restart SMSEXEC Service";
            this.b_cycleSMSEXEC.UseVisualStyleBackColor = true;
            this.b_cycleSMSEXEC.Click += new System.EventHandler(this.b_cycleSMSEXEC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Provider Logging Level";
            // 
            // cb_site_sqlLogging
            // 
            this.cb_site_sqlLogging.AutoSize = true;
            this.cb_site_sqlLogging.Location = new System.Drawing.Point(7, 20);
            this.cb_site_sqlLogging.Name = "cb_site_sqlLogging";
            this.cb_site_sqlLogging.Size = new System.Drawing.Size(88, 17);
            this.cb_site_sqlLogging.TabIndex = 14;
            this.cb_site_sqlLogging.Text = "SQL Logging";
            this.cb_site_sqlLogging.UseVisualStyleBackColor = true;
            this.cb_site_sqlLogging.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // cb_site_siteLogging
            // 
            this.cb_site_siteLogging.AutoSize = true;
            this.cb_site_siteLogging.Location = new System.Drawing.Point(7, 56);
            this.cb_site_siteLogging.Name = "cb_site_siteLogging";
            this.cb_site_siteLogging.Size = new System.Drawing.Size(85, 17);
            this.cb_site_siteLogging.TabIndex = 13;
            this.cb_site_siteLogging.Text = "Site Logging";
            this.cb_site_siteLogging.UseVisualStyleBackColor = true;
            this.cb_site_siteLogging.CheckedChanged += new System.EventHandler(this.cb_site_siteLogging_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "SQL Cache Logging Level";
            // 
            // cb_site_archiveLogs
            // 
            this.cb_site_archiveLogs.AutoSize = true;
            this.cb_site_archiveLogs.Location = new System.Drawing.Point(7, 38);
            this.cb_site_archiveLogs.Name = "cb_site_archiveLogs";
            this.cb_site_archiveLogs.Size = new System.Drawing.Size(88, 17);
            this.cb_site_archiveLogs.TabIndex = 15;
            this.cb_site_archiveLogs.Text = "Archive Logs";
            this.cb_site_archiveLogs.UseVisualStyleBackColor = true;
            this.cb_site_archiveLogs.CheckedChanged += new System.EventHandler(this.cb_site_archiveLogs_CheckedChanged);
            // 
            // num_provider_logsizeMb
            // 
            this.num_provider_logsizeMb.Location = new System.Drawing.Point(303, 82);
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
            this.num_provider_sqlcacheloggingLevel.Location = new System.Drawing.Point(303, 49);
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
            this.num_provider_loggingLevel.Location = new System.Drawing.Point(303, 19);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Provider Log Size (Mb)";
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem5);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 160);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "File";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1011, 107);
            this.ribbon1.TabIndex = 22;
            this.ribbon1.Tabs.Add(this.rt_Home);
            this.ribbon1.Tabs.Add(this.rt_Monitoring);
            this.ribbon1.Tabs.Add(this.rt_Trace);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            this.ribbon1.Click += new System.EventHandler(this.ribbon1_Click);
            // 
            // ribbonOrbMenuItem5
            // 
            this.ribbonOrbMenuItem5.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem5.Image")));
            this.ribbonOrbMenuItem5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem5.SmallImage")));
            this.ribbonOrbMenuItem5.Text = "Exit";
            this.ribbonOrbMenuItem5.Click += new System.EventHandler(this.ribbonOrbMenuItem5_Click);
            // 
            // rt_Home
            // 
            this.rt_Home.Panels.Add(this.ribbonPanel1);
            this.rt_Home.Panels.Add(this.ribbonPanel2);
            this.rt_Home.Panels.Add(this.ribbonPanel4);
            this.rt_Home.Panels.Add(this.ribbonPanel6);
            this.rt_Home.Text = "Home";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rb_scanLogs);
            this.ribbonPanel1.Items.Add(this.ribbonSeparator1);
            this.ribbonPanel1.Items.Add(this.rcb_remoteServer);
            this.ribbonPanel1.Text = "";
            // 
            // rb_scanLogs
            // 
            this.rb_scanLogs.Image = ((System.Drawing.Image)(resources.GetObject("rb_scanLogs.Image")));
            this.rb_scanLogs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_scanLogs.SmallImage")));
            this.rb_scanLogs.Text = "Scan";
            this.rb_scanLogs.ToolTip = "Click to scan device for Logs";
            this.rb_scanLogs.ToolTipTitle = "Scan Device";
            this.rb_scanLogs.Click += new System.EventHandler(this.rb_scanLogs_Click);
            // 
            // rcb_remoteServer
            // 
            this.rcb_remoteServer.Text = "Device";
            this.rcb_remoteServer.TextBoxText = "";
            this.rcb_remoteServer.ToolTip = "Device Name";
            this.rcb_remoteServer.ToolTipTitle = "Enter a device name";
            this.rcb_remoteServer.Value = "";
            this.rcb_remoteServer.TextBoxTextChanged += new System.EventHandler(this.rcb_remoteServer_TextBoxTextChanged);
            this.rcb_remoteServer.TextBoxValidated += new System.EventHandler(this.rcb_remoteServer_TextBoxValidated);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.rcb_hidearchiveLogs);
            this.ribbonPanel2.Items.Add(this.rcc_sortbyModified);
            this.ribbonPanel2.Items.Add(this.rcc_ignoreCRASHDUMP);
            this.ribbonPanel2.Text = "";
            // 
            // rcb_hidearchiveLogs
            // 
            this.rcb_hidearchiveLogs.Checked = true;
            this.rcb_hidearchiveLogs.Text = "Hide Archive Logs";
            this.rcb_hidearchiveLogs.ToolTip = "Hide logs ending in lo_, usually know as archive log files";
            this.rcb_hidearchiveLogs.CheckBoxCheckChanged += new System.EventHandler(this.rcb_hidearchiveLogs_CheckBoxCheckChanged);
            this.rcb_hidearchiveLogs.Click += new System.EventHandler(this.rcb_hidearchiveLogs_Click);
            // 
            // rcc_sortbyModified
            // 
            this.rcc_sortbyModified.Checked = true;
            this.rcc_sortbyModified.Text = "Auto Sort Logs";
            this.rcc_sortbyModified.ToolTip = "Sort logs on last modified date";
            this.rcc_sortbyModified.Click += new System.EventHandler(this.rcc_sortbyModified_Click);
            // 
            // rcc_ignoreCRASHDUMP
            // 
            this.rcc_ignoreCRASHDUMP.Checked = true;
            this.rcc_ignoreCRASHDUMP.Text = "Hide Crashdumps";
            this.rcc_ignoreCRASHDUMP.Click += new System.EventHandler(this.rcc_ignoreCRASHDUMP_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.rb_openLogs);
            this.ribbonPanel4.Items.Add(this.rb_refreshLogs);
            this.ribbonPanel4.Items.Add(this.rb_zipLogs);
            this.ribbonPanel4.Text = "";
            // 
            // rb_openLogs
            // 
            this.rb_openLogs.Image = ((System.Drawing.Image)(resources.GetObject("rb_openLogs.Image")));
            this.rb_openLogs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_openLogs.SmallImage")));
            this.rb_openLogs.Text = "Open";
            this.rb_openLogs.ToolTip = "Open the selected log(s)";
            this.rb_openLogs.ToolTipTitle = "Open Logs";
            this.rb_openLogs.Click += new System.EventHandler(this.rb_openLogs_Click);
            // 
            // rb_refreshLogs
            // 
            this.rb_refreshLogs.Image = ((System.Drawing.Image)(resources.GetObject("rb_refreshLogs.Image")));
            this.rb_refreshLogs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_refreshLogs.SmallImage")));
            this.rb_refreshLogs.Text = "Refresh";
            this.rb_refreshLogs.ToolTip = "Refresh visible logs";
            this.rb_refreshLogs.ToolTipTitle = "Refresh Logs";
            this.rb_refreshLogs.Click += new System.EventHandler(this.rb_refreshLogs_Click);
            // 
            // rb_zipLogs
            // 
            this.rb_zipLogs.DropDownItems.Add(this.rtb_zipselectedLogs);
            this.rb_zipLogs.DropDownItems.Add(this.rtb_zipselectedNode);
            this.rb_zipLogs.DropDownItems.Add(this.rtb_openzipFolder);
            this.rb_zipLogs.DropDownItems.Add(this.rtb_configurezipFolder);
            this.rb_zipLogs.Image = ((System.Drawing.Image)(resources.GetObject("rb_zipLogs.Image")));
            this.rb_zipLogs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_zipLogs.SmallImage")));
            this.rb_zipLogs.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.rb_zipLogs.Text = "Zip";
            this.rb_zipLogs.ToolTip = "Create ZIP Archive containing Logs";
            this.rb_zipLogs.ToolTipTitle = "Zip Log Files";
            // 
            // rtb_zipselectedLogs
            // 
            this.rtb_zipselectedLogs.AllowTextEdit = false;
            this.rtb_zipselectedLogs.Text = "ZIP selected Logs";
            this.rtb_zipselectedLogs.TextBoxText = "ZIP selected Logs";
            this.rtb_zipselectedLogs.ToolTip = "ZIP the currently selected Logs";
            this.rtb_zipselectedLogs.ToolTipTitle = "ZIP selected Logs";
            this.rtb_zipselectedLogs.Value = "ZIP selected Logs";
            this.rtb_zipselectedLogs.Click += new System.EventHandler(this.tsmi_zipselectedlogs_Click);
            // 
            // rtb_zipselectedNode
            // 
            this.rtb_zipselectedNode.AllowTextEdit = false;
            this.rtb_zipselectedNode.Text = "ZIP selected Node";
            this.rtb_zipselectedNode.TextBoxText = "ZIP selected Node";
            this.rtb_zipselectedNode.ToolTip = "ZIP the currently selected Node";
            this.rtb_zipselectedNode.ToolTipTitle = "ZIP selected Node";
            this.rtb_zipselectedNode.Value = "ZIP selected Node";
            this.rtb_zipselectedNode.Click += new System.EventHandler(this.tsmi_Ziplogs_Click);
            // 
            // rtb_openzipFolder
            // 
            this.rtb_openzipFolder.AllowTextEdit = false;
            this.rtb_openzipFolder.Text = "Open ZIP folder";
            this.rtb_openzipFolder.TextBoxText = "Open ZIP folder";
            this.rtb_openzipFolder.ToolTip = "Open the ZIP folder";
            this.rtb_openzipFolder.ToolTipTitle = "Open ZIP folder";
            this.rtb_openzipFolder.Value = "Open ZIP folder";
            this.rtb_openzipFolder.Click += new System.EventHandler(this.tsmi_openzipFolder_Click);
            // 
            // rtb_configurezipFolder
            // 
            this.rtb_configurezipFolder.AllowTextEdit = false;
            this.rtb_configurezipFolder.Text = "Configure ZIP";
            this.rtb_configurezipFolder.TextBoxText = "Configure ZIP";
            this.rtb_configurezipFolder.ToolTip = "Show the Configuration tab where the ZIP folder is configured";
            this.rtb_configurezipFolder.ToolTipTitle = "Configure ZIP Folder";
            this.rtb_configurezipFolder.Value = "Configure ZIP";
            this.rtb_configurezipFolder.Click += new System.EventHandler(this.rtb_configurezipFolder_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.rb_showLogs);
            this.ribbonPanel6.Items.Add(this.rb_customPaths);
            this.ribbonPanel6.Items.Add(this.rb_Logging);
            this.ribbonPanel6.Items.Add(this.rb_debugWindow);
            this.ribbonPanel6.Items.Add(this.rb_supportCenter);
            this.ribbonPanel6.Items.Add(this.rb_Help);
            this.ribbonPanel6.Text = "";
            // 
            // rb_showLogs
            // 
            this.rb_showLogs.Image = ((System.Drawing.Image)(resources.GetObject("rb_showLogs.Image")));
            this.rb_showLogs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_showLogs.SmallImage")));
            this.rb_showLogs.Text = "Logs";
            this.rb_showLogs.ToolTip = "View scanned Logs";
            this.rb_showLogs.ToolTipTitle = "Show the Log View";
            this.rb_showLogs.Value = "Logs";
            this.rb_showLogs.Click += new System.EventHandler(this.rb_showLogs_Click);
            // 
            // rb_customPaths
            // 
            this.rb_customPaths.Image = ((System.Drawing.Image)(resources.GetObject("rb_customPaths.Image")));
            this.rb_customPaths.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_customPaths.SmallImage")));
            this.rb_customPaths.Text = "Locations";
            this.rb_customPaths.ToolTip = "Extend built-in rules for scanning, by adding custom paths";
            this.rb_customPaths.ToolTipTitle = "Show Custom Locations";
            this.rb_customPaths.Click += new System.EventHandler(this.rb_customPaths_Click);
            // 
            // rb_Logging
            // 
            this.rb_Logging.Image = ((System.Drawing.Image)(resources.GetObject("rb_Logging.Image")));
            this.rb_Logging.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_Logging.SmallImage")));
            this.rb_Logging.Text = "Logging";
            this.rb_Logging.ToolTip = "Change Site and Client log settings";
            this.rb_Logging.ToolTipTitle = "Log Settings";
            this.rb_Logging.Value = "Logging";
            this.rb_Logging.Click += new System.EventHandler(this.rb_Logging_Click);
            // 
            // rb_debugWindow
            // 
            this.rb_debugWindow.Image = ((System.Drawing.Image)(resources.GetObject("rb_debugWindow.Image")));
            this.rb_debugWindow.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_debugWindow.SmallImage")));
            this.rb_debugWindow.Text = "Info";
            this.rb_debugWindow.ToolTip = "Show the Debug Window";
            this.rb_debugWindow.ToolTipTitle = "Debugging";
            this.rb_debugWindow.Click += new System.EventHandler(this.rb_debugWindow_Click);
            // 
            // rb_supportCenter
            // 
            this.rb_supportCenter.Image = ((System.Drawing.Image)(resources.GetObject("rb_supportCenter.Image")));
            this.rb_supportCenter.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_supportCenter.SmallImage")));
            this.rb_supportCenter.Text = "CMSC";
            this.rb_supportCenter.ToolTip = "Open Support Center";
            this.rb_supportCenter.ToolTipTitle = "Configuration Manager Support Center";
            this.rb_supportCenter.Visible = false;
            this.rb_supportCenter.Click += new System.EventHandler(this.rb_supportCenter_Click);
            // 
            // rb_Help
            // 
            this.rb_Help.Image = ((System.Drawing.Image)(resources.GetObject("rb_Help.Image")));
            this.rb_Help.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_Help.SmallImage")));
            this.rb_Help.Text = "Help";
            this.rb_Help.ToolTip = "Help on using LogLauncher";
            this.rb_Help.ToolTipTitle = "Help";
            this.rb_Help.Value = "Help";
            this.rb_Help.Click += new System.EventHandler(this.rb_Help_Click);
            // 
            // rt_Monitoring
            // 
            this.rt_Monitoring.Panels.Add(this.ribbonPanel3);
            this.rt_Monitoring.Text = "Monitoring";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.rb_Monitor);
            this.ribbonPanel3.Items.Add(this.ribbonSeparator3);
            this.ribbonPanel3.Items.Add(this.rup_Duration);
            this.ribbonPanel3.Items.Add(this.ribbonSeparator4);
            this.ribbonPanel3.Items.Add(this.rcc_Newest);
            this.ribbonPanel3.Items.Add(this.rcc_Oldest);
            this.ribbonPanel3.Text = "";
            // 
            // rb_Monitor
            // 
            this.rb_Monitor.Image = ((System.Drawing.Image)(resources.GetObject("rb_Monitor.Image")));
            this.rb_Monitor.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_Monitor.SmallImage")));
            this.rb_Monitor.Text = "Monitor";
            this.rb_Monitor.ToolTip = "Begin monitoring device Logs";
            this.rb_Monitor.Click += new System.EventHandler(this.rb_Monitor_Click);
            // 
            // rup_Duration
            // 
            this.rup_Duration.Text = "Refresh every (seconds) ";
            this.rup_Duration.TextBoxText = "5";
            this.rup_Duration.TextBoxWidth = 50;
            this.rup_Duration.ToolTip = "The frequency of monitoring in seconds";
            this.rup_Duration.Value = "5";
            this.rup_Duration.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.rup_Duration_UpButtonClicked);
            this.rup_Duration.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.rup_Duration_DownButtonClicked);
            this.rup_Duration.TextBoxValidated += new System.EventHandler(this.rup_Duration_TextBoxValidated);
            // 
            // rcc_Newest
            // 
            this.rcc_Newest.Color = System.Drawing.Color.Transparent;
            this.rcc_Newest.Image = ((System.Drawing.Image)(resources.GetObject("rcc_Newest.Image")));
            this.rcc_Newest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rcc_Newest.SmallImage")));
            this.rcc_Newest.Text = "Newest";
            this.rcc_Newest.ToolTip = "The color to mark most recently modified files";
            this.rcc_Newest.Click += new System.EventHandler(this.rcc_Newest_Click);
            // 
            // rcc_Oldest
            // 
            this.rcc_Oldest.Color = System.Drawing.Color.Transparent;
            this.rcc_Oldest.Image = ((System.Drawing.Image)(resources.GetObject("rcc_Oldest.Image")));
            this.rcc_Oldest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rcc_Oldest.SmallImage")));
            this.rcc_Oldest.Text = "Oldest";
            this.rcc_Oldest.ToolTip = "The color to mark logs that have been modified in this monitoring session, but ha" +
    "ve not been modified since";
            this.rcc_Oldest.Click += new System.EventHandler(this.rcc_Oldest_Click);
            // 
            // rt_Trace
            // 
            this.rt_Trace.Panels.Add(this.ribbonPanel7);
            this.rt_Trace.Panels.Add(this.ribbonPanel8);
            this.rt_Trace.Panels.Add(this.ribbonPanel5);
            this.rt_Trace.Text = "Configuration";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Items.Add(this.rtb_tracerPath);
            this.ribbonPanel7.Items.Add(this.rb_tracerFind);
            this.ribbonPanel7.Text = "Tracer";
            // 
            // rtb_tracerPath
            // 
            this.rtb_tracerPath.Text = "Path";
            this.rtb_tracerPath.TextBoxText = "";
            this.rtb_tracerPath.TextBoxWidth = 400;
            this.rtb_tracerPath.ToolTip = "The full path to your chosen Tracer tool";
            // 
            // rb_tracerFind
            // 
            this.rb_tracerFind.Image = ((System.Drawing.Image)(resources.GetObject("rb_tracerFind.Image")));
            this.rb_tracerFind.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_tracerFind.SmallImage")));
            this.rb_tracerFind.Text = "Find";
            this.rb_tracerFind.ToolTip = "Find a Tracer to use when opening Logs";
            this.rb_tracerFind.Value = "...";
            this.rb_tracerFind.Click += new System.EventHandler(this.rb_tracerFind_Click);
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.Items.Add(this.rcb_MultiMerge);
            this.ribbonPanel8.Text = "Tracer Config";
            // 
            // rcb_MultiMerge
            // 
            this.rcb_MultiMerge.Text = "Merge\\Multiple";
            this.rcb_MultiMerge.ToolTip = "Open multiple log files in your chosen tracer, merged if supported, or as multipl" +
    "e windows (Note there is no automation for Merge in CMTrace but there is in CMLo" +
    "gViewer)";
            this.rcb_MultiMerge.CheckBoxCheckChanged += new System.EventHandler(this.rcb_MultiMerge_CheckBoxCheckChanged);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.rtb_zipoutputDirectory);
            this.ribbonPanel5.Items.Add(this.rb_zipoutputdirectorySelect);
            this.ribbonPanel5.Text = "Zip Config";
            // 
            // rtb_zipoutputDirectory
            // 
            this.rtb_zipoutputDirectory.Text = "ZIP Destination";
            this.rtb_zipoutputDirectory.TextBoxText = "";
            this.rtb_zipoutputDirectory.TextBoxWidth = 200;
            this.rtb_zipoutputDirectory.TextBoxTextChanged += new System.EventHandler(this.rtb_zipoutputDirectory_TextBoxTextChanged);
            this.rtb_zipoutputDirectory.TextBoxValidated += new System.EventHandler(this.rtb_zipoutputDirectory_TextBoxValidated);
            // 
            // rb_zipoutputdirectorySelect
            // 
            this.rb_zipoutputdirectorySelect.Image = ((System.Drawing.Image)(resources.GetObject("rb_zipoutputdirectorySelect.Image")));
            this.rb_zipoutputdirectorySelect.SmallImage = ((System.Drawing.Image)(resources.GetObject("rb_zipoutputdirectorySelect.SmallImage")));
            this.rb_zipoutputdirectorySelect.Text = "Select";
            this.rb_zipoutputdirectorySelect.Click += new System.EventHandler(this.rb_zipoutputdirectorySelect_Click);
            // 
            // ribbonOrbRecentItem1
            // 
            this.ribbonOrbRecentItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.Image")));
            this.ribbonOrbRecentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.SmallImage")));
            this.ribbonOrbRecentItem1.Text = "ribbonOrbRecentItem1";
            // 
            // ribbonOrbRecentItem2
            // 
            this.ribbonOrbRecentItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem2.Image")));
            this.ribbonOrbRecentItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem2.SmallImage")));
            this.ribbonOrbRecentItem2.Text = "ribbonOrbRecentItem2";
            // 
            // ribbonOrbRecentItem3
            // 
            this.ribbonOrbRecentItem3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem3.Image")));
            this.ribbonOrbRecentItem3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem3.SmallImage")));
            this.ribbonOrbRecentItem3.Text = "ribbonOrbRecentItem3";
            // 
            // ribbonOrbRecentItem4
            // 
            this.ribbonOrbRecentItem4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem4.Image")));
            this.ribbonOrbRecentItem4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem4.SmallImage")));
            this.ribbonOrbRecentItem4.Text = "ribbonOrbRecentItem4";
            // 
            // ribbonOrbRecentItem5
            // 
            this.ribbonOrbRecentItem5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem5.Image")));
            this.ribbonOrbRecentItem5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem5.SmallImage")));
            this.ribbonOrbRecentItem5.Text = "ribbonOrbRecentItem5";
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.DropDownItems.Add(this.ribbonButton1);
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Exit";
            // 
            // ribbonOrbMenuItem2
            // 
            this.ribbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.Image")));
            this.ribbonOrbMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.SmallImage")));
            this.ribbonOrbMenuItem2.Text = "ribbonOrbMenuItem2";
            // 
            // panel_Logs
            // 
            this.panel_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Logs.Controls.Add(this.splitContainer1);
            this.panel_Logs.Location = new System.Drawing.Point(2, 108);
            this.panel_Logs.Name = "panel_Logs";
            this.panel_Logs.Size = new System.Drawing.Size(1009, 509);
            this.panel_Logs.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pb_pinSlider);
            this.splitContainer1.Panel1.Controls.Add(this.pb_snapOut);
            this.splitContainer1.Panel1.Controls.Add(this.tv_Logs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Logs);
            this.splitContainer1.Size = new System.Drawing.Size(1009, 506);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 11;
            // 
            // pb_pinSlider
            // 
            this.pb_pinSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_pinSlider.Location = new System.Drawing.Point(196, 1);
            this.pb_pinSlider.Name = "pb_pinSlider";
            this.pb_pinSlider.Size = new System.Drawing.Size(15, 14);
            this.pb_pinSlider.TabIndex = 3;
            this.pb_pinSlider.TabStop = false;
            this.pb_pinSlider.Click += new System.EventHandler(this.pb_Test_Click);
            // 
            // pb_snapOut
            // 
            this.pb_snapOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_snapOut.BackColor = System.Drawing.SystemColors.Info;
            this.pb_snapOut.Location = new System.Drawing.Point(3, 0);
            this.pb_snapOut.Name = "pb_snapOut";
            this.pb_snapOut.Size = new System.Drawing.Size(23, 503);
            this.pb_snapOut.TabIndex = 1;
            this.pb_snapOut.TabStop = false;
            this.pb_snapOut.Visible = false;
            this.pb_snapOut.MouseEnter += new System.EventHandler(this.pb_snapOut_MouseEnter);
            // 
            // rtb_Help
            // 
            this.rtb_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Help.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_Help.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Help.Location = new System.Drawing.Point(7, 3);
            this.rtb_Help.Name = "rtb_Help";
            this.rtb_Help.ReadOnly = true;
            this.rtb_Help.Size = new System.Drawing.Size(999, 500);
            this.rtb_Help.TabIndex = 0;
            this.rtb_Help.Text = "";
            this.rtb_Help.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb_Help_LinkClicked);
            // 
            // b_deleteLocation
            // 
            this.b_deleteLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_deleteLocation.Location = new System.Drawing.Point(810, 474);
            this.b_deleteLocation.Name = "b_deleteLocation";
            this.b_deleteLocation.Size = new System.Drawing.Size(75, 23);
            this.b_deleteLocation.TabIndex = 20;
            this.b_deleteLocation.TabStop = false;
            this.b_deleteLocation.Text = "Delete";
            this.b_deleteLocation.UseVisualStyleBackColor = true;
            this.b_deleteLocation.Click += new System.EventHandler(this.b_deleteLocation_Click);
            // 
            // b_addupdateLocation
            // 
            this.b_addupdateLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_addupdateLocation.Location = new System.Drawing.Point(684, 474);
            this.b_addupdateLocation.Name = "b_addupdateLocation";
            this.b_addupdateLocation.Size = new System.Drawing.Size(107, 23);
            this.b_addupdateLocation.TabIndex = 19;
            this.b_addupdateLocation.Text = "Add / Update";
            this.b_addupdateLocation.UseVisualStyleBackColor = true;
            this.b_addupdateLocation.Click += new System.EventHandler(this.b_addupdateLocation_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Log Product";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Log Category";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Recurse Folder";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "File Mask - Example *.lo_";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(372, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Custom Location (No UNC, C:\\TEMP or for Share use SHARENAME:\\PATH)";
            // 
            // cb_recurseFolder
            // 
            this.cb_recurseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_recurseFolder.FormattingEnabled = true;
            this.cb_recurseFolder.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cb_recurseFolder.Location = new System.Drawing.Point(158, 473);
            this.cb_recurseFolder.Name = "cb_recurseFolder";
            this.cb_recurseFolder.Size = new System.Drawing.Size(76, 21);
            this.cb_recurseFolder.TabIndex = 18;
            this.cb_recurseFolder.Text = "False";
            // 
            // tb_logProduct
            // 
            this.tb_logProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_logProduct.Location = new System.Drawing.Point(439, 421);
            this.tb_logProduct.Name = "tb_logProduct";
            this.tb_logProduct.Size = new System.Drawing.Size(446, 20);
            this.tb_logProduct.TabIndex = 16;
            // 
            // tb_logCategory
            // 
            this.tb_logCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_logCategory.Location = new System.Drawing.Point(10, 421);
            this.tb_logCategory.Name = "tb_logCategory";
            this.tb_logCategory.Size = new System.Drawing.Size(423, 20);
            this.tb_logCategory.TabIndex = 15;
            // 
            // tb_fileMask
            // 
            this.tb_fileMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_fileMask.Location = new System.Drawing.Point(13, 474);
            this.tb_fileMask.Name = "tb_fileMask";
            this.tb_fileMask.Size = new System.Drawing.Size(122, 20);
            this.tb_fileMask.TabIndex = 17;
            // 
            // tb_customLocation
            // 
            this.tb_customLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_customLocation.Location = new System.Drawing.Point(13, 366);
            this.tb_customLocation.Name = "tb_customLocation";
            this.tb_customLocation.Size = new System.Drawing.Size(872, 20);
            this.tb_customLocation.TabIndex = 14;
            // 
            // dgv_customLocations
            // 
            this.dgv_customLocations.AllowUserToAddRows = false;
            this.dgv_customLocations.AllowUserToDeleteRows = false;
            this.dgv_customLocations.AllowUserToOrderColumns = true;
            this.dgv_customLocations.AllowUserToResizeColumns = false;
            this.dgv_customLocations.AllowUserToResizeRows = false;
            this.dgv_customLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_customLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_customLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_cust_customLocation,
            this.c_cust_fileMask,
            this.c_cust_recurseFolder,
            this.c_cust_logClass,
            this.c_cust_logProduct});
            this.dgv_customLocations.Location = new System.Drawing.Point(0, 0);
            this.dgv_customLocations.MultiSelect = false;
            this.dgv_customLocations.Name = "dgv_customLocations";
            this.dgv_customLocations.ReadOnly = true;
            this.dgv_customLocations.RowHeadersVisible = false;
            this.dgv_customLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_customLocations.Size = new System.Drawing.Size(1006, 335);
            this.dgv_customLocations.TabIndex = 13;
            this.dgv_customLocations.SelectionChanged += new System.EventHandler(this.dgv_customLocations_SelectionChanged);
            // 
            // c_cust_customLocation
            // 
            this.c_cust_customLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_cust_customLocation.HeaderText = "Custom Location";
            this.c_cust_customLocation.Name = "c_cust_customLocation";
            this.c_cust_customLocation.ReadOnly = true;
            this.c_cust_customLocation.Width = 102;
            // 
            // c_cust_fileMask
            // 
            this.c_cust_fileMask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_cust_fileMask.HeaderText = "File Mask";
            this.c_cust_fileMask.Name = "c_cust_fileMask";
            this.c_cust_fileMask.ReadOnly = true;
            this.c_cust_fileMask.Width = 71;
            // 
            // c_cust_recurseFolder
            // 
            this.c_cust_recurseFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_cust_recurseFolder.HeaderText = "Recurse Folder";
            this.c_cust_recurseFolder.Name = "c_cust_recurseFolder";
            this.c_cust_recurseFolder.ReadOnly = true;
            this.c_cust_recurseFolder.Width = 96;
            // 
            // c_cust_logClass
            // 
            this.c_cust_logClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.c_cust_logClass.HeaderText = "Log Category";
            this.c_cust_logClass.Name = "c_cust_logClass";
            this.c_cust_logClass.ReadOnly = true;
            this.c_cust_logClass.Width = 87;
            // 
            // c_cust_logProduct
            // 
            this.c_cust_logProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_cust_logProduct.HeaderText = "Log Product";
            this.c_cust_logProduct.Name = "c_cust_logProduct";
            this.c_cust_logProduct.ReadOnly = true;
            // 
            // panel_Help
            // 
            this.panel_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Help.Controls.Add(this.rtb_Help);
            this.panel_Help.Location = new System.Drawing.Point(2, 108);
            this.panel_Help.Name = "panel_Help";
            this.panel_Help.Size = new System.Drawing.Size(1009, 506);
            this.panel_Help.TabIndex = 24;
            // 
            // panel_customLocations
            // 
            this.panel_customLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_customLocations.Controls.Add(this.b_deleteLocation);
            this.panel_customLocations.Controls.Add(this.dgv_customLocations);
            this.panel_customLocations.Controls.Add(this.b_addupdateLocation);
            this.panel_customLocations.Controls.Add(this.label1);
            this.panel_customLocations.Controls.Add(this.tb_customLocation);
            this.panel_customLocations.Controls.Add(this.label2);
            this.panel_customLocations.Controls.Add(this.tb_fileMask);
            this.panel_customLocations.Controls.Add(this.label9);
            this.panel_customLocations.Controls.Add(this.label11);
            this.panel_customLocations.Controls.Add(this.cb_recurseFolder);
            this.panel_customLocations.Controls.Add(this.label10);
            this.panel_customLocations.Controls.Add(this.tb_logProduct);
            this.panel_customLocations.Controls.Add(this.tb_logCategory);
            this.panel_customLocations.Location = new System.Drawing.Point(2, 108);
            this.panel_customLocations.Name = "panel_customLocations";
            this.panel_customLocations.Size = new System.Drawing.Size(1009, 509);
            this.panel_customLocations.TabIndex = 25;
            // 
            // panel_Diagnostics
            // 
            this.panel_Diagnostics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Diagnostics.Controls.Add(this.dgv_Diagnostics);
            this.panel_Diagnostics.Location = new System.Drawing.Point(2, 108);
            this.panel_Diagnostics.Name = "panel_Diagnostics";
            this.panel_Diagnostics.Size = new System.Drawing.Size(1009, 506);
            this.panel_Diagnostics.TabIndex = 26;
            // 
            // ribbonOrbMenuItem3
            // 
            this.ribbonOrbMenuItem3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.Image")));
            this.ribbonOrbMenuItem3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.SmallImage")));
            this.ribbonOrbMenuItem3.Text = "ribbonOrbMenuItem3";
            // 
            // ribbonOrbRecentItem6
            // 
            this.ribbonOrbRecentItem6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem6.Image")));
            this.ribbonOrbRecentItem6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem6.SmallImage")));
            this.ribbonOrbRecentItem6.Text = "ribbonOrbRecentItem6";
            // 
            // ribbonOrbRecentItem7
            // 
            this.ribbonOrbRecentItem7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem7.Image")));
            this.ribbonOrbRecentItem7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem7.SmallImage")));
            this.ribbonOrbRecentItem7.Text = "ribbonOrbRecentItem7";
            // 
            // ribbonOrbRecentItem8
            // 
            this.ribbonOrbRecentItem8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem8.Image")));
            this.ribbonOrbRecentItem8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem8.SmallImage")));
            this.ribbonOrbRecentItem8.Text = "ribbonOrbRecentItem8";
            // 
            // ribbonOrbRecentItem9
            // 
            this.ribbonOrbRecentItem9.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem9.Image")));
            this.ribbonOrbRecentItem9.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem9.SmallImage")));
            this.ribbonOrbRecentItem9.Text = "ribbonOrbRecentItem9";
            // 
            // ribbonOrbMenuItem4
            // 
            this.ribbonOrbMenuItem4.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem4.Image")));
            this.ribbonOrbMenuItem4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem4.SmallImage")));
            this.ribbonOrbMenuItem4.Text = "ribbonOrbMenuItem4";
            // 
            // tsmi_monitorNode
            // 
            this.tsmi_monitorNode.Name = "tsmi_monitorNode";
            this.tsmi_monitorNode.Size = new System.Drawing.Size(210, 22);
            this.tsmi_monitorNode.Text = "Monitor Node";
            this.tsmi_monitorNode.Click += new System.EventHandler(this.tsmi_monitorNode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1011, 642);
            this.Controls.Add(this.panel_Logging);
            this.Controls.Add(this.panel_Logs);
            this.Controls.Add(this.panel_Help);
            this.Controls.Add(this.panel_Diagnostics);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel_customLocations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(949, 681);
            this.Name = "Form1";
            this.Text = "Log Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diagnostics)).EndInit();
            this.panel_Logging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logging)).EndInit();
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
            this.panel_Logs.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_pinSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_snapOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customLocations)).EndInit();
            this.panel_Help.ResumeLayout(false);
            this.panel_customLocations.ResumeLayout(false);
            this.panel_customLocations.PerformLayout();
            this.panel_Diagnostics.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Logs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView dgv_Logs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openLogFolder;
        private System.Windows.Forms.DataGridView dgv_Diagnostics;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_dgvDiag_Diagnostics;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openlogorLogs;
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
        private System.Windows.Forms.Panel panel_Logging;
        private System.Windows.Forms.DataGridView dgv_Logging;
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
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rt_Home;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rb_scanLogs;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonComboBox rcb_remoteServer;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonCheckBox rcb_hidearchiveLogs;
        private System.Windows.Forms.RibbonTab rt_Monitoring;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rb_Monitor;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonUpDown rup_Duration;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonColorChooser rcc_Newest;
        private System.Windows.Forms.RibbonColorChooser rcc_Oldest;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton rb_openLogs;
        private System.Windows.Forms.RibbonButton rb_refreshLogs;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton rb_debugWindow;
        private System.Windows.Forms.RibbonButton rb_customPaths;
        private System.Windows.Forms.RibbonButton rb_Help;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem1;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem2;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem3;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem4;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem5;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.Panel panel_Logs;
        private System.Windows.Forms.RichTextBox rtb_Help;
        private System.Windows.Forms.Button b_deleteLocation;
        private System.Windows.Forms.Button b_addupdateLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_recurseFolder;
        private System.Windows.Forms.TextBox tb_logProduct;
        private System.Windows.Forms.TextBox tb_logCategory;
        private System.Windows.Forms.TextBox tb_fileMask;
        private System.Windows.Forms.TextBox tb_customLocation;
        private System.Windows.Forms.DataGridView dgv_customLocations;
        private System.Windows.Forms.RibbonTab rt_Trace;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonCheckBox rcb_MultiMerge;
        private System.Windows.Forms.RibbonTextBox rtb_tracerPath;
        private System.Windows.Forms.RibbonButton rb_showLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_customLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_fileMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_recurseFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_logClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_logProduct;
        private System.Windows.Forms.RibbonButton rb_supportCenter;
        private System.Windows.Forms.RibbonButton rb_Logging;
        private System.Windows.Forms.Panel panel_customLocations;
        private System.Windows.Forms.Panel panel_Help;
        private System.Windows.Forms.Panel panel_Diagnostics;
        private System.Windows.Forms.RibbonButton rb_tracerFind;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem3;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem6;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem7;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem8;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem9;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem4;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator5;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator6;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator7;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem5;
        private System.Windows.Forms.RibbonCheckBox rcc_sortbyModified;
        private System.Windows.Forms.RibbonCheckBox rcc_ignoreCRASHDUMP;
        private System.Windows.Forms.PictureBox pb_snapOut;
        private System.Windows.Forms.PictureBox pb_pinSlider;
        private System.Windows.Forms.ToolStripProgressBar tspb_Monitoring;
        private System.Windows.Forms.RibbonButton rb_zipLogs;
        private System.Windows.Forms.ToolStripMenuItem tsmi_zipselectedlogs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Ziplogs;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonTextBox rtb_zipoutputDirectory;
        private System.Windows.Forms.RibbonButton rb_zipoutputdirectorySelect;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openzipFolder;
        private System.Windows.Forms.ToolStripProgressBar tspb_zipfileCount;
        private System.Windows.Forms.ToolStripProgressBar tspb_zipfileProgress;
        private System.Windows.Forms.ToolStripMenuItem openZIPFolderToolStripMenuItem;
        private System.Windows.Forms.RibbonTextBox rtb_zipselectedLogs;
        private System.Windows.Forms.RibbonTextBox rtb_zipselectedNode;
        private System.Windows.Forms.RibbonTextBox rtb_openzipFolder;
        private System.Windows.Forms.RibbonTextBox rtb_configurezipFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmi_monitorNode;
    }
}

