using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsTestAppointmentData
    {
        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT TestAppointments.TestAppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked
                           FROM TestAppointments;";

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


        //Get Test Appointmetns Lists :-
        public static DataTable GetTestAppointmentLists(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT TestAppointments.TestAppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked
                           FROM TestAppointments
                           Where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID
                           Order By TestAppointments.IsLocked ASC";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Test Appointmetns Lists :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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


        //Is Exists By ID :-
        public static bool IsExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM TestAppointments
                           WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Person Exist By ID :-
            command.Parameters.AddWithValue("@TestAppointmentID", ID);

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


        //Is Exists By LocalDrivingLicenseApplicationID :-
        public static bool IsExistBy(int LocalDrivingLicenseApplicationID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM TestAppointments
                           WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By LocalDrivingLicenseApplicationID :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

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


        //Is Exists By LocalDrivingLicenseApplicationID AND TestTypeID:-
        public static bool IsExistBy(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM TestAppointments
                           WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID);";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By LocalDrivingLicenseApplicationID AND TestTypeID:-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

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


        //Get Info By ID :-
        public static bool GetInfo(int TestAppointmentID, ref DateTime AppointmentDate, ref int LocalDrivingLicenseApplicationID, ref int TestTypeID, ref float PaidFees, ref bool IsLocked, ref int RetakeTestApplicationID, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments
                           WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By ID :-
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = (reader["RetakeTestApplicationID"] == System.DBNull.Value) ? -1 : (int)reader["RetakeTestApplicationID"];
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


        //Get Info By LocalDrivingLicenseApplicationID AND TestTypeID :-
        public static bool GetInfo(int LocalDrivingLicenseApplicationID, int TestTypeID, ref int TestAppointmentID, ref DateTime AppointmentDate, ref float PaidFees, ref bool IsLocked, ref int RetakeTestApplicationID, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments
                           WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID);";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By LocalDrivingLicenseApplicationID AND TestTypeID :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = (reader["RetakeTestApplicationID"] == System.DBNull.Value) ? -1 : (int)reader["RetakeTestApplicationID"];
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


        //Get Last Test Appointment ID Per Test Type :-
        public static int GetLastTestAppointmentIDPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Top 1 TestAppointments.TestAppointmentID FROM TestAppointments
                           WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                           AND TestAppointments.TestTypeID = @TestTypeID)
                           Order By TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int PassedID))
                {
                    ID = PassedID;
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


        //Get Last Test Appointment Info By (LocalDrivingLicenseApplicationID AND TestTypeID) :-
        public static bool GetLastTestAppointmentInfo(int LocalDrivingLicenseApplicationID, int TestTypeID, ref int TestAppointmentID, ref DateTime AppointmentDate, ref float PaidFees, ref bool IsLocked, ref int RetakeTestApplicationID, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Top 1 * FROM TestAppointments
                           WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID)
                            Order By TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By LocalDrivingLicenseApplicationID AND TestTypeID :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = (reader["RetakeTestApplicationID"] == System.DBNull.Value) ? -1 : (int)reader["RetakeTestApplicationID"];
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
        public static int AddNew(DateTime AppointmentDate, int LocalDrivingLicenseApplicationID, int TestTypeID, float PaidFees, bool IsLocked, int RetakeTestApplicationID, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments
                           (AppointmentDate , LocalDrivingLicenseApplicationID , TestTypeID , PaidFees , IsLocked , RetakeTestApplicationID , CreatedByUserID)
                           VALUES
                           (@AppointmentDate , @LocalDrivingLicenseApplicationID , @TestTypeID , @PaidFees , @IsLocked , @RetakeTestApplicationID , @CreatedByUserID);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }

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
        public static bool Update(int TestAppointmentID, DateTime AppointmentDate, int LocalDrivingLicenseApplicationID, int TestTypeID, float PaidFees, bool IsLocked, int RetakeTestApplicationID, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE TestAppointments
                           SET AppointmentDate = @AppointmentDate , LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID , 
                           TestTypeID = @TestTypeID , PaidFees = @PaidFees , IsLocked = @IsLocked , RetakeTestApplicationID = @RetakeTestApplicationID , CreatedByUserID = @CreatedByUserID
                           Where TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }

            //Update By ID :-
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

            string query = @"DELETE FROM TestAppointments
                           WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete Person By ID :-
            command.Parameters.AddWithValue("@TestAppointmentID", ID);

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


        //Get Active Test Appointment ID :-
        public static int GetActiveTestAppointmentID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Top 1 TestAppointments.TestAppointmentID
                           FROM TestAppointments INNER JOIN LocalDrivingLicenseApplications 
                           ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           Where (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                           AND TestAppointments.TestTypeID = @TestTypeID
                           AND TestAppointments.IsLocked = 0)
                           Order By TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ActiveID))
                {
                    ID = ActiveID;
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
/*
        public static DataTable GetAllTestAppointments()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                 string query = @"select * from TestAppointments_View
                                  order by AppointmentDate Desc";


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
                    // Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return dt;

            }
*/