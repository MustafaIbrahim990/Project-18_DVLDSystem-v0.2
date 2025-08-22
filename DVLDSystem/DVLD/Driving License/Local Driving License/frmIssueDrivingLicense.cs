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
using DVLDSystem.DVLD.Global_User;
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;

namespace DVLDSystem.DVLD.Driving_License
{
    public partial class frmIssueDrivingLicense : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;

        private int _DriverID = -1;
        private int _DrivingLicenseID = -1;


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }

        private void _UpdateUIWhenCondiationFailed()
        {
            txtNotes.Enabled = false;
            btnIssueDrivingLicenseForFirstTime.Enabled = false;
        }

        private bool _GetLocalDrivingLicenseApplicationObject()
        {
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _UpdateUIWhenCondiationFailed();
                _ShowMessageError($"Error : No Local Driving License Application With ID [{_LocalDrivingLicenseApplicationID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _DoesPassedAllTests()
        {
            if (!clsTest.DoesPassedAllTests(_LocalDrivingLicenseApplicationID))
            {
                _UpdateUIWhenCondiationFailed();
                _ShowMessageError($"Person Should Pass All Tests First! ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _DoesPersonHaveTheSameLicenseClass()
        {
            int DrivingLicenseID = clsDrivingLicense.GetActiveDrivingLicenseID(_LocalDrivingLicenseApplicationInfo.ApplicantPersonID, _LocalDrivingLicenseApplicationInfo.LicenseClassID);
            if (DrivingLicenseID != -1)
            {
                _UpdateUIWhenCondiationFailed();
                _ShowMessageError($"Person Already has Driving License Before With ID [{DrivingLicenseID}] in The System! ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void _LoadUserControl()
        {
            ctrlLocalDrivingLicenseApplication1.LoadLocalDrivingLicenseApplicationInfoByLocalID(_LocalDrivingLicenseApplicationID);
        }

        private void _IssueDrivingLicneseForTheFirstTime()
        {
            _DrivingLicenseID = _LocalDrivingLicenseApplicationInfo.IssueDrivingLicneseForTheFirstTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (_DrivingLicenseID != -1)
            {
                _ShowMessageError($"Driving License Issued Successfully With ID [{_DrivingLicenseID}] in The System.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
            else
            {
                _ShowMessageError($"Driving License Was Not Issued!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Constructor :-
        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            if (!_GetLocalDrivingLicenseApplicationObject())
                return;

            if (!_DoesPassedAllTests())
                return;

            if (!_DoesPersonHaveTheSameLicenseClass())
                return;

            _LoadUserControl();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Issue Driving Licnse For First Time :-
        private void btnIssueDrivingLicenseForFirstTime_Click(object sender, EventArgs e)
        {
            _IssueDrivingLicneseForTheFirstTime();
            this.Close();
        }
    }
}