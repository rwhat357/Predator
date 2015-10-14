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
            var checkProvider = new CheckProvider();
            var results = checkProvider.GetAll();

            return results;
        }

        // GET api/accounts/5
        public Check Get(int id)
        {
            var checkProvider = new CheckProvider();
            return checkProvider.GetCheck(id);
        }

        // POST api/accounts
        public Check Post([FromBody]Check check)
        {
            var checkProvider = new CheckProvider();
            return checkProvider.AddCheck(check);
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
