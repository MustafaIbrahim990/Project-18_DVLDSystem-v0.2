using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.Gobal_Classes;
using DVLDSystem_BusinessLayer;

namespace DVLDSystem.DVLD.User.Controls
{
    public partial class frmAddEditUser : Form
    {
        //Delegate :-
        //public delegate void DataBackEventHandler(object sender, int PersonID);
        //public event DataBackEventHandler DataBack;

        //Enums :-
        private enum enMode { eAddNew = 1, eUpdate = 2 };
        private enMode _Mode;


        //Properties :-
        private int _UserID = -1;
        private clsUser _UserInfo;


        //Private Methods :-
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.eAddNew)
            {
                this.Text = "Add New User";
                lblTitle.Text = "Add New User";
                _UserInfo = new clsUser();
                tpLoginInfo.Enabled = false;
                btnSaveUserData.Enabled = false;
            }
            else
            {
                this.Text = "Update User";
                lblTitle.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnSaveUserData.Enabled = true;
            }
            lblUserID.Text = "N/A";
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtConfirmPassWord.Text = "";
            chbIsActive.Checked = true;
        }

        private void _RefreshUserInfoInUpdateMode()
        {
            lblUserID.Text = _UserInfo.UserID.ToString();
            txtUserName.Text = _UserInfo.UserName;
            txtPassWord.Text = _UserInfo.PassWord;
            txtConfirmPassWord.Text = _UserInfo.PassWord;
            chbIsActive.Checked = _UserInfo.IsActive;
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_UserInfo.PersonID);
        }

        private void _LoadDataInUpdateMode()
        {
            _UserInfo = clsUser.Find(_UserID);

            if (_UserInfo == null)
            {
                MessageBox.Show($"Error : No User With ID [{_UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _RefreshUserInfoInUpdateMode();
        }

        private void _GetUserInfo()
        {
            _UserInfo.PersonID = ctrlPersonInfoWithFilter1.SelectedPersonID;
            _UserInfo.UserName = txtUserName.Text.Trim();
            _UserInfo.PassWord = txtPassWord.Text.Trim();
            _UserInfo.IsActive = chbIsActive.Checked;
        }

        private void _SaveData()
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _GetUserInfo();

            if (_UserInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.eUpdate;
            this.Text = "Update User";
            lblTitle.Text = $"Update User : ";
            lblUserID.Text = _UserInfo.UserID.ToString();
            ctrlPersonInfoWithFilter1.FilterPersonEnabled = false;
            //DataBack?.Invoke(this, _UserInfo.UserID);
        }


        //Constructor :-
        private void _LoadMode()
        {
            if (_UserID == -1)
            {
                _Mode = enMode.eAddNew;
                return;
            }
            _Mode = enMode.eUpdate;
        }
        public frmAddEditUser()
        {
            InitializeComponent();

            _UserID = -1;
            _LoadMode();
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _LoadMode();
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.eUpdate)
            {
                ctrlPersonInfoWithFilter1.FilterPersonEnabled = false;
                _LoadDataInUpdateMode();
            }
        }
        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterFocus();
        }


        //Next Step to Login Screen :-
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.eUpdate)
            {
                tpLoginInfo.Enabled = true;
                btnSaveUserData.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            //incase Of Add New Mode :-
            if (ctrlPersonInfoWithFilter1.SelectedPersonID != -1)
            {
                if (clsUser.IsExistByPersonID(ctrlPersonInfoWithFilter1.SelectedPersonID))
                {
                    MessageBox.Show($"Selected Person [{ctrlPersonInfoWithFilter1.SelectedPersonID}] Already has a User, Chose another One!", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonInfoWithFilter1.FilterFocus();
                }
                else
                {
                    tpLoginInfo.Enabled = true;
                    btnSaveUserData.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show($"Please Select a Person!", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoWithFilter1.FilterFocus();
            }
        }


        //UserName :-
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This Field is Required!");
                return;
            }

            if (_Mode == enMode.eAddNew)
            {
                if (clsUser.IsExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, $"UserName [{txtUserName.Text.Trim()}] Used By another User in The System!");
                    return;
                }
            }
            else
            {
                if (_UserInfo.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.IsExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, $"UserName [{txtUserName.Text.Trim()}] Used By another User in The System!");
                        return;
                    }
                }
            }
            errorProvider1.SetError(txtUserName, null);
        }


        //PassWord :-
        private void txtPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassWord, "This Field is Required!");
                return;
            }
            errorProvider1.SetError(txtPassWord, null);
        }


        //Confirm PassWord :-
        private void txtConfirmPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtConfirmPassWord.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassWord, "This Field is Required!");
                return;
            }

            if (txtConfirmPassWord.Text.Trim() != txtPassWord.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassWord, "PassWord Confrimation Does Not Match PassWord!");
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
            _SaveData();
        }
    }
}