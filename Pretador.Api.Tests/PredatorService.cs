using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretador.Api.Tests
{
    public class PredatorService
    {
        public bool Create()
        {
            return true;
        }

        public bool Retrieve()
        {
            return true;
        }

        public bool Update()
        {
            return true;
        }

        public bool Delete()
        {
            return true;
        }
    }




    public class CheckService: PredatorService
    {

    }

    public class StaffService : PredatorService
    {

    }

    public class StoreService : PredatorService
    {

    }

    public class StoreGroupService : PredatorService
    {

    }
}
