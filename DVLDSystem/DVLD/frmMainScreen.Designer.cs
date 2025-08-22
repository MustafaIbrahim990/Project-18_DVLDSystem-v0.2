namespace DVLDSystem.DVLD
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseDetainedDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ManageInternationaDrivingLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.DetainLicensesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageDetainedLicensestoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.BackColor = System.Drawing.Color.White;
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainMenue.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.servicesToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.UsersToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msMainMenue.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.Size = new System.Drawing.Size(1040, 72);
            this.msMainMenue.TabIndex = 2;
            this.msMainMenue.Text = "menuStrip1";
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesToolStripMenuItem,
            this.toolStripSeparator6,
            this.tsMManageApplications,
            this.toolStripSeparator5,
            this.DetainLicensesToolStripMenuItem1,
            this.toolStripSeparator3,
            this.manageApplicationTypesToolStripMenuItem,
            this.toolStripSeparator7,
            this.manageTestTypesToolStripMenuItem});
            this.servicesToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Applications_64;
            this.servicesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(182, 68);
            this.servicesToolStripMenuItem.Text = "&Applications";
            // 
            // drivingLicensesToolStripMenuItem
            // 
            this.drivingLicensesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.drivingLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oNewDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator1,
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator2,
            this.releaseDetainedDrivingLicenseToolStripMenuItem,
            this.retakeTestToolStripMenuItem1});
            this.drivingLicensesToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Driver_License_48;
            this.drivingLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivingLicensesToolStripMenuItem.Name = "drivingLicensesToolStripMenuItem";
            this.drivingLicensesToolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.drivingLicensesToolStripMenuItem.Text = "&Driving Licenses Services";
            // 
            // oNewDrivingLicenseToolStripMenuItem
            // 
            this.oNewDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.oNewDrivingLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.New_Driving_License_32;
            this.oNewDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.oNewDrivingLicenseToolStripMenuItem.Name = "oNewDrivingLicenseToolStripMenuItem";
            this.oNewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(415, 38);
            this.oNewDrivingLicenseToolStripMenuItem.Text = "&New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Local_32;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 46);
            this.localLicenseToolStripMenuItem.Text = "&Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.internationalLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.International_32;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 46);
            this.internationalLicenseToolStripMenuItem.Text = "&International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Renew_Driving_License_32;
            this.renewDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(415, 38);
            this.renewDrivingLicenseToolStripMenuItem.Text = "&Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(412, 6);
            // 
            // ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem
            // 
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Damaged_Driving_License_32;
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem.Name = "ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem";
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(415, 38);
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem.Text = "Replacement for Lost or &Damaged License";
            this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(412, 6);
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Detained_Driving_License_32;
            this.releaseDetainedDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(415, 38);
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Text = "Release Detained Driving License";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedDrivingLicenseToolStripMenuItem_Click);
            // 
            // retakeTestToolStripMenuItem1
            // 
            this.retakeTestToolStripMenuItem1.Image = global::DVLDSystem.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.retakeTestToolStripMenuItem1.Name = "retakeTestToolStripMenuItem1";
            this.retakeTestToolStripMenuItem1.Size = new System.Drawing.Size(415, 38);
            this.retakeTestToolStripMenuItem1.Text = "Retake Test";
            this.retakeTestToolStripMenuItem1.Click += new System.EventHandler(this.retakeTestToolStripMenuItem1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(328, 6);
            // 
            // tsMManageApplications
            // 
            this.tsMManageApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem,
            this.toolStripSeparator8,
            this.ManageInternationaDrivingLicenseToolStripMenuItem1});
            this.tsMManageApplications.Image = global::DVLDSystem.Properties.Resources.Manage_Applications_64;
            this.tsMManageApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMManageApplications.Name = "tsMManageApplications";
            this.tsMManageApplications.Size = new System.Drawing.Size(331, 70);
            this.tsMManageApplications.Text = "Manage Applications";
            // 
            // manageLocalDrivingLicenseApplicationsToolStripMenuItem
            // 
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Local_32;
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem.Name = "manageLocalDrivingLicenseApplicationsToolStripMenuItem";
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(357, 38);
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            this.manageLocalDrivingLicenseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(354, 6);
            // 
            // ManageInternationaDrivingLicenseToolStripMenuItem1
            // 
            this.ManageInternationaDrivingLicenseToolStripMenuItem1.Image = global::DVLDSystem.Properties.Resources.International_32;
            this.ManageInternationaDrivingLicenseToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageInternationaDrivingLicenseToolStripMenuItem1.Name = "ManageInternationaDrivingLicenseToolStripMenuItem1";
            this.ManageInternationaDrivingLicenseToolStripMenuItem1.Size = new System.Drawing.Size(357, 38);
            this.ManageInternationaDrivingLicenseToolStripMenuItem1.Text = "International License Applications";
            this.ManageInternationaDrivingLicenseToolStripMenuItem1.Click += new System.EventHandler(this.ManageInternationaDrivingLicenseToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(328, 6);
            // 
            // DetainLicensesToolStripMenuItem1
            // 
            this.DetainLicensesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageDetainedLicensestoolStripMenuItem1,
            this.toolStripSeparator9,
            this.detainLicenseToolStripMenuItem,
            this.toolStripSeparator10,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.DetainLicensesToolStripMenuItem1.Image = global::DVLDSystem.Properties.Resources.Detain_64;
            this.DetainLicensesToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetainLicensesToolStripMenuItem1.Name = "DetainLicensesToolStripMenuItem1";
            this.DetainLicensesToolStripMenuItem1.Size = new System.Drawing.Size(331, 70);
            this.DetainLicensesToolStripMenuItem1.Text = "Detain Licenses";
            // 
            // ManageDetainedLicensestoolStripMenuItem1
            // 
            this.ManageDetainedLicensestoolStripMenuItem1.Image = global::DVLDSystem.Properties.Resources.Detain_64;
            this.ManageDetainedLicensestoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageDetainedLicensestoolStripMenuItem1.Name = "ManageDetainedLicensestoolStripMenuItem1";
            this.ManageDetainedLicensestoolStripMenuItem1.Size = new System.Drawing.Size(332, 70);
            this.ManageDetainedLicensestoolStripMenuItem1.Text = "Manage Detained Licenses";
            this.ManageDetainedLicensestoolStripMenuItem1.Click += new System.EventHandler(this.ManageDetainedLicensestoolStripMenuItem1_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(329, 6);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Detain_64;
            this.detainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(332, 70);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(329, 6);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Release_Detained_License_64;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(332, 70);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(328, 6);
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Application_Types_64;
            this.manageApplicationTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(328, 6);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Test_Type_64;
            this.manageTestTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(331, 70);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("peopleToolStripMenuItem.Image")));
            this.peopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(139, 68);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Drivers_64;
            this.driversToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(140, 68);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // UsersToolStripMenuItem
            // 
            this.UsersToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Users_2_64;
            this.UsersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem";
            this.UsersToolStripMenuItem.Size = new System.Drawing.Size(127, 68);
            this.UsersToolStripMenuItem.Text = "Users";
            this.UsersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.toolStripSeparator11,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator4,
            this.signOutToolStripMenuItem});
            this.closeToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.account_settings_64;
            this.closeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(215, 68);
            this.closeToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.PersonDetails_32;
            this.currentUserInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.currentUserInfoToolStripMenuItem.Text = "&Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(227, 6);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(227, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.signOutToolStripMenuItem.Text = "Sign &Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLDSystem.Properties.Resources.WordMark_Logo3;
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1040, 543);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmMainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 615);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMainMenue);
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainScreen_FormClosing);
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsMManageApplications;
        private System.Windows.Forms.ToolStripMenuItem manageLocalDrivingLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageInternationaDrivingLicenseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem DetainLicensesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ManageDetainedLicensestoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
    }
}