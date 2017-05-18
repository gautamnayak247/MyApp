using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRLConnect.DAL
{
    public class SqlRepository : IRepository
    {
        private Lazy<ReportDAL> reportDalObj = new Lazy<ReportDAL>(() => new ReportDAL());
        private Lazy<ReferenceDataDAL> referenceDataDalObj = new Lazy<ReferenceDataDAL>(() => new ReferenceDataDAL(connectionString));

        public ReferenceDataDAL ReferenceDataDalObj { get { return referenceDataDalObj.Value; } }
        public ReportDAL ReportDalObj
        {
            get { return reportDalObj.Value; }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["HRLConnectSQLConnection"].ToString();
        public string MyData()
        {
            return "SqlClass";
        }
        public Person GetPersonDetails(string enterpriseId)
        {
            Person person = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetLoggedInUserDetails";
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
                    person = new Person();
                    person.EnterpriseId = Convert.ToString(reader["EnterpriseID"]);
                    person.Name = "Gautam";
                    person.Email = Convert.ToString(reader["UserEmail"]);
                    person.CareerLevel = Convert.ToString(reader["CareerLevel"]);
                }

                // Call Close when done reading.
                reader.Close();

            }
            return person;
        }

        public List<CareerLevel> GetCareerLevelId()
        {
            List<CareerLevel> careerLevelList;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetCareerLevel";
                command.Connection = connection;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                careerLevelList = new List<CareerLevel>();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    CareerLevel career = new CareerLevel();
                    career.CLID = reader["CLID"] != null ? Convert.ToInt32(reader["CLID"]) : 0;
                    career.CareerLev = Convert.ToString(reader["CL"]);
                    careerLevelList.Add(career);
                }

                // Call Close when done reading.
                reader.Close();

            }
            return careerLevelList;
        }

        public List<Du> GetDuNames()
        {
            List<Du> duLists = new List<Du>();

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
                    duLists.Add(du);
                }

                // Call Close when done reading.
                reader.Close();

            }
            return duLists;
        }

        public List<string> GetEnterpriseIds()
        {
            ReportDAL report = new ReportDAL();
            return report.GetEnterpriseIds();
        }


        //Reports section

        #region Reports
        public List<ConnectsIDone> GetConnectsIDone(string enterpriseId)
        {
            return ReportDalObj.GetConnectsIDone(enterpriseId);
        }
        public List<People> GetActiveUnmappedPeople(int duId)
        {
            return ReportDalObj.GetActiveUnmappedPeople(duId);
        }
        public List<People> GetInActivePeople(int duId)
        {
            return ReportDalObj.GetInActivePeople(duId);
        }

        public List<IndividualConnects> GetIndividualConnectsMySpan(string enterpriseId)
        {
            return ReportDalObj.GetIndividualConnectsMySpan(enterpriseId);
        }

        public List<LeadsConnects> GetLeadsConnectsMySpan(string enterpriseId)
        {
            return ReportDalObj.GetLeadsConnectsMySpan(enterpriseId);
        }

        public List<ConnectsIDone> GetMyConnects(string enterpriseId)
        {
            return ReportDalObj.GetMyConnects(enterpriseId);
        }
        #endregion

        //Manage Reference data

        #region ManageReferenceData
        public bool AddPeople(People p)
        {
            return ReferenceDataDalObj.AddPeople(p);
        }

        public List<People> GetAllPeople()
        {
            //return ReferenceDataDalObj.GetAllPeople();
            return null;
        }

        public List<CareerLevel> GetCareerLevel()
        {
            return ReferenceDataDalObj.GetCareerLevel();
        }
        public List<EmploymentType> GetEmploymentType()
        {
            return ReferenceDataDalObj.GetEmploymentType();
        }

        public List<Du> GetDu()
        {
            return ReferenceDataDalObj.GetDu();
        }
        public List<Project> GetProject(int duId)
        {
            return ReferenceDataDalObj.GetProject(duId);
        }

        public List<People> GetSupervisor(int duId)
        {
            return ReferenceDataDalObj.GetSupervisor(duId);
        }

        public bool AddDu(Du du)
        {
            return ReferenceDataDalObj.AddDu(du);
        }

        #endregion
    }
}
