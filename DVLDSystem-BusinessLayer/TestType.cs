using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsTestType
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public enum enTestType { eVisionTest = 1, eWrittenTest = 2, eStreetTest = 3 };


        //Properties :-
        public enTestType ID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }


        //Constructor :-
        public clsTestType()
        {
            _Mode = enMode.AddNew;
            ID = enTestType.eVisionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
        }
        private clsTestType(enTestType ID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            _Mode = enMode.Update;
            this.ID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }


        //Get All Info :-
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }


        //Is Exist By PersonID :-
        public static bool IsExist(enTestType ID)
        {
            return clsTestTypeData.IsExist((byte)ID);
        }


        //Get Info By TestTypeID :-
        public static clsTestType Find(enTestType ID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            float TestTypeFees = -1;

            if (clsTestTypeData.GetInfo((byte)ID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestType(ID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }


        //Add New :-
        private bool _AddNew()
        {
            int result = clsTestTypeData.AddNew(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            if (result != -1)
            {
                this.ID = (enTestType)result;
                return true;
            }
            return false;
        }


        //Update :-
        private bool _Update()
        {
            return clsTestTypeData.Update((byte)this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
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


        //Delete By PersonID :-
        public static bool Delete(enTestType ID)
        {
            return clsTestTypeData.Delete((byte)ID);
        }
    }
}