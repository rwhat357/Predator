using Predator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Predator.Api.Services;

namespace Predator.Api.Controllers
{
    public class CheckController : ApiController
    {
        // GET api/accounts
        public IEnumerable<Check> Get()
        {
            var results = CheckService.GetAll();

            return results;
        }

        // GET api/accounts/5
        public Check Get(int id)
        {
            return CheckService.GetCheck(id);
        }

        // POST api/accounts
        public Check Post([FromBody]Check check)
        {
            return CheckService.AddCheck(check);
        }

        // PUT api/accounts/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/accounts/5
        public void Delete(int id)
        {
            CheckService.DeleteCheck(id);
        }
    }
}
