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
using System.IO;
using DVLDSystem.Gobal_Classes;
using DVLDSystem.DVLD.People;

namespace DVLDSystem
{
    public partial class frmManagePeople : Form
    {
        //Private Prpperties :-
        private static DataTable _dtPeopleLists;


        //Private Methods :-
        private bool _IsVisible(Control control)
        {
            return control.Visible;
        }

        private void _FocusControl(Control control)
        {
            control.Focus();
        }

        private void _GetPeopleLists()
        {
            _dtPeopleLists = clsPerson.GetAllPeopleForGrid();
        }

        private void _ShowPeopleListsInGrid()
        {
            dgvPeopleLists.DataSource = _dtPeopleLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvPeopleLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetPeopleLists();
            _ShowPeopleListsInGrid();
            _ShowRecordCountInGrid();

            cbFilterBy.SelectedIndex = 0;
        }

        private void _FilterPeopleListsInGridByIntValue(string ColumnName, int Value)
        {
            _dtPeopleLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _FilterPeopleListsInGridByStringValue(string ColumnName, string Value)
        {
            _dtPeopleLists.DefaultView.RowFilter = String.Format($"{ColumnName} Like '{Value}%'");
        }

        private void _RefreshPeopleListsInGridWithOutFilter()
        {
            _dtPeopleLists.DefaultView.RowFilter = null;
        }

        private void _RefreshPeopleListsInGridWithFilter()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            //We Filter dtPeopleListsInGrid :-
            if (FilterColumn == "PersonID")
            {
                _FilterPeopleListsInGridByIntValue(FilterColumn, int.Parse(txtFilterValue.Text.Trim()));
            }
            else
            {
                _FilterPeopleListsInGridByStringValue(FilterColumn, txtFilterValue.Text.Trim());
            }
            _ShowRecordCountInGrid();
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvPeopleLists.Rows.Count > 0)
            {
                dgvPeopleLists.Columns[0].HeaderText = "Person ID";
                dgvPeopleLists.Columns[0].Width = 100;

                dgvPeopleLists.Columns[1].HeaderText = "National No.";
                dgvPeopleLists.Columns[1].Width = 110;

                dgvPeopleLists.Columns[2].HeaderText = "First Name";
                dgvPeopleLists.Columns[2].Width = 110;

                dgvPeopleLists.Columns[3].HeaderText = "Second Name";
                dgvPeopleLists.Columns[3].Width = 130;

                dgvPeopleLists.Columns[4].HeaderText = "Third Name";
                dgvPeopleLists.Columns[4].Width = 110;

                dgvPeopleLists.Columns[5].HeaderText = "Last Name";
                dgvPeopleLists.Columns[5].Width = 110;

                dgvPeopleLists.Columns[6].HeaderText = "Gender";
                dgvPeopleLists.Columns[6].Width = 100;

                dgvPeopleLists.Columns[7].HeaderText = "Date Of Birth";
                dgvPeopleLists.Columns[7].Width = 120;

                dgvPeopleLists.Columns[8].HeaderText = "Nationality";
                dgvPeopleLists.Columns[8].Width = 110;

                dgvPeopleLists.Columns[9].HeaderText = "Phone";
                dgvPeopleLists.Columns[9].Width = 120;

                dgvPeopleLists.Columns[10].HeaderText = "Email";
                dgvPeopleLists.Columns[10].Width = 180;
            }
        }


        //Constructor :-
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }
        private void frmManagePeople_Activated(object sender, EventArgs e)
        {
            cbFilterBy.Focus();
        }


        //Filter By :-
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFilterBy.Focus();
            txtFilterValue.Text = null;
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (_IsVisible(txtFilterValue))
            {
                _FocusControl(txtFilterValue);
            }
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text.Trim()))
            {
                txtFilterValue.Text = null;
                _RefreshPeopleListsInGridWithOutFilter();
            }
            else
            {
                _RefreshPeopleListsInGridWithFilter();
            }
            _ShowRecordCountInGrid();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Add New Person :-
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson.PerformClick();
        }


        //Show Person Details :-
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleLists.CurrentRow.Cells[0].Value;

            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show($"Error : No Person With ID [{PersonID}] in The System!", "Person Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }
        private void dgvPeopleLists_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }


        //Edit Person :-
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleLists.CurrentRow.Cells[0].Value;

            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show($"Error : No Person With ID [{PersonID}] in The System!", "Person Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }


        //Delete Person :-
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleLists.CurrentRow.Cells[0].Value;

            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show($"Error : No Person With ID [{PersonID}] in The System!", "Person Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are You Sure You Want to Delete Person [{PersonID}] From The System?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                clsPerson PersonInfo = clsPerson.Find(PersonID);

                if (clsPerson.Delete(PersonID))
                {
                    if (!clsValidation.IsEmpty(PersonInfo.ImagePath) && File.Exists(PersonInfo.ImagePath))
                    {
                        File.Delete(PersonInfo.ImagePath);
                    }

                    MessageBox.Show($"Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh :-
                    _RefreshDataInGrid();
                }
                else
                {
                    MessageBox.Show($"Error : Person Was Not Deleted because it has Data Linked to it in The System.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Send Email :-
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Phone Call :-
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}