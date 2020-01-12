using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAIMLTD.Models.Entity;
using MySql.Data.MySqlClient;

namespace SAIMLTD.Models.DAO
{
    public class ContactPersonDAO : BaseDAO
    {
        public List<ContactPerson> GetContactPersonById(int id)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;
            List<ContactPerson> result = new List<ContactPerson>();
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = "SELECT * FROM contact_person WHERE id_societe = @idsociete";
                command.Parameters.AddWithValue("@idsociete", id);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ContactPerson contact = new ContactPerson();
                    contact.SetId(reader.GetInt32(0));
                    contact.SetIdSociete(reader.GetInt32(1));
                    contact.SetNomPersonne(reader.GetString(2));
                    contact.SetPoste(reader.GetString(3));
                    result.Add(contact);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                try
                {
                    if (reader != null) reader.Close();
                    if (command != null) command.Dispose();
                    if (connection != null) connection.CloseConnection();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }
    }
}