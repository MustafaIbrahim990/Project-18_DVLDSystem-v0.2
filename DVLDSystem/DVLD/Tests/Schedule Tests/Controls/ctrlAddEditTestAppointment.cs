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

namespace DVLDSystem.DVLD.Tests.Schedule_Tests.Controls
{
    public partial class ctrlAddEditTestAppointment : UserControl
    {
        //Delegate :-
        public delegate void DataBackEventHandler(string FormTitle);
        public event DataBackEventHandler DataBack;

        //Enums :-
        private enum enMode { eAddNew = 1, eUpdate = 2 };
        private enMode _Mode = enMode.eAddNew;

        private enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private enum enUpdateMode { NotTakeTest = 0, TakeTest = 1 };
        private enUpdateMode _UpdateMode = enUpdateMode.NotTakeTest;


        //Private Properties :-
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointmentInfo;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;


        //Public Properties :-
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                _UpdateTestTypeUI();
            }
        }


        //Private Methods :-
        private void _LoadTestTypeTitle(string Title)
        {
            gbTestType.Text = Title;
        }

        private void _LoadTestTypeImage(Image image)
        {
            pictureBox1.Image = image;
        }

        private void _UpdateTestTypeUI()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.eVisionTest:

                    _LoadTestTypeTitle("Vision Test");
                    _LoadTestTypeImage(Properties.Resources.Vision_512);
                    break;

                case clsTestType.enTestType.eWrittenTest:

                    _LoadTestTypeTitle("Written Test");
                    _LoadTestTypeImage(Properties.Resources.Written_Test_512);
                    break;

                case clsTestType.enTestType.eStreetTest:

                    _LoadTestTypeTitle("Street Test");
                    _LoadTestTypeImage(Properties.Resources.driving_test_512);
                    break;
            }
        }

        private void _ShowErrorMessage(string Message, string Caption)
        {
            MessageBox.Show($"Error : {Message}", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _ShowUserMessage(bool ShowControl, string Message = "")
        {
            lblUserMessage.Visible = ShowControl;
            lblUserMessage.Text = Message;
        }

        private void _UpdateUIWhenFailedShowInfo(bool ShowControl)
        {
            dtpAppointmentDate.Enabled = ShowControl;
            btnSaveData.Enabled = ShowControl;
        }

        private bool _IsLocalDrivingLicenseApplicationDataValid()
        {
            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _ShowErrorMessage($"No Local Driving License Application With ID [{_LocalDrivingLicenseApplicationID}] in The System!", "Error!");
                _ShowUserMessage(true, $"No Local Driving License Application With ID [{_LocalDrivingLicenseApplicationID}] in The System!");
                _UpdateUIWhenFailedShowInfo(false);
                return false;
            }
            return true;
        }

        private bool _IsTestAppointmentDataValid()
        {
            if (_TestAppointmentInfo == null)
            {
                _ShowErrorMessage($"No Test Appointment With ID[{_TestAppointmentID}] in The System!", "Error!");
                _ShowUserMessage(true, $"No Test Appointment With ID [{_TestAppointmentID}] in The System!");
                _UpdateUIWhenFailedShowInfo(false);
                return false;
            }
            return true;
        }

        private void _LoadFormMode()
        {
            //if no Test Appointment the Mode is AddNew mode otherwise is Update mode
            _Mode = (_TestAppointmentID == -1) ? enMode.eAddNew : enMode.eUpdate;
        }

        private void _LoadCreationMode()
        {
            //decide if The Creation Mode is retake test or not Based on if The Person attend the Test Type By _LocalDrivingLicenseApplicationID
            _CreationMode = (_LocalDrivingLicenseApplicationInfo.DoesAttendTestType(_TestTypeID)) ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;
        }

        private void _LoadUpdateMode()
        {
            //decide if The update Mode is Take Test or not Based on if The Person attend the Test Type By _TestAppointmentID
            _UpdateMode = (clsTestAppointment.DoesAttendTestTypeAtUpdateMode(_TestAppointmentID, _TestTypeID)) ? enUpdateMode.TakeTest : enUpdateMode.NotTakeTest;
        }

        private void _LoadCreationOrUpdateModeBasedOnFormMode()
        {
            if (_Mode == enMode.eAddNew)
                _LoadCreationMode();
            else
                _LoadUpdateMode();
        }

        private void _DetermineModes()
        {
            _LoadFormMode();
            _LoadCreationOrUpdateModeBasedOnFormMode();
        }

        private void _ResetUIForSharedData()
        {
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplicationInfo.FullName;
            lblTrial.Text = clsTest.GetTotalTrailPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID).ToString();
        }

        private void _LoadSharedData()
        {
            _ShowUserMessage(false);
            _UpdateUIWhenFailedShowInfo(true);
            _ResetUIForSharedData();
        }

        private void _DisableRetakeTestInfo()
        {
            lblTitle.Text = "Schedule Test";
            lblRetakeTestApplicationID.Text = "N/A";
            lblRetakeApplicationFees.Text = "0";
            lblTotalFees.Text = "0";

            gbRetakeTestInfo.Enabled = false;
        }

        private void _EnableRetakeTestInfoForAddMode()
        {
            lblTitle.Text = "Schedule Retake Test";
            lblRetakeTestApplicationID.Text = "N/A";
            lblRetakeApplicationFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RetakeTest).Fees.ToString() + " $";
            lblTotalFees.Text = (Convert.ToSingle(lblTestFees.Text.Replace("$", "").Trim()) + Convert.ToSingle(lblRetakeApplicationFees.Text.Replace("$", "").Trim())).ToString() + " $";

            gbRetakeTestInfo.Enabled = true;
        }

        private void _RefreshAddModeData()
        {
            if (_CreationMode == enCreationMode.FirstTimeSchedule)
            {
                _DisableRetakeTestInfo();
                return;
            }
            _EnableRetakeTestInfoForAddMode();
        }

        private void _ResetUIForAddMode()
        {
            dtpAppointmentDate.MinDate = DateTime.Now;
            dtpAppointmentDate.Value = DateTime.Now;
            lblTestFees.Text = clsTestType.Find(TestTypeID).TestTypeFees.ToString() + " $";
        }

        private bool _LoadAddModeData()
        {
            _ResetUIForAddMode();

            _TestAppointmentInfo = new clsTestAppointment();
            _RefreshAddModeData();
            return true;
        }

        private void _EnableRetakeTestInfoForUpdateMode()
        {
            lblRetakeTestApplicationID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
            lblRetakeApplicationFees.Text = _TestAppointmentInfo.RetakeTestApplicationInfo.PaidFees.ToString() + " $";
            lblTotalFees.Text = (_TestAppointmentInfo.PaidFees + _TestAppointmentInfo.RetakeTestApplicationInfo.PaidFees).ToString() + " $";
            gbRetakeTestInfo.Enabled = true;
        }

        private bool _RefreshLockedAppointmentInfoForUpdateMode()
        {
            _ShowUserMessage(true, "Person Already Take This Test, Appointment Locked!");
            _UpdateUIWhenFailedShowInfo(false);
            lblTitle.Text = "Schedule Retake Test";
            return false;
        }

        private bool _RefreshUnLockedAppointmentInfoForUpdateMode()
        {
            _ShowUserMessage(false);
            _UpdateUIWhenFailedShowInfo(true);
            lblTitle.Text = "Schedule Test";
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointmentInfo.IsLocked)
                return _RefreshLockedAppointmentInfoForUpdateMode();
            else
                return _RefreshUnLockedAppointmentInfoForUpdateMode();
        }

        private bool _RefreshRetakeTestInfo()
        {
            if (_TestAppointmentInfo.RetakeTestApplicationID != -1)
                _EnableRetakeTestInfoForUpdateMode();
            else
                _DisableRetakeTestInfo();

            return _HandleAppointmentLockedConstraint();
        }

        private void _ResetUIForUpdateMode()
        {
            if (DateTime.Now < dtpAppointmentDate.Value)
                dtpAppointmentDate.MinDate = DateTime.Now;
            else
                dtpAppointmentDate.MinDate = dtpAppointmentDate.Value;

            dtpAppointmentDate.Value = _TestAppointmentInfo.AppointmentDate;
            lblTestFees.Text = _TestAppointmentInfo.PaidFees.ToString() + " $";
        }

        private bool _RefreshUpdateModeData()
        {
            _ResetUIForUpdateMode();
            return _RefreshRetakeTestInfo();
        }

        private bool _LoadUpdateModeData()
        {
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);

            if (!_IsTestAppointmentDataValid())
                return false;

            return _RefreshUpdateModeData();
        }

        private bool _LoadDataBasedOnMode()
        {
            if (_Mode == enMode.eAddNew)
                return _LoadAddModeData();
            else
                return _LoadUpdateModeData();
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.eAddNew && clsTestAppointment.DoesHaveActiveTestAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                _ShowUserMessage(true, "Person Already have an Active Appointment For This Test, You Can't Add New Appointment!");
                _UpdateUIWhenFailedShowInfo(false);
                return false;
            }
            return true;
        }

        private bool _ValidatePreviousTest(string UserMessage, bool IsPass)
        {
            if (!IsPass)
            {
                _ShowUserMessage(true, UserMessage);
                _UpdateUIWhenFailedShowInfo(false);
                return false;
            }
            _ShowUserMessage(false);
            _UpdateUIWhenFailedShowInfo(true);
            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.eVisionTest:
                    _UpdateUIWhenFailedShowInfo(true);
                    return true;

                case clsTestType.enTestType.eWrittenTest:
                    return _ValidatePreviousTest("Can't Sechule, Vision Test Should be Passed First", clsTest.DoesPassTestType(_LocalDrivingLicenseApplicationID, clsTestType.enTestType.eVisionTest));

                case clsTestType.enTestType.eStreetTest:
                    return _ValidatePreviousTest("Can't Sechule, Written Test Should be Passed First", clsTest.DoesPassTestType(_LocalDrivingLicenseApplicationID, clsTestType.enTestType.eWrittenTest));

                default:
                    return true;
            }
        }

        private bool IsAppointmentTestDateValid()
        {
            if (dtpAppointmentDate.Value < DateTime.Now)
            {
                _ShowErrorMessage("The Test Appointemnt Date Must be Greater Than The Current Time!", "Not Valid!");
                return false;
            }
            return true;
        }

        private bool _GetNewRetakeTestApplicationID()
        {
            _TestAppointmentInfo.RetakeTestApplicationID = -1;
            clsApplication NewRetakeTestApplicationInfo = new clsApplication();

            NewRetakeTestApplicationInfo.ApplicantPersonID = _LocalDrivingLicenseApplicationInfo.ApplicantPersonID;
            NewRetakeTestApplicationInfo.ApplicationDate = DateTime.Now;
            NewRetakeTestApplicationInfo.ApplicationTypeID = (int)clsApplicationType.enApplicationType.RetakeTest;
            NewRetakeTestApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            NewRetakeTestApplicationInfo.LastStatusDate = DateTime.Now;
            NewRetakeTestApplicationInfo.PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RetakeTest).Fees;
            NewRetakeTestApplicationInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!NewRetakeTestApplicationInfo.Save())
            {
                _ShowErrorMessage("Error : Failed to Create Application!", "Failed");
                return false;
            }
            _TestAppointmentInfo.RetakeTestApplicationID = NewRetakeTestApplicationInfo.ApplicationID;
            return true;
        }

        private bool _HandleRetakeTestApplicationID()
        {
            if (_Mode == enMode.eAddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                return _GetNewRetakeTestApplicationID();
            }
            return true;
        }

        private bool _FillTestAppointmentObjectForSave()
        {
            try
            {
                _TestAppointmentInfo.AppointmentDate = dtpAppointmentDate.Value;
                _TestAppointmentInfo.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
                _TestAppointmentInfo.TestTypeID = _TestTypeID;
                _TestAppointmentInfo.PaidFees = Convert.ToSingle(lblTestFees.Text.Replace("$", "").Trim());
                _TestAppointmentInfo.IsLocked = false;
                _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }
            catch (Exception ex)
            {
                _ShowErrorMessage(ex.Message, "Error!");
                return false;
            }
            return true;
        }

        private bool _GetInfoToSave()
        {
            if (!IsAppointmentTestDateValid())
                return false;

            if (!_HandleRetakeTestApplicationID())
                return false;

            return _FillTestAppointmentObjectForSave();
        }

        private void _ResetUIAfterSavedData()
        {
            _Mode = enMode.eUpdate;
            DataBack?.Invoke("Update Test Appointment");

            if (_TestAppointmentInfo.RetakeTestApplicationID != -1)
                lblRetakeTestApplicationID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
            else
                lblRetakeTestApplicationID.Text = "N/A";
        }

        private void _SaveData()
        {
            if (!_GetInfoToSave())
                return;

            if (_TestAppointmentInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ResetUIAfterSavedData();
        }


        //Public Methods :-
        public void LoadInfo(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal(_LocalDrivingLicenseApplicationID);

            if (!_IsLocalDrivingLicenseApplicationDataValid())
                return;

            _DetermineModes();
            _LoadSharedData();

            if (!_LoadDataBasedOnMode())
                return;

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;
        }


        //Constructor :-
        public ctrlAddEditTestAppointment()
        {
            InitializeComponent();
        }
        private void ctrlAddEditTestAppointment_Load(object sender, EventArgs e)
        {

        }


        //Save Data :-
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            _SaveData();
        }
    }
}