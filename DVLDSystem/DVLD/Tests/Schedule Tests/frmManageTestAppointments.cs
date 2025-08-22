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
using DVLDSystem.DVLD.Tests.Schedule_Tests;

namespace DVLDSystem.DVLD.Tests.Schedule_Tests
{
    public partial class frmManageTestAppointments : Form
    {
        //Private Prpperties :-
        private static DataTable _dtTestAppointmentLists;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;


        //Private Methods :-
        private void _LoadTestTypeTitle(string Title)
        {
            lblTitle.Text = Title;
        }

        private void _UpdateTestTypeUI()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.eVisionTest:
                    {
                        _LoadTestTypeTitle("Vision Test Appointment");
                        break;
                    }
                case clsTestType.enTestType.eWrittenTest:
                    {
                        _LoadTestTypeTitle("Written Test Appointment");
                        break;
                    }
                case clsTestType.enTestType.eStreetTest:
                    {
                        _LoadTestTypeTitle("Street Test Appointment");
                        break;
                    }
            }
        }

        private void _GetTestAppointmentLists()
        {
            _dtTestAppointmentLists = clsTestAppointment.GetTestAppointmentLists(_LocalDrivingLicenseApplicationID, _TestTypeID);
        }

        private void _ShowTestAppointmentListsInGrid()
        {
            dgvTestAppointmentLists.DataSource = _dtTestAppointmentLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvTestAppointmentLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetTestAppointmentLists();
            _ShowTestAppointmentListsInGrid();
            _ShowRecordCountInGrid();
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvTestAppointmentLists.Rows.Count > 0)
            {
                if (dgvTestAppointmentLists.Rows.Count > 0)
                {
                    dgvTestAppointmentLists.Columns[0].HeaderText = "Appointment ID";
                    dgvTestAppointmentLists.Columns[0].Width = 100;

                    dgvTestAppointmentLists.Columns[1].HeaderText = "Appointment Date";
                    dgvTestAppointmentLists.Columns[1].Width = 150;

                    dgvTestAppointmentLists.Columns[2].HeaderText = "Paid Fees";
                    dgvTestAppointmentLists.Columns[2].Width = 100;

                    dgvTestAppointmentLists.Columns[3].HeaderText = "Is Locked";
                    dgvTestAppointmentLists.Columns[3].Width = 100;
                }
            }
        }


        //Constructor :-
        public frmManageTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }
        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _UpdateTestTypeUI();
            _RefreshDataInGrid();
            ctrlLocalDrivingLicenseApplication1.LoadLocalDrivingLicenseApplicationInfoByLocalID(_LocalDrivingLicenseApplicationID);

            _ResetColumnsInGrid();
        }


        //Add New Test Appointment :-
        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.DoesHaveActiveTestAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                MessageBox.Show($"Person Already have an Active Appointment For This Test, You Can't Add New Appointment!", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointment.DoesPassTestType(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                MessageBox.Show($"This Person Already Passed in This Test, You Can Retake This Test Only if You Fail!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddEditTestAppointment frm = new frmAddEditTestAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID);
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageTestAppointments_Load(null, null);
        }


        //Edit Test Appointment :-
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestAppointmentLists.Rows.Count == 0)
                return;

            int TestAppointmentID = (int)dgvTestAppointmentLists.CurrentRow.Cells[0].Value;

            if (!clsTestAppointment.IsExist(TestAppointmentID))
            {
                MessageBox.Show($"No Test Appointment With ID [{TestAppointmentID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddEditTestAppointment frm = new frmAddEditTestAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageTestAppointments_Load(null, null);
        }


        //Take Test :-
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestAppointmentLists.Rows.Count == 0)
                return;

            int TestAppointmentID = (int)dgvTestAppointmentLists.CurrentRow.Cells[0].Value;

            if (!clsTestAppointment.IsExist(TestAppointmentID))
            {
                MessageBox.Show($"No Test Appointment With ID [{TestAppointmentID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestTypeID);
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageTestAppointments_Load(null, null);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}