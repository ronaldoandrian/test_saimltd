using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.Entity
{
    public class ContactPerson
    {
        private int id;
        private int id_societe;
        private string nom_personne;
        private string poste;

        public int GetId()
        {
            return id;
        }
        public void SetId(int new_id)
        {
            id = new_id;
        }
        public int GetIdSociete()
        {
            return id_societe;
        }
        public void SetIdSociete(int id_societe)
        {
            this.id_societe = id_societe;
        }

        public string GetNomPersonne()
        {
            return nom_personne;
        }
        public void SetNomPersonne(string nom_personne)
        {
            this.nom_personne = nom_personne;
        }
        public string GetPoste()
        {
            return poste;
        }
        public void SetPoste(string poste)
        {
            this.poste = poste;
        }
    }
}