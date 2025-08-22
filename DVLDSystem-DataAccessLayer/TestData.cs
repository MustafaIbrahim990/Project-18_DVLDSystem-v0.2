using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsTestData
    {
        //Private Methods :-
        private static bool _IsEmpty(string Text)
        {
            return string.IsNullOrWhiteSpace(Text);
        }

        private static string _GetStringFromReader(SqlDataReader reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
            {
                return "";
            }
            else
            {
                return (string)reader[columnName];
            }
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


        //Get All Info :-
        public static DataTable GetAllInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Tests;";
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


        //Is Exists By ID :-
        public static bool IsExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Tests
                           WHERE Tests.TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Person Exist By ID :-
            command.Parameters.AddWithValue("@TestID", ID);

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


        //Is Exists By ID :-
        public static bool IsExistBy(int TestAppointmentID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM Tests
                           WHERE Tests.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By TestAppointmentID :-
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
        public static bool GetInfo(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Tests
                           WHERE Tests.TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By ID :-
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    Notes = _GetStringFromReader(reader, "Notes");
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


        //Get Info By TestAppointmentID :-
        public static bool GetInfoBy(int TestAppointmentID, ref int TestID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM Tests
                           WHERE Tests.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By TestAppointmentID :-
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    Notes = _GetStringFromReader(reader, "Notes");
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


        //Get TestID By TestAppointmentID :-
        public static int GetTestID(int TestAppointmentID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Tests.TestID FROM Tests
                           WHERE Tests.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get TestID By TestAppointmentID :-
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ID = id;
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


        //Add New :-
        public static int AddNew(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO Tests
                           (TestAppointmentID , TestResult , Notes , CreatedByUserID)
                           VALUES
                           (@TestAppointmentID , @TestResult , @Notes , @CreatedByUserID);

                           UPDATE TestAppointments
                           SET TestAppointments.IsLocked = 1 
						   WHERE (TestAppointments.TestAppointmentID = @TestAppointmentID)

                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            _AddParameterWithNullCheck(command, "@Notes", Notes);

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
        public static bool Update(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE Tests
                           SET TestAppointmentID = @TestAppointmentID , TestResult = @TestResult , 
                           Notes = @Notes , CreatedByUserID = @CreatedByUserID
                           Where Tests.TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            _AddParameterWithNullCheck(command, "@Notes", Notes);

            //Update By ID :-
            command.Parameters.AddWithValue("@TestID", TestID);

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

            string query = @"DELETE FROM Tests
                           WHERE Tests.TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete Person By ID :-
            command.Parameters.AddWithValue("@TestID", ID);

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


        //Dose Pass Test Type By (LocalDrivingLicenseAppliationID AND TestTypeID) :-
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Top 1 Tests.TestResult
                           FROM TestAppointments INNER JOIN
                           Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID INNER JOIN
                           LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID
                           Order By TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool TestResult))
                {
                    Result = TestResult;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Result;
        }


        //Dose Attend Test Type By (LocalDrivingLicenseAppliationID AND TestTypeID) :-
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Top 1 Result = 'Yes'
                           FROM TestAppointments INNER JOIN
                           Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID INNER JOIN
                           LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID
                           Order By TestAppointments.TestAppointmentID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
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


        //Dose Attend Test Type By (TestAppointmentID AND TestTypeID) :-
        public static bool DoesAttendTestTypeAtUpdateMode(int TestAppointmentID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes' FROM TestAppointments
                           WHERE (TestAppointments.TestAppointmentID = @TestAppointmentID AND TestAppointments.TestTypeID = @TestTypeID);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
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


        //Total Trial Per Test Type By (LocalDrivingLicenseApplicationID AND TestTypeID) :-
        public static byte GetTotalTrailPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrial = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT COUNT(*) AS TotalTrialPerTestType FROM Tests 
                           INNER JOIN TestAppointments
                           ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                           INNER JOIN LocalDrivingLicenseApplications
                           ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID);";

            SqlCommand command = new SqlCommand(query, connection);

            //Total Trial Per Test Type By (LocalDrivingLicenseApplicationID AND TestTypeID) :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte NumberOfTrial))
                {
                    TotalTrial = NumberOfTrial;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return TotalTrial;
        }


        ////Get Fail Count By LocalDrivingLicenseApplicationID AND TestTypeID :-
        public static byte GetFailCountPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte failcount = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT COUNT(*) AS FailCount FROM Tests 
                           INNER JOIN TestAppointments
                           ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                           INNER JOIN LocalDrivingLicenseApplications
                           ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           WHERE (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID AND Tests.TestResult = 0);";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Fail Count By LocalDrivingLicenseApplicationID AND TestTypeID :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte NumberOfFail))
                {
                    failcount = NumberOfFail;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return failcount;
        }


        //Get Passed Tests :-
        public static byte GetPassTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications_View.PassedTestCount FROM LocalDrivingLicenseApplications_View
                           WHERE LocalDrivingLicenseApplications_View.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte passTestCount))
                {
                    PassTestCount = passTestCount;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PassTestCount;
        }
    }
}
/*
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
            (int PersonID,int LicenseClassID,int TestTypeID, ref int TestID,
              ref int TestAppointmentID, ref bool TestResult,
              ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
*/