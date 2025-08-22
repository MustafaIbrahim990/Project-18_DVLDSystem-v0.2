using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsTest
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int ID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTestAppointment TestAppointmentInfo;
        public clsUser CreatedByUserInfo;


        //Constructor :-
        public clsTest()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;

            TestAppointmentInfo = null;
            CreatedByUserInfo = null;
        }
        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.ID = TestID;
            this.ID = TestID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            CreatedByUserInfo = clsUser.Find(CreatedByUserID);
        }


        //Get All People :-
        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllInfo();
        }


        //Is Test Exist By TestID :-
        public static bool IsExist(int ID)
        {
            return clsTestData.IsExist(ID);
        }


        //Is Test Exist By TestAppointmentID :-
        public static bool IsExistBy(int TestAppointmentID)
        {
            return clsTestData.IsExistBy(TestAppointmentID);
        }


        //Does Taked Test Before :-
        public static bool DoesTakedTestBefore(int TestAppointmentID)
        {
            return clsTestData.IsExistBy(TestAppointmentID);
        }


        //Get Test Info By TestID :-
        public static clsTest Find(int ID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            if (clsTestData.GetInfo(ID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(ID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Get Test Info By TestAppointmentID :-
        public static clsTest FindBy(int TestAppointmentID)
        {
            int TestID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            if (clsTestData.GetInfoBy(TestAppointmentID, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Add New :-
        private bool _AddNew()
        {
            this.ID = clsTestData.AddNew(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.ID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsTestData.Update(this.ID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
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
            return clsTestData.Delete(ID);
        }


        //Get Passed Test Count :-
        public static byte GetPassTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassTestCount(LocalDrivingLicenseApplicationID);
        }


        //Does Passed All Tests :-
        public static bool DoesPassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassTestCount(LocalDrivingLicenseApplicationID) == 3;
        }


        //Get Last Test Pass :-
        public static clsTestType.enTestType GetLastTestPass(int LocalDrivingLicenseApplicationID)
        {
            switch (clsTestData.GetPassTestCount(LocalDrivingLicenseApplicationID))
            {
                case 0:
                    return clsTestType.enTestType.eVisionTest;

                case 1:
                    return clsTestType.enTestType.eWrittenTest;

                case 2:
                    return clsTestType.enTestType.eStreetTest;

                default:
                    return clsTestType.enTestType.eVisionTest;
            }
        }


        //Get Fail Count By LocalDrivingLicenseApplicationID AND TestTypeID :-
        public static byte GetFailCountPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestData.GetFailCountPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Dose Pass Test Type :-
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Dose Attend Test Type By (LocalDrivingLicenseAppliationID AND TestTypeID) :-
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Dose Attend Test Type By (LocalDrivingLicenseAppliationID AND TestTypeID) :-
        public static bool DoesAttendTestTypeAtUpdateMode(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            return clsTestData.DoesAttendTestTypeAtUpdateMode(TestAppointmentID, (int)TestTypeID);
        }


        //Total Trial Per Test Type By (LocalDrivingLicenseApplicationID AND TestTypeID) :-
        public static byte GetTotalTrailPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestData.GetTotalTrailPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //Get TestID By TestAppointmentID :-
        public static int GetTestID(int TestAppointmentID)
        {
            return clsTestData.GetTestID(TestAppointmentID);
        }
    }
}
/*
        public static clsTest FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID,LicenseClassID,(int) TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

*/