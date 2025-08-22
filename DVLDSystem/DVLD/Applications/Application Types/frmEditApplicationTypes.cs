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

namespace DVLDSystem.DVLD.Applications.Application_Types
{
    public partial class frmEditApplicationTypes : Form
    {
        //Properties :-
        private int _ApplicationTypeID = -1;
        private clsApplicationType _ApplicationTypeInfo;


        //Private Methods :-
        public void _ResetDefaultValues()
        {
            lblID.Text = "N/A";
            txtTitle.Text = "";
            txtFees.Text = "";
        }

        private void _RefreshApplicationTypeInfo()
        {
            lblID.Text = _ApplicationTypeInfo.ID.ToString();
            txtTitle.Text = _ApplicationTypeInfo.Title;
            txtFees.Text = _ApplicationTypeInfo.Fees.ToString();
        }

        private void _LoadDataInUpdateMode()
        {
            _ApplicationTypeInfo = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationTypeInfo == null)
            {
                MessageBox.Show($"Error : No Application Type With ID [{_ApplicationTypeID}] in The System!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _RefreshApplicationTypeInfo();
        }

        private void _GetApplicationTypeInfo()
        {
            _ApplicationTypeInfo.Title = txtTitle.Text.Trim();
            _ApplicationTypeInfo.Fees = float.Parse(txtFees.Text.Trim());
        }

        private void _SaveData()
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _GetApplicationTypeInfo();

            if (_ApplicationTypeInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //Constructor :-
        public frmEditApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _LoadDataInUpdateMode();
        }


        //Title :-
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This Field is Required!");
                return;
            }
            errorProvider1.SetError(txtTitle, null);
        }


        //Fees :-
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This Field is Required!");
                return;
            }

            if (!clsValidation.IsNumber(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Fees, Must be Number!");
                return;
            }
            errorProvider1.SetError(txtFees, null);
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Save Data :-
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            _SaveData();
        }
    }
}