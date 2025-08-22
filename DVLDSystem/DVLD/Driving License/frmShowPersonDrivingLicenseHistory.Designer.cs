namespace DVLDSystem.DVLD.Driving_License
{
    partial class frmShowPersonDrivingLicenseHistory
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
            this.ctrlDrivingLicenses1 = new DVLDSystem.DVLD.Driving_License.Controls.ctrlDrivingLicenses();
            this.ctrlPersonInfoWithFilter1 = new DVLDSystem.DVLD.People.Controls.ctrlPersonInfoWithFilter();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 22F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(427, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 38);
            this.label3.TabIndex = 29;
            this.label3.Text = "Driving License History";
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
            this.btnCloseForm.Location = new System.Drawing.Point(1023, 910);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 217;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            // 
            // ctrlDrivingLicenses1
            // 
            this.ctrlDrivingLicenses1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenses1.Location = new System.Drawing.Point(16, 618);
            this.ctrlDrivingLicenses1.Name = "ctrlDrivingLicenses1";
            this.ctrlDrivingLicenses1.Size = new System.Drawing.Size(1173, 283);
            this.ctrlDrivingLicenses1.TabIndex = 218;
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInfoWithFilter1.btnAddNewPersonEnabled = true;
            this.ctrlPersonInfoWithFilter1.FilterPersonEnabled = true;
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(10, 61);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(1183, 551);
            this.ctrlPersonInfoWithFilter1.TabIndex = 30;
            // 
            // frmShowPersonDrivingLicenseHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1204, 973);
            this.Controls.Add(this.ctrlDrivingLicenses1);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowPersonDrivingLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Person Driving License History";
            this.Load += new System.EventHandler(this.frmShowPersonDrivingLicenseHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Button btnCloseForm;
        private Controls.ctrlDrivingLicenses ctrlDrivingLicenses1;
    }
}