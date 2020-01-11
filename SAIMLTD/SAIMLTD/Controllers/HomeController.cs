using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIMLTD.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Customers()
        {
            return View("NosClients");
        }
    }
}