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
using DVLDSystem.DVLD.User.Controls;

namespace DVLDSystem.DVLD.User
{
    public partial class frmManageUsers : Form
    {
        //Private Prpperties :-
        private static DataTable _dtUserLists;


        //Private Methods :-
        private bool _IsVisible(Control control)
        {
            return control.Visible;
        }

        private void _FocusControl(Control control)
        {
            control.Focus();
        }

        private void _GetUserLists()
        {
            _dtUserLists = clsUser.GetAllUsers();
        }

        private void _ShowUserListsInGrid()
        {
            dgvUserLists.DataSource = _dtUserLists;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvUserLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetUserLists();
            _ShowUserListsInGrid();
            _ShowRecordCountInGrid();

            cbFilterBy.SelectedIndex = 0;
        }

        private void _FilterDataInGridByIntValue(string ColumnName, int Value)
        {
            _dtUserLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _FilterDataInGridByStringValue(string ColumnName, string Value)
        {
            _dtUserLists.DefaultView.RowFilter = String.Format($"{ColumnName} Like '{Value}%'");
        }

        private void _FilterDataInGridByBooleanValue(string ColumnName, bool Value)
        {
            _dtUserLists.DefaultView.RowFilter = String.Format($"{ColumnName} = {Value}");
        }

        private void _RefreshDataInGridWithoutFilter()
        {
            _dtUserLists.DefaultView.RowFilter = null;
        }

        private void _RefreshDataInGridWithFilter()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            //We Filter PeopleListsInGrid :-
            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
            {
                _FilterDataInGridByIntValue(FilterColumn, int.Parse(txtFilterValue.Text.Trim()));
            }
            else
            {
                _FilterDataInGridByStringValue(FilterColumn, txtFilterValue.Text.Trim());
            }
            _ShowRecordCountInGrid();
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvUserLists.Rows.Count > 0)
            {
                dgvUserLists.Columns[0].HeaderText = "User ID";
                dgvUserLists.Columns[0].Width = 50;

                dgvUserLists.Columns[1].HeaderText = "Person ID";
                dgvUserLists.Columns[1].Width = 50;

                dgvUserLists.Columns[2].HeaderText = "Full Name";
                dgvUserLists.Columns[2].Width = 300;

                dgvUserLists.Columns[3].HeaderText = "User Name";
                dgvUserLists.Columns[3].Width = 150;

                dgvUserLists.Columns[4].HeaderText = "Is Active";
                dgvUserLists.Columns[4].Width = 110;
            }
        }


        //Constructor :-
        public frmManageUsers()
        {
            InitializeComponent();
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }


        //Filter By :-
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


        //Is Active :-
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.Text == "All")
            {
                _RefreshDataInGridWithoutFilter();
                _ShowRecordCountInGrid();
                return;
            }

            if (cbIsActive.Text == "Yes")
            {
                _FilterDataInGridByBooleanValue("IsActive", true);
            }
            else
            {
                _FilterDataInGridByBooleanValue("IsActive", false);
            }
            _ShowRecordCountInGrid();
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
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


        //Add New User :-
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick();
        }


        //Show User Details(Info) :-
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserLists.CurrentRow.Cells[0].Value;

            if (!clsUser.IsExist(UserID))
            {
                MessageBox.Show($"Error : No User With ID [{UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowUserInfo frm = new frmShowUserInfo(UserID);
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }
        private void dgvUserLists_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }        


        //Edit User :-
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserLists.CurrentRow.Cells[0].Value;

            if (!clsUser.IsExist(UserID))
            {
                MessageBox.Show($"No User With ID [{UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }


        //Delete User :-
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserLists.CurrentRow.Cells[0].Value;

            if (!clsUser.IsExist(UserID))
            {
                MessageBox.Show($"Error : No User With ID [{UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are You Sure You Want to Delete User [{UserID}] From The System?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsUser.Delete(UserID))
                {
                    MessageBox.Show($"User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh :-
                    _RefreshDataInGrid();
                }
                else
                {
                    MessageBox.Show($"User Was Not Deleted because it has Data Linked to it in The System.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Change User PassWord :-
        private void ChangePassWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserLists.CurrentRow.Cells[0].Value;

            if (!clsUser.IsExist(UserID))
            {
                MessageBox.Show($"Error : No User With ID [{UserID}] in The System!", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmChangePassWord frm = new frmChangePassWord(UserID);
            frm.ShowDialog();

            //Refresh :-
            _RefreshDataInGrid();
        }


        //Send Email to User :-
        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //Phone Call to User :-
        private void phoneCallToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}