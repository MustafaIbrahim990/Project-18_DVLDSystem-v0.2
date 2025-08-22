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

namespace DVLDSystem.DVLD.Tests.Test_Types
{
    public partial class frmShowTestTypeInfo : Form
    {
        //Properties :-
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.eVisionTest;


        //Constructor :-
        public frmShowTestTypeInfo(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }
        private void frmShowTestTypeInfo_Load(object sender, EventArgs e)
        {
            ctrlTestTypeCard1.LoadTestTypeInfo(_TestTypeID);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}