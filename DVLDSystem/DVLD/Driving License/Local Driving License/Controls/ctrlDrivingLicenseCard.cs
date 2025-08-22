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
using DVLDSystem.DVLD.People;
using DVLDSystem.Gobal_Classes;
using System.IO;

namespace DVLDSystem.DVLD.Driving_License.Local_Driving_License.Controls
{
    public partial class ctrlDrivingLicenseCard : UserControl
    {
        //Enums :-
        private enum enGender { eMale = 1, Female = 2 };

        //Private Properties :-
        private int _DrivingLicenseID = -1;
        private clsDrivingLicense _DrivingLicenseInfo;


        //Public Properties :-
        public int SelectedDrivingLicenseID
        {
            get { return _DrivingLicenseID; }
        }
        public clsDrivingLicense SelectedDrivingLicenseInfo
        {
            get { return _DrivingLicenseInfo; }
        }


        //Private Methods :-
        private bool _GetLocalDrivingLicenseObject()
        {
            _DrivingLicenseInfo = clsDrivingLicense.Find(_DrivingLicenseID);

            if (_DrivingLicenseInfo == null)
            {
                MessageBox.Show($"Error : Could Not Find Driving License With ID [{_DrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetLocalDrivingLicenseInfo(); 
                return false;
            }
            return true;
        }

        private void _GetDefaultPersonImage()
        {
            if (_DrivingLicenseInfo.ApplicationInfo.PersonInfo.Gender == (byte)enGender.eMale)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private void _LoadGenderImage()
        {
            if (_DrivingLicenseInfo.ApplicationInfo.PersonInfo.Gender == (byte)enGender.eMale)
            {
                lblGender.Text = "Male";
                pbGenderImage.Image = Properties.Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGenderImage.Image = Properties.Resources.Woman_32;
            }
        }

        private void _LoadPersonImage()
        {
            if (!clsValidation.IsEmpty(_DrivingLicenseInfo.ApplicationInfo.PersonInfo.ImagePath))
            {
                if (File.Exists(_DrivingLicenseInfo.ApplicationInfo.PersonInfo.ImagePath))
                {
                    pbPersonImage.ImageLocation = _DrivingLicenseInfo.ApplicationInfo.PersonInfo.ImagePath;
                    return;
                }
                else
                {
                    MessageBox.Show("Could Not Find this image : " + _DrivingLicenseInfo.ApplicationInfo.PersonInfo.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _GetDefaultPersonImage();
        }

        private void _FillLocalDrivingLicenseInfo()
        {
            lblClass.Text = _DrivingLicenseInfo.LicenseClassInfo.ClassName;
            lblFullName.Text = _DrivingLicenseInfo.ApplicationInfo.FullName;
            lblDrivingLicenseID.Text = _DrivingLicenseInfo.ID.ToString();
            lblNationalNumber.Text = _DrivingLicenseInfo.ApplicationInfo.PersonInfo.NationalNo;
            lblGender.Text = _DrivingLicenseInfo.ApplicationInfo.PersonInfo.Gender.ToString();
            lblIssueDate.Text = _DrivingLicenseInfo.IssueDate.ToShortDateString();
            lblIssueReason.Text = _DrivingLicenseInfo.IssueReasonText;
            lblNotes.Text = (!clsValidation.IsEmpty(_DrivingLicenseInfo.Notes)) ? _DrivingLicenseInfo.Notes : "No Notes";
            lblIsActive.Text = (_DrivingLicenseInfo.IsActive) ? "Yes" : "No";
            lblDataOfBirth.Text = _DrivingLicenseInfo.ApplicationInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _DrivingLicenseInfo.DriverInfo.ID.ToString();
            lblExpirationDate.Text = _DrivingLicenseInfo.ExpriationDate.ToShortDateString();

            lblIsDetained.Text = (_DrivingLicenseInfo.IsDetained) ? "Yes" : "No";

            _LoadGenderImage();
            _LoadPersonImage();
            llShowPersonInfo.Enabled = true;
        }


        //Public Methods :-
        public void ResetLocalDrivingLicenseInfo()
        {
            _DrivingLicenseID = -1;

            lblClass.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDrivingLicenseID.Text = "N/A";
            lblNationalNumber.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDataOfBirth.Text = "[????]";
            lblDriverID.Text = "N/A";
            lblExpirationDate.Text = "[????]";
            lblIsDetained.Text = "[????]";
            pbGenderImage.Image = Properties.Resources.Man_32;
            pbPersonImage.Image = Properties.Resources.Male_512;
            llShowPersonInfo.Enabled = false;
        }
        public void LoadLocalDrivingLicenseInfo(int LocalDrivingLicenseID)
        {
            _DrivingLicenseID = LocalDrivingLicenseID;

            if (!_GetLocalDrivingLicenseObject())
                return;

            _FillLocalDrivingLicenseInfo();
        }


        //Constructor :-
        public ctrlDrivingLicenseCard()
        {
            InitializeComponent();
        }
        private void ctrlDrivingLicenseCard_Load(object sender, EventArgs e)
        {

        }



        //Show Person Info :-
        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_DrivingLicenseInfo.ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();

            //Refresh :-
            LoadLocalDrivingLicenseInfo(_DrivingLicenseID);
        }
    }
}