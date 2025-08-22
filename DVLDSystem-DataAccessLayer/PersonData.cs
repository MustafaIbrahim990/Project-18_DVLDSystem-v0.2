using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsPersonData
    {
        //Private Methods :-
        private static bool _IsEmpty(string Text)
        {
            return string.IsNullOrWhiteSpace(Text);
        }

        private static string _GetStringFromReader(SqlDataReader reader, string columnName)
        {
            return (reader[columnName] == System.DBNull.Value) ? "" : (string)reader[columnName];

            //if (reader[columnName] == DBNull.Value)
            //{
            //    return "";
            //}
            //else
            //{
            //    return (string)reader[columnName];
            //}
        }

        private static void _AddParameterWithNullCheck(SqlCommand command, string parameterName, string value)
        {
            if (_IsEmpty(value))
            {
                command.Parameters.AddWithValue(parameterName, System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(parameterName, value);
            }
        }


        //Get All People :-
        public static DataTable GetAllPeopleForGrid()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName,
                           Case 
                           When Gender = 1 Then 'Male'
                           Else 'Female'
                           End AS Gender, 
                           Cast(People.DateOfBirth AS Date) AS DateOfBirth, Countries.CountryName, People.Phone, People.Email, People.Address
                           FROM People INNER JOIN Countries
                           ON People.NationalityCountryID = Countries.CountryID;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }


        //Is Person Exist By ID :-
        public static bool IsExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM People
                           WHERE People.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By ID :-
            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                isExist = (Result != null) ? true : false;
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Is Person Exist By NationalNo :-
        public static bool IsExist(string NationalNo)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM People
                           WHERE People.NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By NationalNo :-
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                isExist = (Result != null) ? true : false;
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Get Person Info By ID :-
        public static bool GetInfo(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref int NationalityCountryID, ref string Phone, ref string Email, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM People
                           WHERE People.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Person Info By ID :-
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    Email = _GetStringFromReader(reader, "Email");
                    ThirdName = _GetStringFromReader(reader, "ThirdName");
                    ImagePath = _GetStringFromReader(reader, "ImagePath");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Get Person Info By NationalNo :-
        public static bool GetInfo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref int NationalityCountryID, ref string Phone, ref string Email, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM People
                           WHERE People.NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Person Info By NationalNo :-
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    Email = _GetStringFromReader(reader, "Email");
                    ThirdName = _GetStringFromReader(reader, "ThirdName");
                    ImagePath = _GetStringFromReader(reader, "ImagePath");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Add New Person :-
        public static int AddNew(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, int NationalityCountryID, string Phone, string Email, string Address, string ImagePath)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO People
                           (NationalNo , FirstName , SecondName , ThirdName , LastName , DateOfBirth , Gender , NationalityCountryID , Phone , Email , Address , ImagePath)
                           VALUES
                           (@NationalNo , @FirstName , @SecondName , @ThirdName , @LastName , @DateOfBirth , @Gender ,@NationalityCountryID , @Phone , @Email , @Address , @ImagePath);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);

            _AddParameterWithNullCheck(command, "@ThirdName", ThirdName);
            _AddParameterWithNullCheck(command, "@Email", Email);
            _AddParameterWithNullCheck(command, "@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }


        //Update Person By ID :-
        public static bool Update(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, int NationalityCountryID, string Phone, string Email, string Address, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE People
                           SET NationalNo = @NationalNo , FirstName = @FirstName , SecondName = @SecondName , ThirdName = @ThirdName , LastName = @LastName ,
                           DateOfBirth = @DateOfBirth , Gender = @Gender , NationalityCountryID = @NationalityCountryID , Phone = @Phone , Email = @Email ,
                           Address = @Address , ImagePath = @ImagePath
                           Where People.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);

            _AddParameterWithNullCheck(command, "@Email", Email);
            _AddParameterWithNullCheck(command, "@ThirdName", ThirdName);
            _AddParameterWithNullCheck(command, "@ImagePath", ImagePath);

            //Update Person By ID :-
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        //Delete Person By ID :-
        public static bool Delete(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"DELETE FROM People
                           WHERE People.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete Person By ID :-
            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
}