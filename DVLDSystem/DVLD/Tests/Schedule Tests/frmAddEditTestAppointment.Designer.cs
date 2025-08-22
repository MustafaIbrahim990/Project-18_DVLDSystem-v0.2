namespace DVLDSystem.DVLD.Tests.Schedule_Tests
{
    partial class frmAddEditTestAppointment
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
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.ctrlAddEditTestAppointment1 = new DVLDSystem.DVLD.Tests.Schedule_Tests.Controls.ctrlAddEditTestAppointment();
            this.SuspendLayout();
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(502, 794);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 24;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // ctrlAddEditTestAppointment1
            // 
            this.ctrlAddEditTestAppointment1.BackColor = System.Drawing.Color.White;
            this.ctrlAddEditTestAppointment1.Location = new System.Drawing.Point(9, 8);
            this.ctrlAddEditTestAppointment1.Name = "ctrlAddEditTestAppointment1";
            this.ctrlAddEditTestAppointment1.Size = new System.Drawing.Size(1147, 778);
            this.ctrlAddEditTestAppointment1.TabIndex = 0;
            this.ctrlAddEditTestAppointment1.TestTypeID = DVLDSystem_BusinessLayer.clsTestType.enTestType.eVisionTest;
            // 
            // frmAddEditTestAppointment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 848);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.ctrlAddEditTestAppointment1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddEditTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Test Appointment";
            this.Load += new System.EventHandler(this.frmAddEditTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlAddEditTestAppointment ctrlAddEditTestAppointment1;
        private System.Windows.Forms.Button btnCloseForm;
    }
}