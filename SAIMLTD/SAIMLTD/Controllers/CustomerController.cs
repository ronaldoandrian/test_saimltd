using SAIMLTD.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIMLTD.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        public ActionResult Update()
        {
            try
            {
                string id = Request.Form["id"];
                bool isUpdated = new CustomerService().UpdateCustomer(id, Request.Form["denomination"], Request.Form["adresse"], Request.Form["telephone"], Request.Form["mail"], Request.Form["siren"], Request.Form["activite"], Request.Form["capital"], Request.Form["forme_juridique"]);
                if(isUpdated)
                {
                    ViewBag.success = "Le client a été mise à jour!";
                    return Redirect("/customer/viewcustomer?idcustomer=" + id);
                }
                else
                {
                    ViewBag.success = "Echec de la modification!";
                    return Redirect("/customer/edit?idcustomer=" + id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(string idcustomer)
        {
            try
            {
                bool isDeleted = new CustomerService().DeleteCustomerById(idcustomer);
                if (isDeleted) ViewBag.success = "Le client a été supprimé avec succès!";
                else ViewBag.error = "Echec de la suppression du client!";
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult ViewCustomer(string idcustomer)
        {
            try
            {
                ViewBag.societe = new CustomerService().GetCustomerById(idcustomer);
            }
            catch (Exception)
            {
                throw;
            }
            return View("ViewCustomer");
        }

        [HttpGet]
        public ActionResult Edit(string idcustomer)
        {
            ViewBag.societe = new CustomerService().GetCustomerById(idcustomer);
            return View("EditCustomer");
        }

        public ActionResult Add()
        {
            return View("AddCustomer");
        }
    }
}