using Predator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Predator.Api.Providers;

namespace Predator.Api.Controllers
{
    public class CheckController : ApiController
    {
        // GET api/accounts
        public IEnumerable<Check> Get()
        {
            var checks = new CheckProvider();
            var results = checks.Retrieve();

            return results;
        }

        // GET api/accounts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/accounts
        public void Post([FromBody]string value)
        {
        }

        // PUT api/accounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/accounts/5
        public void Delete(int id)
        {
        }
    }
}
