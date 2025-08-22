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
using DVLDSystem.DVLD.Applications;

namespace DVLDSystem.DVLD.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingLicenseApplicationCard : Form
    {
        //Properties :-
        private int _LocalDrivingLicenseApplicationID = -1;


        //Constructor :-
        public frmShowLocalDrivingLicenseApplicationCard(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmShowLocalDrivingLicenseApplicationCard_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplication1.LoadLocalDrivingLicenseApplicationInfoByLocalID(_LocalDrivingLicenseApplicationID);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}