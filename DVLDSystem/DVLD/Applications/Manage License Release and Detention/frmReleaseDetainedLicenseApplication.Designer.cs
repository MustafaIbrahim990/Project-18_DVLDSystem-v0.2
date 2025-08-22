namespace DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention
{
    partial class frmReleaseDetainedLicenseApplication
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
            this.label3 = new System.Windows.Forms.Label();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.ctrlReleaseDetainedLicenseApplication1 = new DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention.Controls.ctrlReleaseDetainedLicenseApplication();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(478, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 35);
            this.label3.TabIndex = 44;
            this.label3.Text = "Release Detained License";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseInfo.LinkColor = System.Drawing.Color.Blue;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(229, 884);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(126, 17);
            this.llShowLicenseInfo.TabIndex = 48;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show License Info.";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.LinkColor = System.Drawing.Color.Blue;
            this.llShowLicenseHistory.Location = new System.Drawing.Point(39, 884);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(147, 17);
            this.llShowLicenseHistory.TabIndex = 47;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History.";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(930, 886);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 49;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.BackColor = System.Drawing.Color.White;
            this.btnReleaseDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseDetainedLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReleaseDetainedLicense.Image = global::DVLDSystem.Properties.Resources.Release_Detained_License_321;
            this.btnReleaseDetainedLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(1111, 886);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(161, 47);
            this.btnReleaseDetainedLicense.TabIndex = 46;
            this.btnReleaseDetainedLicense.Text = "Release";
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = false;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // ctrlReleaseDetainedLicenseApplication1
            // 
            this.ctrlReleaseDetainedLicenseApplication1.BackColor = System.Drawing.Color.White;
            this.ctrlReleaseDetainedLicenseApplication1.Location = new System.Drawing.Point(10, 65);
            this.ctrlReleaseDetainedLicenseApplication1.Name = "ctrlReleaseDetainedLicenseApplication1";
            this.ctrlReleaseDetainedLicenseApplication1.Size = new System.Drawing.Size(1275, 813);
            this.ctrlReleaseDetainedLicenseApplication1.TabIndex = 45;
            // 
            // frmReleaseDetainedLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1297, 947);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.ctrlReleaseDetainedLicenseApplication1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseDetainedLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Detained License Application";
            this.Activated += new System.EventHandler(this.frmReleaseDetainedLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicenseApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Controls.ctrlReleaseDetainedLicenseApplication ctrlReleaseDetainedLicenseApplication1;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
    }
}