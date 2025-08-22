using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsLicenseClass
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }


        //Constructor :-
        public clsLicenseClass()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
        }
        private clsLicenseClass(int ID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            _Mode = enMode.Update;
            this.ID = ID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            return clsLicenseClassData.GetAllInfo();
        }


        //Is Exist By LicenseClassID :-
        public static bool IsExist(int LicenseClassID)
        {
            return clsLicenseClassData.IsExist(LicenseClassID);
        }


        //Get Info By LicenseClassID :-
        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClassData.GetInfo(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }


        //Get Info By ClassName :-
        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClassData.GetInfo(ClassName, ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }


        //Add New :-
        private bool _AddNew()
        {
            this.ID = clsLicenseClassData.AddNew(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.ID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsLicenseClassData.Update(this.ID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
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


        //Delete By LicenseClassID :-
        public static bool Delete(int LicenseClassID)
        {
            return clsLicenseClassData.Delete(LicenseClassID);
        }
    }
}