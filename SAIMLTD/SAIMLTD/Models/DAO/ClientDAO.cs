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
        public bool AddCustomer(Client client)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = @"INSERT INTO Client(denomination, adresse, telephone, mail, siren, activite, capital, forme_juridique) VALUES (@den, @adr,  @tel,  @mail,  @sir,  @act,  @cap, @for)";
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

        public bool Import(List<Client> clients)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlTransaction transaction = null;
            try
            {
                connection = new DBConnection();
                MySqlConnection mySqlConnection = connection.GetConnection();
                transaction = mySqlConnection.BeginTransaction();
                command = new MySqlCommand();
                command.Connection = mySqlConnection;
                command.Transaction = transaction;
                int row_affected = 0;
                foreach (Client client in clients)
                {
                    string sql = "INSERT INTO Client (";
                    List<string> champs = client.GetChamps();
                    List<string> valeurs = client.GetValeurs();
                    int i = 0;
                    foreach (string champ in champs)
                    {
                        sql += champ;
                        i++;
                        if (i < champs.Count) sql += ",";
                    }
                    i = 0;
                    sql += ") VALUES (";
                    foreach (string valeur in valeurs)
                    {
                        sql += "'"+valeur+"'";
                        i++;
                        if (i < valeurs.Count) sql += ",";
                    }
                    sql += ")";
                    command.CommandText = sql;
                    row_affected += command.ExecuteNonQuery();
                }
                transaction.Commit();
                return row_affected > 0;
            }
            catch (Exception)
            {
                if (transaction != null) transaction.Rollback();
                throw;
            }
            finally
            {
                try
                {
                    if (transaction != null) transaction.Dispose();
                    if (command != null) command.Dispose();
                    if (connection != null) connection.CloseConnection();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

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
                command.CommandText = @"UPDATE Client SET denomination = @den, adresse = @adr, telephone = @tel, mail = @mail, siren = @sir, activite = @act, capital = @cap, forme_juridique = @for WHERE id = @id";
                command.Parameters.AddWithValue("@den", client.GetDenomination());
                command.Parameters.AddWithValue("@adr", client.GetAdresse());
                command.Parameters.AddWithValue("@tel", client.GetTelephone());
                command.Parameters.AddWithValue("@mail", client.GetMail());
                command.Parameters.AddWithValue("@sir", client.GetSiren());
                command.Parameters.AddWithValue("@act", client.GetActivite());
                command.Parameters.AddWithValue("@cap", client.GetCapital());
                command.Parameters.AddWithValue("@for", client.GetFormeJuridique());
                command.Parameters.AddWithValue("@id", client.GetId());
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

        public int CountCustomer()
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;
            try
            {
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = @"SELECT count(*) FROM Client";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
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
            return 0;
        }

        public bool DeleteCustomerById(string idcustomer)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlTransaction transaction = null;
            try
            {
                connection = new DBConnection();
                MySqlConnection mySqlConnection = connection.GetConnection();
                transaction = mySqlConnection.BeginTransaction();
                command = new MySqlCommand();
                command.Connection = mySqlConnection;
                command.Transaction = transaction;
                command.CommandText = @"DELETE FROM Contact_person WHERE id_societe = @Ids";
                command.Parameters.AddWithValue("@Ids", idcustomer);
                int row_affected = command.ExecuteNonQuery();
                command.CommandText = @"DELETE FROM Client WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", idcustomer);
                row_affected += command.ExecuteNonQuery();
                transaction.Commit();
                return row_affected > 0;
            }
            catch (Exception)
            {
                if (transaction != null) transaction.Rollback();
                throw;
            }
            finally
            {
                try
                {
                    if (transaction != null) transaction.Dispose();
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

        public List<Client> GetCustomers(int page)
        {
            DBConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader reader = null;
            List<Client> result = new List<Client>();
            try
            {
                int offset = (page - 1) * 10;
                connection = new DBConnection();
                command = connection.GetConnection().CreateCommand();
                command.CommandText = "SELECT * FROM Client LIMIT 10 OFFSET @offset";
                command.Parameters.AddWithValue("@offset", offset);
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