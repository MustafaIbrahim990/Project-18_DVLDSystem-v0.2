using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.Driving_License
{
    public partial class frmShowPersonDrivingLicenseHistory : Form
    {
        //Private Prpperties :-
        private int _PersonID = -1;


        //Private Methods :-
        private void _LoadPersonInfo()
        {
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_PersonID);
        }
        private void _LoadDrivingLicenses()
        {
            ctrlDrivingLicenses1.LoadDrivingLicensesInfoBy(_PersonID);
        }
        private void CtrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID == -1)
                ctrlDrivingLicenses1.Clear();
            else
                _LoadDrivingLicenses();
        }


        //Constructor :-
        public frmShowPersonDrivingLicenseHistory()
        {
            InitializeComponent();

            _PersonID = -1;
        }
        public frmShowPersonDrivingLicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }
        private void frmShowPersonDrivingLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                ctrlPersonInfoWithFilter1.FilterPersonEnabled = true;
                ctrlPersonInfoWithFilter1.FilterFocus();
                ctrlPersonInfoWithFilter1.OnPersonSelected += CtrlPersonCardWithFilter1_OnPersonSelected;
            }
            else
            {
                ctrlPersonInfoWithFilter1.FilterPersonEnabled = false;
                _LoadPersonInfo();
                _LoadDrivingLicenses();

            }
        }
    }
}