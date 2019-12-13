using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace MeetUpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string connectionStr;

        public ValuesController()
        {
            var conStr = Settings.GetConnectionString("meetupDb");
            connectionStr = conStr ?? @"Data Source=localhost;Initial Catalog=MeetUpDB;User ID=sa;Password=Test@12345";
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get()
        {          

            using (var conn = new SqlConnection(connectionStr)) 
            {
                IEnumerable<dynamic> hosts = await conn.QueryAsync<dynamic>(
                    sql: @"SELECT * FROM [dbo].[hosts]"
                    );

                return Ok(hosts);
            }

             //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get(int id)
        {
            return Ok(await getSpeakersByMeetUpId(id));
        }

        public async Task<IEnumerable<dynamic>> getSpeakersByMeetUpId(int id)
        {
            using (var conn = new SqlConnection(connectionStr))
            {
                IEnumerable<dynamic> speakers = await conn.QueryAsync<dynamic>(
                    sql: @"SELECT * FROM [dbo].[speakers] WHERE [meetupId] = @id",
                    param: new { id }
                    );

                return speakers;
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<dynamic>>> getStatic() 
        {
            return Ok(new string[] { "Hello", "bratislava", connectionStr });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
