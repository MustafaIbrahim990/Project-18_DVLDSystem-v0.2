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
using DVLDSystem.Gobal_Classes;

namespace DVLDSystem.DVLD.Driving_License.Detain_License.Controls
{
    public partial class ctrlDetainLicenseApplication : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;
        public event Action<float> FineFeesSelected;


        //Private Properties :-
        private int _LocalDrivingLicenseID = -1;
        private int _DetainID = -1;


        //Public Properties :-
        public int SelectedLocalDrivingLicenseID
        {
            get { return _LocalDrivingLicenseID; }
        }
        public int SelectedDetainID
        {
            get { return _DetainID; }
        }
        public float SelectedFineFees
        {
            get { return (string.IsNullOrWhiteSpace(txtFineFees.Text)) ? -1 : Convert.ToSingle(txtFineFees.Text); }
        }


        //Private Methods :-
        private void _LoadBasicApplicationInfo()
        {
            lblDetainID.Text = "N/A";
            lblLicenseID.Text = "N/A";

            txtFineFees.Text = null;
            txtFineFees.Visible = true;

            lblFineFees.Text = null;
            lblFineFees.Visible = false;

            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _LoadAdditionalApplicationInfo()
        {
            _LoadBasicApplicationInfo();

            if (_LocalDrivingLicenseID != -1)
            {
                lblLicenseID.Text = _LocalDrivingLicenseID.ToString();
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
            lblDetainID.Text = _DetainID.ToString();

            txtFineFees.Visible = false;
            lblDolarSymbol.Visible = false;

            lblFineFees.Text = txtFineFees.Text + " $";
            lblFineFees.Visible = true;
        }


        //Protected Methods :-
        protected void OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            LocalDrivingLicenseIDSelected?.Invoke(LocalLicenseID);
        }
        protected void OnFineFeesSelected(float FineFees)
        {
            FineFeesSelected?.Invoke(SelectedFineFees);
        }


        //Public Methods :-
        public void FilterFocus()
        {
            ctrlDrivingLicenseCardWithFilter1.FilterFocus();
        }
        public void FineFeesFocus()
        {
            txtFineFees.Focus();
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
        public ctrlDetainLicenseApplication()
        {
            InitializeComponent();
        }
        private void ctrlDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            //Subscribe With Local Driving License ID Selected :-
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }


        //Fine Fees :-
        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtFineFees_TextChanged(object sender, EventArgs e)
        {
            if (clsValidation.IsEmpty(txtFineFees.Text.Trim()))
            {
                txtFineFees.Text = null;
                txtFineFees.Focus();
                errorProvider1.SetError(txtFineFees, "Fine Fees Can't Be Empty.");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
                FineFeesSelected?.Invoke(SelectedFineFees);
            }
        }
        private void txtFineFees_Leave(object sender, EventArgs e)
        {
            FineFeesSelected?.Invoke(SelectedFineFees);
        }
    }
}