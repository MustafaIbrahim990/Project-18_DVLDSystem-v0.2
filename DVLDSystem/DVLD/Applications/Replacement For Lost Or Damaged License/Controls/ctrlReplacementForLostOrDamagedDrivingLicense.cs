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
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Applications.Replacement_For_Lost_Or_Damaged_License.Controls
{
    public partial class ctrlReplacementForLostOrDamagedDrivingLicense : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;
        public event Action<clsDrivingLicense.enIssueReason> IssueReasonSelected;

        //Enums :-
        private clsDrivingLicense.enIssueReason _IssueReason;


        //Private Properties :-
        private int _OldLocalDrivingLicenseID = -1;
        private int _RenewLocalDrivingLicenseID = -1;
        private clsDrivingLicense _RenewLocalDrivingLicenseInfo;


        //Public Properties :-
        public int SelectedLocalDrivingLicenseID
        {
            get { return _RenewLocalDrivingLicenseID; }
        }
        public clsDrivingLicense SelectedLocalDrivingLicenseInfo
        {
            get { return _RenewLocalDrivingLicenseInfo; }
        }
        public clsDrivingLicense.enIssueReason IssueReason
        {
            get { return _IssueReason; }
        }
        public bool ReplacementForEnabled
        {
            set { gbReplacementFor.Enabled = value; }
        }


        //Private Methods :-
        private void _GetApplicationFeesForIssueReason()
        {
            if (_IssueReason == clsDrivingLicense.enIssueReason.ReplacementForLost)
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).Fees.ToString() + " $";
            else
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString() + " $";
        }
        private void _LoadBasicApplicationInfo()
        {
            gbReplacementFor.Enabled = true;

            lblNewApplicationID.Text = "N/A";
            lblReplacedLicenseID.Text = "N/A";
            lblOldLocalLicenseID.Text = "N/A";

            lblNewApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _LoadAdditionalApplicationInfo()
        {
            _LoadBasicApplicationInfo();

            if (_OldLocalDrivingLicenseID != -1)
            {
                lblOldLocalLicenseID.Text = _OldLocalDrivingLicenseID.ToString();
            }
        }
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _OldLocalDrivingLicenseID = LocalLicenseID;
            _LoadAdditionalApplicationInfo();

            //Send Local License ID to Subscriber :-
            LocalDrivingLicenseIDSelected?.Invoke(_OldLocalDrivingLicenseID);
        }
        private void _ResetInfo()
        {
            _OldLocalDrivingLicenseID = -1;
            _RenewLocalDrivingLicenseID = -1;

            _LoadBasicApplicationInfo();
        }
        private void _FillInfo()
        {
            //UnSubscribe With Local Driving License ID Selected :-
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected -= _OnLocalDrivingLicenseIDSelected;

            ctrlDrivingLicenseCardWithFilter1.LoadLocalDrivingLicenseInfo(_RenewLocalDrivingLicenseID);
            lblNewApplicationID.Text = _RenewLocalDrivingLicenseInfo.ApplicationID.ToString();
            lblReplacedLicenseID.Text = _RenewLocalDrivingLicenseID.ToString();
        }


        //Protected Methods :-
        protected void OnLocalDrivingLicenseIDSelected(int InternationalLicenseID)
        {
            LocalDrivingLicenseIDSelected?.Invoke(InternationalLicenseID);
        }
        protected void OnIssueReasonSelected(clsDrivingLicense.enIssueReason ReplacementFor)
        {
            IssueReasonSelected?.Invoke(ReplacementFor);
        }


        //Public Methods :-
        public void FilterFocus()
        {
            ctrlDrivingLicenseCardWithFilter1.FilterFocus();
        }
        public void LoadLocalDrivingLicenseWithApplicationInfo(int LocalLicenseID)
        {
            _RenewLocalDrivingLicenseID = LocalLicenseID;
            _RenewLocalDrivingLicenseInfo = clsDrivingLicense.Find(_RenewLocalDrivingLicenseID);

            if (_RenewLocalDrivingLicenseInfo == null)
            {
                _ResetInfo();
                MessageBox.Show($"Error : Could Not Find Local Driving License With ID [{_RenewLocalDrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
            gbReplacementFor.Enabled = false;
            ctrlDrivingLicenseCardWithFilter1.FilterDrivingLicenseEnabled = false;
        }
        public void RefreshLocalDrivingLicenseInfo(int LocalDrivingLicenseID)
        {
            ctrlDrivingLicenseCardWithFilter1.LoadLocalDrivingLicenseInfo(LocalDrivingLicenseID);
        }


        //Constructor :-
        public ctrlReplacementForLostOrDamagedDrivingLicense()
        {
            InitializeComponent();
        }
        private void ctrlReplacementForLostOrDamagedDrivingLicense_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.PerformClick();

            //Subscribe With Local Driving License ID Selected :-
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }


        //Radio Button (Damaged License) :-
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _IssueReason = clsDrivingLicense.enIssueReason.ReplacementForDamaged;
            _GetApplicationFeesForIssueReason();

            //Send Issue Reason to Secibecriber :-
            IssueReasonSelected?.Invoke(_IssueReason);
        }


        //Radio Button (Lost License) :-
        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _IssueReason = clsDrivingLicense.enIssueReason.ReplacementForLost;
            _GetApplicationFeesForIssueReason();

            //Send Issue Reason to Secibecriber :-
            IssueReasonSelected?.Invoke(_IssueReason);
        }
    }
}