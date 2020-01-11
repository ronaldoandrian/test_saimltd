using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIMLTD.Controllers
{
    public class AuthentificationController : BaseController
    {
        public ActionResult Login()
        {
            return View("Connexion");
        }
    }
}