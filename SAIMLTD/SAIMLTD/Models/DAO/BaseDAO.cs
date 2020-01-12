using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.DAO
{
    public class BaseDAO
    {
        public DBConnection connection;

        public BaseDAO()
        {
            connection = new DBConnection();
        }
    }
}