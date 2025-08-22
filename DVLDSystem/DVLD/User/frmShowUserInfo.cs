using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSystem.DVLD.User
{
    public partial class frmShowUserInfo : Form
    {
        //Properties :-
        private int _UserID = -1;


        //Constructor :-
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadUserInfo(_UserID);
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}