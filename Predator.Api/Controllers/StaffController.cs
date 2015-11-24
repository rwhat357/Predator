using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Predator.Api.Models;
using Predator.Api.Services;

namespace Predator.Api.Controllers
{
    public class StaffController : ApiController
    {
        // GET: api/Staff
        public IEnumerable<Staff> Get()
        {
            return StaffService.RetrieveAllStaff();
        }

        // GET: api/Staff/5
        public Staff Get(int id)
        {
            return StaffService.RetrieveSingleStaff(id);
        }

        // POST: api/Staff
        public void Post([FromBody]Staff value)
        {
            StaffService.CreateStaff(value);
        }

        // PUT: api/Staff/5
        public void Put(int id, [FromBody]Staff value)
        {
            StaffService.UpdateStaff(id, value);
        }

        // DELETE: api/Staff/5
        public void Delete(int id)
        {
            StaffService.DeleteStaff(id);
        }
    }
}
