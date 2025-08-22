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
using System.IO;
using DVLDSystem.DVLD.Global_User;

namespace DVLDSystem.DVLD.Applications.International_Driving_License.Controls
{
    public partial class ctrlInternationalDrivingLicenseApplicationCard : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;


        //Properties :-
        private int _LocalDrivingLicenseID = -1;
        private int _InternationalDrivingLicenseID = -1;
        private clsInternationalDrivingLicense _InternationalDrivingLicenseInfo;

        public int SelectedInternationalDrivingLicenseID
        {
            get { return _InternationalDrivingLicenseID; }
        }
        public clsInternationalDrivingLicense SelectedInternationalDrivingLicenseInfo
        {
            get { return _InternationalDrivingLicenseInfo; }
        }


        //Private Methods :-
        private void _LoadApplicationBasicInfo()
        {
            lblInternationalApplicationID.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblLocalLicenseID.Text = "N/A";
            lblInternationalApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalDrivingLicense).Fees.ToString() + " $";
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _OnLocalDrivingLicenseIDSelected(int LocalLicenseID)
        {
            _LocalDrivingLicenseID = LocalLicenseID;
            _LoadApplicationBasicInfo();

            //Send Local License ID to Subscriber :-
            LocalDrivingLicenseIDSelected?.Invoke(_LocalDrivingLicenseID);
        }
        private void _ResetInfo()
        {
            lblInternationalApplicationID.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblLocalLicenseID.Text = "N/A";
        }
        private void _FillInfo()
        {
            lblInternationalApplicationID.Text = _InternationalDrivingLicenseInfo.ApplicationID.ToString();
            lblInternationalLicenseID.Text = _InternationalDrivingLicenseInfo.InternationalDrivingLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalDrivingLicenseInfo.IssuedUsingDrivingLicenseID.ToString();
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
        public void LoadApplicationBasicInfo(int InternationalDrivingLicenseID)
        {
            _InternationalDrivingLicenseInfo = clsInternationalDrivingLicense.FindInternationalID(InternationalDrivingLicenseID);

            if (_InternationalDrivingLicenseInfo == null)
            {
                _ResetInfo();
                MessageBox.Show($"Error : Could Not Find International Driving License With ID [{InternationalDrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInfo();
            ctrlDrivingLicenseCardWithFilter1.FilterDrivingLicenseEnabled = false;
        }


        //Constructor :-
        public ctrlInternationalDrivingLicenseApplicationCard()
        {
            InitializeComponent();
        }
        private void ctrlInternationalDrivingLicenseApplicationCard_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseCardWithFilter1.LocalDrivingLicenseIDSelected += _OnLocalDrivingLicenseIDSelected;
        }
    }
}