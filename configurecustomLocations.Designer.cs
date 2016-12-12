namespace LogLauncher
{
    partial class configurecustomLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configurecustomLocations));
            this.dgv_customLocations = new System.Windows.Forms.DataGridView();
            this.c_cust_customLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_fileMask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_recurseFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_logClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cust_logProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_customLocation = new System.Windows.Forms.TextBox();
            this.tb_fileMask = new System.Windows.Forms.TextBox();
            this.tb_logCategory = new System.Windows.Forms.TextBox();
            this.tb_logProduct = new System.Windows.Forms.TextBox();
            this.cb_recurseFolder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.b_addupdateLocation = new System.Windows.Forms.Button();
            this.b_deleteLocation = new System.Windows.Forms.Button();
            this.b_Close = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customLocations)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_customLocations
            // 
            this.dgv_customLocations.AllowUserToAddRows = false;
            this.dgv_customLocations.AllowUserToDeleteRows = false;
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
            this.dgv_customLocations.Location = new System.Drawing.Point(12, 12);
            this.dgv_customLocations.MultiSelect = false;
            this.dgv_customLocations.Name = "dgv_customLocations";
            this.dgv_customLocations.ReadOnly = true;
            this.dgv_customLocations.RowHeadersVisible = false;
            this.dgv_customLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_customLocations.Size = new System.Drawing.Size(537, 151);
            this.dgv_customLocations.TabIndex = 0;
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
            this.c_cust_fileMask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_cust_fileMask.HeaderText = "File Mask";
            this.c_cust_fileMask.Name = "c_cust_fileMask";
            this.c_cust_fileMask.ReadOnly = true;
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
            // tb_customLocation
            // 
            this.tb_customLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_customLocation.Location = new System.Drawing.Point(12, 195);
            this.tb_customLocation.Name = "tb_customLocation";
            this.tb_customLocation.Size = new System.Drawing.Size(537, 20);
            this.tb_customLocation.TabIndex = 1;
            // 
            // tb_fileMask
            // 
            this.tb_fileMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_fileMask.Location = new System.Drawing.Point(12, 256);
            this.tb_fileMask.Name = "tb_fileMask";
            this.tb_fileMask.Size = new System.Drawing.Size(429, 20);
            this.tb_fileMask.TabIndex = 2;
            // 
            // tb_logCategory
            // 
            this.tb_logCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_logCategory.Location = new System.Drawing.Point(12, 310);
            this.tb_logCategory.Name = "tb_logCategory";
            this.tb_logCategory.Size = new System.Drawing.Size(237, 20);
            this.tb_logCategory.TabIndex = 4;
            // 
            // tb_logProduct
            // 
            this.tb_logProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_logProduct.Location = new System.Drawing.Point(273, 310);
            this.tb_logProduct.Name = "tb_logProduct";
            this.tb_logProduct.Size = new System.Drawing.Size(276, 20);
            this.tb_logProduct.TabIndex = 5;
            // 
            // cb_recurseFolder
            // 
            this.cb_recurseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_recurseFolder.FormattingEnabled = true;
            this.cb_recurseFolder.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cb_recurseFolder.Location = new System.Drawing.Point(465, 255);
            this.cb_recurseFolder.Name = "cb_recurseFolder";
            this.cb_recurseFolder.Size = new System.Drawing.Size(84, 21);
            this.cb_recurseFolder.TabIndex = 3;
            this.cb_recurseFolder.Text = "False";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Custom Location (No UNC)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "File Mask - Example *.lo_";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Recurse Folder";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Log Category";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Log Product";
            // 
            // b_addupdateLocation
            // 
            this.b_addupdateLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_addupdateLocation.Location = new System.Drawing.Point(12, 342);
            this.b_addupdateLocation.Name = "b_addupdateLocation";
            this.b_addupdateLocation.Size = new System.Drawing.Size(107, 23);
            this.b_addupdateLocation.TabIndex = 6;
            this.b_addupdateLocation.Text = "Add / Update";
            this.b_addupdateLocation.UseVisualStyleBackColor = true;
            this.b_addupdateLocation.Click += new System.EventHandler(this.b_addupdateLocation_Click);
            // 
            // b_deleteLocation
            // 
            this.b_deleteLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_deleteLocation.Location = new System.Drawing.Point(146, 342);
            this.b_deleteLocation.Name = "b_deleteLocation";
            this.b_deleteLocation.Size = new System.Drawing.Size(75, 23);
            this.b_deleteLocation.TabIndex = 12;
            this.b_deleteLocation.TabStop = false;
            this.b_deleteLocation.Text = "Delete";
            this.b_deleteLocation.UseVisualStyleBackColor = true;
            this.b_deleteLocation.Click += new System.EventHandler(this.b_deleteLocation_Click);
            // 
            // b_Close
            // 
            this.b_Close.Location = new System.Drawing.Point(474, 342);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(75, 23);
            this.b_Close.TabIndex = 7;
            this.b_Close.Text = "Close";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(561, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // configurecustomLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 395);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.b_deleteLocation);
            this.Controls.Add(this.b_addupdateLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_recurseFolder);
            this.Controls.Add(this.tb_logProduct);
            this.Controls.Add(this.tb_logCategory);
            this.Controls.Add(this.tb_fileMask);
            this.Controls.Add(this.tb_customLocation);
            this.Controls.Add(this.dgv_customLocations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(577, 434);
            this.MinimumSize = new System.Drawing.Size(577, 434);
            this.Name = "configurecustomLocations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Locations";
            this.Load += new System.EventHandler(this.configurecustomLocations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customLocations)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_customLocations;
        private System.Windows.Forms.TextBox tb_customLocation;
        private System.Windows.Forms.TextBox tb_fileMask;
        private System.Windows.Forms.TextBox tb_logCategory;
        private System.Windows.Forms.TextBox tb_logProduct;
        private System.Windows.Forms.ComboBox cb_recurseFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_addupdateLocation;
        private System.Windows.Forms.Button b_deleteLocation;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_customLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_fileMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_recurseFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_logClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cust_logProduct;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}