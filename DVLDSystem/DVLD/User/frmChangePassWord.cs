using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem_BusinessLayer;
using DVLDSystem.Gobal_Classes;

namespace DVLDSystem.DVLD.User
{
    public partial class frmChangePassWord : Form
    {

        //Properties :-
        private int _UserID = -1;
        private clsUser _UserInfo;


        //Private Methods :-
        private void _ResetDefualtValues()
        {
            txtCurrentPassWord.Text = "";
            txtNewPassWord.Text = "";
            txtConfirmPassWord.Text = "";
            txtCurrentPassWord.Focus();
        }

        private void _LoadUserInfo()
        {
            _UserInfo = clsUser.Find(_UserID);

            if (_UserInfo == null)
            {
                MessageBox.Show($"Error : Could Not Find User With ID [{_UserID}] in The System!", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlUserInfo1.LoadUserInfo(_UserID);
        }


        //Constructor :-
        public frmChangePassWord(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }
        private void frmChangePassWord_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _LoadUserInfo();
        }


        //Current PassWord :-
        private void txtCurrentPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtCurrentPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassWord, "This Field is Required!");
                return;
            }

            if (ctrlUserInfo1.SelectedUserInfo.PassWord != txtCurrentPassWord.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassWord, "Current PassWord is Wrong!");
                return;
            }
            errorProvider1.SetError(txtCurrentPassWord, null);
        }


        //New PassWord :-
        private void txtNewPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtNewPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassWord, "This Field is Required!");
                return;
            }
            errorProvider1.SetError(txtNewPassWord, null);
        }


        //Confirm New PassWord :-
        private void txtConfirmPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtConfirmPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassWord, "This Field is Required!");
                return;
            }

            if (txtNewPassWord.Text.Trim() != txtConfirmPassWord.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassWord, "PassWord Confrimation Does Not Match New PassWord!");
                return;
            }
            errorProvider1.SetError(txtConfirmPassWord, null);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Save User Data :-
        private void btnSaveUserData_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _UserInfo.PassWord = txtNewPassWord.Text.Trim();

            if (_UserInfo.Save())
            {
                MessageBox.Show("PassWord Changed Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("Change PassWord is Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }
    }
}