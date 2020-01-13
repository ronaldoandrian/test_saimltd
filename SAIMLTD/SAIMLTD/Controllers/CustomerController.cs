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
        public ActionResult import()
        {
            try
            {
                HttpFileCollectionBase fichiers = Request.Files;
                string path = Server.MapPath("~/") + "App_Data_Storage/import/";
                bool isImported = new CustomerService().Importer(fichiers, path);
                if(isImported) return Redirect("/customer/add?&success_import=true");
                else return Redirect("/customer/add?&error_import=true");
            }
            catch (Exception)
            {
                return Redirect("/customer/add?&error_import=true");
            }
        }

        public JsonResult Prepare_export()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                string path = Server.MapPath("~/") + "App_Data_Storage/export/";
                new CustomerService().Prepare_Export(path);
                result.Data = new { Status = 1, Chemin = "/App_Data_Storage/export/liste_clients_SAIM_LTD.txt" };
            }
            catch (Exception ex)
            {
                result.Data = new { Status = 0, message = ex.Message };
            }
            return result;
        }

        [HttpPost]
        public ActionResult Addcustomer()
        {
            try
            {
                bool isAdded = new CustomerService().AddCustomer(Request.Form["denomination"], Request.Form["adresse"], Request.Form["telephone"], Request.Form["mail"], Request.Form["siren"], Request.Form["activite"], Request.Form["capital"], Request.Form["forme_juridique"]);
                if (isAdded) return Redirect("/customer/add?success=true");
                else return Redirect("/customer/add?&error=true");
            }
            catch (Exception)
            {
                return Redirect("/customer/add?&error=true");
            }
        }
        [HttpPost]
        public ActionResult Update()
        {
            string id = "";
            try
            {
                id = Request.Form["id"];
                bool isUpdated = new CustomerService().UpdateCustomer(id, Request.Form["denomination"], Request.Form["adresse"], Request.Form["telephone"], Request.Form["mail"], Request.Form["siren"], Request.Form["activite"], Request.Form["capital"], Request.Form["forme_juridique"]);
                if(isUpdated) return Redirect("/customer/viewcustomer?idcustomer=" + id + "&success=true");
                else return Redirect("/customer/edit?idcustomer=" + id + "&error=true"); 
            }
            catch (Exception)
            {
                return Redirect("/customer/edit?idcustomer=" + id + "&error=true");
            }
        }

        [HttpGet]
        public ActionResult Delete(string idcustomer)
        {
            try
            {
                bool isDeleted = new CustomerService().DeleteCustomerById(idcustomer);
                if (isDeleted) return Redirect("/home/customers?success=true"); 
                else return Redirect("/home/customers?error=true"); 
            }
            catch (Exception ex)
            {
                var stack = ex.StackTrace;
                var t = stack;
                return Redirect("/home/customers?error=true");
            }
        }

        [HttpGet]
        public ActionResult ViewCustomer(string idcustomer, string success)
        {
            try
            {
                ViewBag.societe = new CustomerService().GetCustomerById(idcustomer);
                if(success != null) ViewBag.success = "Le client a été mise à jour!";
            }
            catch (Exception)
            {
                ViewBag.error = "Une erreur s'est produite!";
            }
            return View("ViewCustomer");
        }

        [HttpGet]
        public ActionResult Edit(string idcustomer, string error)
        {
            ViewBag.societe = new CustomerService().GetCustomerById(idcustomer);
            if(error != null) ViewBag.error = "Echec de la modification!";
            return View("EditCustomer");
        }

        public ActionResult Add(string success, string error, string success_import, string error_import)
        {
            if (success != null) ViewBag.success = "Création d'un client avec succès!";
            if (error != null) ViewBag.error = "Echec de la création du client!";
            if (success_import != null) ViewBag.success = "Import des clients à partir d'un fichier avec succès!";
            if (error_import != null) ViewBag.error = "Echec de l'import du fichier!";
            return View("AddCustomer");
        }
    }
}