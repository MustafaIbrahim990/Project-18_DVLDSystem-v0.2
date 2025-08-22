using System;
using System.Data;
using DVLDSystem_DataAccessLayer;

namespace DVLDSystem_BusinessLayer
{
    public class clsPerson
    {
        //Enums :-
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        //Properties :-
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry CountryInfo;


        //Constructor :-
        public clsPerson()
        {
            _Mode = enMode.AddNew;
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = new DateTime();
            Gender = 0;
            NationalityCountryID = -1;
            Phone = "";
            Email = "";
            Address = "";
            ImagePath = "";
            CountryInfo = null;
        }
        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, int NationalityCountryID, string Phone, string Email, string Address, string ImagePath)
        {
            _Mode = enMode.Update;
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.NationalityCountryID = NationalityCountryID;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
        }


        //Get All People :-
        public static DataTable GetAllPeopleForGrid()
        {
            return clsPersonData.GetAllPeopleForGrid();
        }


        //Is Person Exist By PersonID :-
        public static bool IsExist(int PersonID)
        {
            return clsPersonData.IsExist(PersonID);
        }


        //Is Person Exist By NationalNo :-
        public static bool IsExist(string NationalNo)
        {
            return clsPersonData.IsExist(NationalNo);
        }


        //Get Person Info By PersonID :-
        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = new DateTime();
            int NationalityCountryID = -1;
            byte Gender = 0;


            if (clsPersonData.GetInfo(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref NationalityCountryID, ref Phone, ref Email, ref Address, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, NationalityCountryID, Phone, Email, Address, ImagePath);
            }
            else
            {
                return null;
            }
        }


        //Get Person Info By NationalNo :-
        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1, NationalityCountryID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = new DateTime();
            byte Gender = 0;


            if (clsPersonData.GetInfo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref NationalityCountryID, ref Phone, ref Email, ref Address, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, NationalityCountryID, Phone, Email, Address, ImagePath);
            }
            else
            {
                return null;
            }
        }


        //Add New Person :-
        private bool _AddNew()
        {
            this.PersonID = clsPersonData.AddNew(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.NationalityCountryID, this.Phone, this.Email, this.Address, this.ImagePath);
            return (this.PersonID != -1);
        }


        //Update Person :-
        private bool _Update()
        {
            return clsPersonData.Update(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.NationalityCountryID, this.Phone, this.Email, this.Address, this.ImagePath);
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
            return clsPersonData.Delete(ID);
        }
    }
}