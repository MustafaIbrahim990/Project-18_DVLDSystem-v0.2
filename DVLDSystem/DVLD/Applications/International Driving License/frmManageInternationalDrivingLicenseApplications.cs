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
using DVLDSystem.DVLD.People;
using DVLDSystem.DVLD.Driving_License.International_Driving_License;
using DVLDSystem.DVLD.Applications.International_Driving_License;

namespace DVLDSystem.DVLD.Driving_License.International_Driving_License
{
    public partial class frmManageInternationalDrivingLicenseApplications : Form
    {
        //Private Properties :-
        private static DataTable _dtInternationalDrivingLicenseApplicationLists;


        //Private Methods :-
        private bool _IsVisible(Control control)
        {
            return control.Visible;
        }

        private void _FocusControl(Control control)
        {
            control.Focus();
        }

        private void _GetInternationalDrivingLicenseApplicationLists()
        {
            _dtInternationalDrivingLicenseApplicationLists = clsInternationalDrivingLicense.GetAllInternationalDrivingLicenseApplications();
        }

        private void _ShowInternationalDrivingLicenseApplicationListsInGrid()
        {
            dgvInterationalDrivingLicenseApplicationLists.DataSource = _dtInternationalDrivingLicenseApplicationLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvInterationalDrivingLicenseApplicationLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetInternationalDrivingLicenseApplicationLists();
            _ShowInternationalDrivingLicenseApplicationListsInGrid();
            _ShowRecordCountInGrid();

            cbFilterBy.SelectedIndex = 0;
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvInterationalDrivingLicenseApplicationLists.Rows.Count > 0)
            {
                dgvInterationalDrivingLicenseApplicationLists.Columns[0].HeaderText = "International License ID";
                dgvInterationalDrivingLicenseApplicationLists.Columns[0].Width = 110;

                dgvInterationalDrivingLicenseApplicationLists.Columns[1].HeaderText = "Application ID";
                dgvInterationalDrivingLicenseApplicationLists.Columns[1].Width = 110;

                dgvInterationalDrivingLicenseApplicationLists.Columns[2].HeaderText = "Driver ID";
                dgvInterationalDrivingLicenseApplicationLists.Columns[2].Width = 110;

                dgvInterationalDrivingLicenseApplicationLists.Columns[3].HeaderText = "Local License ID";
                dgvInterationalDrivingLicenseApplicationLists.Columns[3].Width = 110;

                dgvInterationalDrivingLicenseApplicationLists.Columns[4].HeaderText = "Issue Date";
                dgvInterationalDrivingLicenseApplicationLists.Columns[4].Width = 200;

                dgvInterationalDrivingLicenseApplicationLists.Columns[5].HeaderText = "Expiration Date";
                dgvInterationalDrivingLicenseApplicationLists.Columns[5].Width = 200;

                dgvInterationalDrivingLicenseApplicationLists.Columns[6].HeaderText = "Is Active";
                dgvInterationalDrivingLicenseApplicationLists.Columns[6].Width = 100;
            }
        }

        private void _FilterDataInGridByIntValue(string ColumnName, int Value)
        {
            _dtInternationalDrivingLicenseApplicationLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _FilterDataInGridByStringValue(string ColumnName, string Value)
        {
            _dtInternationalDrivingLicenseApplicationLists.DefaultView.RowFilter = String.Format($"{ColumnName} Like '{Value}%'");
        }

        private void _FilterDataInGridByBooleanValue(string ColumnName, bool Value)
        {
            _dtInternationalDrivingLicenseApplicationLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _RefreshDataInGridWithoutFilter()
        {
            _dtInternationalDrivingLicenseApplicationLists.DefaultView.RowFilter = null;
        }

        private void _RefreshDataInGridWithFilter()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalDrivingLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingDrivingLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            //We Filter DataInGrid :-
            if (FilterColumn == "InternationalDrivingLicenseID" || FilterColumn == "ApplicationID" || FilterColumn == "DriverID" || FilterColumn == "IssuedUsingDrivingLicenseID")
            {
                _FilterDataInGridByIntValue(FilterColumn, int.Parse(txtFilterValue.Text.Trim()));
            }
            else
            {
                _FilterDataInGridByStringValue(FilterColumn, txtFilterValue.Text.Trim());
            }
        }


        //Constructor :-
        public frmManageInternationalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmManageInternationalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }


        //cbFilter By :-
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = null;
            cbIsActive.Text = null;
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active");
            cbIsActive.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text == "Is Active");

            if (cbFilterBy.Text == "None")
            {
                _RefreshDataInGridWithoutFilter();
                _ShowRecordCountInGrid();
                return;
            }

            if (_IsVisible(txtFilterValue))
            {
                _FocusControl(txtFilterValue);
                return;
            }

            if (_IsVisible(cbIsActive))
            {
                cbIsActive.SelectedIndex = 0;
                _FocusControl(cbIsActive);
            }
        }


        //cbIsActive :-
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.Text)
            {
                case "All":
                    _RefreshDataInGridWithoutFilter();
                    break;

                case "Yes":
                    _FilterDataInGridByBooleanValue("IsActive", true);
                    break;

                default:
                    _FilterDataInGridByBooleanValue("IsActive", false);
                    break;
            }
            _ShowRecordCountInGrid();
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "International License ID" || cbFilterBy.Text == "Application ID" || cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Local License ID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (clsValidation.IsEmpty(txtFilterValue.Text.Trim()))
            {
                txtFilterValue.Text = null;
                _RefreshDataInGridWithoutFilter();
            }
            else
            {
                _RefreshDataInGridWithFilter();
            }
            _ShowRecordCountInGrid();
        }


        //Issue International Driving License :-
        private void btnIssueInternationalDrivingLicense_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense frm = new frmIssueInternationalDrivingLicense();
            frm.ShowDialog();

            //Refresh The Form: -
            frmManageInternationalDrivingLicenseApplications_Load(null, null);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Show Person Details :-
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(clsDriver.Find((int)dgvInterationalDrivingLicenseApplicationLists.CurrentRow.Cells[2].Value).PersonID);
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageInternationalDrivingLicenseApplications_Load(null, null);
        }


        //Show International Driving License :-
        private void showInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalDrivingLicenseCard frm = new frmShowInternationalDrivingLicenseCard((int)dgvInterationalDrivingLicenseApplicationLists.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh The Form: -
            frmManageInternationalDrivingLicenseApplications_Load(null, null);
        }
        private void dgvInterationalDrivingLicenseApplicationLists_DoubleClick(object sender, EventArgs e)
        {
            showInternationalLicenseToolStripMenuItem.PerformClick();
        }


        //Show Person Licenses History :-
        private void showPersonLicneseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(clsDriver.Find((int)dgvInterationalDrivingLicenseApplicationLists.CurrentRow.Cells[2].Value).PersonID);
            frm.ShowDialog();

            //Refresh :-
            frmManageInternationalDrivingLicenseApplications_Load(null, null);
        }
    }
}