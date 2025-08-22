using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsInternationalDrivingLicenseData
    {
        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalDrivingLicenses;";
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


        //Get All International Driving License Lists :-
        public static DataTable GetAllInternationalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT InternationalDrivingLicenses.InternationalDrivingLicenseID,
                           InternationalDrivingLicenses.ApplicationID, InternationalDrivingLicenses.DriverID, InternationalDrivingLicenses.IssuedUsingDrivingLicenseID,
                           InternationalDrivingLicenses.IssueDate, InternationalDrivingLicenses.ExpriationDate, InternationalDrivingLicenses.IsActive
                           FROM InternationalDrivingLicenses;";
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


        //Is Exist By ID :-
        public static bool IsExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM InternationalDrivingLicenses
                           WHERE InternationalDrivingLicenses.InternationalDrivingLicenseID = @InternationalDrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Person Exist By ID :-
            command.Parameters.AddWithValue("@InternationalDrivingLicenseID", ID);

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


        //Dose Have Active International License By ID :-
        public static bool DoesHaveActiveInternationalLicense(int LocalDrivingLicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT IsFound = 'Yes' FROM InternationalDrivingLicenses
                           Where 
                           (InternationalDrivingLicenses.IssuedUsingDrivingLicenseID = @IssuedUsingDrivingLicenseID
                           AND InternationalDrivingLicenses.IsActive = 1
                           AND GetDate() Between InternationalDrivingLicenses.IssueDate and InternationalDrivingLicenses.ExpriationDate
                           );";

            SqlCommand command = new SqlCommand(query, connection);

            //Dose Have Active Local License By ID :-
            command.Parameters.AddWithValue("@IssuedUsingDrivingLicenseID", LocalDrivingLicenseID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                isFound = (Result == null) ? false : true;
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


        //Get Info By ID :-
        public static bool GetInfo(int InternationalDrivingLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingDrivingLicenseID, ref DateTime IssueDate, ref DateTime ExpriationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalDrivingLicenses
                           WHERE InternationalDrivingLicenses.InternationalDrivingLicenseID = @InternationalDrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By ID :-
            command.Parameters.AddWithValue("@InternationalDrivingLicenseID", InternationalDrivingLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingDrivingLicenseID = (int)reader["IssuedUsingDrivingLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpriationDate = (DateTime)reader["ExpriationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        //Get Info By DriverID :-
        public static bool GetInfoBy(int DriverID, ref int InternationalDrivingLicenseID, ref int ApplicationID, ref int IssuedUsingDrivingLicenseID, ref DateTime IssueDate, ref DateTime ExpriationDate, ref bool IsActive, ref int CreatedByUserID) 
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalDrivingLicenses
                           WHERE InternationalDrivingLicenses.DriverID = @DriverID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By DriverID :-
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InternationalDrivingLicenseID = (int)reader["InternationalDrivingLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    IssuedUsingDrivingLicenseID = (int)reader["IssuedUsingDrivingLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpriationDate = (DateTime)reader["ExpriationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        //Get Info By LocalLicenseID :-
        public static bool GetInfoByLocalLicenseID(int IssuedUsingDrivingLicenseID, ref int InternationalDrivingLicenseID, ref int ApplicationID, ref int DriverID, ref DateTime IssueDate, ref DateTime ExpriationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalDrivingLicenses
                           WHERE InternationalDrivingLicenses.IssuedUsingDrivingLicenseID = @IssuedUsingDrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By IssuedUsingDrivingLicenseID :-
            command.Parameters.AddWithValue("@IssuedUsingDrivingLicenseID", IssuedUsingDrivingLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InternationalDrivingLicenseID = (int)reader["InternationalDrivingLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpriationDate = (DateTime)reader["ExpriationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        //Add New :-
        public static int AddNew(int ApplicationID, int DriverID, int IssuedUsingDrivingLicenseID, DateTime IssueDate, DateTime ExpriationDate, bool IsActive, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"
                           Update InternationalDrivingLicenses
                           SET InternationalDrivingLicenses.IsActive = 0
                           WHere InternationalDrivingLicenses.DriverID = @DriverID;

                           INSERT INTO InternationalDrivingLicenses
                           (ApplicationID , DriverID , IssuedUsingDrivingLicenseID , IssueDate , ExpriationDate , IsActive , CreatedByUserID)
                           VALUES
                           (@ApplicationID , @DriverID , @IssuedUsingDrivingLicenseID , @IssueDate , @ExpriationDate , @IsActive , @CreatedByUserID);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingDrivingLicenseID", IssuedUsingDrivingLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpriationDate", ExpriationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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


        //Update By ID :-
        public static bool Update(int InternationalDrivingLicenseID, int ApplicationID, int DriverID, int IssuedUsingDrivingLicenseID, DateTime IssueDate, DateTime ExpriationDate, bool IsActive, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE InternationalDrivingLicenses
                           SET ApplicationID = @ApplicationID , DriverID = @DriverID , IssuedUsingDrivingLicenseID = @IssuedUsingDrivingLicenseID , IssueDate = @IssueDate , 
                           ExpriationDate = @ExpriationDate , IsActive = @IsActive , CreatedByUserID = @CreatedByUserID
                           Where InternationalDrivingLicenses.InternationalDrivingLicenseID = @InternationalDrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingDrivingLicenseID", IssuedUsingDrivingLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpriationDate", ExpriationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            //Update By ID :-
            command.Parameters.AddWithValue("@InternationalDrivingLicenseID", InternationalDrivingLicenseID);

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


        //Delete By ID :-
        public static bool Delete(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"DELETE FROM InternationalDrivingLicenses
                           WHERE InternationalDrivingLicenses.InternationalDrivingLicenseID = @InternationalDrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete By ID :-
            command.Parameters.AddWithValue("@InternationalDrivingLicenseID", ID);

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


        //Get All Driving Licenses For Driver By DriverID :-
        public static DataTable GetDrivingLicensesForDriver(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT InternationalDrivingLicenses.InternationalDrivingLicenseID AS [Internation L. ID], InternationalDrivingLicenses.ApplicationID AS ApplicationID, 
                           InternationalDrivingLicenses.IssuedUsingDrivingLicenseID AS [Local L. ID], InternationalDrivingLicenses.IssueDate AS IssueDate,
                           InternationalDrivingLicenses.ExpriationDate AS ExpriationDate, InternationalDrivingLicenses.IsActive AS IsActive
                           FROM InternationalDrivingLicenses
                           Where InternationalDrivingLicenses.DriverID = @DriverID
                           Order By InternationalDrivingLicenses.IsActive DESC, ExpriationDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By DriverID :-
            command.Parameters.AddWithValue("@DriverID", DriverID);

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


        //Get Active International License ID DriverID :-
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Top 1 InternationalDrivingLicenses.InternationalDrivingLicenseID FROM InternationalDrivingLicenses 
                           Where InternationalDrivingLicenses.DriverID = @DriverID
                           AND
                           GetDate() between IssueDate and ExpriationDate 
                           Order By InternationalDrivingLicenses.ExpriationDate Desc;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Active International License ID DriverID :-
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
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
    }
}