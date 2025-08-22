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

namespace DVLDSystem.DVLD.Tests.Schedule_Tests
{
    public partial class frmAddEditTestAppointment : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestAppointmentID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;


        //Private Methods :-
        private void GetFormTilte()
        {
            this.Text = (_TestAppointmentID == -1) ? "Add Test Appointment" : "Update Test Appointment";
        }


        //Public Methods :-
        public void DataBackEventHandler(string FormTitle)
        {
            this.Text = FormTitle;
        }


        //Constructor :-
        public frmAddEditTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }
        private void frmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            GetFormTilte();
            ctrlAddEditTestAppointment1.TestTypeID = _TestTypeID;
            ctrlAddEditTestAppointment1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
            ctrlAddEditTestAppointment1.DataBack += DataBackEventHandler;
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}