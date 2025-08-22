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

namespace DVLDSystem.DVLD.Applications.Application_Types.Controls
{
    public partial class ctrlApplicationTypeCard : UserControl
    {
        //Properties :-
        private int _ApplicationTypeID = -1;
        private clsApplicationType _ApplicationTypeInfo;


        //Private Methods :-
        private void _ResetDefaultValues()
        {
            _ApplicationTypeID = -1;
            lblID.Text = "N/A";
            lblTitle.Text = "????";
            lblFees.Text = "????";
            llEditApplicationTypeInfo.Enabled = false;
        }

        private void _ShowApplicationTypeInfo()
        {
            _ApplicationTypeID = _ApplicationTypeInfo.ID;
            lblID.Text = _ApplicationTypeInfo.ID.ToString();
            lblTitle.Text = _ApplicationTypeInfo.Title.Trim();
            lblFees.Text = _ApplicationTypeInfo.Fees.ToString() + " $";
            llEditApplicationTypeInfo.Enabled = true;
        }


        //Public Methods :-
        public void LoadApplicationTypeInfo(int ApplicationTypeID)
        {
            _ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);

            if (_ApplicationTypeInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show($"Error : No Application Type With ID [{ApplicationTypeID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ShowApplicationTypeInfo();
        }


        //Constructor :-
        public ctrlApplicationTypeCard()
        {
            InitializeComponent();
        }
        private void ctrlApplicationTypeCard_Load(object sender, EventArgs e)
        {

        }


        //Edit Application Type :-
        private void llEditApplicationTypeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes(_ApplicationTypeID);
            frm.ShowDialog();

            //Refresh :-
            LoadApplicationTypeInfo(_ApplicationTypeID);
        }
    }
}