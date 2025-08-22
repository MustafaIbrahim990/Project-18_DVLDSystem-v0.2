using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsApplication
    {
        //Enums :-
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3, ReplaceDamagedDrivingLicense = 4,
            ReplaceDetainedDrivingLicense = 5, NewInternationalDrivingLicense = 6, RetakeTest = 7
        };


        //Properties :-
        public int ApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicantPersonID { get; set; }
        public string FullName
        {
            get { return PersonInfo.FullName; }
        }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsPerson PersonInfo;
        public clsApplicationType ApplicationTypeInfo;
        public clsUser CreatedByUserInfo;


        //Constructor :-
        public clsApplication()
        {
            Mode = enMode.AddNew;
            ApplicationID = -1;
            ApplicationDate = DateTime.Now;
            ApplicantPersonID = -1;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;

            PersonInfo = null;
            ApplicationTypeInfo = null;
            CreatedByUserInfo = null;
        }
        private clsApplication(int ApplicationID, DateTime ApplicationDate, int ApplicantPersonID, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            Mode = enMode.Update;
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
        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }


        //Is Exist By ApplicationID :-
        public static bool IsExist(int ID)
        {
            return clsApplicationData.IsExist(ID);
        }


        //Get Info By ApplicationID :-
        public static clsApplication Find(int ID)
        {
            DateTime ApplicationDate = new DateTime(), LastStatusDate = new DateTime();
            int ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            byte ApplicationStatus = 0;
            float PaidFees = 0;

            if (clsApplicationData.GetInfo(ID, ref ApplicationDate, ref ApplicantPersonID, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ID, ApplicationDate, ApplicantPersonID, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Add New :-
        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationData.AddNew(this.ApplicationDate, this.ApplicantPersonID, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsApplicationData.Update(this.ApplicationID, this.ApplicationDate, this.ApplicantPersonID, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }


        //Save Mode in (Add New && Update) :-
        public virtual bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            Mode = enMode.Update;
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


        //Delete By ApplicationID :-
        public static bool Delete(int ID)
        {
            return clsApplicationData.Delete(ID);
        }
        public virtual bool Delete()
        {
            return clsApplicationData.Delete(this.ApplicationID);
        }


        //Get Active ApplicationID :-
        public static int GetActiveApplicationID(int PersonID, enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        //Dose Person have Active Application :-
        public static bool DoesPersonHaveActiveApplication(int PersonID, enApplicationType ApplicationID)
        {
            return clsApplication.GetActiveApplicationID(PersonID, ApplicationID) != -1;
        }


        //Get Active Application ID For License Class :-
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

       
        //Dose Person Have Active Application For License Class :-
        public static bool DosePersonHaveActiveApplicationForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return (clsApplication.GetActiveApplicationIDForLicenseClass(PersonID, ApplicationTypeID, LicenseClassID) != -1);
        }


        //Cancel Application Status :-
        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Cancelled);
        }


        //Complete Application Status :-
        public bool Complete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Completed);
        }
    }
}