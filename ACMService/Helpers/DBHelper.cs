using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACMService.Helpers
{
    public static class DBHelper
    {
        public static ACMEntities GetDBContext()
        {
            return new ACMEntities();
        }
    }
}