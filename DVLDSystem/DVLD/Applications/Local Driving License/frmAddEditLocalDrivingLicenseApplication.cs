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

namespace DVLDSystem.DVLD.Applications.Local_Driving_License
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        //Enums :-
        private enum enMode { eAddNew = 1, eUpdate = 2 };
        private enMode _Mode;


        //Properties :-
        private int _SelectedPersonID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;


        //Private Methods :-
        private void _FillLicenseClassesInComboBox()
        {
            DataTable dt = clsLicenseClass.GetAllInfo();

            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();

            if (_Mode == enMode.eAddNew)
            {
                this.Text = "Add New Local Driving License Application";
                lblTitle.Text = "Add New Local Driving License Application";
                _LocalDrivingLicenseApplicationInfo = new clsLocalDrivingLicenseApplication();
                tpApplicationInfo.Enabled = false;
                btnSaveData.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.NewDrivingLicense).Fees.ToString() + " $";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";
                tpApplicationInfo.Enabled = true;
                btnSaveData.Enabled = true;
            }
            lblDrivingLicenseApplicationID.Text = "N/A";
        }

        private void _RefreshInfoCard()
        {
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplicationInfo.ApplicantPersonID);
            lblDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplicationInfo.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _LocalDrivingLicenseApplicationInfo.PaidFees.ToString() + " $";
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName);
            lblCreatedBy.Text = _LocalDrivingLicenseApplicationInfo.CreatedByUserInfo.UserName.ToString();
        }

        private void _LoadData()
        {
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                MessageBox.Show($"Error : No Local Driving License Application With ID [{_LocalDrivingLicenseApplicationID}] in The System!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _RefreshInfoCard();
        }

        private void _NextPage()
        {
            if (_Mode == enMode.eUpdate)
            {
                tpApplicationInfo.Enabled = true;
                btnSaveData.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab = tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            //incase Of Add New Mode :-
            if (ctrlPersonInfoWithFilter1.SelectedPersonID != -1)
            {
                tpApplicationInfo.Enabled = true;
                btnSaveData.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab = tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
            }
            else
            {
                MessageBox.Show($"Please Select a Person!", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfoWithFilter1.FilterFocus();
            }
        }

        private bool _DosePersonAgeValidForLicenseClass()
        {
            clsPerson PersonInfo = clsPerson.Find(ctrlPersonInfoWithFilter1.SelectedPersonID);
            int MinimumAllowedAge = clsLicenseClass.Find(_LocalDrivingLicenseApplicationInfo.LicenseClassID).MinimumAllowedAge;

            if (clsValidation.CalculateAge(PersonInfo.DateOfBirth) >= MinimumAllowedAge)
            {
                return true;
            }
            MessageBox.Show($"Person With ID [{PersonInfo.PersonID}], To Get This License Class You Must be {MinimumAllowedAge} Years old Or older!", "Age is Not Suitable!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool _DosePersonHaveActiveApplication()
        {
            if (clsApplication.DosePersonHaveActiveApplicationForLicenseClass(ctrlPersonInfoWithFilter1.SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, _LocalDrivingLicenseApplicationInfo.LicenseClassID))
            {
                MessageBox.Show($"Choose another License Class, The Selected Person Already have an Active Application For The Selected Class in The System!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return true;
            }
            return false;
        }

        private bool _DosePersonHaveDrivingLicnese()
        {
            if (clsDrivingLicense.DosePersonHaveDrivingLicense(ctrlPersonInfoWithFilter1.SelectedPersonID, _LocalDrivingLicenseApplicationInfo.LicenseClassID))
            {
                MessageBox.Show("Person Already have a Driving License With The Same Applied License Class, Choose Diffrent License Class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return true;
            }
            return false;
        }

        private void _GetInfo()
        {
            _LocalDrivingLicenseApplicationInfo.ApplicantPersonID = ctrlPersonInfoWithFilter1.SelectedPersonID;
            _LocalDrivingLicenseApplicationInfo.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplicationInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplicationInfo.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplicationInfo.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplicationInfo.PaidFees = Convert.ToSingle(lblApplicationFees.Text.Replace("$", "").Trim());
        }

        private void _Save()
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid :-
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplicationInfo.LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).ID;

            if (!_DosePersonAgeValidForLicenseClass())
                return;

            if (_DosePersonHaveActiveApplication())
                return;

            if (_DosePersonHaveDrivingLicnese())
                return;

            _GetInfo();

            if (_LocalDrivingLicenseApplicationInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.eUpdate;
            this.Text = "Update Local Driving License Application";
            lblTitle.Text = "Update Local Driving License Application";
            lblDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            ctrlPersonInfoWithFilter1.FilterPersonEnabled = false;
        }


        //Constructor :-
        private void _LoadMode()
        {
            if (_LocalDrivingLicenseApplicationID == -1)
            {
                _Mode = enMode.eAddNew;
                return;
            }
            _Mode = enMode.eUpdate;
        }
        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = -1;
        }
        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadMode();
            _ResetDefaultValues();

            if (_Mode == enMode.eUpdate)
            {
                ctrlPersonInfoWithFilter1.FilterPersonEnabled = false;
                _LoadData();
            }
        }
        private void frmAddEditLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterFocus();
        }


        //Next Step (Page) :-
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            _NextPage();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Save Data :-
        private void btnSaveUserData_Click(object sender, EventArgs e)
        {
            _Save();

        }


        //We Can Retrieve PersonID From (ctrlPersonCardWithFilter1) When We Select Person :-
        private void CtrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
    }
}