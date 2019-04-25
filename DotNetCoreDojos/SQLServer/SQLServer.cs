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


        /// <summary>
        /// The test only works if a redis is available. This can be started with a docker run command:
        /// docker run --name dojoredis -p 6379:6379 -d redis
        /// </summary>
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

        /// <summary>
        /// The test only works if a redis is available. This can be started with a docker run command:
        /// docker run --name dojoredis -p 6379:6379 -d redis
        /// </summary>
        [Test]
        public void ConnectToSqlServerWithUserNameAndPassword()
        {
            List<string> ListOfColumns = new List<string>();

            string connectionString = @"Server=vdmbase_c; Database=MBASEP_C; Integrated Security=false; User Id=SVC-CUUR; Password=pobr#xaZOzeHitafLh1r;";

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

    }
}