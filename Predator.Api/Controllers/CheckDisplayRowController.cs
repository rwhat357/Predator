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
    public class CheckDisplayRowController : ApiController
    {
        // GET: api/CheckDisplayRow
        public IEnumerable<CheckDisplayRow> Get()
        {
            return CheckDisplayRowService.RetrieveAllCheckDisplayRows();
        }

        // GET: api/CheckDisplayRow/5
        public CheckDisplayRow Get(int id)
        {
            return CheckDisplayRowService.RetrieveSingleCheckDisplayRow(id);
        }

        // POST: api/CheckDisplayRow
        public void Post([FromBody]string value)
        {
            CheckDisplayRowService.CreateCheckDisplayRow(value);
        }

        // PUT: api/CheckDisplayRow/5
        public void Put(int id, [FromBody]string value)
        {
            CheckDisplayRowService.UpdateCheckDisplayRow(id, value);
        }

        // DELETE: api/CheckDisplayRow/5
        public void Delete(int id)
        {
            CheckDisplayRowService.DeleteCheckDisplayRow(id);
        }
    }
}
