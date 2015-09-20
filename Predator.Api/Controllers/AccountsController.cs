using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Predator.Api.Controllers
{
    public class AccountsController : ApiController
    {
        // GET api/accounts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
