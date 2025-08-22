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

namespace DVLDSystem.DVLD.Tests.Test_Types
{
    public partial class frmEditTestType : Form
    {
        //Properties :-
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;
        private clsTestType _TestTypeInfo;


        //Private Methods :-
        public void _ResetDefaultValues()
        {
            lblID.Text = "N/A";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtFees.Text = "";
        }

        private void _RefreshTestTypeInfo()
        {
            lblID.Text = ((byte)_TestTypeInfo.ID).ToString();
            txtTitle.Text = _TestTypeInfo.TestTypeTitle;
            txtDescription.Text = _TestTypeInfo.TestTypeDescription;
            txtFees.Text = _TestTypeInfo.TestTypeFees.ToString();
        }

        private void _LoadDataInUpdateMode()
        {
            _TestTypeInfo = clsTestType.Find(_TestTypeID);

            if (_TestTypeInfo == null)
            {
                MessageBox.Show($"Error : Could Not Find Test Type With ID [{(byte)_TestTypeID}] in The System!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _RefreshTestTypeInfo();
        }

        private void _GetTestTypeInfo()
        {
            _TestTypeInfo.TestTypeTitle = txtTitle.Text.Trim();
            _TestTypeInfo.TestTypeDescription = txtDescription.Text.Trim();
            _TestTypeInfo.TestTypeFees = float.Parse(txtFees.Text.Trim());
        }

        private void _SaveData()
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _GetTestTypeInfo();

            if (_TestTypeInfo.Save())
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
        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
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


        //Description :-
        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This Field is Required!");
                return;
            }
            errorProvider1.SetError(txtDescription, null);
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