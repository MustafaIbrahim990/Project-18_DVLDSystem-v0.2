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

namespace DVLDSystem
{
    public partial class frmAddEditPerson : Form
    {
        //Delegate :-
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        //Enums :-
        private enum enMode { eAddNew = 1, eUpdate = 2 };
        private enum enGender { eMale = 1, eFemale = 2 };
        private enMode _Mode;


        //Properties :-
        private int _PersonID = -1;
        private clsPerson _PersonInfo;


        //Private Methods :-
        private void _ShowMessageError(string Message,string Caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(Message, Caption, messageBoxButtons, messageBoxIcon);
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _GetDefaultImage()
        {
            if (rbMale.Checked)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        public void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.eAddNew)
            {
                lblTitle.Text = "Add New Person";
                _PersonInfo = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }
            rbMale.Checked = true;
            _GetDefaultImage();

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");

            lblPersonID.Text = "N/A";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationaNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _RefreshPersonInfoInUpdateMode()
        {
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            txtFirstName.Text = _PersonInfo.FirstName;
            txtSecondName.Text = _PersonInfo.SecondName;
            txtThirdName.Text = _PersonInfo.ThirdName;
            txtLastName.Text = _PersonInfo.LastName;
            txtNationaNo.Text = _PersonInfo.NationalNo;
            dtpDateOfBirth.Value = _PersonInfo.DateOfBirth;
            txtPhone.Text = _PersonInfo.Phone;
            txtEmail.Text = _PersonInfo.Email;
            txtAddress.Text = _PersonInfo.Address;

            cbCountry.SelectedIndex = cbCountry.FindString(_PersonInfo.CountryInfo.CountryName);

            if (_PersonInfo.Gender == (byte)enGender.eMale)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


            if (!clsValidation.IsEmpty(_PersonInfo.ImagePath))
                pbPersonImage.ImageLocation = _PersonInfo.ImagePath;

            llRemoveImage.Visible = !clsValidation.IsEmpty(_PersonInfo.ImagePath);
        }

        private void _LoadDataInUpdateMode()
        {
            _PersonInfo = clsPerson.Find(_PersonID);

            if (_PersonInfo == null)
            {
                _ShowMessageError($"Error : No Person With ID [{_PersonID}] in The System!", "Person Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _RefreshPersonInfoInUpdateMode();
        }

        private bool _HandelPersonImage()
        {
            //_PersonInfo.ImagePath Contains Old Image, We Check if it Chenged Then We Copy The New Image :-
            if (_PersonInfo.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!clsValidation.IsEmpty(_PersonInfo.ImagePath))
                {
                    try
                    {
                        File.Delete(_PersonInfo.ImagePath);
                    }
                    catch (IOException)
                    {
                        //We Could Not Delete The File.
                    }
                }
            }

            if (!clsValidation.IsEmpty(pbPersonImage.ImageLocation))
            {
                string SourceFileImage = pbPersonImage.ImageLocation.ToString();

                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceFileImage))
                {
                    pbPersonImage.ImageLocation = SourceFileImage;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void _GetPersonInfo()
        {
            _PersonInfo.FirstName = txtFirstName.Text.Trim();
            _PersonInfo.SecondName = txtSecondName.Text.Trim();
            _PersonInfo.ThirdName = txtThirdName.Text.Trim();
            _PersonInfo.LastName = txtLastName.Text.Trim();
            _PersonInfo.NationalNo = txtNationaNo.Text.Trim();
            _PersonInfo.DateOfBirth = dtpDateOfBirth.Value;
            _PersonInfo.Phone = txtPhone.Text.Trim();
            _PersonInfo.Email = txtEmail.Text.Trim();
            _PersonInfo.Address = txtAddress.Text.Trim();
            _PersonInfo.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;

            if (rbMale.Checked)
                _PersonInfo.Gender = (byte)enGender.eMale;
            else
                _PersonInfo.Gender = (byte)enGender.eFemale;

            if (!clsValidation.IsEmpty(pbPersonImage.ImageLocation))
                _PersonInfo.ImagePath = pbPersonImage.ImageLocation;
            else
                _PersonInfo.ImagePath = "";
        }

        private void _SaveData()
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandelPersonImage())
                return;

            _GetPersonInfo();

            if (_PersonInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.eUpdate;
            lblTitle.Text = $"Update Person : ";
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            DataBack?.Invoke(this, _PersonInfo.PersonID);
        }

        private void _InsertImage()
        {
            openFileDialog1.Filter = "Image Files|*.jpeg;*.jpg;*.png;*.gif;*.bmp;";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SelectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(SelectedFilePath);
                llRemoveImage.Visible = true;
            }
        }

        private void _RemoveImage()
        {
            _GetDefaultImage();
            pbPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;
        }


        //Constructor :-
        private void _LoadMode()
        {
            if (_PersonID == -1)
            {
                _Mode = enMode.eAddNew;
                return;
            }
            _Mode = enMode.eUpdate;
        }
        public frmAddEditPerson()
        {
            InitializeComponent();

            _PersonID = -1;
            _LoadMode();
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _LoadMode();
        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.eUpdate)
                _LoadDataInUpdateMode();
        }


        //Validation Data :-
        //Validate Empty TextBox :-
        private void SetErrorProvider(Control control, string Message)
        {
            errorProvider1.SetError(control, Message);
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (clsValidation.IsEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                SetErrorProvider(Temp, "This Field is Required!");
            }
            else
            {
                SetErrorProvider(Temp, null);
            }
        }


        //Validate National No :-
        private void txtNationaNo_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtNationaNo.Text.Trim()))
            {
                e.Cancel = true;
                SetErrorProvider(txtNationaNo, "This Field is Required!");
                return;
            }

            if (clsPerson.IsExist(txtNationaNo.Text.Trim()) && _PersonInfo.NationalNo != txtNationaNo.Text.Trim())
            {
                e.Cancel = true;
                SetErrorProvider(txtNationaNo, "National Number is Used For another Person, Enter another One!");
                return;
            }
            SetErrorProvider(txtNationaNo, null);
        }


        //Validate Phone Number :-
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }


        //Validate County :-
        private void cbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbCountry.Text.Trim()))
            {
                e.Cancel = true;
                SetErrorProvider(cbCountry, "This Field is Required!");
                return;
            }

            if (!clsCountry.IsExist(cbCountry.Text.Trim()))
            {
                e.Cancel = true;
                SetErrorProvider(cbCountry, "This Country is Not Exist!");
                return;
            }
            SetErrorProvider(cbCountry, null);
        }


        //Validate DateOfBirth :-
        private void dtpDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(dtpDateOfBirth.Text.Trim()))
            {
                e.Cancel = true;
                SetErrorProvider(dtpDateOfBirth, "This Field is Required!");
            }
            else
            {
                SetErrorProvider(dtpDateOfBirth, null);
            }
        }


        //Validate Email :-
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtEmail.Text.Trim()))
            {
                SetErrorProvider(txtEmail, null);
                return;
            }

            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                SetErrorProvider(txtEmail, "Invalid Email Address, Should Include @gmail.com!");
                return;
            }
            SetErrorProvider(txtEmail, null);
        }


        //Load Gender Image :-
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                _GetDefaultImage();
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                _GetDefaultImage();
        }


        //Set Image :-
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _InsertImage();
        }


        //Remove Image :-
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemoveImage();
        }


        //Clode Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Save Person Data :-
        private void btnSavePersonData_Click(object sender, EventArgs e)
        {
            _SaveData();
        }
    }
}