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
    public partial class ctrlTestTypeCard : UserControl
    {
        //Properties :-
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;
        private clsTestType _TestTypeInfo;


        //Private Methods :-
        private void _ResetDefaultValues()
        {
            _TestTypeID = clsTestType.enTestType.eVisionTest;
            lblID.Text = "N/A";
            lblTitle.Text = "????";
            lblDescription.Text = "";
            lblFees.Text = "????";
            llEditTestTypeInfo.Enabled = false;
        }

        private void _ShowTestTypeInfo()
        {
            _TestTypeID = _TestTypeInfo.ID;
            lblID.Text = ((byte)_TestTypeInfo.ID).ToString();
            lblTitle.Text = _TestTypeInfo.TestTypeTitle.Trim();
            lblDescription.Text = _TestTypeInfo.TestTypeDescription.Trim();
            lblFees.Text = _TestTypeInfo.TestTypeFees.ToString() + " $";
            llEditTestTypeInfo.Enabled = true;
        }


        //Public Methods :-
        public void LoadTestTypeInfo(clsTestType.enTestType TestTypeID)
        {
            _TestTypeInfo = clsTestType.Find(TestTypeID);

            if (_TestTypeInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show($"Error : Could Not Find Test Type With ID [{(byte)TestTypeID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ShowTestTypeInfo();
        }


        //Constructor :-
        public ctrlTestTypeCard()
        {
            InitializeComponent();
        }
        private void ctrlTestTypeCard_Load(object sender, EventArgs e)
        {

        }


        //Edit Test Type :-
        private void llEditTestTypeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditTestType frm = new frmEditTestType(_TestTypeID);
            frm.ShowDialog();

            //Refresh :-
            LoadTestTypeInfo(_TestTypeID);
        }
    }
}