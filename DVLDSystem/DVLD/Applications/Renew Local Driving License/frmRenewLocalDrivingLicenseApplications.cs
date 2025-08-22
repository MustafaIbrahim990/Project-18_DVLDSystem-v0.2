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
using DVLDSystem.DVLD.Driving_License;
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Applications.Renew_Local_Driving_License
{
    public partial class frmRenewLocalDrivingLicenseApplications : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseID = -1;
        private clsDrivingLicense _LocalDrivingLicenseInfo;


        //Private Methods :-
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            btnRenewLocalDrivingLicenseApplication.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            llShowLicenseHistory.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            llShowNewLicenseInfo.Enabled = false;
        }
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }
        private bool _GetLocalDrivingLicenseObject()
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
                btnRenewLocalDrivingLicenseApplication.Enabled = false;
                llShowNewLicenseInfo.Enabled = false;
                ctrlRenewLocalDrivingLicenseApplications1.FilterFocus();
                return true;
            }
            return false;
        }
        private bool _IsLicenseExpired()
        {
            if (!_LocalDrivingLicenseInfo.IsLicenseExpired())  
            {
                MessageBox.Show($"Error : Selected License is Not Yet Expiared, It Will Expire On : {_LocalDrivingLicenseInfo.ExpriationDate}.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLocalDrivingLicenseApplication.Enabled = false;
                llShowNewLicenseInfo.Enabled = true;
                llShowNewLicenseInfo.Focus();
                return true;
            }
            return false;
        }
        private void _RenewLocalDrivingLicense()
        {
            _LocalDrivingLicenseID = _LocalDrivingLicenseInfo.RenewLocalDrivingLicenseApplication(ctrlRenewLocalDrivingLicenseApplications1.Notes, clsGlobal.CurrentUser.UserID);

            if (_LocalDrivingLicenseID != -1)
            {
                _ShowMessageError($"Local Driving License Renewed Successfully With ID [{_LocalDrivingLicenseID}] in The System.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlRenewLocalDrivingLicenseApplications1.LoadLocalDrivingLicenseWithApplicationInfo(_LocalDrivingLicenseID);
            }
            else
            {
                _ShowMessageError($"Local Driving License Was Not Renewed!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llShowNewLicenseInfo.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            btnRenewLocalDrivingLicenseApplication.Enabled = false;
        }


        //Constructor :-
        public frmRenewLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmRenewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            ctrlRenewLocalDrivingLicenseApplications1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
        private void frmRenewLocalDrivingLicenseApplications_Activated(object sender, EventArgs e)
        {
            ctrlRenewLocalDrivingLicenseApplications1.FilterFocus();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Renew Local Driving License Application :-
        private void btnRenewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            if (!_GetLocalDrivingLicenseObject())
                return;

            if (_DoesPersonHaveActiveLocalDrivingLicense())
                return;

            if (_IsLicenseExpired())
                return;

            if (MessageBox.Show("Are You Sure You Want to Renew This License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _RenewLocalDrivingLicense();
        }


        //Show New Local Driving License Info :-
        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard(_LocalDrivingLicenseID);
            frm.ShowDialog();

            //Refresh The Form :-
            ctrlRenewLocalDrivingLicenseApplications1.RefreshLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }


        //Show Driving License History :-
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(clsDrivingLicense.Find(_LocalDrivingLicenseID).DriverInfo.PersonID);
            frm.ShowDialog();

            //Refresh The Form :-
            ctrlRenewLocalDrivingLicenseApplications1.RefreshLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }
    }
}