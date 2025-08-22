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
using DVLDSystem.DVLD.Driving_License;

namespace DVLDSystem.DVLD.Driver
{
    public partial class frmManageDrivers : Form
    {
        //Private Prpperties :-
        private static DataTable _dtDriverLists;


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }

        private bool _IsVisible(Control control)
        {
            return control.Visible;
        }

        private void _FocusControl(Control control)
        {
            control.Focus();
        }

        private void _GetDriverLists()
        {
            _dtDriverLists = clsDriver.GetAllDriversView();
        }

        private void _ShowDriverListsInGrid()
        {
            dgvDriverLists.DataSource = _dtDriverLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvDriverLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetDriverLists();
            _ShowDriverListsInGrid();
            _ShowRecordCountInGrid();
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvDriverLists.Rows.Count > 0)
            {
                dgvDriverLists.Columns[0].HeaderText = "Driver ID";
                dgvDriverLists.Columns[0].Width = 50;

                dgvDriverLists.Columns[1].HeaderText = "Person ID";
                dgvDriverLists.Columns[1].Width = 50;

                dgvDriverLists.Columns[2].HeaderText = "National No.";
                dgvDriverLists.Columns[2].Width = 100;

                dgvDriverLists.Columns[3].HeaderText = "Full Name";
                dgvDriverLists.Columns[3].Width = 250;

                dgvDriverLists.Columns[4].HeaderText = "Created Date";
                dgvDriverLists.Columns[4].Width = 150;

                dgvDriverLists.Columns[5].HeaderText = "No. Of Active Licenses";
                dgvDriverLists.Columns[5].Width = 180;
            }
        }

        private void _FilterDataInGridByIntValue(string ColumnName, int Value)
        {
            _dtDriverLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _FilterDataInGridByStringValue(string ColumnName, string Value)
        {
            _dtDriverLists.DefaultView.RowFilter = String.Format($"{ColumnName} Like '{Value}%'");
        }

        private void _FilterDataInGridByBooleanValue(string ColumnName, bool Value)
        {
            _dtDriverLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _RefreshDataInGridWithoutFilter()
        {
            _dtDriverLists.DefaultView.RowFilter = null;
        }

        private void _RefreshDataInGridWithFilter()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Active Licenses":
                    FilterColumn = "NumberOfActiveLicenses";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            //We Filter DriversListsInGrid :-
            if (FilterColumn == "DriverID" || FilterColumn == "PersonID" || FilterColumn == "NumberOfActiveLicenses")
            {
                _FilterDataInGridByIntValue(FilterColumn, int.Parse(txtFilterValue.Text.Trim()));
            }
            else
            {
                _FilterDataInGridByStringValue(FilterColumn, txtFilterValue.Text.Trim());
            }
            _ShowRecordCountInGrid();
        }


        //Constructor :-
        public frmManageDrivers()
        {
            InitializeComponent();
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();

            //Select None In Combo Box :-
            cbFilterBy.SelectedIndex = 0;
        }


        //Filter By :-
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = null;
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

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
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Active Licenses")
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


        //Close Form _-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Show Person Details :-
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDriverLists.CurrentRow.Cells[0].Value;

            if (!clsDriver.IsExist(DriverID))
            {
                _ShowMessageError($"Error : Could Not Find Driver With ID [{DriverID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowPersonInfo frm = new frmShowPersonInfo(clsDriver.Find(DriverID).PersonID);
            frm.ShowDialog();

            //Refresh :-
            frmManageDrivers_Load(null, null);
        }
        private void dgvDriverLists_DoubleClick(object sender, EventArgs e)
        {
            showPersonDetailsToolStripMenuItem.PerformClick();
        }


        //Show Person License Histroy :-
        private void showPersonLicneseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDriverLists.CurrentRow.Cells[0].Value;

            if (!clsDriver.IsExist(DriverID))
            {
                _ShowMessageError($"Error : Could Not Find Driver With ID [{DriverID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int PersonID = clsDriver.Find(DriverID).PersonID;

            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show($"Error : Could Not Find Person With ID [{PersonID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(PersonID);
            frm.ShowDialog();

            //Refresh :-
            frmManageDrivers_Load(null, null);
        }
    }
}