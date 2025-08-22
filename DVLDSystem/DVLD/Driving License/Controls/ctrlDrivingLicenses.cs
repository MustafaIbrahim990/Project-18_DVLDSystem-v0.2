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
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;
using DVLDSystem.DVLD.Driving_License.International_Driving_License;

namespace DVLDSystem.DVLD.Driving_License.Controls
{
    public partial class ctrlDrivingLicenses : UserControl
    {
        //Private Prpperties :-
        private static DataTable _dtLocalDrivingLicenseLists;
        private static DataTable _dtInternationalDrivingLicenseLists;

        private int _PersonID = -1;
        private int _DriverID = -1;


        //Private Methods :-
        private void _ShowErrorMessage(string Message, string Caption)
        {
            MessageBox.Show($"Error : {Message}", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool _IsDriverExist()
        {
            if (!clsDriver.IsExist(_DriverID))
            {
                _ShowErrorMessage($"Error : No Driver With ID [{_DriverID}] in The System!", "Not Found!");
                return false;
            }
            return true;
        }

        private bool _IsPersonDriver()
        {
            return clsDriver.IsPersonDriver(_PersonID);
        }

        private void _GetLocalDrivingLicenseLists()
        {
            _dtLocalDrivingLicenseLists = clsDrivingLicense.GetDrivingLicensesForDriver(_DriverID);
        }

        private void _ShowLocalDrivingLicenseListsInGrid()
        {
            dgvLocalDrivingLicenseLists.DataSource = _dtLocalDrivingLicenseLists;
        }

        private void _ShowLocalRecordCountInGrid()
        {
            lblRecordCountInLocal.Text = dgvLocalDrivingLicenseLists.Rows.Count.ToString();
        }

        private void _GetInternationalDrivingLicenseLists()
        {
            _dtInternationalDrivingLicenseLists = clsInternationalDrivingLicense.GetDrivingLicensesForDriver(_DriverID);
        }

        private void _ShowInternationalDrivingLicenseListsInGrid()
        {
            dgvInternationalDrivingLicenseLists.DataSource = _dtInternationalDrivingLicenseLists;
        }

        private void _ShowInternationalRecordCountInGrid()
        {
            lblRecordCountInInternational.Text = dgvInternationalDrivingLicenseLists.Rows.Count.ToString();
        }

        private void _LoadLocalDrivingLicensesInfo()
        {
            _GetLocalDrivingLicenseLists();
            _ShowLocalDrivingLicenseListsInGrid();
            _ShowLocalRecordCountInGrid();
        }

        private void _LoadInternationalDrivingLicensesInfo()
        {
            _GetInternationalDrivingLicenseLists();
            _ShowInternationalDrivingLicenseListsInGrid();
            _ShowInternationalRecordCountInGrid();
        }

        private void _RefreshDataInGrid()
        {
            _LoadLocalDrivingLicensesInfo();
            _LoadInternationalDrivingLicensesInfo();
        }

        private void _ResetColumnsOfLocalDrivingLicense()
        {
            if (dgvLocalDrivingLicenseLists.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseLists.Columns[0].HeaderText = "Local L. ID";
                dgvLocalDrivingLicenseLists.Columns[0].Width = 70;

                dgvLocalDrivingLicenseLists.Columns[1].HeaderText = "Application ID";
                dgvLocalDrivingLicenseLists.Columns[1].Width = 80;

                dgvLocalDrivingLicenseLists.Columns[2].HeaderText = "Class Name";
                dgvLocalDrivingLicenseLists.Columns[2].Width = 190;

                dgvLocalDrivingLicenseLists.Columns[3].HeaderText = "Issue Date";
                dgvLocalDrivingLicenseLists.Columns[3].Width = 120;

                dgvLocalDrivingLicenseLists.Columns[4].HeaderText = "Expiration Date";
                dgvLocalDrivingLicenseLists.Columns[4].Width = 120;

                dgvLocalDrivingLicenseLists.Columns[5].HeaderText = "Is Active";
                dgvLocalDrivingLicenseLists.Columns[5].Width = 90;
            }
        }

        private void _ResetColumnsOfInternationalDrivingLicense()
        {
            //We Need to Use (MultiThreading Or Asynchronous) Programming :-

            //if (dgvInternationalDrivingLicenseLists.Rows.Count > 0) 
            //{
            //    dgvInternationalDrivingLicenseLists.Columns[0].HeaderText = "Internation L. ID";
            //    dgvInternationalDrivingLicenseLists.Columns[0].Width = 80;

            //    dgvInternationalDrivingLicenseLists.Columns[1].HeaderText = "Application ID";
            //    dgvInternationalDrivingLicenseLists.Columns[1].Width = 70;

            //    dgvInternationalDrivingLicenseLists.Columns[2].HeaderText = "Local L. ID";
            //    dgvInternationalDrivingLicenseLists.Columns[2].Width = 70;

            //    dgvInternationalDrivingLicenseLists.Columns[3].HeaderText = "Issue Date";
            //    dgvInternationalDrivingLicenseLists.Columns[3].Width = 145;

            //    dgvInternationalDrivingLicenseLists.Columns[4].HeaderText = "Expiration Date";
            //    dgvInternationalDrivingLicenseLists.Columns[4].Width = 145;

            //    dgvInternationalDrivingLicenseLists.Columns[5].HeaderText = "Is Active";
            //    dgvInternationalDrivingLicenseLists.Columns[5].Width = 100;
            //}
        }

        private void _ResetColumnsInGrid()
        {
            _ResetColumnsOfLocalDrivingLicense();
            _ResetColumnsOfInternationalDrivingLicense();
        }


        //Public Methods :-
        public void LoadDrivingLicensesInfo(int DriverID)
        {
            _DriverID = DriverID;

            if (!_IsDriverExist())
                return;

            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }
        public void LoadDrivingLicensesInfoBy(int PersonID)
        {
            _PersonID = PersonID;

            if (!_IsPersonDriver())
                return;

            _DriverID = clsDriver.FindBy(PersonID).ID;

            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }
        public void Clear()
        {
            _dtLocalDrivingLicenseLists.Clear();
            _dtInternationalDrivingLicenseLists.Clear();
        }


        //Constructor :-
        public ctrlDrivingLicenses()
        {
            InitializeComponent();
        }
        private void ctrlDrivingLicenses_Load(object sender, EventArgs e)
        {

        }


        //Show Local Driving License :-
        private void showLocalDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard((int)dgvLocalDrivingLicenseLists.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh :-
            LoadDrivingLicensesInfo(_DriverID);
        }
        private void dgvLocalDrivingLicenseLists_DoubleClick(object sender, EventArgs e)
        {
            showLocalDrivingLicenseToolStripMenuItem1.PerformClick();
        }


        //Show International Driving License :-
        private void showInternationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalDrivingLicenseCard frm = new frmShowInternationalDrivingLicenseCard((int)dgvInternationalDrivingLicenseLists.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh :-
            LoadDrivingLicensesInfo(_DriverID);
        }
        private void dgvInternationalDrivingLicenseLists_DoubleClick_1(object sender, EventArgs e)
        {
            showInternationalDrivingLicenseToolStripMenuItem.PerformClick();
        }
    }
}