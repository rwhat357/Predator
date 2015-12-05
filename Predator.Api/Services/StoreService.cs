using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Predator.Api.Models;
using Predator.Api.Providers;

namespace Predator.Api.Services
{
    public class StoreService
    {

        private StoreProvider _storeProvider;

        public StoreService()
        {
            _storeProvider = new StoreProvider();
        }

        internal IEnumerable<Store> GetAll()
        {
            return _storeProvider.GetAll();
        }

        internal string GetStoreById(int id)
        {
            return _storeProvider.GetStoreById(id);
        }
    }
}