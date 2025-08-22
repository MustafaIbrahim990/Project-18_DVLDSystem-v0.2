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

namespace DVLDSystem.DVLD.Applications.Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        //Private Prpperties :-
        private static DataTable _dtApplicationTypeLists;


        //Private Methods :-
        private void _GetApplicationTypeLists()
        {
            _dtApplicationTypeLists = clsApplicationType.GetAllApplicationTypes();
        }

        private void _ShowApplicationTypeListsInGrid()
        {
            dgvApplicationTypeLists.DataSource = _dtApplicationTypeLists; ;
        }

        private void _ShowRecordCountInGrid()
        {
            lblRecordCount.Text = dgvApplicationTypeLists.Rows.Count.ToString();
        }

        private void _RefreshDataInGrid()
        {
            _GetApplicationTypeLists();
            _ShowApplicationTypeListsInGrid();
            _ShowRecordCountInGrid();
        }

        private void _ResetColumnsInGrid()
        {
            if (dgvApplicationTypeLists.Rows.Count > 0)
            {
                dgvApplicationTypeLists.Columns[0].HeaderText = "ID";
                dgvApplicationTypeLists.Columns[0].Width = 70;

                dgvApplicationTypeLists.Columns[1].HeaderText = "Title";
                dgvApplicationTypeLists.Columns[1].Width = 300;

                dgvApplicationTypeLists.Columns[2].HeaderText = "Fees ($)";
                dgvApplicationTypeLists.Columns[2].Width = 200;
            }
        }


        //Constructor :-
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshDataInGrid();
            _ResetColumnsInGrid();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Show Application Type Details :-
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = (int)dgvApplicationTypeLists.CurrentRow.Cells[0].Value;

            if (!clsApplicationType.IsExist(ApplicationTypeID))
            {
                MessageBox.Show($"Error: No Application Type With ID [{ApplicationTypeID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowApplicationTypeCard frm = new frmShowApplicationTypeCard(ApplicationTypeID);
            frm.ShowDialog();

            //Refresh :-
            frmManageApplicationTypes_Load(null, null);
        }
        private void dgvApplicationTypeLists_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }


        //Edit Application Types :-
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = (int)dgvApplicationTypeLists.CurrentRow.Cells[0].Value;

            if (!clsApplicationType.IsExist(ApplicationTypeID))
            {
                MessageBox.Show($"Error : No Application Type With ID [{ApplicationTypeID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmEditApplicationTypes frm = new frmEditApplicationTypes(ApplicationTypeID);
            frm.ShowDialog();

            //Refresh :-
            frmManageApplicationTypes_Load(null, null);
        }
    }
}