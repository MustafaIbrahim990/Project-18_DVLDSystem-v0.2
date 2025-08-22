using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        //Constructor :-
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrlPersonInfo1.LoadPersonInfo(PersonID);
        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonInfo1.LoadPersonInfo(NationalNo);
        }
        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {

        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}