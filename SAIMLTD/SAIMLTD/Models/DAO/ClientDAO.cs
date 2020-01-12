using MySql.Data.MySqlClient;
using SAIMLTD.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.DAO
{
    public class ClientDAO : BaseDAO
    {
        public Client GetCustomerById(int id)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;
            Client result = null;
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = @"SELECT * FROM Client WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client();
                    client.SetId(reader.GetInt32(0));
                    client.SetDenomination(reader.GetString(1));
                    client.SetAdresse(reader.GetString(2));
                    client.SetTelephone(reader.GetString(3));
                    client.SetMail(reader.GetString(4));
                    client.SetSiren(reader.GetString(5));
                    client.SetActivite(reader.GetString(6));
                    client.SetCapital(reader.GetDouble(7));
                    client.SetFormeJuridique(reader.GetString(8));
                    result = client;
                    break;
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

        public bool UpdateCustomer(Client client)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = @"UPDATE Client SET denomination = @den, adresse = @adr, telephone = @tel, mail = @mail, siren = @sir, activite = @act, capital = @cap, forme_juridique = @for";
                command.Parameters.AddWithValue("@den", client.GetDenomination());
                command.Parameters.AddWithValue("@adr", client.GetAdresse());
                command.Parameters.AddWithValue("@tel", client.GetTelephone());
                command.Parameters.AddWithValue("@mail", client.GetMail());
                command.Parameters.AddWithValue("@sir", client.GetSiren());
                command.Parameters.AddWithValue("@act", client.GetActivite());
                command.Parameters.AddWithValue("@cap", client.GetCapital());
                command.Parameters.AddWithValue("@for", client.GetFormeJuridique());
                int row_affected = command.ExecuteNonQuery();
                return row_affected > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                try
                {
                    if (command != null) command.Dispose();
                    if (connection != null) connection.CloseConnection();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool DeleteCustomerById(string idcustomer)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = @"DELETE FROM Client WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", idcustomer);
                int row_affected = command.ExecuteNonQuery();
                return row_affected > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                try
                {
                    if (command != null) command.Dispose();
                    if (connection != null) connection.CloseConnection();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Client> GetCustomers()
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;
            List<Client> result = new List<Client>();
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = "select * from Client";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client();
                    client.SetId(reader.GetInt32(0));
                    client.SetDenomination(reader.GetString(1));
                    client.SetAdresse(reader.GetString(2));
                    client.SetTelephone(reader.GetString(3));
                    client.SetMail(reader.GetString(4));
                    client.SetSiren(reader.GetString(5));
                    client.SetActivite(reader.GetString(6));
                    client.SetCapital(reader.GetDouble(7));
                    client.SetFormeJuridique(reader.GetString(8));
                    result.Add(client);
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