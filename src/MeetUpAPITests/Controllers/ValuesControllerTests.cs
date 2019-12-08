using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetUpAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;

namespace MeetUpAPI.Controllers.Tests
{
    [TestClass()]
    public class ValuesControllerTests
    {
        string connectionStr = @"Data Source=localhost;Initial Catalog=MeetUpDB;User ID=sa;Password=Test@12345";

        [TestMethod()]
        public void GetSpeakersTest()
        {
            using (var conn = new SqlConnection(connectionStr))
            {
                IEnumerable<dynamic> speakers = conn.Query<dynamic>(
                    sql: @"SELECT * FROM [dbo].[speakers]"
                    );

                Assert.IsTrue(speakers.AsList().Count == 2);
            }           
        }

        [TestMethod()]
        public void GetHostsTest()
        {
            using (var conn = new SqlConnection(connectionStr))
            {
                IEnumerable<dynamic> speakers = conn.Query<dynamic>(
                    sql: @"SELECT * FROM [dbo].[hosts]"
                    );

                Assert.IsTrue(speakers.AsList().Count == 1);
            }
        }

        [TestMethod()]
        public void AddHostsTest()
        {
            using (var conn = new SqlConnection(connectionStr))
            {
                string name = "superman";

                IEnumerable<dynamic> speakers = conn.Query<dynamic>(
                    sql: @"INSERT INTO [dbo].[hosts] (fullName) OUTPUT inserted.* VALUES (@name)",
                    param: new { name }
                    );

                Assert.IsTrue(speakers.AsList().Count == 1);
            }
        }
    }
}