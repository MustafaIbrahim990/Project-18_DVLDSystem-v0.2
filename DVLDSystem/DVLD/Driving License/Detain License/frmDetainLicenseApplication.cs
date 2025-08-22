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
using DVLDSystem.DVLD.Driving_License.Local_Driving_License;
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Driving_License.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseID = -1;
        private clsDrivingLicense _LocalDrivingLicenseInfo;

        private int _DetainID = -1;


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }

        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            btnDetainLicense.Enabled = ((_LocalDrivingLicenseID != -1) && (ctrlDetainLicenseApplication1.SelectedFineFees != -1)) ? true : false;
            llShowLicenseHistory.Enabled = (_LocalDrivingLicenseID == -1) ? false : true;
            llShowLicenseInfo.Enabled = false;
            ctrlDetainLicenseApplication1.FineFeesFocus();
        }

        private void CtrlDetainLicenseApplication1_FineFeesSelected(float FineFees)
        {
            btnDetainLicense.Enabled = (_LocalDrivingLicenseID != -1 && FineFees != -1) ? true : false;
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
                btnDetainLicense.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                ctrlDetainLicenseApplication1.FilterFocus();
                return true;
            }
            return false;
        }

        private bool _IsLicenseDetained()
        {
            if (clsDetainedDrivingLicense.IsDetainedDrivingLicense(_LocalDrivingLicenseID))
            {
                MessageBox.Show($"Selected License is already Detained, Choose another One.", "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetainLicense.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                ctrlDetainLicenseApplication1.FilterFocus();
                return true;
            }
            return false;
        }

        private void _DetainDrivingLicense()
        {
            _DetainID = _LocalDrivingLicenseInfo.DetainLicense(ctrlDetainLicenseApplication1.SelectedFineFees, clsGlobal.CurrentUser.UserID);

            if (_DetainID != -1)
            {
                _ShowMessageError($"License Detained Successfully With ID [{_DetainID}] in The System.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlDetainLicenseApplication1.LoadDetainLicenseInfo(_LocalDrivingLicenseID);
            }
            else
            {
                _ShowMessageError($"License Was Not Detain!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llShowLicenseInfo.Enabled = (_DetainID == -1) ? false : true;
            btnDetainLicense.Enabled = false;
        }


        //Constructor :-
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }
        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDetainLicenseApplication1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
            ctrlDetainLicenseApplication1.FineFeesSelected += CtrlDetainLicenseApplication1_FineFeesSelected;
        }
        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDetainLicenseApplication1.FilterFocus();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Detain License :-
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_GetLocalDrivingLicenseObject())
                return;

            if (_DoesPersonHaveActiveLocalDrivingLicense())
                return;

            if (_IsLicenseDetained())
                return;

            if (MessageBox.Show("Are You Sure You Want to Detain This License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _DetainDrivingLicense();
        }


        //Show Local Driving License :-
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseCard frm = new frmShowDrivingLicenseCard(_LocalDrivingLicenseID);
            frm.ShowDialog();

            //Refresh The Form :-
            //ctrlDetainLicenseApplication1.RefreshLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }


        //Show Person Licenses History :-
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDrivingLicenseHistory frm = new frmShowPersonDrivingLicenseHistory(clsDrivingLicense.Find(_LocalDrivingLicenseID).DriverInfo.PersonID);
            frm.ShowDialog();

            //Refresh The Form :-
            //ctrlDetainLicenseApplication1.RefreshLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }
    }
}