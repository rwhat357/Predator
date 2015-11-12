using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Models;

namespace Predator.Api.Providers
{
    class TestCheckProvider
    {
        public List<Check> GetAll()
        {
            //return set sample data
            return new List<Check>();
        }

        public Check GetCheck(int id)
        {
            return null;
        }

        public Check AddCheck(Check check)
        {
            return null;
        }

        public void DeleteCheck(int id)
        {
            return;
        }
    }
}
