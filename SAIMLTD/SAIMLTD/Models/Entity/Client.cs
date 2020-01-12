using SAIMLTD.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.Entity
{
    public class Client
    {
        private int id;
        private string denomination;
        private string adresse;
        private string telephone;
        private string mail;
        private string siren;
        private string activite;
        private double capital;
        private string forme_juridique;
        private List<ContactPerson> personnes;

        public int GetId()
        {
            return id;
        }
        public void SetId(int new_id)
        {
            id = new_id;
        }

        public string GetDenomination()
        {
            return denomination;
        }
        public void SetDenomination(string denomination)
        {
            this.denomination = denomination;
        }

        public string GetAdresse()
        {
            return adresse;
        }
        public void SetAdresse(string adresse)
        {
            this.adresse = adresse;
        }

        public string GetTelephone()
        {
            return telephone;
        }
        public void SetTelephone(string telephone)
        {
            this.telephone = telephone;
        }

        public string GetMail()
        {
            return mail;
        }
        public void SetMail(string mail)
        {
            this.mail = mail;
        }

        public string GetSiren()
        {
            return siren;
        }
        public void SetSiren(string siren)
        {
            this.siren = siren;
        }

        public string GetActivite()
        {
            return activite;
        }
        public void SetActivite(string activite)
        {
            this.activite = activite;
        }

        public double GetCapital()
        {
            return capital;
        }
        public void SetCapital(double capital)
        {
            this.capital = capital;
        }

        public string GetFormeJuridique()
        {
            return forme_juridique;
        }
        public void SetFormeJuridique(string forme_juridique)
        {
            this.forme_juridique = forme_juridique;
        }
        public List<ContactPerson> GetContactPerson()
        {
            try
            {
                return new CustomerService().GetContactPersonById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}