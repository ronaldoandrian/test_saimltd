using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIMLTD.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult ViewCustomer(string idcustomer)
        {
            ViewBag.societe = "Société " + idcustomer;
            return View("ViewCustomer");
        }

        [HttpGet]
        public ActionResult Edit(string idcustomer)
        {
            ViewBag.societe = "Société " + idcustomer;
            return View("EditCustomer");
        }

        public ActionResult Add()
        {
            return View("AddCustomer");
        }
    }
}