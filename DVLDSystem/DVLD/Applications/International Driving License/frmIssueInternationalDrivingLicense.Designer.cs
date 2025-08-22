namespace DVLDSystem.DVLD.Applications.International_Driving_License
{
    partial class frmIssueInternationalDrivingLicense
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
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnIssueInternationalDrivingLicense = new System.Windows.Forms.Button();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlInternationalDrivingLicenseApplicationCard1 = new DVLDSystem.DVLD.Applications.International_Driving_License.Controls.ctrlInternationalDrivingLicenseApplicationCard();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(371, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(552, 35);
            this.label3.TabIndex = 41;
            this.label3.Text = "International Driving License Applications";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(933, 935);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 217;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnIssueInternationalDrivingLicense
            // 
            this.btnIssueInternationalDrivingLicense.BackColor = System.Drawing.Color.White;
            this.btnIssueInternationalDrivingLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueInternationalDrivingLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueInternationalDrivingLicense.Image = global::DVLDSystem.Properties.Resources.International_322;
            this.btnIssueInternationalDrivingLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueInternationalDrivingLicense.Location = new System.Drawing.Point(1114, 935);
            this.btnIssueInternationalDrivingLicense.Name = "btnIssueInternationalDrivingLicense";
            this.btnIssueInternationalDrivingLicense.Size = new System.Drawing.Size(161, 47);
            this.btnIssueInternationalDrivingLicense.TabIndex = 216;
            this.btnIssueInternationalDrivingLicense.Text = "Issue";
            this.btnIssueInternationalDrivingLicense.UseVisualStyleBackColor = false;
            this.btnIssueInternationalDrivingLicense.Click += new System.EventHandler(this.btnIssueInternationalDrivingLicense_Click);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.LinkColor = System.Drawing.Color.Blue;
            this.llShowLicenseHistory.Location = new System.Drawing.Point(56, 937);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(147, 17);
            this.llShowLicenseHistory.TabIndex = 219;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History.";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseInfo.LinkColor = System.Drawing.Color.Blue;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(246, 937);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(126, 17);
            this.llShowLicenseInfo.TabIndex = 220;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show License Info.";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // ctrlInternationalDrivingLicenseApplicationCard1
            // 
            this.ctrlInternationalDrivingLicenseApplicationCard1.BackColor = System.Drawing.Color.White;
            this.ctrlInternationalDrivingLicenseApplicationCard1.Location = new System.Drawing.Point(10, 68);
            this.ctrlInternationalDrivingLicenseApplicationCard1.Name = "ctrlInternationalDrivingLicenseApplicationCard1";
            this.ctrlInternationalDrivingLicenseApplicationCard1.Size = new System.Drawing.Size(1275, 861);
            this.ctrlInternationalDrivingLicenseApplicationCard1.TabIndex = 218;
            // 
            // frmIssueInternationalDrivingLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1297, 990);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.ctrlInternationalDrivingLicenseApplicationCard1);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnIssueInternationalDrivingLicense);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmIssueInternationalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue International  Driving License";
            this.Activated += new System.EventHandler(this.frmIssueInternationalDrivingLicense_Activated);
            this.Load += new System.EventHandler(this.frmIssueInternationalDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnIssueInternationalDrivingLicense;
        private Controls.ctrlInternationalDrivingLicenseApplicationCard ctrlInternationalDrivingLicenseApplicationCard1;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
    }
}