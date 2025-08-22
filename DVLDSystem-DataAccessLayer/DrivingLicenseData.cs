using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDSystem_DataAccessLayer
{
    public static class clsDrivingLicenseData
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

            string query = @"SELECT * FROM DrivingLicenses;";
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

            string query = @"SELECT Result = 'Yes' FROM DrivingLicenses
                           WHERE DrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Person Exist By ID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", ID);

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


        //Is Exist By PersonID AND LicenseClassID :-
        public static bool IsExist(int PersonID, int LicenseClassID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes'
                           FROM DrivingLicenses INNER JOIN Applications
                           ON DrivingLicenses.ApplicationID = Applications.ApplicationID
                           Where Applications.ApplicantPersonID = @ApplicantPersonID AND DrivingLicenses.LicenseClassID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Is Exist By PersonID :-
            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
        public static bool GetInfo(int DrivingLicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpriationDate, ref bool IsActive, ref byte IssueReason, ref string Notes, ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT * FROM DrivingLicenses
                           WHERE DrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Info By ID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpriationDate = (DateTime)reader["ExpriationDate"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
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


        //Get All Driving Licenses For Driver By DriverID :-
        public static DataTable GetDrivingLicensesForDriver(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT DrivingLicenses.DrivingLicenseID, DrivingLicenses.ApplicationID, LicenseClasses.ClassName,
                           DrivingLicenses.IssueDate, DrivingLicenses.ExpriationDate, DrivingLicenses.IsActive
                           FROM DrivingLicenses INNER JOIN LicenseClasses
                           ON DrivingLicenses.LicenseClassID = LicenseClasses.LicenseClassID
                           WHERE DrivingLicenses.DriverID = @DriverID
                           Order By DrivingLicenses.IsActive DESC, ExpriationDate DESC;";

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


        //Add New :-
        public static int AddNew(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpriationDate, bool IsActive, byte IssueReason, string Notes, float PaidFees, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"INSERT INTO DrivingLicenses
                           (ApplicationID , DriverID , LicenseClassID , IssueDate , ExpriationDate , IsActive , IssueReason , Notes , PaidFees , CreatedByUserID)
                           VALUES
                           (@ApplicationID , @DriverID , @LicenseClassID , @IssueDate , @ExpriationDate , @IsActive , @IssueReason ,@Notes , @PaidFees , @CreatedByUserID);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpriationDate", ExpriationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
        public static bool Update(int DrivingLicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpriationDate, bool IsActive, byte IssueReason, string Notes, float PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"UPDATE DrivingLicenses
                           SET ApplicationID = @ApplicationID , DriverID = @DriverID , LicenseClassID = @LicenseClassID , IssueDate = @IssueDate , ExpriationDate = @ExpriationDate ,
                           IsActive = @IsActive , IssueReason = @IssueReason , Notes = @Notes , PaidFees = @PaidFees , CreatedByUserID = @CreatedByUserID
                           Where DrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpriationDate", ExpriationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            _AddParameterWithNullCheck(command, "@Notes", Notes);

            //Update By ID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);

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

            string query = @"DELETE FROM DrivingLicenses
                           WHERE DrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Delete By ID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", ID);

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


        //Get Active Driving License ID :-
        public static int GetActiveDrivingLicenseID(int PersonID, int LicenseClassID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT DrivingLicenses.DrivingLicenseID
                           FROM DrivingLicenses
                           INNER JOIN Drivers 
                           ON DrivingLicenses.DriverID = Drivers.DriverID
                           WHERE ((DrivingLicenses.IsActive = 1 AND DrivingLicenses.LicenseClassID = @LicenseClassID) AND (Drivers.PersonID = @PersonID AND GetDate() Between IssueDate and ExpriationDate));";

            /*
             SELECT DrivingLicenses.DrivingLicenseID
             FROM DrivingLicenses
             INNER JOIN Drivers 
             ON DrivingLicenses.DriverID = Drivers.DriverID
             WHERE DrivingLicenses.IsActive = 1 AND DrivingLicenses.LicenseClassID = 3 AND Drivers.PersonID = 1 AND GetDate() Between IssueDate and ExpriationDate
             */

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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


        //Get Driving License ID By LocalDrivingLicenseApplicationID :-
        public static int GetDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT DrivingLicenses.DrivingLicenseID FROM DrivingLicenses 
                           INNER JOIN Applications 
                           ON DrivingLicenses.ApplicationID = Applications.ApplicationID
                           INNER JOIN LocalDrivingLicenseApplications
                           ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                           Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Get Driving License ID By LocalDrivingLicenseApplicationID :-
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int drivingLicenseID))
                {
                    ID = drivingLicenseID;
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


        //Deactivate Local Driving License :-
        public static bool DeactivateLocalDrivingLicense(int LocalDrivingLicenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"Update DrivingLicenses
                           SET DrivingLicenses.IsActive = 0
                           Where DrivingLicenses.DrivingLicenseID = @DrivingLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            //Deactivate Local Driving License By LocalDrivingLicenseID :-
            command.Parameters.AddWithValue("@DrivingLicenseID", LocalDrivingLicenseID);

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


        //Does Person Have Active Driving License :-
        public static bool DoesPersonHaveActiveDrivingLicense(int PersonID, int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString);

            string query = @"SELECT Result = 'Yes'
                           FROM DrivingLicenses
                           INNER JOIN Drivers 
                           ON DrivingLicenses.DriverID = Drivers.DriverID
                           WHERE DrivingLicenses.LicenseClassID = @LicenseClassID AND Drivers.PersonID = @PersonID AND GetDate() Between IssueDate and ExpriationDate AND IsActive = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            //Does Person Have Active Driving License :-
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
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
    }
}