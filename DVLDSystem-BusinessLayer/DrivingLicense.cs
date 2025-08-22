using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsDrivingLicense
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForLost = 3, ReplacementForDamaged = 4 };

        //Properties :-
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpriationDate { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get { return GetIssueReasonTest(this.IssueReason); }
        }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }


        public clsApplication ApplicationInfo;
        public clsDriver DriverInfo;
        public clsLicenseClass LicenseClassInfo;
        public clsUser CreatedByUserInfo;

        //
        public bool IsDetained
        {
            get { return clsDetainedDrivingLicense.IsDetainedDrivingLicense(this.ID); }
        }


        //Constructor :-
        public clsDrivingLicense()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpriationDate = DateTime.Now;
            IsActive = true;
            IssueReason = enIssueReason.FirstTime;
            Notes = "";
            PaidFees = -1;
            CreatedByUserID = -1;

            ApplicationInfo = null;
            DriverInfo = null;
            LicenseClassInfo = null;
            CreatedByUserInfo = null;

            //DetainedDrivingLicenseInfo = null;
        }
        private clsDrivingLicense(int DrivingLicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpriationDate, bool IsActive, enIssueReason IssueReason, string Notes, float PaidFees, int CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.ID = DrivingLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpriationDate = ExpriationDate;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            ApplicationInfo = clsApplication.Find(ApplicationID);
            DriverInfo = clsDriver.Find(DriverID);
            LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            CreatedByUserInfo = clsUser.Find(CreatedByUserID);

            //DetainedDrivingLicenseInfo = clsDetainedDrivingLicense.FindBy(DrivingLicenseID);
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            return clsDrivingLicenseData.GetAllInfo();
        }


        //Is Exist By DrivingLicenseID :-
        public static bool IsExist(int ID)
        {
            return clsDrivingLicenseData.IsExist(ID);
        }


        //Is Exist By PersonID AND LicenseClassID :-
        public static bool IsExist(int PersonID, int LicenseClassID)
        {
            return clsDrivingLicenseData.IsExist(PersonID, LicenseClassID);
        }


        //Get Info By DrivingLicenseID :-
        public static clsDrivingLicense Find(int ID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpriationDate = DateTime.Now;
            byte IssueReason = 0;
            string Notes = "";
            float PaidFees = -1;
            bool IsActive = false;


            if (clsDrivingLicenseData.GetInfo(ID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpriationDate, ref IsActive, ref IssueReason, ref Notes, ref PaidFees, ref CreatedByUserID))
            {
                return new clsDrivingLicense(ID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpriationDate, IsActive, (enIssueReason)IssueReason, Notes, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Get All Driving Licenses For Driver By DriverID :-
        public static DataTable GetDrivingLicensesForDriver(int DriverID)
        {
            return clsDrivingLicenseData.GetDrivingLicensesForDriver(DriverID);
        }


        //Add New :-
        private bool _AddNew()
        {
            //int PersonID = -1;
            this.ID = clsDrivingLicenseData.AddNew(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpriationDate, this.IsActive, (byte)this.IssueReason, this.Notes, this.PaidFees, this.CreatedByUserID);
            return (this.ID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsDrivingLicenseData.Update(this.ID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpriationDate, this.IsActive, (byte)this.IssueReason, this.Notes, this.PaidFees, this.CreatedByUserID);
        }


        //Save Mode in (Add New && Update) :-
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _Update();
                    }
                default:
                    {
                        return false;
                    }
            }
        }


        //Delete By DrivingLicenseID:-
        public static bool Delete(int ID)
        {
            return clsDrivingLicenseData.Delete(ID);
        }


        //Get Issue Reason Test :-
        public static string GetIssueReasonTest(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";

                case enIssueReason.Renew:
                    return "Renew";

                case enIssueReason.ReplacementForLost:
                    return "Replacement For a Lost";

                case enIssueReason.ReplacementForDamaged:
                    return "Replacement For a Damaged";

                default:
                    return "First Time";
            }
        }


        //Get Active Driving License ID :-
        public static int GetActiveDrivingLicenseID(int PersonID, int LicenseClassID)
        {
            return clsDrivingLicenseData.GetActiveDrivingLicenseID(PersonID, LicenseClassID);
        }


        //Does Person Have Active Driving License :-
        public static bool DoesPersonHaveActiveDrivingLicnese(int PersonID, int LicenseClassID)
        {
            return clsDrivingLicense.GetActiveDrivingLicenseID(PersonID, LicenseClassID) != -1;
        }


        //Is Driving License Active :-
        public bool IsDrivingLicenseActive()
        {
            return DateTime.Now < this.ExpriationDate;
        }


        //Is Driving License Expire :-
        public bool IsDrivingLicenseExpired()
        {
            //return this.ExpriationDate < DateTime.Now;
            return !IsDrivingLicenseActive();
        }


        //Problem
        ////Dose Person Have a Driving License By PersonID AND LicenseClassID :-
        public static bool DosePersonHaveDrivingLicense(int PersonID, int LicenseClassID)
        {
            return clsDrivingLicense.IsExist(PersonID, LicenseClassID);
        }


        //Does Person Have Active Driving License :-
        public static bool DoesPersonHaveActiveDrivingLicense(int PersonID, int LicenseClassID)
        {
            return clsDrivingLicenseData.DoesPersonHaveActiveDrivingLicense(PersonID, LicenseClassID);
        }


        //Is Local Driving License Expired :-
        public bool IsLicenseExpired()
        {
            return this.ExpriationDate < DateTime.Now;
        }


        ////Get Driving License ID By LocalDrivingLicenseApplicationID :-
        public static int GetDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {
            return clsDrivingLicenseData.GetDrivingLicenseID(LocalDrivingLicenseApplicationID);
        }


        //Deactivate Current Local Driving License :-
        public bool DeactivateCurrentLocalLicense()
        {
            return clsDrivingLicenseData.DeactivateLocalDrivingLicense(this.ID);
        }


        //Renew Local Driving License Application :-
        public int RenewLocalDrivingLicenseApplication(string Notes, int CreatedByUserID)
        {
            clsApplication NewApplicationInfo = new clsApplication();

            //Application Info :-
            NewApplicationInfo.ApplicationDate = DateTime.Now;
            NewApplicationInfo.ApplicantPersonID = this.ApplicationInfo.ApplicantPersonID;
            NewApplicationInfo.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            NewApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            NewApplicationInfo.LastStatusDate = DateTime.Now;
            NewApplicationInfo.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            NewApplicationInfo.CreatedByUserID = CreatedByUserID;

            if (!NewApplicationInfo.Save())
            {
                return -1;
            }
            clsDrivingLicense NewLocalDrivingLicenseInfo = new clsDrivingLicense();

            //ReNew Local Driving License Info :-
            NewLocalDrivingLicenseInfo.ApplicationID = NewApplicationInfo.ApplicationID;
            NewLocalDrivingLicenseInfo.DriverID = this.DriverID;
            NewLocalDrivingLicenseInfo.LicenseClassID = this.LicenseClassID;
            NewLocalDrivingLicenseInfo.IssueDate = DateTime.Now;
            NewLocalDrivingLicenseInfo.ExpriationDate = DateTime.Now.AddYears(clsLicenseClass.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).DefaultValidityLength);
            NewLocalDrivingLicenseInfo.IsActive = true;
            NewLocalDrivingLicenseInfo.IssueReason = clsDrivingLicense.enIssueReason.Renew;
            NewLocalDrivingLicenseInfo.Notes = Notes;
            NewLocalDrivingLicenseInfo.PaidFees = clsLicenseClass.Find(this.LicenseClassID).ClassFees;
            NewLocalDrivingLicenseInfo.CreatedByUserID = CreatedByUserID;

            if (!NewLocalDrivingLicenseInfo.Save())
            {
                return -1;
            }

            DeactivateCurrentLocalLicense();
            return NewLocalDrivingLicenseInfo.ID;
        }


        //Renew Local Driving License Application :-
        public int ReplacementLicenseForDamagedOrLost(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplication NewApplicationInfo = new clsApplication();
            
            //Application Info :-
            NewApplicationInfo.ApplicationDate = DateTime.Now;
            NewApplicationInfo.ApplicantPersonID = this.ApplicationInfo.ApplicantPersonID;
            NewApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            NewApplicationInfo.LastStatusDate = DateTime.Now;

            NewApplicationInfo.ApplicationTypeID = (IssueReason == enIssueReason.ReplacementForDamaged) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            NewApplicationInfo.PaidFees = clsApplicationType.Find(NewApplicationInfo.ApplicationTypeID).Fees;
            NewApplicationInfo.CreatedByUserID = CreatedByUserID;

            if (!NewApplicationInfo.Save())
            {
                return -1;
            }

            clsDrivingLicense NewLocalDrivingLicenseInfo = new clsDrivingLicense();

            //Replacement Local Driving License Info :-
            NewLocalDrivingLicenseInfo.ApplicationID = NewApplicationInfo.ApplicationID;
            NewLocalDrivingLicenseInfo.DriverID = this.DriverID;
            NewLocalDrivingLicenseInfo.LicenseClassID = this.LicenseClassID;
            NewLocalDrivingLicenseInfo.IssueDate = DateTime.Now;
            NewLocalDrivingLicenseInfo.IsActive = true;
            NewLocalDrivingLicenseInfo.Notes = this.Notes;
            NewLocalDrivingLicenseInfo.PaidFees = 0;    // No Fees For The License because it's a Replacement.
            NewLocalDrivingLicenseInfo.CreatedByUserID = CreatedByUserID;
            NewLocalDrivingLicenseInfo.IssueReason = IssueReason;
            NewLocalDrivingLicenseInfo.ExpriationDate = this.ExpriationDate;

            if (!NewLocalDrivingLicenseInfo.Save())
            {
                return -1;
            }

            DeactivateCurrentLocalLicense();
            return NewLocalDrivingLicenseInfo.ID;
        }


        //Detain License :-
        public int DetainLicense(float FineFees, int CreatedByUserID)
        {
            clsDetainedDrivingLicense DetainLicenseInfo = new clsDetainedDrivingLicense();

            //Detain License Info :-
            DetainLicenseInfo.DetainDate = DateTime.Now;
            DetainLicenseInfo.DrivingLicenseID = this.ID;
            DetainLicenseInfo.FineFees = FineFees;
            DetainLicenseInfo.CreatedByUserID = CreatedByUserID;

            if (!DetainLicenseInfo.Save())
            {
                return -1;
            }

            return DetainLicenseInfo.ID;
        }        
    }
}