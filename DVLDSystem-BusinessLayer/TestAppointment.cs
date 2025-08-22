using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsTestAppointment
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public float PaidFees { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo;
        public clsTestType TestTypeInfo;
        public clsApplication RetakeTestApplicationInfo;
        public clsUser CreatedByUserInfo;


        //Constructor :-
        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            AppointmentDate = new DateTime();
            LocalDrivingLicenseApplicationID = -1;
            TestTypeID = clsTestType.enTestType.eVisionTest;
            PaidFees = -1;
            IsLocked = false;
            CreatedByUserID = -1;
            RetakeTestApplicationID = -1;

            LocalDrivingLicenseApplicationInfo = null;
            TestTypeInfo = null;
            RetakeTestApplicationInfo = null;
            CreatedByUserInfo = null;
        }
        private clsTestAppointment(int TestAppointmentID, DateTime AppointmentDate, int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, float PaidFees, bool IsLocked, int RetakeTestApplicationID, int CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.ID = TestAppointmentID;
            this.AppointmentDate = AppointmentDate;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestTypeID = TestTypeID;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.CreatedByUserID = CreatedByUserID;

            this.LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocal(LocalDrivingLicenseApplicationID);
            this.TestTypeInfo = clsTestType.Find(TestTypeID);
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);

            if (RetakeTestApplicationID != -1)
                this.RetakeTestApplicationInfo = clsApplication.Find(RetakeTestApplicationID);
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            return clsTestAppointmentData.GetAllInfo();
        }

        public static DataTable GetTestAppointmentLists(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetTestAppointmentLists(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Is Exist By TestAppointmentID :-
        public static bool IsExist(int ID)
        {
            return clsTestAppointmentData.IsExist(ID);
        }


        //Is Exist By LocalDrivingLicenseApplicationID AND TestTypeID :-
        public static bool IsExistBy(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.IsExistBy(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Get Info By TestAppointmentID :-
        public static clsTestAppointment Find(int TestAppointmentID)
        {
            DateTime AppointmentDate = new DateTime();
            int LocalDrivingLicenseApplicationID = -1, TestTypeID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            float PaidFees = -1;
            bool IsLocked = false;


            if (clsTestAppointmentData.GetInfo(TestAppointmentID, ref AppointmentDate, ref LocalDrivingLicenseApplicationID, ref TestTypeID, ref PaidFees, ref IsLocked, ref RetakeTestApplicationID, ref CreatedByUserID))
            {
                return new clsTestAppointment(TestAppointmentID, AppointmentDate, LocalDrivingLicenseApplicationID, (clsTestType.enTestType)TestTypeID, PaidFees, IsLocked, RetakeTestApplicationID, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Get Info By LocalDrivingLicenseApplicationID :-
        public static clsTestAppointment FindBy(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = new DateTime();
            float PaidFees = -1;
            bool IsLocked = false;


            if (clsTestAppointmentData.GetInfo(LocalDrivingLicenseApplicationID, (int)TestTypeID, ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref IsLocked, ref RetakeTestApplicationID, ref CreatedByUserID))
            {
                return new clsTestAppointment(TestAppointmentID, AppointmentDate, LocalDrivingLicenseApplicationID, (clsTestType.enTestType)TestTypeID, PaidFees, IsLocked, RetakeTestApplicationID, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Get Info By LocalDrivingLicenseApplicationID :-
        public static clsTestAppointment FindLastTestAppointmentInfo(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = new DateTime();
            float PaidFees = -1;
            bool IsLocked = false;


            if (clsTestAppointmentData.GetLastTestAppointmentInfo(LocalDrivingLicenseApplicationID, (int)TestTypeID, ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref IsLocked, ref RetakeTestApplicationID, ref CreatedByUserID))
            {
                return new clsTestAppointment(TestAppointmentID, AppointmentDate, LocalDrivingLicenseApplicationID, (clsTestType.enTestType)TestTypeID, PaidFees, IsLocked, RetakeTestApplicationID, CreatedByUserID);
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
            this.ID = clsTestAppointmentData.AddNew(this.AppointmentDate, this.LocalDrivingLicenseApplicationID, (int)this.TestTypeID, this.PaidFees, this.IsLocked, this.RetakeTestApplicationID, this.CreatedByUserID);
            return (this.ID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsTestAppointmentData.Update(this.ID, this.AppointmentDate, this.LocalDrivingLicenseApplicationID, (int)this.TestTypeID, this.PaidFees, this.IsLocked, this.RetakeTestApplicationID, this.CreatedByUserID);
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


        //Delete :-
        public static bool Delete(int ID)
        {
            return clsTestAppointmentData.Delete(ID);
        }


        //Get Active Test Appointment ID :-
        public static int GetActiveTestAppointmentID(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetActiveTestAppointmentID(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Dose have Active Test Appointment :-
        public static bool DoesHaveActiveTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointment.GetActiveTestAppointmentID(LocalDrivingLicenseApplicationID, TestTypeID) != -1;
        }


        ////Get Last Test Appointment ID :-
        public static int GetLastTestAppointmentIDPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetLastTestAppointmentIDPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Dose Attend Test Type By (LocalDrivingLicenseAppliationID AND TestTypeID) :-
        public static bool DoesAttendTestTypeAtUpdateMode(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            return clsTest.DoesAttendTestTypeAtUpdateMode(TestAppointmentID, TestTypeID);
        }


        //Dose Pass Test Type :-
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTest.DoesPassTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
    }
}

/*
 
 using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestAppointment
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { set; get; }
        public clsTestType.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestAppInfo { set; get; }

        public int  TestID   
        {
            get { return _GetTestID(); }   
          
        }

        public clsTestAppointment()

        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;  
            Mode = enMode.AddNew;

        }

        public clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, 
           int CreatedByUserID ,bool IsLocked, int RetakeTestApplicationID)

        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID= RetakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            //call DataAccess Layer 

            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int) this.TestTypeID,this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            //call DataAccess Layer 

            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int) this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = 1;  int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;  float PaidFees = 0;  
            int CreatedByUserID = -1; bool IsLocked=false;int RetakeTestApplicationID = -1;

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref  TestTypeID, ref  LocalDrivingLicenseApplicationID,
            ref   AppointmentDate, ref  PaidFees, ref  CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointment(TestAppointmentID,  (clsTestType.enTestType) TestTypeID,  LocalDrivingLicenseApplicationID,
             AppointmentDate,  PaidFees,  CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID )
        {
             int TestAppointmentID=-1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1;bool IsLocked=false;int RetakeTestApplicationID=-1;

            if (clsTestAppointmentData.GetLastTestAppointment( LocalDrivingLicenseApplicationID, (int) TestTypeID,
                ref TestAppointmentID,ref AppointmentDate, ref PaidFees, ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))

                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();

        }

        public  DataTable GetApplicationTestAppointmentsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID,(int) TestTypeID);

        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int) TestTypeID);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestAppointment();

            }

            return false;
        }

        private int  _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }

    }
}
 
 */