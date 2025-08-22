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
using DVLDSystem.DVLD.Applications;
using DVLDSystem.DVLD.People;

namespace DVLDSystem.DVLD.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        //Properties :-
        private int _ApplicationID = -1;
        private clsApplication _ApplicationInfo;

        public int SelectedApplicationID
        {
            get { return _ApplicationID; }
        }
        public clsApplication SelectedApplicationInfo
        {
            get { return _ApplicationInfo; }
        }


        //Private Methods :-
        private void _FillInfo()
        {
            _ApplicationID = _ApplicationInfo.ApplicationID;

            lblApplicationID.Text = _ApplicationInfo.ApplicationID.ToString();
            lblApplicationStatus.Text = _ApplicationInfo.StatusText;
            lblApplicationFees.Text = _ApplicationInfo.PaidFees.ToString() + " $";
            lblApplicationTypes.Text = _ApplicationInfo.ApplicationTypeInfo.Title;
            lblApplicantName.Text = _ApplicationInfo.FullName;
            lblApplicationDate.Text = _ApplicationInfo.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = _ApplicationInfo.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _ApplicationInfo.CreatedByUserInfo.UserName;

            llShowPersonInfo.Enabled = true;
        }


        //Public Methods :-
        public void ResetInfo()
        {
            lblApplicationID.Text = "????";
            lblApplicationStatus.Text = "????";
            lblApplicationFees.Text = "????";
            lblApplicationTypes.Text = "????";
            lblApplicantName.Text = "????";
            lblApplicationDate.Text = "????";
            lblLastStatusDate.Text = "????";
            lblCreatedBy.Text = "????";

            llShowPersonInfo.Enabled = false;
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _ApplicationInfo = clsApplication.Find(ApplicationID);

            if (_ApplicationInfo == null)
            {
                ResetInfo();
                MessageBox.Show($"No Application With ID [{ApplicationID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
        }


        //Constructor :-
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }


        //Show Person Info :-
        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();

            //Refresh :-
            LoadApplicationInfo(_ApplicationID);
        }
    }
}