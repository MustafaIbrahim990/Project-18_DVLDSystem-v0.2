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
using DVLDSystem.DVLD.Global_User;
using DVLDSystem_BusinessLayer;

namespace DVLDSystem.DVLD.Login
{
    public partial class frmLogin : Form
    {
        //Private Properties :-
        private string UserName = "";
        private string PassWord = "";

        private clsUser _UserInfo;


        //Private Methods :-
        private bool _CheckLocalRegistryData()
        {
            //string UserName = "", PassWord = "";

            //if (clsGlobal.GetUserNameANDPassWord(ref UserName, ref PassWord))
            //{
            //    this.UserName = UserName;
            //    this.PassWord = PassWord;

            //    return true;
            //}
            //return false;
            return clsGlobal.GetUserNameANDPassWord(ref this.UserName, ref this.PassWord);
        }
        private bool _RememberUserNameANDPassWord()
        {
            if (chbRememberMe.Checked)
            {
                //Save UserName and HashedPassword in Local Registry :-
                return clsGlobal.SaveUserNameANDPassWord(txtUserName.Text.Trim(), _UserInfo.PassWord);
            }
            else
            {
                return clsGlobal.SaveUserNameANDPassWord(null, null);
            }
        }
        private bool _GetUserInfo()
        {
            //string Salt = "";
            //string PassWord = clsGlobal.GenerateHash("1234", ref Salt);
            _UserInfo = clsUser.Find(txtUserName.Text.Trim(), clsGlobal.GenerateHash(txtPassWord.Text.Trim() + clsUser.Find(txtUserName.Text.Trim()).Salt));

            if (_UserInfo == null)
            {
                MessageBox.Show("Invalid UserName Or PassWord!", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassWord.Focus();
                return false;
            }
            return true;
        }


        //Constructor :-
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
        private void frmLogin_Shown(object sender, EventArgs e)
        {
            if (_CheckLocalRegistryData())
            {
                txtUserName.Text = this.UserName;
                txtPassWord.Focus();

                chbRememberMe.Checked = true;
                return;
            }
            txtUserName.Text = "";
            txtPassWord.Text = "";

            chbRememberMe.Checked = false;
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

            if (!clsUser.IsExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Invalid UserName!");
                return;
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


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Login :-
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_GetUserInfo())
                return;

            if (!_RememberUserNameANDPassWord())
                return;

            if (!_UserInfo.IsActive)
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Your Account is Not Active, Contact With Admin!", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsGlobal.CurrentUser = _UserInfo;
            this.Hide();

            frmMainScreen frm = new frmMainScreen(this);
            frm.ShowDialog();
        }
    }
}