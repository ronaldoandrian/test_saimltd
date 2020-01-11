using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIMLTD.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            bool isConnected = true;
            if(isConnected) return Redirect("/home/customers");
            else return Redirect("/authentification/login");
        }
    }
}