using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.Driving_License.Local_Driving_License
{
    public partial class frmShowDrivingLicenseCard : Form
    {
        //Properties :-
        private int _DrivingLicenseID = -1;


        //Constructor :-
        public frmShowDrivingLicenseCard(int DrivingLicenseID)
        {
            InitializeComponent();

            _DrivingLicenseID = DrivingLicenseID;
        }
        private void frmShowDrivingLicenseCard_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseCard1.LoadLocalDrivingLicenseInfo(_DrivingLicenseID);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}