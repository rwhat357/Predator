using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Predator.Api.Controllers
{
    public class StaffController : ApiController
    {
        // GET: api/Staff
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Staff/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Staff
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Staff/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Staff/5
        public void Delete(int id)
        {
        }
    }
}
