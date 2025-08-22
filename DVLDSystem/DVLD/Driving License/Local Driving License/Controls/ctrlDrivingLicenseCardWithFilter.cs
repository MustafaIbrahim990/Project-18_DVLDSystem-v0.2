using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDSystem.Gobal_Classes;
using DVLDSystem.DVLD.People;
using DVLDSystem_BusinessLayer;

namespace DVLDSystem.DVLD.Driving_License.Local_Driving_License.Controls
{
    public partial class ctrlDrivingLicenseCardWithFilter : UserControl
    {
        //Event :-
        public event Action<int> LocalDrivingLicenseIDSelected;


        //Privte Properties :-
        private int _LocalDrivingLicenseID = -1;

        private bool _ShowDrivingLicenseButton = true;
        private bool _FilterDrivingLicenseEnabled = true;


        //Public Properties :-
        public bool ShowDrivingLicenseButton
        {
            get { return _ShowDrivingLicenseButton; }
            set { _ShowDrivingLicenseButton = value; btnFindDrivingLicenseCard.Visible = _ShowDrivingLicenseButton; }
        }
        public bool FilterDrivingLicenseEnabled
        {
            get { return _FilterDrivingLicenseEnabled; }
            set { _FilterDrivingLicenseEnabled = value; gbDrivingLicenseFilter.Enabled = _FilterDrivingLicenseEnabled; }
        }
        public int SelectedDrivingLicenseID
        {
            get { return ctrlDrivingLicenseCard1.SelectedDrivingLicenseID; }
        }
        public clsDrivingLicense SelectedDrivingLicenseInfo
        {
            get { return ctrlDrivingLicenseCard1.SelectedDrivingLicenseInfo; }
        }


        //Private Methods :-
        private void _ShowMessageError(string Message, string Caption, MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons, MessageBoxIcon);
        }


        //Protected Methods :-
        protected virtual void OnLocalDrivingLicenseIDSelected(int LocalDrivingLicenseID)
        {
            //Action<int> handler = OnPersonSelected;
            //if (handler != null)
            //{
            //    handler(PersonID); // Raise the event with the parameter
            //}
            LocalDrivingLicenseIDSelected?.Invoke(LocalDrivingLicenseID);
        }


        //Public Methods :-
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        public void ResetInfo()
        {
            txtFilterValue.Text = null;
            ctrlDrivingLicenseCard1.ResetLocalDrivingLicenseInfo();
        }
        public void LoadLocalDrivingLicenseInfo(int LocalDrivingLicenseID)
        {
            txtFilterValue.Text = LocalDrivingLicenseID.ToString();

            ctrlDrivingLicenseCard1.LoadLocalDrivingLicenseInfo(LocalDrivingLicenseID);
            _LocalDrivingLicenseID = ctrlDrivingLicenseCard1.SelectedDrivingLicenseID;

            if (_LocalDrivingLicenseID == -1)
            {
                FilterFocus();
            }

            //Send Local Driving License ID to Subscriber :-
            if (LocalDrivingLicenseIDSelected != null && FilterDrivingLicenseEnabled)
                LocalDrivingLicenseIDSelected.Invoke(_LocalDrivingLicenseID);
        }


        //Constructor :-
        public ctrlDrivingLicenseCardWithFilter()
        {
            InitializeComponent();
        }
        private void ctrlDrivingLicenseCardWithFilter_Load(object sender, EventArgs e)
        {
            FilterFocus();
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if the preesed key is enter (character code 13 = Enter key)
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFindDrivingLicenseCard.PerformClick();
            }

            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (clsValidation.IsEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This Field is Required!");
                return;
            }
            errorProvider1.SetError(txtFilterValue, null);
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }


        //Show Driving Licese By DrivimgLicenseID :-
        private void btnShowDrivingLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                _ShowMessageError("Some Fileds Are Not Valid!, Put The Mouse On THe Red Icon to The Error!", "Not Valid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FilterFocus();
                return;
            }
            _LocalDrivingLicenseID = Convert.ToInt32(txtFilterValue.Text.Trim());
            LoadLocalDrivingLicenseInfo(_LocalDrivingLicenseID);
        }
    }
}