using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsCountryData
    {
        //Get All Countries :-
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Countries;";
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


        //Is Country Exists By ID :-
        public static bool IsExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Countries
                           WHERE Countries.CountryID = @CountryID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Country Exist By ID :-
            command.Parameters.AddWithValue("@CountryID", ID);

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


        //Is Country Exist By Name :-
        public static bool IsExist(string Name)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Countries
                           WHERE Countries.CountryName = @CountryName;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Country Exist By Name :-
            command.Parameters.AddWithValue("@CountryName", Name);

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


        //Get Country Info By ID :-
        public static bool GetInfo(int ID, ref string Name)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Countries
                           WHERE Countries.CountryID = @CountryID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Country Info By ID :-
            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Name = (string)reader["CountryName"];
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


        //Get Country Info By ID :-
        public static bool GetInfo(string Name, ref int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Countries
                           WHERE Countries.CountryName = @CountryName;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Country Info By ID :-
            command.Parameters.AddWithValue("@CountryName", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["CountryID"];
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


        //Add New Country :-
        public static int AddNew(string Name)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO Countries
                           (CountryName)
                           VALUES
                           (@CountryName)
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", Name);

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


        //Update Country By ID :-
        public static bool Update(int ID, string Name)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE Countries
                           SET CountryName = @CountryName
                           Where Countries.CountryID = @CountryID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", Name);

            //Update Country By ID :-
            command.Parameters.AddWithValue("@CountryID", ID);

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


        //Delete Country By ID :-
        public static bool Delete(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"DELETE FROM Countries
                           WHERE Countries.CountryID = @CountryID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete Country By ID :-
            command.Parameters.AddWithValue("@CountryID", ID);

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


        //Delete Country By Name :-
        public static bool Delete(string Name)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"DELETE FROM Countries
                           WHERE Countries.CountryName = @CountryName;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete Country By Name :-
            command.Parameters.AddWithValue("@CountryName", Name);

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
    }
}