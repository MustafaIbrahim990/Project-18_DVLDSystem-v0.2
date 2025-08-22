using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLDSystem_BusinessLayer;
using DVLDSystem.DVLD.People;
using DVLDSystem.Gobal_Classes;

namespace DVLDSystem.DVLD.Driving_License.International_Driving_License.Controls
{
    public partial class ctrlInternationalDrivingLicenseCard : UserControl
    {
        //Enums :-
        private enum enGender { eMale = 1, Female = 2 };

        //Private Properties :-
        private int _InternationalDrivingLicenseID = -1;
        private clsInternationalDrivingLicense _InternationalDrivingLicenseInfo;


        //Public Properties :-
        public int SelectedInternationalDrivingLicenseID
        {
            get { return _InternationalDrivingLicenseID; }
        }
        public clsInternationalDrivingLicense SelectedInternationalDrivingLicenseInfo
        {
            get { return _InternationalDrivingLicenseInfo; }
        }


        //Private Methods :-
        private bool _GetInternationalDrivingLicenseObject()
        {
            _InternationalDrivingLicenseInfo = clsInternationalDrivingLicense.FindInternationalID(_InternationalDrivingLicenseID);

            if (_InternationalDrivingLicenseInfo == null)
            {
                MessageBox.Show($"Error : Could Not Find International Driving License With ID [{_InternationalDrivingLicenseID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetInternationalDrivingLicenseInfo();
                return false;
            }
            return true;
        }

        private void _LoadGenderImage()
        {
            if (_InternationalDrivingLicenseInfo.PersonInfo.Gender == (byte)enGender.eMale)
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

        private void _GetDefaultPersonImage()
        {
            if (_InternationalDrivingLicenseInfo.PersonInfo.Gender == (byte)enGender.eMale)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private void _LoadPersonImage()
        {
            if (!clsValidation.IsEmpty(_InternationalDrivingLicenseInfo.PersonInfo.ImagePath))
            {
                if (File.Exists(_InternationalDrivingLicenseInfo.PersonInfo.ImagePath))
                {
                    pbPersonImage.ImageLocation = _InternationalDrivingLicenseInfo.PersonInfo.ImagePath;
                    return;
                }
                else
                {
                    MessageBox.Show("Could Not Find this image : " + _InternationalDrivingLicenseInfo.PersonInfo.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _GetDefaultPersonImage();
        }

        private void _FillInternationalDrivingLicenseInfo()
        {
            lblFullName.Text = _InternationalDrivingLicenseInfo.FullName;
            lblInternationalDrivingLicenseID.Text = _InternationalDrivingLicenseInfo.InternationalDrivingLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalDrivingLicenseInfo.IssuedUsingDrivingLicenseID.ToString();
            lblGender.Text = _InternationalDrivingLicenseInfo.PersonInfo.Gender.ToString();
            lblDriverID.Text = _InternationalDrivingLicenseInfo.DriverID.ToString();
            lblIssueDate.Text = _InternationalDrivingLicenseInfo.IssueDate.ToShortDateString();

            lblApplicationID.Text = _InternationalDrivingLicenseInfo.ApplicationID.ToString();
            lblNationalNumber.Text = _InternationalDrivingLicenseInfo.PersonInfo.NationalNo;
            lblDataOfBirth.Text = _InternationalDrivingLicenseInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblIsActive.Text = (_InternationalDrivingLicenseInfo.IsActive) ? "Yes" : "No";
            lblExpriationDate.Text = _InternationalDrivingLicenseInfo.ExpriationDate.ToShortDateString();

            _LoadGenderImage();
            _LoadPersonImage();
            llShowPersonInfo.Enabled = true;
        }


        //Public Methods :-
        public void ResetInternationalDrivingLicenseInfo()
        {
            _InternationalDrivingLicenseID = -1;

            lblFullName.Text = "[????]";
            lblInternationalDrivingLicenseID.Text = "N/A";
            lblLocalLicenseID.Text = "N/A";
            lblGender.Text = "[????]";
            lblDriverID.Text = "N/A";
            lblIssueDate.Text = "[????]";

            lblApplicationID.Text = "N/A";
            lblNationalNumber.Text = "[????]";
            lblDataOfBirth.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblExpriationDate.Text = "[????]";

            pbGenderImage.Image = Properties.Resources.Man_32;
            pbPersonImage.Image = Properties.Resources.Male_512;
            llShowPersonInfo.Enabled = false;
        }
        public void LoadInternationalDrivingLicenseInfo(int InternationalLicenseID)
        {
            _InternationalDrivingLicenseID = InternationalLicenseID;

            if (!_GetInternationalDrivingLicenseObject())
                return;

            _FillInternationalDrivingLicenseInfo();
        }


        //Constructor :-
        public ctrlInternationalDrivingLicenseCard()
        {
            InitializeComponent();
        }
        private void ctrlInternationalDrivingLicenseCard_Load(object sender, EventArgs e)
        {

        }


        //Show Person Info :-
        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_InternationalDrivingLicenseInfo.ApplicantPersonID);
            frm.ShowDialog();

            //Refresh :-
            LoadInternationalDrivingLicenseInfo(_InternationalDrivingLicenseID);
        }
    }
}