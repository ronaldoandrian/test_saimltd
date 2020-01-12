using SAIMLTD.Models.Entity;
using SAIMLTD.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIMLTD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/home/customers");
        }
        public ActionResult Customers()
        {
            try
            {
                List<Client> clients = new CustomerService().GetCustomers();
                ViewBag.clients = clients;
                ViewBag.nombre = clients.Count;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View("NosClients");
        }


    }
}