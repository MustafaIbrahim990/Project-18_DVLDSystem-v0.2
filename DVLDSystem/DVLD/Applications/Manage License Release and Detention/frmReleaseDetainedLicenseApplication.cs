using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.DVLD.Driving_License;
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;
using DVLDSystem_BusinessLayer;
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Applications.Manage_License_Release_and_Detention
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseID = -1;
        private clsDrivingLicense _LocalDrivingLicenseInfo;

        private int _DetainID = -1;
        private clsDetainedDrivingLicense _DetainInfo;


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }

        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            btnReleaseDetainedLicense.Enabled = (_LocalDrivingLicenseID != -1 && ctrlReleaseDetainedLicenseApplication1.SelectedDetainID != -1) ? true : false;
            llShowLicenseHistory.Enabled = (_LocalDrivingLicenseID != -1) ? true : false;
            llShowLicenseInfo.Enabled = false;
        }

        private bool _GetLocalDrivingLicenseObject()
        {
            _LocalDrivingLicenseInfo = ctrlReleaseDetainedLicenseApplication1.SelectedLocalDrivingLicenseInfo;

            if (_LocalDrivingLicenseInfo == null)
            {
                _LocalDrivingLicenseID = -1;
                return false;
            }
            _LocalDrivingLicenseID = _LocalDrivingLicenseInfo.ID;
            return true;
        }

        private bool _GetDetainInfoObject()
        {
            _DetainInfo = ctrlReleaseDetainedLicenseApplication1.SelectedDetainInfo;

            if (_DetainInfo == null)
            {
                _DetainID = -1;
                return false;
            }
            _DetainID = _DetainInfo.ID;
            return true;
        }

        private void _ReleaseDetaainedLicense()
        {
            if (ctrlReleaseDetainedLicenseApplication1.SelectedDetainInfo.ReleaseDetainedLicense(_LocalDrivingLicenseID, clsGlobal.CurrentUser.UserID)) 
            {
                _ShowMessageError($"Detained License Released Successfully.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlReleaseDetainedLicenseApplication1.LoadDetainLicenseInfo(_DetainID);
            }
            else
            {
                _ShowMessageError($"License Was Not Released!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llShowLicenseInfo.Enabled = (_DetainID == -1) ? false : true;
            btnReleaseDetainedLicense.Enabled = false;
        }


        //Constructor :-
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlReleaseDetainedLicenseApplication1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlReleaseDetainedLicenseApplication1.FilterFocus();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Release Detained License :-
        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            if (!_GetLocalDrivingLicenseObject())
                return;

            if (!_GetDetainInfoObject())
                return;

            if (MessageBox.Show("Are You Sure You Want to Release This Detained License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _ReleaseDetaainedLicense();
        }


        //Show License Info ;-
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard(_LocalDrivingLicenseID);
            frm.ShowDialog();

            //Refresh The Form :-
            //frmManageLicenseReleaseAndDetention_Load(null, null);
        }


        //Show Licenses History :-
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(ctrlReleaseDetainedLicenseApplication1.SelectedLocalDrivingLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();

            //Refresh The Form: -
            //frmManageLicenseReleaseAndDetention_Load(null, null);
        }
    }
}