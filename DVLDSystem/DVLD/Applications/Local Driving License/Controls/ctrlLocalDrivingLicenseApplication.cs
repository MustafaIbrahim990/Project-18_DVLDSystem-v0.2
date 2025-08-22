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
using DVLDSystem.DVLD.Applications;
using DVLDSystem.DVLD.Tests;
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;

namespace DVLDSystem.DVLD.Applications.Local_Driving_License.Controls
{
    public partial class ctrlLocalDrivingLicenseApplication : UserControl
    {
        //Properties :-
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;

        public int SelectedLocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }
        public clsLocalDrivingLicenseApplication SelectedLocalDrivingLicenseApplicationInfo
        {
            get { return _LocalDrivingLicenseApplicationInfo; }
        }


        //Private Methods :-
        private void _ResetInfo()
        {
            ctrlApplicationBasicInfo1.ResetInfo();

            _LocalDrivingLicenseApplicationID = -1;
            lblLocalDrivingLicenseApplicationID.Text = "N/A";
            lblAppliedForLicense.Text = "????";
            lblPassedTests.Text = "????";

            llShowLicenseInfo.Enabled = false;
        }
        private void _FillInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID;

            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplicationInfo.ApplicationID);
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblPassedTests.Text = clsTest.GetPassTestCount(_LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID).ToString() + "/3";

            llShowLicenseInfo.Enabled = clsDrivingLicense.DosePersonHaveDrivingLicense(_LocalDrivingLicenseApplicationInfo.ApplicantPersonID, _LocalDrivingLicenseApplicationInfo.LicenseClassID);
        }


        //Public Methods :-
        public void LoadLocalDrivingLicenseApplicationInfoByLocalID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _ResetInfo();
                MessageBox.Show($"No Local Driving License Application With ID [{LocalDrivingLicenseApplicationID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
        }
        public void LoadLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocalBy(ApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _ResetInfo();
                MessageBox.Show($"No Local Driving License Application With ID [{ApplicationID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
        }


        //Constructor :-
        public ctrlLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        private void ctrlLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }


        //Show Local Driving License Info :-
        private void llShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsDrivingLicense.DosePersonHaveDrivingLicense(_LocalDrivingLicenseApplicationInfo.ApplicantPersonID, _LocalDrivingLicenseApplicationInfo.LicenseClassID))
            {
                MessageBox.Show($"Person With ID [{_LocalDrivingLicenseApplicationInfo.ApplicantPersonID}] doesn't have a License [{_LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName}] in The System!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard(clsDrivingLicense.GetDrivingLicenseID(_LocalDrivingLicenseApplicationID));
            frm.ShowDialog();

            //Refresh :-
            LoadLocalDrivingLicenseApplicationInfoByLocalID(_LocalDrivingLicenseApplicationID);
        }
    }
}