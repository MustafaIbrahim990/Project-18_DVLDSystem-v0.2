namespace DVLDSystem.DVLD.Driving_License.Controls
{
    partial class ctrlDrivingLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblRecordCountInLocal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseLists = new System.Windows.Forms.DataGridView();
            this.cmsLocalDrivingLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocalDrivingLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRecordCountInInternational = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmsInternationalDrivinglicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalDrivingLicenseLists = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseLists)).BeginInit();
            this.cmsLocalDrivingLicenseHistory.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmsInternationalDrivinglicenseHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicenseLists)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Bright", 10F);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1160, 275);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabControl1.Location = new System.Drawing.Point(14, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1133, 234);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lblRecordCountInLocal);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgvLocalDrivingLicenseLists);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1125, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Local";
            // 
            // lblRecordCountInLocal
            // 
            this.lblRecordCountInLocal.AutoSize = true;
            this.lblRecordCountInLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCountInLocal.Location = new System.Drawing.Point(140, 177);
            this.lblRecordCountInLocal.Name = "lblRecordCountInLocal";
            this.lblRecordCountInLocal.Size = new System.Drawing.Size(26, 17);
            this.lblRecordCountInLocal.TabIndex = 38;
            this.lblRecordCountInLocal.Text = "##";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "# Records :";
            // 
            // dgvLocalDrivingLicenseLists
            // 
            this.dgvLocalDrivingLicenseLists.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseLists.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseLists.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseLists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalDrivingLicenseLists.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicenseLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseLists.ContextMenuStrip = this.cmsLocalDrivingLicenseHistory;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicenseLists.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseLists.GridColor = System.Drawing.Color.Black;
            this.dgvLocalDrivingLicenseLists.Location = new System.Drawing.Point(21, 57);
            this.dgvLocalDrivingLicenseLists.Name = "dgvLocalDrivingLicenseLists";
            this.dgvLocalDrivingLicenseLists.ReadOnly = true;
            this.dgvLocalDrivingLicenseLists.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseLists.RowTemplate.Height = 24;
            this.dgvLocalDrivingLicenseLists.Size = new System.Drawing.Size(1082, 109);
            this.dgvLocalDrivingLicenseLists.TabIndex = 31;
            this.dgvLocalDrivingLicenseLists.DoubleClick += new System.EventHandler(this.dgvLocalDrivingLicenseLists_DoubleClick);
            // 
            // cmsLocalDrivingLicenseHistory
            // 
            this.cmsLocalDrivingLicenseHistory.Font = new System.Drawing.Font("Perpetua", 13F);
            this.cmsLocalDrivingLicenseHistory.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsLocalDrivingLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocalDrivingLicenseToolStripMenuItem1});
            this.cmsLocalDrivingLicenseHistory.Name = "cmsLocalDrivingLicenseHistory";
            this.cmsLocalDrivingLicenseHistory.Size = new System.Drawing.Size(286, 50);
            // 
            // showLocalDrivingLicenseToolStripMenuItem1
            // 
            this.showLocalDrivingLicenseToolStripMenuItem1.Image = global::DVLDSystem.Properties.Resources.License_View_32;
            this.showLocalDrivingLicenseToolStripMenuItem1.Name = "showLocalDrivingLicenseToolStripMenuItem1";
            this.showLocalDrivingLicenseToolStripMenuItem1.Size = new System.Drawing.Size(285, 46);
            this.showLocalDrivingLicenseToolStripMenuItem1.Text = "Show Local Driving License";
            this.showLocalDrivingLicenseToolStripMenuItem1.Click += new System.EventHandler(this.showLocalDrivingLicenseToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Local Driving License History :";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgvInternationalDrivingLicenseLists);
            this.tabPage1.Controls.Add(this.lblRecordCountInInternational);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1125, 205);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "International";
            // 
            // lblRecordCountInInternational
            // 
            this.lblRecordCountInInternational.AutoSize = true;
            this.lblRecordCountInInternational.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCountInInternational.Location = new System.Drawing.Point(140, 177);
            this.lblRecordCountInInternational.Name = "lblRecordCountInInternational";
            this.lblRecordCountInInternational.Size = new System.Drawing.Size(26, 17);
            this.lblRecordCountInInternational.TabIndex = 43;
            this.lblRecordCountInInternational.Text = "##";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "# Records :";
            // 
            // cmsInternationalDrivinglicenseHistory
            // 
            this.cmsInternationalDrivinglicenseHistory.Font = new System.Drawing.Font("Perpetua", 13F);
            this.cmsInternationalDrivinglicenseHistory.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsInternationalDrivinglicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalDrivingLicenseToolStripMenuItem});
            this.cmsInternationalDrivinglicenseHistory.Name = "cmsInternationalDrivinglicenseHistory";
            this.cmsInternationalDrivinglicenseHistory.Size = new System.Drawing.Size(333, 50);
            // 
            // showInternationalDrivingLicenseToolStripMenuItem
            // 
            this.showInternationalDrivingLicenseToolStripMenuItem.Image = global::DVLDSystem.Properties.Resources.License_View_32;
            this.showInternationalDrivingLicenseToolStripMenuItem.Name = "showInternationalDrivingLicenseToolStripMenuItem";
            this.showInternationalDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(332, 46);
            this.showInternationalDrivingLicenseToolStripMenuItem.Text = "Show International Driving License";
            this.showInternationalDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.showInternationalDrivingLicenseToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "International Driving License History :";
            // 
            // dgvInternationalDrivingLicenseLists
            // 
            this.dgvInternationalDrivingLicenseLists.AllowUserToAddRows = false;
            this.dgvInternationalDrivingLicenseLists.AllowUserToDeleteRows = false;
            this.dgvInternationalDrivingLicenseLists.AllowUserToOrderColumns = true;
            this.dgvInternationalDrivingLicenseLists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalDrivingLicenseLists.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalDrivingLicenseLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalDrivingLicenseLists.ContextMenuStrip = this.cmsLocalDrivingLicenseHistory;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalDrivingLicenseLists.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalDrivingLicenseLists.GridColor = System.Drawing.Color.Black;
            this.dgvInternationalDrivingLicenseLists.Location = new System.Drawing.Point(21, 57);
            this.dgvInternationalDrivingLicenseLists.Name = "dgvInternationalDrivingLicenseLists";
            this.dgvInternationalDrivingLicenseLists.ReadOnly = true;
            this.dgvInternationalDrivingLicenseLists.RowHeadersWidth = 51;
            this.dgvInternationalDrivingLicenseLists.RowTemplate.Height = 24;
            this.dgvInternationalDrivingLicenseLists.Size = new System.Drawing.Size(1082, 109);
            this.dgvInternationalDrivingLicenseLists.TabIndex = 44;
            this.dgvInternationalDrivingLicenseLists.DoubleClick += new System.EventHandler(this.dgvInternationalDrivingLicenseLists_DoubleClick_1);
            // 
            // ctrlDrivingLicenses
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDrivingLicenses";
            this.Size = new System.Drawing.Size(1173, 283);
            this.Load += new System.EventHandler(this.ctrlDrivingLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseLists)).EndInit();
            this.cmsLocalDrivingLicenseHistory.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cmsInternationalDrivinglicenseHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicenseLists)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblRecordCountInLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseLists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsLocalDrivingLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLocalDrivingLicenseToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalDrivinglicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showInternationalDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.Label lblRecordCountInInternational;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvInternationalDrivingLicenseLists;
    }
}
