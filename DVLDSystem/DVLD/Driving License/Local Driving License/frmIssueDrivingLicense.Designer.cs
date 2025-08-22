namespace DVLDSystem.DVLD.Driving_License
{
    partial class frmIssueDrivingLicense
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
            this.ctrlLocalDrivingLicenseApplication1 = new DVLDSystem.DVLD.Applications.Local_Driving_License.Controls.ctrlLocalDrivingLicenseApplication();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnIssueDrivingLicenseForFirstTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicenseApplication1
            // 
            this.ctrlLocalDrivingLicenseApplication1.BackColor = System.Drawing.Color.White;
            this.ctrlLocalDrivingLicenseApplication1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLocalDrivingLicenseApplication1.Name = "ctrlLocalDrivingLicenseApplication1";
            this.ctrlLocalDrivingLicenseApplication1.Size = new System.Drawing.Size(1187, 516);
            this.ctrlLocalDrivingLicenseApplication1.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNotes.Location = new System.Drawing.Point(309, 540);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(871, 67);
            this.txtNotes.TabIndex = 218;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(62, 540);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 216;
            this.label9.Text = "Notes :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSystem.Properties.Resources.Notes_32;
            this.pictureBox1.Location = new System.Drawing.Point(218, 540);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 217;
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
            this.btnCloseForm.Location = new System.Drawing.Point(838, 623);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 215;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnIssueDrivingLicenseForFirstTime
            // 
            this.btnIssueDrivingLicenseForFirstTime.BackColor = System.Drawing.Color.White;
            this.btnIssueDrivingLicenseForFirstTime.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIssueDrivingLicenseForFirstTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueDrivingLicenseForFirstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueDrivingLicenseForFirstTime.Image = global::DVLDSystem.Properties.Resources.IssueDrivingLicense_321;
            this.btnIssueDrivingLicenseForFirstTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueDrivingLicenseForFirstTime.Location = new System.Drawing.Point(1019, 623);
            this.btnIssueDrivingLicenseForFirstTime.Name = "btnIssueDrivingLicenseForFirstTime";
            this.btnIssueDrivingLicenseForFirstTime.Size = new System.Drawing.Size(161, 47);
            this.btnIssueDrivingLicenseForFirstTime.TabIndex = 214;
            this.btnIssueDrivingLicenseForFirstTime.Text = "Issue";
            this.btnIssueDrivingLicenseForFirstTime.UseVisualStyleBackColor = false;
            this.btnIssueDrivingLicenseForFirstTime.Click += new System.EventHandler(this.btnIssueDrivingLicenseForFirstTime_Click);
            // 
            // frmIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1209, 691);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnIssueDrivingLicenseForFirstTime);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplication1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmIssueDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue Driving License For FIrst Time";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Local_Driving_License.Controls.ctrlLocalDrivingLicenseApplication ctrlLocalDrivingLicenseApplication1;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnIssueDrivingLicenseForFirstTime;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
    }
}