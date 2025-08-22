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

namespace DVLDSystem.DVLD.Applications.Replacement_For_Lost_Or_Damaged_License
{
    public partial class frmReplacementForLostOrDamagedDrivingLicense : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseID = -1;
        private clsDrivingLicense _LocalDrivingLicenseInfo;


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }
        private void _OnIssueReasonSelected(clsDrivingLicense.enIssueReason IssueReason)
        {
            if (IssueReason == clsDrivingLicense.enIssueReason.ReplacementForDamaged)
            {
                lblTitle.Text = "Replacement For Damaged License";
                this.Text = lblTitle.Text;
            }
            else
            {
                lblTitle.Text = "Replacement For Lost License";
                this.Text = lblTitle.Text;
            }
        }
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            btnIssueReplacementLicense.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            llShowLicenseHistory.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            llShowNewLicenseInfo.Enabled = false;
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
                btnIssueReplacementLicense.Enabled = false;
                llShowNewLicenseInfo.Enabled = false;
                ctrlReplacementForLostOrDamagedDrivingLicense1.FilterFocus();
                return true;
            }
            return false;
        }
        private void _ReplacementLicenseForDamagedOrLost()
        {
            _LocalDrivingLicenseID = _LocalDrivingLicenseInfo.ReplacementLicenseForDamagedOrLost(ctrlReplacementForLostOrDamagedDrivingLicense1.IssueReason, clsGlobal.CurrentUser.UserID);

            if (_LocalDrivingLicenseID != -1)
            {
                _ShowMessageError($"Local Driving License Replaced Successfully With ID [{_LocalDrivingLicenseID}] in The System.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlReplacementForLostOrDamagedDrivingLicense1.LoadLocalDrivingLicenseWithApplicationInfo(_LocalDrivingLicenseID);
            }
            else
            {
                _ShowMessageError($"Local Driving License Was Not Replaced!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llShowNewLicenseInfo.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            btnIssueReplacementLicense.Enabled = false;
        }


        //Constructor :-
        public frmReplacementForLostOrDamagedDrivingLicense()
        {
            InitializeComponent();
        }
        private void frmReplacementForLostOrDamagedDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlReplacementForLostOrDamagedDrivingLicense1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
            ctrlReplacementForLostOrDamagedDrivingLicense1.IssueReasonSelected += _OnIssueReasonSelected;
        }
        private void frmReplacementForLostOrDamagedDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlReplacementForLostOrDamagedDrivingLicense1.FilterFocus();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Issue Replacement License For (Damaged Or Lost) Local Driving License :-
        private void btnIssueReplacementLicense_Click(object sender, EventArgs e)
        {
            if (!_GetLocalDrivingLicenseObject())
                return;

            if (_DoesPersonHaveActiveLocalDrivingLicense())
                return;

            if (MessageBox.Show("Are You Sure You Want to Replaced This License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _ReplacementLicenseForDamagedOrLost();
        }


        //Show New Local Driving License Info :-
        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard(_LocalDrivingLicenseID);
            frm.ShowDialog();

            //Refresh The Form :-
            ctrlReplacementForLostOrDamagedDrivingLicense1.RefreshLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }


        //Show Driving License History :-
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(clsDrivingLicense.Find(_LocalDrivingLicenseID).DriverInfo.PersonID);
            frm.ShowDialog();

            //Refresh The Form :-
            ctrlReplacementForLostOrDamagedDrivingLicense1.RefreshLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }
    }
}