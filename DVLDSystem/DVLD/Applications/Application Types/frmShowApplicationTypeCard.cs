using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.Applications.Application_Types
{
    public partial class frmShowApplicationTypeCard : Form
    {
        //Properties :-
        private int _ApplicationTypeID = -1;


        //Constructor :-
        public frmShowApplicationTypeCard(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmShowApplicationTypeCard_Load(object sender, EventArgs e)
        {
            ctrlApplicationTypeCard1.LoadApplicationTypeInfo(_ApplicationTypeID);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {

        }
    }
}