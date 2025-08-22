using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsDriver
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int ID { get; set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        public clsPerson PersonInfo;
        public clsUser CreatedByUserInfo;

        //Constructor :-
        public clsDriver()
        {
            _Mode = enMode.AddNew;
            ID = -1;
            PersonID = -1;
            CreatedDate = new DateTime();
            CreatedByUserID = -1;
            PersonInfo = null;
            CreatedByUserInfo = null;
        }
        private clsDriver(int ID, int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.ID = ID;
            this.PersonID = PersonID;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
        }


        //Get All Drivers :-
        public static DataTable GetAllInfo()
        {
            return clsDriverData.GetAllInfo();
        }


        //Get All Drivers_View :-
        public static DataTable GetAllDriversView()
        {
            return clsDriverData.GetAllDriversView();
        }


        //Is Exist By DriverID :-
        public static bool IsExist(int ID)
        {
            return clsDriverData.IsExist(ID);
        }


        //Is Exist By PersonID :-
        public static bool IsExistBy(int PersonID)
        {
            return clsDriverData.IsExistBy(PersonID);
        }


        //Is Person A Driver :-
        public static bool IsPersonDriver(int PersonID)
        {
            return IsExistBy(PersonID);
        }


        //Get Info By DriverID :-
        public static clsDriver Find(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = new DateTime();


            if (clsDriverData.GetInfo(DriverID, ref PersonID, ref CreatedDate, ref CreatedByUserID))
            {
                return new clsDriver(DriverID, PersonID, CreatedDate, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        //Get Info By PersonID :-
        public static clsDriver FindBy(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = new DateTime();


            if (clsDriverData.GetInfoBy(PersonID, ref DriverID, ref CreatedDate, ref CreatedByUserID))
            {
                return new clsDriver(DriverID, PersonID, CreatedDate, CreatedByUserID);
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
            this.ID = clsDriverData.AddNew(this.PersonID, this.CreatedByUserID);
            return (this.ID != -1);
        }


        //Update User :-
        private bool _Update()
        {
            return clsDriverData.Update(this.ID, this.PersonID, this.CreatedDate, this.CreatedByUserID);
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
            return clsDriverData.Delete(ID);
        }
    }
}