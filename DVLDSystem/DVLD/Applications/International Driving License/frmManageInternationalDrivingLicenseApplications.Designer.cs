namespace DVLDSystem.DVLD.Driving_License.International_Driving_License
{
    partial class frmManageInternationalDrivingLicenseApplications
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.dgvInterationalDrivingLicenseApplicationLists = new System.Windows.Forms.DataGridView();
            this.cmsInternationalApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showInternationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicneseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIssueInternationalDrivingLicense = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterationalDrivingLicenseApplicationLists)).BeginInit();
            this.cmsInternationalApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.White;
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFilterValue.Location = new System.Drawing.Point(371, 302);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(214, 24);
            this.txtFilterValue.TabIndex = 43;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // dgvInterationalDrivingLicenseApplicationLists
            // 
            this.dgvInterationalDrivingLicenseApplicationLists.AllowUserToAddRows = false;
            this.dgvInterationalDrivingLicenseApplicationLists.AllowUserToDeleteRows = false;
            this.dgvInterationalDrivingLicenseApplicationLists.AllowUserToOrderColumns = true;
            this.dgvInterationalDrivingLicenseApplicationLists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInterationalDrivingLicenseApplicationLists.BackgroundColor = System.Drawing.Color.White;
            this.dgvInterationalDrivingLicenseApplicationLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterationalDrivingLicenseApplicationLists.ContextMenuStrip = this.cmsInternationalApplications;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInterationalDrivingLicenseApplicationLists.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInterationalDrivingLicenseApplicationLists.GridColor = System.Drawing.Color.Black;
            this.dgvInterationalDrivingLicenseApplicationLists.Location = new System.Drawing.Point(13, 343);
            this.dgvInterationalDrivingLicenseApplicationLists.Name = "dgvInterationalDrivingLicenseApplicationLists";
            this.dgvInterationalDrivingLicenseApplicationLists.ReadOnly = true;
            this.dgvInterationalDrivingLicenseApplicationLists.RowHeadersWidth = 51;
            this.dgvInterationalDrivingLicenseApplicationLists.RowTemplate.Height = 24;
            this.dgvInterationalDrivingLicenseApplicationLists.Size = new System.Drawing.Size(1458, 322);
            this.dgvInterationalDrivingLicenseApplicationLists.TabIndex = 42;
            this.dgvInterationalDrivingLicenseApplicationLists.DoubleClick += new System.EventHandler(this.dgvInterationalDrivingLicenseApplicationLists_DoubleClick);
            // 
            // cmsInternationalApplications
            // 
            this.cmsInternationalApplications.Font = new System.Drawing.Font("Perpetua", 13F);
            this.cmsInternationalApplications.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsInternationalApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator5,
            this.showInternationalLicenseToolStripMenuItem,
            this.toolStripSeparator6,
            this.showPersonLicneseHistoryToolStripMenuItem});
            this.cmsInternationalApplications.Name = "contextMenuStrip1";
            this.cmsInternationalApplications.Size = new System.Drawing.Size(294, 154);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(293, 46);
            this.showDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(290, 6);
            // 
            // showInternationalLicenseToolStripMenuItem
            // 
            this.showInternationalLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.License_View_32;
            this.showInternationalLicenseToolStripMenuItem.Name = "showInternationalLicenseToolStripMenuItem";
            this.showInternationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(293, 46);
            this.showInternationalLicenseToolStripMenuItem.Text = "show International License";
            this.showInternationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(290, 6);
            // 
            // showPersonLicneseHistoryToolStripMenuItem
            // 
            this.showPersonLicneseHistoryToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicneseHistoryToolStripMenuItem.Name = "showPersonLicneseHistoryToolStripMenuItem";
            this.showPersonLicneseHistoryToolStripMenuItem.Size = new System.Drawing.Size(293, 46);
            this.showPersonLicneseHistoryToolStripMenuItem.Text = "Show Person Licnese History";
            this.showPersonLicneseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicneseHistoryToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(466, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(552, 35);
            this.label3.TabIndex = 40;
            this.label3.Text = "International Driving License Applications";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Silver;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbFilterBy.ItemHeight = 15;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(117, 303);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(236, 23);
            this.cbFilterBy.TabIndex = 39;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Filter By :";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(133, 686);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(26, 17);
            this.lblRecordCount.TabIndex = 36;
            this.lblRecordCount.Text = "##";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 686);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "# Records :";
            // 
            // btnIssueInternationalDrivingLicense
            // 
            this.btnIssueInternationalDrivingLicense.BackColor = System.Drawing.Color.White;
            this.btnIssueInternationalDrivingLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueInternationalDrivingLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueInternationalDrivingLicense.Image = global::DVLDSystem.Properties.Resources.New_Application_64;
            this.btnIssueInternationalDrivingLicense.Location = new System.Drawing.Point(1383, 262);
            this.btnIssueInternationalDrivingLicense.Name = "btnIssueInternationalDrivingLicense";
            this.btnIssueInternationalDrivingLicense.Size = new System.Drawing.Size(88, 66);
            this.btnIssueInternationalDrivingLicense.TabIndex = 45;
            this.btnIssueInternationalDrivingLicense.UseVisualStyleBackColor = false;
            this.btnIssueInternationalDrivingLicense.Click += new System.EventHandler(this.btnIssueInternationalDrivingLicense_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDSystem.Properties.Resources.International_321;
            this.pictureBox2.Location = new System.Drawing.Point(817, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSystem.Properties.Resources.Manage_Applications_643;
            this.pictureBox1.Location = new System.Drawing.Point(604, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(1310, 684);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 37;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.Silver;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(371, 302);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(214, 25);
            this.cbIsActive.TabIndex = 46;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // frmManageInternationalDrivingLicenseApplications
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1484, 750);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnIssueInternationalDrivingLicense);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.dgvInterationalDrivingLicenseApplicationLists);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManageInternationalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage International Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageInternationalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterationalDrivingLicenseApplicationLists)).EndInit();
            this.cmsInternationalApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvInterationalDrivingLicenseApplicationLists;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIssueInternationalDrivingLicense;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalApplications;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicneseHistoryToolStripMenuItem;
    }
}