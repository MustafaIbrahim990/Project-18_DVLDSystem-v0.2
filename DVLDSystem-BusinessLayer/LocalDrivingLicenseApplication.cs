using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        //Enums :-
        private enum enMode1 { AddNew = 0, Update = 1 };
        private enMode1 _Mode1;


        //Properties :-
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo;
        public string PersonFullName
        {
            get { return base.PersonInfo.FullName; }
        }


        //Constructor :-
        public clsLocalDrivingLicenseApplication()
        {
            _Mode1 = enMode1.AddNew;
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;

            LicenseClassInfo = null;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, DateTime ApplicationDate, int ApplicantPersonID,
        int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            _Mode1 = enMode1.Update;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            //
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
            return clsLocalDrivingLicenseApplicationData.GetAllInfo();
        }


        //Is Exist By LocalDrivingLicenseApplicationID :-
        public static bool IsExistLocal(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.IsExist(LocalDrivingLicenseApplicationID);
        }


        //Get Info By LocalDrivingLicenseApplicationID :-
        public static clsLocalDrivingLicenseApplication FindLocal(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetInfo(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (!IsFound)
                return null;

            clsApplication ApplicationInfo = clsApplication.Find(ApplicationID);

            return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, ApplicationInfo.ApplicationDate, ApplicationInfo.ApplicantPersonID,
            ApplicationInfo.ApplicationTypeID, ApplicationInfo.ApplicationStatus, ApplicationInfo.LastStatusDate, ApplicationInfo.PaidFees, ApplicationInfo.CreatedByUserID, LicenseClassID);
        }


        //Get Info By ApplicationID :-
        public static clsLocalDrivingLicenseApplication FindLocalBy(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);

            if (!IsFound)
                return null;

            clsApplication ApplicationInfo = clsApplication.Find(ApplicationID);

            return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, ApplicationInfo.ApplicationDate, ApplicationInfo.ApplicantPersonID,
            ApplicationInfo.ApplicationTypeID, ApplicationInfo.ApplicationStatus, ApplicationInfo.LastStatusDate, ApplicationInfo.PaidFees, ApplicationInfo.CreatedByUserID, LicenseClassID);
        }


        //Add New :-
        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNew(this.ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData.Update(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }


        //Save Mode in (Add New && Update) :-
        public override bool Save()
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


        //Delete By LocalDrivingLicenseApplicationID :-
        public override bool Delete()
        {
            if (clsLocalDrivingLicenseApplicationData.Delete(LocalDrivingLicenseApplicationID))
            {
                return base.Delete();
            }
            return false;
        }


        //Dose Attend Test Type By (LocalDrivingLicenseAppliationID AND TestTypeID) :-
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
           return clsTest.DoesAttendTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }


        //Issue Driving License For The First Time :-
        public int IssueDrivingLicneseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver DriverInfo = clsDriver.FindBy(this.ApplicantPersonID);

            if (DriverInfo == null)
            {
                DriverInfo = new clsDriver();

                DriverInfo.PersonID = this.ApplicantPersonID;
                DriverInfo.CreatedDate = DateTime.Now;
                DriverInfo.CreatedByUserID = CreatedByUserID;

                if (DriverInfo.Save())
                {
                    DriverID = DriverInfo.ID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = DriverInfo.ID;
            }

            clsDrivingLicense DrivingLicenseInfo = new clsDrivingLicense();

            DrivingLicenseInfo.ApplicationID = this.ApplicationID;
            DrivingLicenseInfo.DriverID = DriverID;
            DrivingLicenseInfo.LicenseClassID = this.LicenseClassID;
            DrivingLicenseInfo.IssueDate = DateTime.Now;
            DrivingLicenseInfo.ExpriationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            DrivingLicenseInfo.Notes = Notes;
            DrivingLicenseInfo.PaidFees = this.PaidFees;
            DrivingLicenseInfo.IsActive = true;
            DrivingLicenseInfo.IssueReason = clsDrivingLicense.enIssueReason.FirstTime;
            DrivingLicenseInfo.CreatedByUserID = CreatedByUserID;

            if (DrivingLicenseInfo.Save())
            {
                //Now We Should Set The Application Status to Complete.
                this.Complete();
                return DrivingLicenseInfo.ID;
            }
            else
            {
                return -1;
            }
        }


        //Is Local Driving License As a Oridinary Driving License(Class 3) :-
        public static bool IsLocalDrivingLicenseAsOrdinaryDrivingLicense(int LocalLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.IsLocalDrivingLicenseAsOrdinaryDrivingLicense(LocalLicenseApplicationID);
        }
    }
}