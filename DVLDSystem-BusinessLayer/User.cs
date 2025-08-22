using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsUser
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo;


        //Constructor :-
        public clsUser()
        {
            _Mode = enMode.AddNew;
            UserID = -1;
            PersonID = -1;
            UserName = "";
            PassWord = "";
            IsActive = true;
            PersonInfo = null;
        }
        private clsUser(int UserID, int PersonID, string UserName, string PassWord, bool IsActive)
        {
            _Mode = enMode.Update;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(PersonID);
        }


        //Get All Users :-
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }


        //Is User Exist By UserID :-
        public static bool IsExist(int UserID)
        {
            return clsUserData.IsExist(UserID);
        }


        //Is User Exist By PersonID :-
        public static bool IsExistByPersonID(int PersonID)
        {
            return clsUserData.IsExist(PersonID);
        }


        //Is User Exist By UserName :-
        public static bool IsExist(string UserName)
        {
            return clsUserData.IsExist(UserName);
        }


        //Is User Exist By UserName AND PassWord :-
        public static bool IsExist(string UserName, string PassWord)
        {
            return clsUserData.IsExist(UserName, PassWord);
        }


        //Get User Info By UserID :-
        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "", PassWord = "";
            bool IsActive = false;


            if (clsUserData.GetInfo(UserID, ref PersonID, ref UserName, ref PassWord, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, PassWord, IsActive);
            }
            else
            {
                return null;
            }
        }


        //Get User Info By PersonID :-
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", PassWord = "";
            bool IsActive = false;


            if (clsUserData.GetInfoByPersonID(PersonID, ref UserID, ref UserName, ref PassWord, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, PassWord, IsActive);
            }
            else
            {
                return null;
            }
        }


        //Get User Info By UserName AND PassWord :-
        public static clsUser Find(string UserName, string PassWord)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;


            if (clsUserData.GetInfo(UserName, PassWord, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, PassWord, IsActive);
            }
            else
            {
                return null;
            }
        }


        //Change PassWord By UserID :-
        public static bool ChangePassWord(int UserID, string NewPassWord)
        {
            return clsUserData.ChangePassWord(UserID, NewPassWord);
        }


        //Add New User :-
        private bool _AddNew()
        {
            this.UserID = clsUserData.AddNew(this.PersonID, this.UserName, this.PassWord, this.IsActive);
            return (this.UserID != -1);
        }


        //Update User :-
        private bool _Update()
        {
            return clsUserData.Update(this.UserID, this.PersonID, this.UserName, this.PassWord, this.IsActive);
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