using SAIMLTD.Models.DAO;
using SAIMLTD.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.Services
{
    public class CustomerService
    {
        public Client GetCustomerById(string id)
        {
            try
            {
                int _id = 0;
                bool isParsed = int.TryParse(id, out _id);
                if (!isParsed || _id <= 0) return null;
                else return new ClientDAO().GetCustomerById(_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCustomer(string id, string denomination, string adresse, string telephone, string mail, string siren, string activite, string capital, string forme_juridique)
        {
            try
            {
                Client client = new Client();
                int _id = 0;
                bool isParsed = int.TryParse(id, out _id);
                if(!isParsed || _id <= 0)
                {
                    return false;
                }
                client.SetId(_id);
                client.SetDenomination(denomination);
                client.SetAdresse(adresse);
                client.SetTelephone(telephone);
                client.SetMail(mail);
                client.SetSiren(siren);
                client.SetActivite(activite);
                double _capital = 0;
                bool isCParsed = double.TryParse(capital, out _capital);
                if (!isCParsed) _capital = 0;
                client.SetCapital(_capital);
                client.SetFormeJuridique(forme_juridique);
                return new ClientDAO().UpdateCustomer(client);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCustomerById(string idcustomer)
        {
            try
            {
                return new ClientDAO().DeleteCustomerById(idcustomer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Client> GetCustomers()
        {
            try
            {
                return new ClientDAO().GetCustomers();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ContactPerson> GetContactPersonById(int id)
        {
            try
            {
                return new ContactPersonDAO().GetContactPersonById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}