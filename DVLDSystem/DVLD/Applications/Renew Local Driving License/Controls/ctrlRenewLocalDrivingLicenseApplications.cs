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

namespace DVLDSystem.DVLD.Applications.Renew_Local_Driving_License.Controls
{
    public partial class ctrlRenewLocalDrivingLicenseApplications : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;


        //Properties :-
        private int _OldLocalDrivingLicenseID = -1;

        private int _RenewLocalDrivingLicenseID = -1;
        private clsDrivingLicense _RenewLocalDrivingLicenseInfo;

        public string Notes
        {
            get { return txtNotes.Text.Trim(); }
        }
        public int SelectedLocalDrivingLicenseID
        {
            get { return _RenewLocalDrivingLicenseID; }
        }
        public clsDrivingLicense SelectedLocalDrivingLicenseInfo
        {
            get { return _RenewLocalDrivingLicenseInfo; }
        }


        //Private Methods :-
        private void _LoadBasicApplicationInfo()
        {
            lblRenewlApplicationID.Text = "N/A";
            lblRenewedLocalLicenseID.Text = "N/A";
            //
            lblOldLocalLicenseID.Text = "N/A";
            lblExpirationDate.Text = "[????]";
            lblLocalLicenseFees.Text = "[????]";
            lblTotalFees.Text = "[????]";
            txtNotes.Text = null;

            lblRenewApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString() + " $";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _LoadAdditionalApplicationInfo()
        {
            _LoadBasicApplicationInfo();

            if (_OldLocalDrivingLicenseID != -1)
            {
                lblOldLocalLicenseID.Text = _OldLocalDrivingLicenseID.ToString();
                lblExpirationDate.Text = (DateTime.Now.AddYears(clsLicenseClass.Find(clsDrivingLicense.Find(_OldLocalDrivingLicenseID).LicenseClassID).DefaultValidityLength).ToShortDateString());
                lblLocalLicenseFees.Text = clsLicenseClass.Find(clsDrivingLicense.Find(_OldLocalDrivingLicenseID).LicenseClassID).ClassFees.ToString() + " $";
                lblTotalFees.Text = ((Convert.ToSingle(lblApplicationFees.Text.Replace("$", " ").Trim())) + (Convert.ToSingle(lblLocalLicenseFees.Text.Replace("$", " ").Trim()))).ToString() + " $";
                txtNotes.Text = ctrlDrivingLicenseCardWithFilter1.SelectedDrivingLicenseInfo.Notes;
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
            lblRenewlApplicationID.Text = _RenewLocalDrivingLicenseInfo.ApplicationID.ToString();
            lblRenewedLocalLicenseID.Text = _RenewLocalDrivingLicenseID.ToString();
        }


        //Protected Methods :-
        protected void OnLocalDrivingLicenseIDSelected(int InternationalLicenseID)
        {
            LocalDrivingLicenseIDSelected?.Invoke(InternationalLicenseID);
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
            ctrlDrivingLicenseCardWithFilter1.FilterDrivingLicenseEnabled = false;
        }
        public void RefreshLocalDrivingLicenseInfo(int LocalDrivingLicenseID)
        {
            ctrlDrivingLicenseCardWithFilter1.LoadLocalDrivingLicenseInfo(LocalDrivingLicenseID);
        }


        //Constructor :-
        public ctrlRenewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void ctrlRenewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            //Subscribe With Local Driving License ID Selected :-
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
    }
}