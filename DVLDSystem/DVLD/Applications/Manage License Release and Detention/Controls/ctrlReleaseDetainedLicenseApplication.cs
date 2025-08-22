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

namespace DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention.Controls
{
    public partial class ctrlReleaseDetainedLicenseApplication : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;


        //Private Properties :-
        private int _LocalDrivingLicenseID = -1;
        private int _DetainID = -1;

        private clsDetainedDrivingLicense _DetainInfo;
        private clsDrivingLicense _LocalDrivingLicenseInfo;


        //Public Properties :-
        public int SelectedLocalDrivingLicenseID
        {
            get { return _LocalDrivingLicenseID; }
        }
        public int SelectedDetainID
        {
            get { return _DetainID; }
        }

        public clsDrivingLicense SelectedLocalDrivingLicenseInfo
        {
            get { return _LocalDrivingLicenseInfo; }
        }
        public clsDetainedDrivingLicense SelectedDetainInfo
        {
            get { return _DetainInfo; }
        }


        //Private Methods :-
        private bool _GetLocalLicenseObject()
        {
            _LocalDrivingLicenseInfo = clsDrivingLicense.Find(_LocalDrivingLicenseID);

            if (_LocalDrivingLicenseInfo == null)
            {
                return false;
            }
            return true;
        }
        private bool _DoesPersonHaveActiveLocalDrivingLicense()
        {
            if (!_LocalDrivingLicenseInfo.IsActive)
            {
                MessageBox.Show($"Selected License is Not Active, Choose an Active License.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool _GetDetainInfoObject()
        {
            _DetainInfo = clsDetainedDrivingLicense.FindBy(_LocalDrivingLicenseID);

            if (_DetainInfo == null)
            {
                _DetainID = -1;
                MessageBox.Show($"There is No Detain License With License ID [{_LocalDrivingLicenseID}] in The System.", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _DetainID = _DetainInfo.ID;
            return true;
        }
        private bool _IsLicenseDetained()
        {
            if (_DetainInfo.IsReleased)
            {
                _DetainID = -1;
                MessageBox.Show($"Selected License is Not Detained.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void _LoadBasicApplicationInfo()
        {
            lblDetainID.Text = "N/A";
            lblLicenseID.Text = "N/A";
            lblDetainDate.Text = "[????]";
            lblApplicationFees.Text = "[????]";
            lblTotalFees.Text = "[????]";
            lblCreatedBy.Text = "[????]";
            lblFineFees.Text = "[????]";
            lblApplicationFees.Text = "[????]";
        }
        private void _LoadAdditionalApplicationInfo()
        {
            _LoadBasicApplicationInfo();

            if (!_GetLocalLicenseObject())
                return;

            if (!_DoesPersonHaveActiveLocalDrivingLicense())
                return;

            if (!_GetDetainInfoObject())
                return;

            if (!_IsLicenseDetained())
                return;

            if (_LocalDrivingLicenseID != -1 && _DetainID != -1) 
            {
                lblDetainID.Text = _DetainID.ToString();
                lblLicenseID.Text = _LocalDrivingLicenseID.ToString();
                lblDetainDate.Text = _DetainInfo.DetainDate.ToShortDateString();
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReleaseeDetainedDrivingLicense).Fees.ToString() + " $";
                lblFineFees.Text = _DetainInfo.FineFees.ToString() + " $";
                lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text.Replace("$", " ").Trim()) + _DetainInfo.FineFees).ToString() + " $";
                lblCreatedBy.Text = _DetainInfo.CreatedByUserID.ToString();
            }
        }
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            _LoadAdditionalApplicationInfo();

            //Send Local License ID to Subscriber :-
            LocalDrivingLicenseIDSelected?.Invoke(_LocalDrivingLicenseID);
        }
        private void _ResetInfo()
        {
            _LocalDrivingLicenseID = -1;
            _DetainID = -1;

            _LoadBasicApplicationInfo();
        }
        private void _FillInfo()
        {
            //UnSubscribe With Local Driving License ID Selected :-
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected -= _OnLocalDrivingLicenseIDSelected;

            ctrlDrivingLicenseCardWithFilter1.LoadLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
            lblApplicationID.Text = clsDetainedDrivingLicense.Find(_DetainID).ReleaseApplicationID.ToString();
        }


        //Protected Methods :-
        protected void OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            LocalDrivingLicenseIDSelected?.Invoke(LocalLicenseID);
        }


        //Public Methods :-
        public void FilterFocus()
        {
            ctrlDrivingLicenseCardWithFilter1.FilterFocus();
        }
        public void FilterEnabled(bool Enable)
        {
            ctrlDrivingLicenseCardWithFilter1.FilterDrivingLicenseEnabled = Enable;
        }
        public void LoadDetainLicenseInfo(int DetainID)
        {
            _DetainID = DetainID;

            if (_DetainID == -1)
            {
                _ResetInfo();
                MessageBox.Show($"Error : Could Not Find Detain License With ID [{_DetainID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public ctrlReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        private void ctrlReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            //Subscribe With Local Driving License ID Selected :-
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
    }
}