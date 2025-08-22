using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsInternationalDrivingLicense : clsApplication
    {
        //Enums :-
        private enum enMode1 { AddNew = 0, Update = 1 };
        private enMode1 _Mode1;


        //Properties :-
        public int InternationalDrivingLicenseID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingDrivingLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpriationDate { get; set; }
        public bool IsActive { get; set; }
        public clsDriver DriverInfo;
        public clsDrivingLicense IssuedUsingLocalDrivingLicenseInfo;
        

        //Constructor :-
        public clsInternationalDrivingLicense()
        {
            _Mode1 = enMode1.AddNew;
            InternationalDrivingLicenseID = -1;
            DriverID = -1;
            IssuedUsingDrivingLicenseID = -1;
            IssueDate = new DateTime();
            ExpriationDate = new DateTime();
            IsActive = false;
            DriverInfo = null;
            IssuedUsingLocalDrivingLicenseInfo = null;

            //

            this.ApplicationID = -1;
            this.ApplicationDate = new DateTime();
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = clsApplication.enApplicationStatus.New;
            this.LastStatusDate = new DateTime();
            this.PaidFees = -1;
            this.CreatedByUserID = -1;

            this.PersonInfo = null;
            this.ApplicationTypeInfo = null;
            this.CreatedByUserInfo = null;
        }
        private clsInternationalDrivingLicense(int ApplicationID, DateTime ApplicationDate, int ApplicantPersonID, int ApplicationTypeID, enApplicationStatus ApplicationStatus,
        DateTime LastStatusDate, float PaidFees, int InternationalDrivingLicenseID, int DriverID, int IssuedUsingDrivingLicenseID, DateTime IssueDate, DateTime ExpriationDate, 
        bool IsActive, int CreatedByUserID)
        {
            _Mode1 = enMode1.Update;
            this.InternationalDrivingLicenseID = InternationalDrivingLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingDrivingLicenseID = IssuedUsingDrivingLicenseID;
            this.IssueDate = IssueDate;
            this.ExpriationDate = ExpriationDate;

            this.DriverInfo = clsDriver.Find(DriverID);
            this.IssuedUsingLocalDrivingLicenseInfo = clsDrivingLicense.Find(IssuedUsingDrivingLicenseID);
            this.IsActive = IsActive;

            //Base Class :-

            this.ApplicationID = ApplicationID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            return clsInternationalDrivingLicenseData.GetAllInfo();
        }


        //Get All International Driving License Lists :-
        public static DataTable GetAllInternationalDrivingLicenseApplications()
        {
            return clsInternationalDrivingLicenseData.GetAllInternationalDrivingLicenseApplications();
        }


        //Does Have Active International License By ID :-
        public static bool IsInternationalLicenseExist(int ID)
        {
            return clsInternationalDrivingLicenseData.IsExist(ID);
        }


        //Is Exist By ID :-
        public static bool DoesHaveActiveInternationalLicense(int LocalDrivingLicenseID)
        {
            return clsInternationalDrivingLicenseData.DoesHaveActiveInternationalLicense(LocalDrivingLicenseID);
        }


        //Get Info By ID :-
        public static clsInternationalDrivingLicense FindInternationalID(int InternationalDrivingLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingDrivingLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = new DateTime(), ExpriationDate = new DateTime();
            bool IsActive = false;

            bool IsFound = clsInternationalDrivingLicenseData.GetInfo(InternationalDrivingLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingDrivingLicenseID, ref IssueDate, ref ExpriationDate, ref IsActive, ref CreatedByUserID);

            if (!IsFound)
                return null;

            clsApplication ApplicationInfo = clsApplication.Find(ApplicationID);

            return new clsInternationalDrivingLicense(ApplicationID, ApplicationInfo.ApplicationDate, ApplicationInfo.ApplicantPersonID, ApplicationInfo.ApplicationTypeID,
            ApplicationInfo.ApplicationStatus, ApplicationInfo.LastStatusDate, ApplicationInfo.PaidFees, InternationalDrivingLicenseID, DriverID, IssuedUsingDrivingLicenseID,
            IssueDate, ExpriationDate, IsActive, CreatedByUserID);
        }


        //Get Info By DriverID :-
        public static clsInternationalDrivingLicense FindByDriverID(int DriverID)
        {
            int InternationalDrivingLicenseID = -1, ApplicationID = -1, IssuedUsingDrivingLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = new DateTime(), ExpriationDate = new DateTime();
            bool IsActive = false;


            bool IsFound = clsInternationalDrivingLicenseData.GetInfoBy(DriverID, ref InternationalDrivingLicenseID, ref ApplicationID, ref IssuedUsingDrivingLicenseID, ref IssueDate, ref ExpriationDate, ref IsActive, ref CreatedByUserID);

            if (!IsFound)
                return null;

            clsApplication ApplicationInfo = clsApplication.Find(ApplicationID);

            return new clsInternationalDrivingLicense(ApplicationID, ApplicationInfo.ApplicationDate, ApplicationInfo.ApplicantPersonID, ApplicationInfo.ApplicationTypeID,
            ApplicationInfo.ApplicationStatus, ApplicationInfo.LastStatusDate, ApplicationInfo.PaidFees, InternationalDrivingLicenseID, DriverID, IssuedUsingDrivingLicenseID,
            IssueDate, ExpriationDate, IsActive, CreatedByUserID);
        }


        //Get Info By LocalLicenseID :-
        public static clsInternationalDrivingLicense FindByLocalLicenseID(int LocalLicenseID)
        {
            int InternationalDrivingLicenseID = -1, ApplicationID = -1, DriverID = -1, CreatedByUserID = -1;
            DateTime IssueDate = new DateTime(), ExpriationDate = new DateTime();
            bool IsActive = false;


            bool IsFound = clsInternationalDrivingLicenseData.GetInfoByLocalLicenseID(LocalLicenseID, ref InternationalDrivingLicenseID, ref ApplicationID, ref DriverID, ref IssueDate, ref ExpriationDate, ref IsActive, ref CreatedByUserID);

            if (!IsFound)
                return null;

            clsApplication ApplicationInfo = clsApplication.Find(ApplicationID);

            return new clsInternationalDrivingLicense(ApplicationID, ApplicationInfo.ApplicationDate, ApplicationInfo.ApplicantPersonID, ApplicationInfo.ApplicationTypeID,
            ApplicationInfo.ApplicationStatus, ApplicationInfo.LastStatusDate, ApplicationInfo.PaidFees, InternationalDrivingLicenseID, DriverID, LocalLicenseID,
            IssueDate, ExpriationDate, IsActive, CreatedByUserID);
        }


        //Add New :-
        private bool _AddNew()
        {
            //int ID = -1;
            this.InternationalDrivingLicenseID = clsInternationalDrivingLicenseData.AddNew(this.ApplicationID, this.DriverID, this.IssuedUsingDrivingLicenseID, this.IssueDate, this.ExpriationDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalDrivingLicenseID != -1);
        }


        //Update Person :-
        private bool _Update()
        {
            return clsInternationalDrivingLicenseData.Update(this.InternationalDrivingLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingDrivingLicenseID, this.IssueDate, this.ExpriationDate, this.IsActive, this.CreatedByUserID);
        }


        //Save Mode in (Add New && Update) :-//
        public bool SaveInternational()
        {
            base.Mode = (clsApplication.enMode)_Mode1;

            if (!base.Save())
                return false;

            switch (_Mode1)
            {
                case enMode1.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode1 = enMode1.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode1.Update:
                    {
                        return _Update();
                    }
                default:
                    {
                        return false;
                    }
            }
        }


        //Delete :-
        public bool DeleteInternational(int ID)
        {
            //return clsInternationalDrivingLicenseData.Delete(ID);
            return false;
        }


        //Get All Driving Licenses For Driver By DriverID :-
        public static DataTable GetDrivingLicensesForDriver(int DriverID)
        {
            return clsInternationalDrivingLicenseData.GetDrivingLicensesForDriver(DriverID);
        }


        //Issue International Driving License :-
        public int IssueInternationalDrivingLicense(int LocalDrivingLicenseID, int CreatedByUserID)
        {
            clsInternationalDrivingLicense InternationalDrivingLicenseInfo = new clsInternationalDrivingLicense();

            //Application Info :-
            InternationalDrivingLicenseInfo.ApplicationDate = DateTime.Now;
            InternationalDrivingLicenseInfo.ApplicantPersonID = clsDrivingLicense.Find(LocalDrivingLicenseID).ApplicationInfo.ApplicantPersonID;
            InternationalDrivingLicenseInfo.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalDrivingLicense;
            InternationalDrivingLicenseInfo.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalDrivingLicenseInfo.LastStatusDate = DateTime.Now;
            InternationalDrivingLicenseInfo.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalDrivingLicense).Fees;
            InternationalDrivingLicenseInfo.CreatedByUserID = CreatedByUserID;

            //International Driving License Info :-
            InternationalDrivingLicenseInfo.ApplicationID = this.ApplicationID;
            InternationalDrivingLicenseInfo.DriverID = clsDrivingLicense.Find(LocalDrivingLicenseID).DriverID;
            InternationalDrivingLicenseInfo.IssuedUsingDrivingLicenseID = LocalDrivingLicenseID;
            InternationalDrivingLicenseInfo.IssueDate = DateTime.Now;
            InternationalDrivingLicenseInfo.ExpriationDate = DateTime.Now.AddYears(1);
            InternationalDrivingLicenseInfo.IsActive = true;
            InternationalDrivingLicenseInfo.CreatedByUserID = CreatedByUserID;

            if (InternationalDrivingLicenseInfo.SaveInternational())
            {
                return InternationalDrivingLicenseInfo.InternationalDrivingLicenseID;
            }
            else
            {
                return -1;
            }
        }


        //Get Active International License ID DriverID :-
        public static int GetActiveInternationalLicenseID(int DriverID)
        {
            return clsInternationalDrivingLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }
    }
}