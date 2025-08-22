namespace DVLDSystem.DVLD.People.Controls
{
    partial class ctrlPersonInfoWithFilter
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
            this.gbFilterPerson = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFindPersonInfo = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonInfo1 = new DVLDSystem.DVLD.People.Controls.ctrlPersonInfo();
            this.gbFilterPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilterPerson
            // 
            this.gbFilterPerson.Controls.Add(this.btnAddNewPerson);
            this.gbFilterPerson.Controls.Add(this.btnFindPersonInfo);
            this.gbFilterPerson.Controls.Add(this.txtFilterValue);
            this.gbFilterPerson.Controls.Add(this.cbFilterBy);
            this.gbFilterPerson.Controls.Add(this.label3);
            this.gbFilterPerson.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.gbFilterPerson.Location = new System.Drawing.Point(12, 3);
            this.gbFilterPerson.Name = "gbFilterPerson";
            this.gbFilterPerson.Size = new System.Drawing.Size(1155, 97);
            this.gbFilterPerson.TabIndex = 4;
            this.gbFilterPerson.TabStop = false;
            this.gbFilterPerson.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.White;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPerson.Image = global::DVLDSystem.Properties.Resources.AddPerson_321;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1009, 27);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(73, 48);
            this.btnAddNewPerson.TabIndex = 69;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFindPersonInfo
            // 
            this.btnFindPersonInfo.BackColor = System.Drawing.Color.White;
            this.btnFindPersonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindPersonInfo.Image = global::DVLDSystem.Properties.Resources.SearchPerson;
            this.btnFindPersonInfo.Location = new System.Drawing.Point(911, 27);
            this.btnFindPersonInfo.Name = "btnFindPersonInfo";
            this.btnFindPersonInfo.Size = new System.Drawing.Size(73, 48);
            this.btnFindPersonInfo.TabIndex = 68;
            this.btnFindPersonInfo.UseVisualStyleBackColor = false;
            this.btnFindPersonInfo.Click += new System.EventHandler(this.btnFindPersonInfo_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.White;
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFilterValue.Location = new System.Drawing.Point(368, 39);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(510, 24);
            this.txtFilterValue.TabIndex = 67;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.White;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Person ID",
            "National No."});
            this.cbFilterBy.Location = new System.Drawing.Point(111, 40);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(236, 23);
            this.cbFilterBy.TabIndex = 66;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Find By :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(6, 106);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(1170, 440);
            this.ctrlPersonInfo1.TabIndex = 5;
            // 
            // ctrlPersonInfoWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Controls.Add(this.gbFilterPerson);
            this.Name = "ctrlPersonInfoWithFilter";
            this.Size = new System.Drawing.Size(1183, 551);
            this.Load += new System.EventHandler(this.ctrlPersonInfoWithFilter_Load);
            this.gbFilterPerson.ResumeLayout(false);
            this.gbFilterPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbFilterPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFindPersonInfo;
        private ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
