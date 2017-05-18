using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HRLConnect.DAL
{
    public class ReportDAL
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["HRLConnectSQLConnection"].ToString();
        public List<People> GetActiveUnmappedPeople(int duId)
        {
            List<People> peopleList = new List<People>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Report_ListActiveUnmappedPeople";
                command.Connection = connection;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@SelectedDUID";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = duId;

                // Add the parameter to the Parameters collection. 
                command.Parameters.Add(parameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    People people = new People();
                    people.UserId = reader["UserID"] != null ? Convert.ToInt32(reader["UserID"]) : 0;
                    people.EnterpriseId = Convert.ToString(reader["EnterpriseID"]);
                    people.Supervisor = Convert.ToString(reader["Supervisor"]);
                    people.Project = Convert.ToString(reader["Project"]);
                    people.Du = Convert.ToString(reader["DU"]);
                    people.CareerLevel = Convert.ToString(reader["CareerLevel"]);
                    peopleList.Add(people);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return peopleList;
        }
        public List<string> GetEnterpriseIds()
        {
            List<string> people = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.Text;
                command.CommandText = "select EnterpriseID from People ";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Name = Convert.ToString(reader["EnterpriseID"]);
                    people.Add(Name);
                }
                reader.Close();

            }
            return people;
        }


        //Not Working
        public List<IndividualConnects> GetIndividualConnectsMySpan(string enterpriseId)
        {
            List<IndividualConnects> individualConnectsList = new List<IndividualConnects>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Report_ListIndividualConnects_mySpan";
                command.Connection = connection;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@EnterpriseID";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = enterpriseId;

                // Add the parameter to the Parameters collection. 
                command.Parameters.Add(parameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    IndividualConnects individual = new IndividualConnects();

                    individual.EnterpriseId = Convert.ToString(reader["EnterpriseID"]);
                    individual.CareerLevel = Convert.ToString(reader["CareerLevel"]);
                    individual.Supervisor = Convert.ToString(reader["Supervisor"]);

                    individual.Q1 = null != reader["Q1 (Sep-Nov)"] ? Convert.ToInt32(reader["Q1 (Sep-Nov)"]) : 0;
                    individual.Q2 = null != reader["Q2 (Dec-Feb)"] ? Convert.ToInt32(reader["Q2 (Dec-Feb)"]) : 0;
                    individual.Q3 = null != reader["Q3 (Mar-May)"] ? Convert.ToInt32(reader["Q3 (Mar-May)"]) : 0;
                    individual.Q4 = null != reader["Q4 (Jun-Aug)"] ? Convert.ToInt32(reader["Q4 (Jun-Aug)"]) : 0;

                    individualConnectsList.Add(individual);
                }

                // Call Close when done reading.
                reader.Close();

            }
            return individualConnectsList;
        }

        public List<People> GetInActivePeople(int duId)
        {
            List<People> inActivePeopleList = new List<People>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Report_ListInactivePeople";
                command.Connection = connection;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@SelectedDUID";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = duId;

                // Add the parameter to the Parameters collection. 
                command.Parameters.Add(parameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    People people = new People();
                    people.UserId = GetReaderIntValue(reader, "UserID");
                    people.EnterpriseId = GetReaderStringValue(reader, "EnterpriseID");
                    people.CareerLevel = GetReaderStringValue(reader, "CareerLevel");
                    people.Supervisor = GetReaderStringValue(reader, "Supervisor");
                    people.Project = GetReaderStringValue(reader, "Project");
                    people.Du = GetReaderStringValue(reader, "DU");
                    inActivePeopleList.Add(people);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return inActivePeopleList;
        }

        public List<ConnectsIDone> GetMyConnects(string enterpriseId)
        {
            List<ConnectsIDone> connectIDoneList = new List<ConnectsIDone>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Report_ListMyConnects";
                command.Connection = connection;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@EnterpriseID";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = enterpriseId;
                command.Parameters.Add(parameter);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ConnectsIDone connect = new ConnectsIDone();
                    connect.ConnectId = GetReaderIntValue(reader, "ConnectID");
                    connect.MonthOfConnect = GetReaderStringValue(reader, "Month of Connect");
                    connect.EnterpriseId = GetReaderStringValue(reader, "Enterprise ID");
                    connect.ProjectName = GetReaderStringValue(reader, "Project Name");
                    connect.Supervisor = GetReaderStringValue(reader, "Supervisor");
                    connect.DateOfConnect = GetReaderDateValue(reader, "Date of Connect");
                    connect.ConnectStatus = GetReaderStringValue(reader, "Connect Status");
                    connect.StatusId = GetReaderIntValue(reader, "StatusID");
                    connect.UiLink = GetReaderStringValue(reader, "UILink");
                    connectIDoneList.Add(connect);
                }
                reader.Close();

            }
            return connectIDoneList;
        }
        public List<LeadsConnects> GetLeadsConnectsMySpan(string enterpriseId)
        {
            List<LeadsConnects> leadsConnectsList = new List<LeadsConnects>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Report_ListLeadsConnects_mySpan";
                command.Connection = connection;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@EnterpriseID";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = enterpriseId;
                command.Parameters.Add(parameter);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LeadsConnects connect = new LeadsConnects();
                    connect.SupervisorEID = GetReaderStringValue(reader, "SupervisorEID");
                    connect.Q1DirectReportee = GetReaderNullableIntValue(reader, "Q1 (Sep-Nov) - Direct Reportee");
                    connect.Q1NoOfConnectsDone = GetReaderNullableIntValue(reader, "Q1 (Sep-Nov) - # of ConnectsDone");
                    connect.Q2DirectReportee = GetReaderNullableIntValue(reader, "Q2 (Dec-Feb) - Direct Reportee");
                    connect.Q2NoOfConnectsDone = GetReaderNullableIntValue(reader, "Q2 (Dec-Feb) - # of ConnectsDone");
                    connect.Q3DirectReportee = GetReaderNullableIntValue(reader, "Q3 (Mar-May) - Direct Reportee");
                    connect.Q3NoOfConnectsDone = GetReaderNullableIntValue(reader, "Q3 (Mar-May) - # of ConnectsDone");
                    connect.Q4DirectReportee = GetReaderNullableIntValue(reader, "Q4 (Jun-Aug) - Direct Reportee");
                    connect.Q4NoOfConnectsDone = GetReaderNullableIntValue(reader, "Q4 (Jun-Aug) - # of ConnectsDone");
                    leadsConnectsList.Add(connect);
                }
                reader.Close();

            }
            return leadsConnectsList;
        }
        public List<ConnectsIDone> GetConnectsIDone(string enterpriseId)
        {
            List<ConnectsIDone> connectsList = new List<ConnectsIDone>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Report_ListConnectsIDone";
                command.Connection = connection;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@EnterpriseID";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = enterpriseId;

                // Add the parameter to the Parameters collection. 
                command.Parameters.Add(parameter);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    ConnectsIDone connect = new ConnectsIDone();
                    connect.ConnectId = GetReaderIntValue(reader, "ConnectID");
                    connect.MonthOfConnect = GetReaderStringValue(reader, "Month Of Connect");
                    connect.EnterpriseId = GetReaderStringValue(reader, "Enterprise ID");
                    connect.ProjectName = GetReaderStringValue(reader, "Project Name");
                    connect.Supervisor = GetReaderStringValue(reader, "Supervisor");
                    connect.DateOfConnect = GetReaderDateValue(reader, "Date Of Connect");
                    connect.ConnectStatus = GetReaderStringValue(reader, "Connect Status");
                    connect.StatusId = GetReaderIntValue(reader, "StatusID");
                    connect.UiLink = GetReaderStringValue(reader, "UILink");
                    connectsList.Add(connect);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return connectsList;
        }
        private int? GetReaderNullableIntValue(SqlDataReader reader, string columnName)
        {
            int? value = null;

            if (reader[columnName] != DBNull.Value)
                value = (int)reader[columnName];

            return value;
        }
        private int GetReaderIntValue(SqlDataReader dr, string ColumnName)
        {
            int value = 0;

            if (dr[ColumnName] != DBNull.Value)
                value = (int)dr[ColumnName];

            return value;
        }
        private string GetReaderStringValue(SqlDataReader reader, string ColumnName)
        {
            string value = Convert.ToString(reader[ColumnName]);
            return value;
        }
        private DateTime GetReaderDateValue(SqlDataReader reader, string ColumnName)
        {
            DateTime date = reader[ColumnName] != null ? Convert.ToDateTime(reader[ColumnName]) : DateTime.MinValue;
            return date;
        }
    }
}

