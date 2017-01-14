namespace LogLauncher
{
    partial class aboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutForm));
            this.rtb_helpContent = new System.Windows.Forms.RichTextBox();
            this.b_Close = new System.Windows.Forms.Button();
            this.b_loadRTF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_helpContent
            // 
            this.rtb_helpContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_helpContent.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_helpContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_helpContent.Location = new System.Drawing.Point(12, 12);
            this.rtb_helpContent.Name = "rtb_helpContent";
            this.rtb_helpContent.Size = new System.Drawing.Size(543, 484);
            this.rtb_helpContent.TabIndex = 0;
            this.rtb_helpContent.Text = "";
            // 
            // b_Close
            // 
            this.b_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_Close.Location = new System.Drawing.Point(480, 487);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(75, 23);
            this.b_Close.TabIndex = 1;
            this.b_Close.Text = "Close";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
            // 
            // b_loadRTF
            // 
            this.b_loadRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_loadRTF.Enabled = false;
            this.b_loadRTF.Location = new System.Drawing.Point(383, 487);
            this.b_loadRTF.Name = "b_loadRTF";
            this.b_loadRTF.Size = new System.Drawing.Size(75, 23);
            this.b_loadRTF.TabIndex = 2;
            this.b_loadRTF.Text = "Load RTF file";
            this.b_loadRTF.UseVisualStyleBackColor = true;
            this.b_loadRTF.Visible = false;
            this.b_loadRTF.Click += new System.EventHandler(this.button1_Click);
            // 
            // aboutForm
            // 
            this.AcceptButton = this.b_Close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Close;
            this.ClientSize = new System.Drawing.Size(567, 522);
            this.ControlBox = false;
            this.Controls.Add(this.b_loadRTF);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.rtb_helpContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(583, 561);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(583, 561);
            this.Name = "aboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About LogLauncher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_helpContent;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.Button b_loadRTF;
    }
}