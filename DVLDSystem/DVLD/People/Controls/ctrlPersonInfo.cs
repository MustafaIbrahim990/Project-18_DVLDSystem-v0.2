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
using DVLDSystem.Gobal_Classes;
using System.IO;

namespace DVLDSystem.DVLD.People.Controls
{
    public partial class ctrlPersonInfo : UserControl
    {
        //Enums :-
        private enum enGender { eMale = 1, Female = 2 };

        //Private Properties :-
        private int _PersonID = -1;
        private clsPerson _PersonInfo;


        //Public Properties :-
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _PersonInfo; }
        }


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(Message, Caption, messageBoxButtons, messageBoxIcon);
        }

        private void _GetDefaultImage()
        {
            if (_PersonInfo.Gender == (byte)enGender.eMale)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private void _LoadGenderImage()
        {
            if (_PersonInfo.Gender == (byte)enGender.eMale)
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
            if (!clsValidation.IsEmpty(_PersonInfo.ImagePath))
            {
                if (File.Exists(_PersonInfo.ImagePath))
                    pbPersonImage.ImageLocation = _PersonInfo.ImagePath;
                else
                {
                    _ShowMessageError("Error : Could Not Find this image : " + _PersonInfo.ImagePath, "Image Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _GetDefaultImage();
                }
            }
            else
            {
                _GetDefaultImage();
            }
        }

        private void _ShowPersonInfo()
        {
            _PersonID = _PersonInfo.PersonID;
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            lblFullName.Text = _PersonInfo.FullName.Trim();
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblDataOfBirth.Text = _PersonInfo.DateOfBirth.ToShortDateString();
            lblPhone.Text = _PersonInfo.Phone;
            lblEmail.Text = _PersonInfo.Email;
            lblCountry.Text = _PersonInfo.CountryInfo.CountryName;
            lblAddress.Text = _PersonInfo.Address;
            _LoadGenderImage();
            _LoadPersonImage();
            llEditPersonInfo.Enabled = true;
        }


        //Public Methods :-
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "N/A";
            lblFullName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblDataOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            lblGender.Text = "[????]";
            pbGenderImage.Image = Properties.Resources.Man_32;
            pbPersonImage.Image = Properties.Resources.Male_512;
            llEditPersonInfo.Enabled = false;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonInfo = clsPerson.Find(PersonID);

            if (_PersonInfo == null)
            {
                ResetPersonInfo();
                _ShowMessageError($"Error : No Person With ID [{PersonID}] in The System!", "Person Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ShowPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _PersonInfo = clsPerson.Find(NationalNo);

            if (_PersonInfo == null)
            {
                ResetPersonInfo();
                _ShowMessageError($"Error : No Person With National No. [{NationalNo}] in The System!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ShowPersonInfo();
        }


        //Constructor :-
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        private void ctrlPersonInfo_Load(object sender, EventArgs e)
        {

        }


        //Edit Person Info :-
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();

            //Refresh :-
            LoadPersonInfo(_PersonID);
        }
    }
}