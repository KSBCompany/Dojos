using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SQLServer
{
    public class SQLServer
    {
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void ConnectToSqlServerWithIntegratedSecurity()
        {
            List<string> ListOfColumns = new List<string>();

            string connectionString = @"Server=vdmbase_c; Database=MBASEP_C; Integrated Security=True;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'R_2P_E04B'", sqlConnection);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string currentColumn = reader.GetString(0);

                ListOfColumns.Add(currentColumn);
            }

            sqlConnection.Close();
        }


        [Test]
        public void ConnectToSqlServerWithUserNameAndPassword()
        {
            List<string> ListOfColumns = new List<string>();

            string connectionString = @"Server=vdmbase_c; Database=MBASEP_C; Integrated Security=false; User Id=SVC-CUUR; Password=@WSX2wsx;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'R_2P_E04B'", sqlConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string currentColumn = reader.GetString(0);

                ListOfColumns.Add(currentColumn);
            }

            sqlConnection.Close();
        }

    }
}