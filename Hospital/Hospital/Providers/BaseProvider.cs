using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Hospital.Providers
{
    public class BaseProvider : ProviderBase
    {
        protected string connectionString;

        public BaseProvider()
            : this(ConfigurationManager.ConnectionStrings["MySqlMembershipConnection"].ConnectionString)
        {
        }

        public BaseProvider(string conn)
        {
            connectionString = conn;
        }


        // Retrieves the integer id of a username that is given when creating the user.
        // All database actions on a specific user should identify the user by id.
        protected int getUserIdFromName(string name)
        {
            int id = -1;
            string query = String.Format("SELECT id FROM my_aspnet_Users WHERE name='{0}' LIMIT 1", name);

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlDataReader response = cmd.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        id = response.GetInt32(0);
                    }
                }
                finally
                {
                    response.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not access appointments. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return id;
        }
    }
}