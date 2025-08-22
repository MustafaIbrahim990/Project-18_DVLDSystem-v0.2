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

namespace DVLDSystem.DVLD.User.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        //Enums :-
        private enum enGender { eMale = 1, Female = 2 };


        //Properties :-
        private int _UserID = -1;
        private clsUser _UserInfo;

        public int UserID
        {
            get { return _UserID; }
        }
        public clsUser SelectedUserInfo
        {
            get { return _UserInfo; }
        }


        //Private Methods :-
        private void _ResetUserInfo()
        {
            ctrlPersonInfo1.ResetPersonInfo();
            _UserID = -1;
            lblUserID.Text = "????";
            lblUserName.Text = "????";
            lblIsActive.Text = "????";
        }

        private void _FillUserInfo()
        {
            _UserID = _UserInfo.PersonID;
            lblUserID.Text = _UserInfo.UserID.ToString();
            lblUserName.Text = _UserInfo.UserName.Trim();
            lblIsActive.Text = (_UserInfo.IsActive) ? "Yes" : "No";

            ctrlPersonInfo1.LoadPersonInfo(_UserInfo.PersonID);
        }


        //Public Methods :-
        public void LoadUserInfo(int UserID)
        {
            _UserInfo = clsUser.Find(UserID);

            if (_UserInfo == null)
            {
                _ResetUserInfo();
                MessageBox.Show($"No User With ID [{_UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }


        //Constructor :-
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}