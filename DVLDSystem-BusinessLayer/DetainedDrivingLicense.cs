using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsDetainedDrivingLicense
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int ID { get; set; }
        public DateTime DetainDate { get; set; }
        public int DrivingLicenseID { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public clsDrivingLicense DrivingLicenseInfo;
        public clsUser CreatedByUserInfo;
        public clsUser ReleasedByUserInfo;
        public clsApplication ReleaseApplicationInfo;


        //Constructor :-
        public clsDetainedDrivingLicense()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            DetainDate = new DateTime();
            DrivingLicenseID = -1;
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = new DateTime();
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            DrivingLicenseInfo = new clsDrivingLicense();
            CreatedByUserInfo = new clsUser();
            ReleasedByUserInfo = new clsUser();
            ReleaseApplicationInfo = new clsApplication();
        }
        private clsDetainedDrivingLicense(int DetainID, DateTime DetainDate, int DrivingLicenseID, float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            _Mode = enMode.Update;
            this.ID = DetainID;
            this.DetainDate = DetainDate;
            this.DrivingLicenseID = DrivingLicenseID;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            this.DrivingLicenseInfo = clsDrivingLicense.Find(DrivingLicenseID);
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            this.ReleasedByUserInfo = clsUser.Find(ReleasedByUserID);
            this.ReleaseApplicationInfo = clsApplication.Find(ReleaseApplicationID);
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            return clsDetainedDrivingLicenseData.GetAllInfo();
        }


        //Get All Custom Info :-
        public static DataTable GetAllCustomInfo()
        {
            return clsDetainedDrivingLicenseData.GetAllCustomInfo();
        }


        //Is Exist By DetainID :-
        public static bool IsExist(int DetainID)
        {
            return clsDetainedDrivingLicenseData.IsExist(DetainID);
        }


        //Is Exist By DrivingLicenseID :-
        public static bool IsExistBy(int DrivingLicenseID)
        {
            return clsDetainedDrivingLicenseData.IsExistBy(DrivingLicenseID);
        }


        //Get Info By DetainID :-
        public static clsDetainedDrivingLicense Find(int DetainID)
        {
            int DrivingLicenseID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1, CreatedByUserID = -1;
            DateTime ReleaseDate = new DateTime();
            DateTime DetainDate = new DateTime();
            float FineFees = -1;
            bool IsReleased = false;


            if (clsDetainedDrivingLicenseData.GetInfo(DetainID, ref DetainDate, ref DrivingLicenseID, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedDrivingLicense(DetainID, DetainDate, DrivingLicenseID, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;
            }
        }


        //Get Info By DrivingLicenseID :-
        public static clsDetainedDrivingLicense FindBy(int DrivingLicenseID)
        {
            int DetainID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1, CreatedByUserID = -1;
            DateTime ReleaseDate = new DateTime();
            DateTime DetainDate = new DateTime();
            float FineFees = -1;
            bool IsReleased = false;


            if (clsDetainedDrivingLicenseData.GetInfoBy(DrivingLicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedDrivingLicense(DetainID, DetainDate, DrivingLicenseID, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;
            }
        }


        //Add New :-
        private bool _AddNew()
        {
            //int PersonID = -1;
            this.ID = clsDetainedDrivingLicenseData.AddNew(this.DetainDate, this.DrivingLicenseID, this.FineFees, this.CreatedByUserID);
            return (this.ID != -1);
        }


        //Update Person :-
        private bool _Update()
        {
            return clsDetainedDrivingLicenseData.Update(this.ID, this.DetainDate, this.DrivingLicenseID, this.FineFees, this.CreatedByUserID);
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


        //Delete Person :-
        public static bool Delete(int ID)
        {
            return clsDetainedDrivingLicenseData.Delete(ID);
        }


        //Is Detained Driving License :-
        public static bool IsReleasedDrivingLicenseBy(int DrivingLicenseID)
        {
            return clsDetainedDrivingLicenseData.IsReleasedBy(DrivingLicenseID);
        }

        public static bool IsReleasedDrivingLicense(int DetainID)
        {
            return clsDetainedDrivingLicenseData.IsReleased(DetainID);
        }


        //Is Detained Driving License :-
        public static bool IsDetainedDrivingLicense(int DrivingLicenseID)
        {
            return clsDetainedDrivingLicenseData.IsDetained(DrivingLicenseID);
        }


        //Reease Detained License :-
        public bool ReleaseDetainedLicense(int DrivingLicenseID, int ReleasedByUserID)
        {
            clsApplication NewApplicationInfo = new clsApplication();

            //Application Info :-
            NewApplicationInfo.ApplicationDate = DateTime.Now;
            NewApplicationInfo.ApplicantPersonID = this.DrivingLicenseInfo.ApplicationInfo.ApplicantPersonID; 
            NewApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            NewApplicationInfo.LastStatusDate = DateTime.Now;
            NewApplicationInfo.ApplicationTypeID = (int)clsApplicationType.enApplicationType.ReleaseeDetainedDrivingLicense;

            NewApplicationInfo.PaidFees = clsApplicationType.Find(NewApplicationInfo.ApplicationTypeID).Fees;
            NewApplicationInfo.CreatedByUserID = CreatedByUserID;

            if (!NewApplicationInfo.Save())
            {
                return false;
            }

            //Release Detained License :-
            return clsDetainedDrivingLicenseData.ReleaseDeatinedLicense(this.DrivingLicenseID, ReleasedByUserID, NewApplicationInfo.ApplicationID);
        }
    }
}