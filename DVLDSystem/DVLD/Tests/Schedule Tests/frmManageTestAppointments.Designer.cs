namespace DVLDSystem.DVLD.Tests.Schedule_Tests
{
    partial class frmManageTestAppointments
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
            this.dgvTestAppointmentLists = new System.Windows.Forms.DataGridView();
            this.cmsTestAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlLocalDrivingLicenseApplication1 = new DVLDSystem.DVLD.Applications.Local_Driving_License.Controls.ctrlLocalDrivingLicenseApplication();
            this.btnAddTestAppointment = new System.Windows.Forms.Button();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCloseForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmentLists)).BeginInit();
            this.cmsTestAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTestAppointmentLists
            // 
            this.dgvTestAppointmentLists.AllowUserToAddRows = false;
            this.dgvTestAppointmentLists.AllowUserToDeleteRows = false;
            this.dgvTestAppointmentLists.AllowUserToOrderColumns = true;
            this.dgvTestAppointmentLists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestAppointmentLists.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestAppointmentLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointmentLists.ContextMenuStrip = this.cmsTestAppointments;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestAppointmentLists.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestAppointmentLists.GridColor = System.Drawing.Color.Black;
            this.dgvTestAppointmentLists.Location = new System.Drawing.Point(24, 643);
            this.dgvTestAppointmentLists.Name = "dgvTestAppointmentLists";
            this.dgvTestAppointmentLists.ReadOnly = true;
            this.dgvTestAppointmentLists.RowHeadersWidth = 51;
            this.dgvTestAppointmentLists.RowTemplate.Height = 24;
            this.dgvTestAppointmentLists.Size = new System.Drawing.Size(1157, 155);
            this.dgvTestAppointmentLists.TabIndex = 42;
            // 
            // cmsTestAppointments
            // 
            this.cmsTestAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripSeparator1,
            this.takeTestToolStripMenuItem});
            this.cmsTestAppointments.Name = "contextMenuStrip1";
            this.cmsTestAppointments.Size = new System.Drawing.Size(139, 86);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(429, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(348, 35);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "Vision Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(133, 828);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(26, 17);
            this.lblRecordCount.TabIndex = 36;
            this.lblRecordCount.Text = "##";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 828);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "# Records :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.TabIndex = 43;
            this.label2.Text = "Appointments :";
            // 
            // ctrlLocalDrivingLicenseApplication1
            // 
            this.ctrlLocalDrivingLicenseApplication1.BackColor = System.Drawing.Color.White;
            this.ctrlLocalDrivingLicenseApplication1.Location = new System.Drawing.Point(10, 66);
            this.ctrlLocalDrivingLicenseApplication1.Name = "ctrlLocalDrivingLicenseApplication1";
            this.ctrlLocalDrivingLicenseApplication1.Size = new System.Drawing.Size(1187, 508);
            this.ctrlLocalDrivingLicenseApplication1.TabIndex = 44;
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.BackColor = System.Drawing.Color.White;
            this.btnAddTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTestAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTestAppointment.Image = global::DVLDSystem.Properties.Resources.AddAppointment_32;
            this.btnAddTestAppointment.Location = new System.Drawing.Point(1123, 580);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(58, 55);
            this.btnAddTestAppointment.TabIndex = 45;
            this.btnAddTestAppointment.UseVisualStyleBackColor = false;
            this.btnAddTestAppointment.Click += new System.EventHandler(this.btnAddTestAppointment_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(138, 38);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(138, 38);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(1020, 813);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 37;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // frmManageTestAppointments
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 866);
            this.Controls.Add(this.btnAddTestAppointment);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplication1);
            this.Controls.Add(this.dgvTestAppointmentLists);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Test Appointments";
            this.Load += new System.EventHandler(this.frmManageTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmentLists)).EndInit();
            this.cmsTestAppointments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTestAppointmentLists;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Applications.Local_Driving_License.Controls.ctrlLocalDrivingLicenseApplication ctrlLocalDrivingLicenseApplication1;
        private System.Windows.Forms.Button btnAddTestAppointment;
        private System.Windows.Forms.ContextMenuStrip cmsTestAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}