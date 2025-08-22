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
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Tests.Schedule_Tests
{
    public partial class frmTakeTest : Form
    {
        //Properties :-
        private int _TestID = -1;
        private clsTest _TestInfo;

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointmentInfo;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;


        //Private Methods :-
        private void _ShowUserMessage(bool ShowMessage, string Message = "")
        {
            lblUserMessage.Visible = ShowMessage;
            lblUserMessage.Text = Message;
        }

        private void _ShowMessasgeBox(string Message, string Caption, MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Error)
        {
            MessageBox.Show(Text, Caption, messageBoxButtons, messageBoxIcon);
        }

        private void _LoadUserControlData()
        {
            ctrlTakeTest1.TestTypeID = _TestTypeID;
            ctrlTakeTest1.LoadTestInfo(_TestAppointmentID);
        }

        private void _ResetUIWhenCounditionFailed()
        {
            rbPass.Enabled = false;
            rbFail.Enabled = false;
            txtNotes.Enabled = false;
            btnSaveData.Enabled = false;
        }

        private bool _ResetDefaultUIData()
        {
            _ShowUserMessage(false);

            if (ctrlTakeTest1.TestAppointmentID == -1)
            {
                _ResetUIWhenCounditionFailed();
                return false;
            }

            rbPass.Checked = true;
            txtNotes.Text = null;
            btnSaveData.Enabled = true;
            return true;
        }

        private bool _GetTestAppointmentObject()
        {
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointmentInfo == null)
            {
                _ResetUIWhenCounditionFailed();
                _ShowMessasgeBox($"Error : No Test Appointment With ID [{_TestAppointmentID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _DoesTakedTestBefore()
        {
            _TestID = ctrlTakeTest1.TestID;
            return _TestID != -1;
        }

        private bool _GetTestObject()
        {
            _TestInfo = clsTest.Find(_TestID);

            if (_TestInfo == null)
            {
                _ResetUIWhenCounditionFailed();
                _ShowMessasgeBox($"Error : No Test With ID [{_TestID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void _RefreshUIWithTestInfo()
        {
            _ShowUserMessage(true, "You Can't Change The Result of The Test!");

            if (_TestInfo.TestResult)
                rbPass.Checked = true;
            else
                rbFail.Checked = true;

            txtNotes.Text = _TestInfo.Notes;

            btnSaveData.Enabled = false;
            txtNotes.Enabled = false;
            rbPass.Enabled = false;
            rbFail.Enabled = false;
        }

        private void _LoadTestInfo()
        {
            //check if the person take test before or not 
            if (!_DoesTakedTestBefore())
            {
                _TestInfo = new clsTest();
                return;
            }

            //if take test will return data of the test
            if (!_GetTestObject())
                return;

            _RefreshUIWithTestInfo();
        }

        private bool _FillTestObjectForSave()
        {
            try
            {
                _TestInfo.TestAppointmentID = _TestAppointmentID;
                _TestInfo.TestResult = rbPass.Checked;
                _TestInfo.Notes = txtNotes.Text;
                _TestInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                return true;
            }
            catch (Exception ex)
            {
                _ShowMessasgeBox($"Error : {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool _GetInfoToSave()
        {
            return _FillTestObjectForSave();
        }

        private void _SaveData()
        {
            if (MessageBox.Show("Are You Sure You Want to Save? After That You Can't Change The Results?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!_GetInfoToSave())
                return;

            if (_TestInfo.Save())
            {
                btnSaveData.Enabled = false;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //Constructor :-
        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadUserControlData();

            if (!_ResetDefaultUIData())
                return;

            if (!_GetTestAppointmentObject())
                return;

            _LoadTestInfo();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Save Data :-
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            _SaveData();
            this.Close();
        }
    }
}