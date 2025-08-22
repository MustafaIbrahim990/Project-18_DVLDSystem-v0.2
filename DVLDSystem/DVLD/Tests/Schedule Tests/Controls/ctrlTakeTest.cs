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

namespace DVLDSystem.DVLD.Tests.Schedule_Tests.Controls
{
    public partial class ctrlTakeTest : UserControl
    {
        //Privte Properties :-
        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointmentInfo;

        private int _TestID = -1;

        private clsTestType.enTestType _TestTypeID;


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
        public int TestID
        {
            get { return _TestID; }
        }
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _LoadTestTypeTitle(string Title)
        {
            gbTestAppointmentInfo.Text = Title;
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

        private bool _GetTestAppointmentObject()
        {
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointmentInfo == null)
            {
                _TestAppointmentID = -1;
                _ShowMessageError($"No Test Appointment With ID [{_TestAppointmentID}] in The System!", "Not Found!");
                return false;
            }
            return true;
        }

        private bool _DoesTakedTestBefore()
        {
            return clsTest.DoesTakedTestBefore(_TestAppointmentID);
        }

        private void _RefreshUIWithTestInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblName.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationInfo.FullName;
            lblTrial.Text = clsTest.GetTotalTrailPerTestType(_TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestTypeID).ToString();
            lblAppointmentDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString();
            lblTestFees.Text = _TestAppointmentInfo.PaidFees.ToString() + " $";

            _TestID = (_DoesTakedTestBefore()) ? clsTest.GetTestID(_TestAppointmentID) : -1;
            lblTestID.Text = (_TestID != -1) ? _TestID.ToString() : "N/A";
        }

        private void _LoadTestData()
        {
            if (!_GetTestAppointmentObject())
                return;

            _RefreshUIWithTestInfo();
        }


        //Public Methods :-
        public void LoadTestInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _LoadTestData();
        }


        //Constructor :-
        public ctrlTakeTest()
        {
            InitializeComponent();
        }
        private void ctrlTakeTest_Load(object sender, EventArgs e)
        {

        }
    }
}