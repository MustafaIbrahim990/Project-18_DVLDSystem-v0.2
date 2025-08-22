namespace DVLDSystem.DVLD.User
{
    partial class frmChangePassWord
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
            this.ctrlUserInfo1 = new DVLDSystem.DVLD.User.Controls.ctrlUserInfo();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPassWord = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnSaveUserData = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlUserInfo1
            // 
            this.ctrlUserInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlUserInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUserInfo1.Name = "ctrlUserInfo1";
            this.ctrlUserInfo1.Size = new System.Drawing.Size(1181, 557);
            this.ctrlUserInfo1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 687);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "Confirm PassWord :";
            // 
            // txtConfirmPassWord
            // 
            this.txtConfirmPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassWord.Location = new System.Drawing.Point(351, 685);
            this.txtConfirmPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmPassWord.MaxLength = 50;
            this.txtConfirmPassWord.Multiline = true;
            this.txtConfirmPassWord.Name = "txtConfirmPassWord";
            this.txtConfirmPassWord.PasswordChar = '*';
            this.txtConfirmPassWord.Size = new System.Drawing.Size(198, 26);
            this.txtConfirmPassWord.TabIndex = 121;
            this.txtConfirmPassWord.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassWord_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 635);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 119;
            this.label2.Text = "New PassWord :";
            // 
            // txtNewPassWord
            // 
            this.txtNewPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassWord.Location = new System.Drawing.Point(351, 630);
            this.txtNewPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPassWord.MaxLength = 50;
            this.txtNewPassWord.Multiline = true;
            this.txtNewPassWord.Name = "txtNewPassWord";
            this.txtNewPassWord.PasswordChar = '*';
            this.txtNewPassWord.Size = new System.Drawing.Size(198, 26);
            this.txtNewPassWord.TabIndex = 118;
            this.txtNewPassWord.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPassWord_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 583);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 116;
            this.label1.Text = "Current PassWord :";
            // 
            // txtCurrentPassWord
            // 
            this.txtCurrentPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassWord.Location = new System.Drawing.Point(351, 580);
            this.txtCurrentPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCurrentPassWord.MaxLength = 50;
            this.txtCurrentPassWord.Multiline = true;
            this.txtCurrentPassWord.Name = "txtCurrentPassWord";
            this.txtCurrentPassWord.PasswordChar = '*';
            this.txtCurrentPassWord.Size = new System.Drawing.Size(198, 26);
            this.txtCurrentPassWord.TabIndex = 115;
            this.txtCurrentPassWord.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPassWord_Validating);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDSystem.Properties.Resources.Password_32;
            this.pictureBox2.Location = new System.Drawing.Point(287, 685);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 123;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSystem.Properties.Resources.Password_32;
            this.pictureBox1.Location = new System.Drawing.Point(287, 630);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 120;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLDSystem.Properties.Resources.Person_32;
            this.pictureBox8.Location = new System.Drawing.Point(287, 580);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 117;
            this.pictureBox8.TabStop = false;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.White;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLDSystem.Properties.Resources.Close_32;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(849, 739);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(161, 47);
            this.btnCloseForm.TabIndex = 129;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnSaveUserData
            // 
            this.btnSaveUserData.BackColor = System.Drawing.Color.White;
            this.btnSaveUserData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUserData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUserData.Image = global::DVLDSystem.Properties.Resources.Save_32;
            this.btnSaveUserData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveUserData.Location = new System.Drawing.Point(1029, 739);
            this.btnSaveUserData.Name = "btnSaveUserData";
            this.btnSaveUserData.Size = new System.Drawing.Size(161, 47);
            this.btnSaveUserData.TabIndex = 128;
            this.btnSaveUserData.Text = "Save";
            this.btnSaveUserData.UseVisualStyleBackColor = false;
            this.btnSaveUserData.Click += new System.EventHandler(this.btnSaveUserData_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangePassWord
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 799);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnSaveUserData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPassWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentPassWord);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.ctrlUserInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangePassWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change PassWord";
            this.Load += new System.EventHandler(this.frmChangePassWord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlUserInfo ctrlUserInfo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentPassWord;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnSaveUserData;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}