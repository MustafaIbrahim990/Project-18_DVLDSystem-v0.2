using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsApplicationType
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3, ReplaceDamagedDrivingLicense = 4,
            ReleaseeDetainedDrivingLicense = 5, NewInternationalDrivingLicense = 6, RetakeTest = 7
        };


        //Properties :-
        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }


        //Constructor :-
        public clsApplicationType()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            Title = "";
            Fees = 0;
        }
        private clsApplicationType(int ID, string Title, float Fees)
        {
            _Mode = enMode.Update;
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }


        //Get All Info :-
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }


        //Is Exists :-
        public static bool IsExist(int ApplicationtypeID)
        {
            return clsApplicationTypeData.IsExist(ApplicationtypeID);
        }


        //Get Application Type Info By ID :-
        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string Title = "";
            float Fees = 0;

            if (clsApplicationTypeData.GetInfo(ApplicationTypeID, ref Title, ref Fees))
            {
                return new clsApplicationType(ApplicationTypeID, Title, Fees);
            }
            else
            {
                return null;
            }
        }


        //Add New User :-
        private bool _AddNew()
        {
            this.ID = clsApplicationTypeData.AddNew(this.Title, this.Fees);
            return (this.ID != -1);
        }


        //Update :-
        private bool _Update()
        {
            return clsApplicationTypeData.Update(this.ID, this.Title, this.Fees);
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


        //Delete User :-
        public static bool Delete(int ID)
        {
            return clsUserData.Delete(ID);
        }
    }
}