using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Predator.Api.Controllers
{
    public class CheckDisplayRowController : ApiController
    {
        // GET: api/CheckDisplayRow
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CheckDisplayRow/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckDisplayRow
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckDisplayRow/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckDisplayRow/5
        public void Delete(int id)
        {
        }
    }
}
