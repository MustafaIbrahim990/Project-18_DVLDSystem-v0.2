using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.DVLD.Login;
using DVLDSystem.DVLD.Global_User;
using DVLDSystem.DVLD.User;
using DVLDSystem.DVLD.Applications.Application_Types;
using DVLDSystem.DVLD.Tests.Test_Types;
using DVLDSystem.DVLD.Applications.Local_Driving_License;
using DVLDSystem.DVLD.Driving_License.International_Driving_License;
using DVLDSystem.DVLD.Applications.International_Driving_License;
using DVLDSystem.DVLD.Driver;
using DVLDSystem.DVLD.Applications.Renew_Local_Driving_License;
using DVLDSystem.DVLD.Applications.Replacement_For_Lost_Or_Damaged_License;
using DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention;
using DVLDSystem.DVLD.Driving_License.Detain_License;

namespace DVLDSystem.DVLD
{
    public partial class frmMainScreen : Form
    {
        //Properties :-
        private frmLogin _frmLoginScreen;


        //Constructor :-
        public frmMainScreen(frmLogin frm)
        {
            InitializeComponent();

            _frmLoginScreen = frm;
        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {

        }
        private void frmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsGlobal.CurrentUser != null)
                _frmLoginScreen.Close();
        }


        //Account Settings :-
        //Current User Info :-
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show($"Error : Could Not Find User With ID [{clsGlobal.CurrentUser.UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }


        //Chaange PassWord :-
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show($"Error : Could Not Find User With ID [{clsGlobal.CurrentUser.UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            frmChangePassWord frm = new frmChangePassWord(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }


        //Sign Out :-
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginScreen.Show();
            this.Close();
        }


        //Manage People :-
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }


        //Manage Users :-
        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }


        //Manage Drivers :-
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }


        //Manage Local Driving License Application :-
        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }
        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }


        //Manage International Driving License Application :-
        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense frm = new frmIssueInternationalDrivingLicense();
            frm.ShowDialog();
        }
        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageInternationalDrivingLicenseApplications frm = new frmManageInternationalDrivingLicenseApplications();
            frm.ShowDialog();
        }


        //Renew Driving License :-
        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplications frm = new frmRenewLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }


        //Replacement Driving License for (Lost Or Damaged) :-
        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForLostOrDamagedDrivingLicense frm = new frmReplacementForLostOrDamagedDrivingLicense();
            frm.ShowDialog();
        }


        //Retake Test :-
        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }


        //Manage Detained Driving Licenses :-
        private void ManageDetainedLicensestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageLicenseReleaseAndDetention frm = new frmManageLicenseReleaseAndDetention();
            frm.ShowDialog();
        }


        //Detain Driving Licenses :-
        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }


        //Release Detained Driving License :-
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }
        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }


        //Manage Application Types :-
        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }


        //Manage Test Types :-
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }
    }
}