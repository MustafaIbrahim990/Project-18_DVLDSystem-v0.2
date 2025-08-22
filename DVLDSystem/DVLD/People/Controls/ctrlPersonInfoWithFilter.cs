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

namespace DVLDSystem.DVLD.People.Controls
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        //Event :-
        public event Action<int> OnPersonSelected;


        //Privte Properties :-
        private bool _ShowAddNewPerson = true;
        private bool _FilterPersonEnabled = true;


        //Public Properties :-
        public bool btnAddNewPersonEnabled
        {
            get { return _ShowAddNewPerson; }
            set { _ShowAddNewPerson = value; btnFindPersonInfo.Visible = _ShowAddNewPerson; }
        }
        public bool FilterPersonEnabled
        {
            get { return _FilterPersonEnabled; }
            set { _FilterPersonEnabled = value; gbFilterPerson.Enabled = _FilterPersonEnabled; }
        }
        public int SelectedPersonID
        {
            get { return ctrlPersonInfo1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonInfo1.SelectedPersonInfo; }
        }


        //Public Methods :-
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            _FindPerson();
        }


        //Protected Methods :-
        protected virtual void PersonSelected(int PersonID)
        {
            OnPersonSelected?.Invoke(PersonID);
        }


        //Private Methods :-
        private void _DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();

            ctrlPersonInfo1.LoadPersonInfo(PersonID);
        }
        private void _FindPerson()
        {
            switch (cbFilterBy.Text.Trim())
            {
                case "Person ID":
                    ctrlPersonInfo1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;

                case "National No.":
                    ctrlPersonInfo1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            //this its call in one case (when we call ctrlPersonInfoWithFilter) :-
            if (OnPersonSelected != null && FilterPersonEnabled == true) 
                OnPersonSelected(SelectedPersonID);
        }


        //Constructor :-
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }
        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }


        //Filter Person By :-
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = null;
            txtFilterValue.Focus();
        }


        //Filter Value :-
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFindPersonInfo.PerformClick();
            }

            if (cbFilterBy.Text == "Person ID")
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


        //Find Person Info :-
        private void btnFindPersonInfo_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!, Put The Mouse On The Red Icon(s) to See The Error!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindPerson();
        }


        //Add New Person :-
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();

            //Subscribe to Event.
            frm.DataBack += _DataBackEvent;
            frm.ShowDialog();
        }
    }
}