using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsCountry
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int CountryID { get; set; }
        public string CountryName { get; set; }


        //Constructor :-
        public clsCountry()
        {
            _Mode = enMode.AddNew;
            CountryID = -1;
            CountryName = "";
        }
        private clsCountry(int ID, string CountryName)
        {
            _Mode = enMode.Update;
            this.CountryID = ID;
            this.CountryName = CountryName;
        }


        //Get All Countries :-
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }


        //Is Country Exist By ID :-
        public static bool IsExist(int ID)
        {
            return clsCountryData.IsExist(ID);
        }


        //Is Country Exist By ID :-
        public static bool IsExist(string CountryName)
        {
            return clsCountryData.IsExist(CountryName);
        }


        //Get Country Info By ID :-
        public static clsCountry Find(int ID)
        {
            string Name = "";

            if (clsCountryData.GetInfo(ID, ref Name))
            {
                return new clsCountry(ID, Name);
            }
            else
            {
                return null;
            }
        }


        //Get Country Info By ID :-
        public static clsCountry Find(string CountryName)
        {
            int ID = -1;

            if (clsCountryData.GetInfo(CountryName, ref ID))
            {
                return new clsCountry(ID, CountryName);
            }
            else
            {
                return null;
            }
        }


        //Add New Country :-
        private bool _AddNew()
        {
            this.CountryID = clsCountryData.AddNew(this.CountryName);
            return (this.CountryID != -1);
        }


        //Update Country :-
        private bool _Update()
        {
            return clsCountryData.Update(this.CountryID, this.CountryName);
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


        //Delete Country By ID :-
        public static bool Delete(int ID)
        {
            return clsCountryData.Delete(ID);
        }


        //Delete Country By Name :-
        public static bool Delete(string CountryName)
        {
            return clsCountryData.Delete(CountryName);
        }
    }
}