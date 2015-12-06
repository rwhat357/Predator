using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Predator.Api.Services;
using Predator.Api.Models;

namespace Predator.Api.Controllers
{
    public class StoreController : ApiController
    {

        private StoreService _storeService;

        public StoreController()
        {
            _storeService = new StoreService();
        }

        // GET: api/Store
        public IEnumerable<Store> Get()
        {
            return _storeService.GetAll();
        }

        // GET: api/Store/5
        public string Get(int id)
        {
            return _storeService.GetStoreById(id);
        }

        // POST: api/Store
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Store/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Store/5
        public void Delete(int id)
        {
        }
    }
}
