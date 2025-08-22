using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsUserData
    {
        //Get All Users Info :-
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Users.UserID, Users.PersonID,
                           FullName = People.FirstName + ' ' + People.SecondName + ' ' +  IsNull(People.ThirdName , '') + ' ' + People.LastName,
                           Users.UserName, Users.IsActive
                           FROM Users INNER JOIN People
                           ON Users.PersonID = People.PersonID";
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


        //Is User Exist By UserID :-
        public static bool IsExist(int UserID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Users
                           WHERE Users.UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is User Exist By UserID :-
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Is User Exist By PersonID :-
        public static bool IsExistByPersonID(int PersonID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Users
                           WHERE Users.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is User Exist By PersonID :-
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Is User Exist By UserName :-
        public static bool IsExist(string UserName)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Users
                           WHERE Users.UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is User Exist By UserName :-
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Is User Exist By UserName AND PassWord :-
        public static bool IsExist(string UserName, string PassWord)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Users
                           WHERE Users.UserName = @UserName AND Users.PassWord = @PassWord;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is User Exist By UserName AND PassWord :-
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PassWord", PassWord);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        //Get User Info By UserID :-
        public static bool GetInfo(int UserID, ref int PersonID, ref string UserName, ref string PassWord, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Users
                           WHERE Users.UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get User Info By ID :-
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    PassWord = (string)reader["PassWord"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Get User Info By PersonID :-
        public static bool GetInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string PassWord, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Users
                           WHERE Users.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get User Info By PersonID :-
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    PassWord = (string)reader["PassWord"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Get User Info By UserName AND PassWord :-
        public static bool GetInfo(string UserName, string PassWord, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Users
                           WHERE Users.UserName = @UserName AND Users.PassWord = @PassWord;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get User Info By UserName AND PassWord :-
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PassWord", PassWord);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }


        //Change PassWord By UserID :-
        public static bool ChangePassWord(int UserID, string NewPassWord)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE Users
                           SET PassWord = @PassWord
                           Where Users.UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PassWord", NewPassWord);

            //Change PassWord By UserID :-
            command.Parameters.AddWithValue("@UserID", UserID);

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


        //Add New User :-
        public static int AddNew(int PersonID, string UserName, string PassWord, bool IsActive)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO Users
                           (PersonID , UserName , PassWord , IsActive)
                           VALUES
                           (@PersonID , @UserName , @PassWord , @IsActive);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PassWord", PassWord);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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


        //Update User By UserID :-
        public static bool Update(int UserID, int PersonID, string UserName, string PassWord, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE Users
                           SET PersonID = @PersonID , UserName = @UserName , PassWord = @PassWord , IsActive = @IsActive 
                           Where Users.UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PassWord", PassWord);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            //Update User By ID :-
            command.Parameters.AddWithValue("@UserID", UserID);

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


        //Delete User By UserID :-
        public static bool Delete(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"DELETE FROM Users
                           WHERE Users.UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete User By UserID :-
            command.Parameters.AddWithValue("@UserID", UserID);

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