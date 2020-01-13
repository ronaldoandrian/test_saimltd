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
        public ActionResult Customers(string page, string success, string error)
        {
            try
            {
                int _page = 1;
                bool isParsedPage = int.TryParse(page, out _page);
                if (!isParsedPage || _page <= 0) _page = 1;
                List<Client> clients = new CustomerService().GetCustomers(_page);
                ViewBag.clients = clients;
                int nombre = new CustomerService().CountCustomer();
                ViewBag.nombre = nombre;
                ViewBag.pagination = new PageService().MakePagination(10, nombre, _page, "/home/customers?page=");
                if(success != null) ViewBag.success = "Le client a été supprimé avec succès!";
                if(error != null) ViewBag.error = "Echec de la suppression du client!";
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View("NosClients");
        }


    }
}