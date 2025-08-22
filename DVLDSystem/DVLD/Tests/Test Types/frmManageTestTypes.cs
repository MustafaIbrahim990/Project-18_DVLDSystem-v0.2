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

namespace DVLDSystem.DVLD.Tests.Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        //Private Prpperties :-
        private static DataTable _dtApplicationTypeLists;


        //Private Methods :-
        private void _GetApplicationTypeLists()
        {
            _dtApplicationTypeLists = clsTestType.GetAllTestTypes();
        }

        private void _ShowApplicationTypeListsInGrid()
        {
            dgvTestTypeLists.DataSource = _dtApplicationTypeLists; ;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvTestTypeLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetApplicationTypeLists();
            _ShowApplicationTypeListsInGrid();
            _ShowRecordCountInGrid();
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvTestTypeLists.Rows.Count > 0)
            {
                dgvTestTypeLists.Columns[0].HeaderText = "ID";
                dgvTestTypeLists.Columns[0].Width = 50;

                dgvTestTypeLists.Columns[1].HeaderText = "Title";
                dgvTestTypeLists.Columns[1].Width = 70;

                dgvTestTypeLists.Columns[2].HeaderText = "Description";
                dgvTestTypeLists.Columns[2].Width = 400;

                dgvTestTypeLists.Columns[3].HeaderText = "Fees ($)";
                dgvTestTypeLists.Columns[3].Width = 110;
            }
        }


        //Constructor :-
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Show Test Types Details :-
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.enTestType TestTypeID = (clsTestType.enTestType)dgvTestTypeLists.CurrentRow.Cells[0].Value;

            if (!clsTestType.IsExist(TestTypeID))
            {
                MessageBox.Show($"Error : Could Not Find Test Type With ID [{(byte)TestTypeID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowTestTypeInfo frm = new frmShowTestTypeInfo(TestTypeID);
            frm.ShowDialog();

            //Refresh :-
            frmManageTestTypes_Load(null, null);
        }
        private void dgvTestTypeLists_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }


        //Edit Test Types :-
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.enTestType TestTypeID = (clsTestType.enTestType)dgvTestTypeLists.CurrentRow.Cells[0].Value;

            if (!clsTestType.IsExist(TestTypeID))
            {
                MessageBox.Show($"Error : Could Not Find Test Type With ID [{(byte)TestTypeID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)TestTypeID);
            frm.ShowDialog();

            //Refresh :-
            frmManageTestTypes_Load(null, null);
        }
    }
}