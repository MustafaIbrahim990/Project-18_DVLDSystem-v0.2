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
using DVLDSystem.DVLD.People;
using DVLDSystem.DVLD.Driving_License;
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;
using DVLDSystem.Gobal_Classes;
using DVLDSystem.DVLD.Driving_License.Detain_License;
using DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention;

namespace DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention
{
    public partial class frmManageLicenseReleaseAndDetention : Form
    {
        //Private Properties :-
        private static DataTable _dtDrivingLicenseReleaseAndDetentionLists;


        //Private Methods :-
        private bool _IsVisible(Control control)
        {
            return control.Visible;
        }

        private void _FocusControl(Control control)
        {
            control.Focus();
        }

        private void _GetDrivingLicenseReleaseAndDetentionLists()
        {
            _dtDrivingLicenseReleaseAndDetentionLists = clsDetainedDrivingLicense.GetAllCustomInfo();
        }

        private void _ShowDrivingLicenseReleaseAndDetentionnListsInGrid()
        {
            dgvDrivingLicenseReleaseAndDetentionLists.DataSource = _dtDrivingLicenseReleaseAndDetentionLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvDrivingLicenseReleaseAndDetentionLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetDrivingLicenseReleaseAndDetentionLists();
            _ShowDrivingLicenseReleaseAndDetentionnListsInGrid();
            _ShowRecordCountInGrid();

            cbFilterBy.SelectedIndex = 0;
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvDrivingLicenseReleaseAndDetentionLists.Rows.Count > 0)
            {
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[0].HeaderText = "Detain ID";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[0].Width = 50;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[1].HeaderText = "Local License ID";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[1].Width = 70;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[2].HeaderText = "National No.";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[2].Width = 70;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[3].HeaderText = "Full Name";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[3].Width = 150;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[4].HeaderText = "Detain Date";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[4].Width = 100;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[5].HeaderText = "Fine Fees";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[5].Width = 70;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[6].HeaderText = "Is Released";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[6].Width = 70;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[7].HeaderText = "Release Date";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[7].Width = 100;

                dgvDrivingLicenseReleaseAndDetentionLists.Columns[8].HeaderText = "R. Application ID";
                dgvDrivingLicenseReleaseAndDetentionLists.Columns[8].Width = 120;
            }
        }

        private void _FilterDataInGridByIntValue(string ColumnName, int Value)
        {
            _dtDrivingLicenseReleaseAndDetentionLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _FilterDataInGridByStringValue(string ColumnName, string Value)
        {
            _dtDrivingLicenseReleaseAndDetentionLists.DefaultView.RowFilter = String.Format($"{ColumnName} Like '{Value}%'");
        }

        private void _FilterDataInGridByBooleanValue(string ColumnName, bool Value)
        {
            _dtDrivingLicenseReleaseAndDetentionLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _RefreshDataInGridWithoutFilter()
        {
            _dtDrivingLicenseReleaseAndDetentionLists.DefaultView.RowFilter = null;
        }

        private void _RefreshDataInGridWithFilter()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "Local License ID":
                    FilterColumn = "DrivingLicenseID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "DrivingLicenseID" || FilterColumn == "ReleaseApplicationID") 
            {
                _FilterDataInGridByIntValue(FilterColumn, int.Parse(txtFilterValue.Text.Trim()));
            }
            else
            {
                _FilterDataInGridByStringValue(FilterColumn, txtFilterValue.Text.Trim());
            }
        }


        //Constructor :-
        public frmManageLicenseReleaseAndDetention()
        {
            InitializeComponent();
        }
        private void frmManageLicenseReleaseAndDetention_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }


        //cbFilter By :-
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = null;
            cbIsReleased.Text = null;
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Released");
            cbIsReleased.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text == "Is Released");

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

            if (_IsVisible(cbIsReleased))
            {
                cbIsReleased.SelectedIndex = 0;
                _FocusControl(cbIsReleased);
            }
        }


        //Check Box (Is Released) :-
        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.Text)
            {
                case "All":
                    _RefreshDataInGridWithoutFilter();
                    break;

                case "Yes":
                    _FilterDataInGridByBooleanValue("IsReleased", true);
                    break;

                default:
                    _FilterDataInGridByBooleanValue("IsReleased", false);
                    break;
            }
            _ShowRecordCountInGrid();
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Local License ID" || cbFilterBy.Text == "Release Application ID")
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


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        //Detain License :-
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageLicenseReleaseAndDetention_Load(null, null);
        }


        //Release Detained License :-
        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageLicenseReleaseAndDetention_Load(null, null);
        }
        private void ReleaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReleaseDetainedLicense.PerformClick();
        }


        //Show Person Details :-
        private void ShowPesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((string)dgvDrivingLicenseReleaseAndDetentionLists.CurrentRow.Cells[2].Value);
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageLicenseReleaseAndDetention_Load(null, null);
        }


        //Show License Details :-
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard((int)dgvDrivingLicenseReleaseAndDetentionLists.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

            //Refresh The Form :-
            frmManageLicenseReleaseAndDetention_Load(null, null);
        }
        private void dgvDrivingLicenseReleaseAndDetentionLists_DoubleClick(object sender, EventArgs e)
        {
            showLicenseDetailsToolStripMenuItem.PerformClick();
        }


        //Show Person License History :-
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(clsPerson.Find((string)dgvDrivingLicenseReleaseAndDetentionLists.CurrentRow.Cells[2].Value).PersonID);
            frm.ShowDialog();

            //Refresh The Form: -
            frmManageLicenseReleaseAndDetention_Load(null, null);
        }


        //cms Application :-
        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            //ReleaseDetainedLicenseToolStripMenuItem.Enabled = !clsDetainedDrivingLicense.IsReleasedDrivingLicense((int)dgvDrivingLicenseReleaseAndDetentionLists.CurrentRow.Cells[0].Value);

            ReleaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDrivingLicenseReleaseAndDetentionLists.CurrentRow.Cells[6].Value;
        }
    }
}