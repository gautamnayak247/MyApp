using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLConnect.CoreObjects;
using System.Data.SqlClient;
using System.Data;

namespace HRLConnect.DAL
{
    public class ReferenceDataDAL
    {
        private string connectionString;
        public ReferenceDataDAL(string conn)
        {
            connectionString = conn;
        }
        public bool AddPeople(People p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddPeople";
                command.Connection = connection;

                command.Parameters.AddWithValue("@EnterpriseID", p.EnterpriseId);
                command.Parameters.AddWithValue("@Name", p.Name);
                command.Parameters.AddWithValue("@Mobile", p.Mobile);
                command.Parameters.AddWithValue("@CLFK", p.CLFK);
                command.Parameters.AddWithValue("@EmploymentType", p.EmploymentTypeFK);
                command.Parameters.AddWithValue("@Email", p.Email);
                command.Parameters.AddWithValue("@DUID", p.DuId);
                command.Parameters.AddWithValue("@ProjectID", p.ProjectID);
                command.Parameters.AddWithValue("@IsActive", true); //setting true as while inserting it should be true.
                command.Parameters.AddWithValue("@SupervisorFK", p.SupervisorFK);
                command.Parameters.AddWithValue("@AccentureDOJ", p.AccentureDOJ);
                command.Parameters.AddWithValue("@ProjectDOJ", p.ProjectDOJ);
                command.Parameters.AddWithValue("@CreatedBy", p.CreatedBy);

                connection.Open();

                int rows = command.ExecuteNonQuery();
                if (rows <= 0)
                {
                    return false;
                    //throw new Exception("No records updated");
                }
                return true;
            }
        }

        public List<CareerLevel> GetCareerLevel()
        {
            List<CareerLevel> careerLevelList = new List<CareerLevel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetCareerLevel";
                command.Connection = connection;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    CareerLevel careerLevel = new CareerLevel();
                    careerLevel.CLID = reader["CLID"] != null ? Convert.ToInt32(reader["CLID"]) : 0;
                    careerLevel.CareerLev = Convert.ToString(reader["CL"]);
                    careerLevelList.Add(careerLevel);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return careerLevelList;
        }

        public List<EmploymentType> GetEmploymentType()
        {
            List<EmploymentType> employmentTypeList = new List<EmploymentType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetEmploymentType";
                command.Connection = connection;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    EmploymentType employmentType = new EmploymentType();
                    employmentType.Id = reader["ETPK"] != null ? Convert.ToInt32(reader["ETPK"]) : 0;
                    employmentType.Type = Convert.ToString(reader["ET"]);
                    employmentTypeList.Add(employmentType);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return employmentTypeList;
        }

        public List<Du> GetDu()
        {
            List<Du> duList = new List<Du>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetDUs";
                command.Connection = connection;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    Du du = new Du();
                    du.DuId = reader["DUID"] != null ? Convert.ToInt32(reader["DUID"]) : 0;
                    du.DuName = Convert.ToString(reader["DUName"]);
                    duList.Add(du);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return duList;
        }

        public List<Project> GetProject(int duId)
        {
            List<Project> projectList = new List<Project>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetProjects";
                command.Connection = connection;
                command.Parameters.AddWithValue("@DUID", duId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    Project project = new Project();
                    project.ProjectId = reader["PID"] != null ? Convert.ToInt32(reader["PID"]) : 0;
                    project.ProjectName = Convert.ToString(reader["ProjectName"]);
                    projectList.Add(project);
                }

                // Call Close when done reading.
                reader.Close();

            }

            return projectList;
        }

        public List<People> GetSupervisor(int duId)
        {
            List<People> supervisorList = new List<People>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSupervisors";
                command.Connection = connection;
                command.Parameters.AddWithValue("@DUID", duId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    People supervisor = new People();
                    supervisor.EnterpriseId = Convert.ToString(reader["EnterpriseID"]);
                    supervisor.CareerLevel = Convert.ToString(reader["CareerLevel"]);
                    supervisorList.Add(supervisor);
                }
                // Call Close when done reading.
                reader.Close();
            }
            return supervisorList;
        }

        public bool AddDu(Du du)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddDU";
                command.Connection = connection;

                command.Parameters.AddWithValue("@DUName", du.DuName);
                command.Parameters.AddWithValue("@DULeadEID", du.DuLeadEId);
                command.Parameters.AddWithValue("@DULeadEmail", du.DuLeadEmail);
                connection.Open();

                int rows = command.ExecuteNonQuery();
                if (rows <= 0)
                {
                    throw new Exception("No records updated");
                }
                return true;
            }
        }

        //public List<People> GetAllPeople()
        //{
        //    List<People> peopleList = new List<People>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(connectionString);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "Report_ListActiveUnmappedPeople";
        //        command.Connection = connection;


        //        // Add the parameter to the Parameters collection. 
        //        command.Parameters.Add(parameter);

        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        // Call Read before accessing data.
        //        while (reader.Read())
        //        {
        //            People people = new People();
        //            people.UserId = reader["UserID"] != null ? Convert.ToInt32(reader["UserID"]) : 0;
        //            people.EnterpriseId = Convert.ToString(reader["EnterpriseID"]);
        //            people.Supervisor = Convert.ToString(reader["Supervisor"]);
        //            people.Project = Convert.ToString(reader["Project"]);
        //            people.Du = Convert.ToString(reader["DU"]);
        //            people.CareerLevel = Convert.ToString(reader["CareerLevel"]);
        //            peopleList.Add(people);
        //        }

        //        // Call Close when done reading.
        //        reader.Close();

        //    }

        //    return peopleList;
        //}
    }
}
