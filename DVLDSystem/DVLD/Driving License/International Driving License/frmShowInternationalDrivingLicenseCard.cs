using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.Driving_License.International_Driving_License
{
    public partial class frmShowInternationalDrivingLicenseCard : Form
    {
        //Properties :-
        private int _InternationalDrivingLicenseID = -1;


        //Constructor :-
        public frmShowInternationalDrivingLicenseCard(int InternationalDrivingLicenseID)
        {
            InitializeComponent();

            _InternationalDrivingLicenseID = InternationalDrivingLicenseID;
        }
        private void frmShowInternationalDrivingLicenseCard_Load(object sender, EventArgs e)
        {
            ctrlInternationalDrivingLicenseCard1.LoadInternationalDrivingLicenseInfo(_InternationalDrivingLicenseID);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}