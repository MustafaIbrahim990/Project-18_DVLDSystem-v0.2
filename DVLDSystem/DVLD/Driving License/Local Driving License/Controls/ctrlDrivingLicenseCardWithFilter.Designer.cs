namespace DVLDSystem.DVLD.Driving_License.Local_Driving_License.Controls
{
    partial class ctrlDrivingLicenseCardWithFilter
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
            this.gbDrivingLicenseFilter = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindDrivingLicenseCard = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.ctrlDrivingLicenseCard1 = new DVLDSystem.DVLD.Driving_License.Local_Driving_License.Controls.ctrlDrivingLicenseCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDrivingLicenseFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDrivingLicenseFilter
            // 
            this.gbDrivingLicenseFilter.Controls.Add(this.label1);
            this.gbDrivingLicenseFilter.Controls.Add(this.btnFindDrivingLicenseCard);
            this.gbDrivingLicenseFilter.Controls.Add(this.txtFilterValue);
            this.gbDrivingLicenseFilter.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.gbDrivingLicenseFilter.Location = new System.Drawing.Point(10, 6);
            this.gbDrivingLicenseFilter.Name = "gbDrivingLicenseFilter";
            this.gbDrivingLicenseFilter.Size = new System.Drawing.Size(1247, 97);
            this.gbDrivingLicenseFilter.TabIndex = 5;
            this.gbDrivingLicenseFilter.TabStop = false;
            this.gbDrivingLicenseFilter.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "Local Driving License ID :";
            // 
            // btnFindDrivingLicenseCard
            // 
            this.btnFindDrivingLicenseCard.BackColor = System.Drawing.Color.White;
            this.btnFindDrivingLicenseCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindDrivingLicenseCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindDrivingLicenseCard.Image = global::DVLDSystem.Properties.Resources.License_View_32;
            this.btnFindDrivingLicenseCard.Location = new System.Drawing.Point(911, 27);
            this.btnFindDrivingLicenseCard.Name = "btnFindDrivingLicenseCard";
            this.btnFindDrivingLicenseCard.Size = new System.Drawing.Size(73, 48);
            this.btnFindDrivingLicenseCard.TabIndex = 68;
            this.btnFindDrivingLicenseCard.UseVisualStyleBackColor = false;
            this.btnFindDrivingLicenseCard.Click += new System.EventHandler(this.btnShowDrivingLicense_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.White;
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFilterValue.Location = new System.Drawing.Point(264, 39);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(614, 24);
            this.txtFilterValue.TabIndex = 67;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // ctrlDrivingLicenseCard1
            // 
            this.ctrlDrivingLicenseCard1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseCard1.Location = new System.Drawing.Point(3, 109);
            this.ctrlDrivingLicenseCard1.Name = "ctrlDrivingLicenseCard1";
            this.ctrlDrivingLicenseCard1.Size = new System.Drawing.Size(1262, 482);
            this.ctrlDrivingLicenseCard1.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlDrivingLicenseCardWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlDrivingLicenseCard1);
            this.Controls.Add(this.gbDrivingLicenseFilter);
            this.Name = "ctrlDrivingLicenseCardWithFilter";
            this.Size = new System.Drawing.Size(1268, 598);
            this.Load += new System.EventHandler(this.ctrlDrivingLicenseCardWithFilter_Load);
            this.gbDrivingLicenseFilter.ResumeLayout(false);
            this.gbDrivingLicenseFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbDrivingLicenseFilter;
        private System.Windows.Forms.Button btnFindDrivingLicenseCard;
        private System.Windows.Forms.TextBox txtFilterValue;
        private ctrlDrivingLicenseCard ctrlDrivingLicenseCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
    }
}
