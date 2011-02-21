using System;
using MySql.Data.MySqlClient;

namespace SQLConnector{

    public class SQLConnector{
        private MySqlConnection connection;
        private string conn_str;
        private bool is_connected;

        public SQLConnector(string svr, string db, string user, string pass)
            : this("Server=" + svr + ";Database=" + db + ";Username=" + user + ";Password=" + pass + ";")
        { }

        public SQLConnector(string conn_str){
            this.conn_str = conn_str;

            try{
                this.connection = new MySqlConnection(this.conn_str);
            }
            catch (Exception e){
                throw new Exception("Error connecting to sql server. Internal message: " + e.Message, e);
            }
            this.is_connected = false;
        }

        public void connect() {
            if (!this.is_connected) {
                try {
                    this.connection.Open();
                    this.is_connected = true;
                }
                catch (Exception e) {
                    throw new Exception("Error opening connection to database. Error: " + e.Message, e);
                }
            }
        }

        public void disconnect() {
            if (this.is_connected) {
                this.connection.Close();
            }
        }

        public bool isConnected {
            get {
                return this.is_connected;
            }
        }

        public void addUser(string username, string password) {
            string query = "INSERT INTO users (username, password)" +
                "VALUES ('" + username + "','" + password + "')";
            MySqlCommand addUser = new MySqlCommand(query, this.connection);

            try {
                addUser.ExecuteNonQuery();
            }
            catch (Exception e) {
                throw new Exception("Could not add user. Error: " + e.Message, e);
            }
        }

        private bool queryExists(string query){
            int ret = 0;

            MySqlCommand verifyUser = new MySqlCommand(query, this.connection);

            try {
                verifyUser.ExecuteNonQuery();

                MySqlDataReader response = verifyUser.ExecuteReader();
                while (response.Read()) {
                    ret = response.GetInt32(0);
                }
                response.Close();
            }
            catch (Exception e) {
                throw new Exception("Could not verify user. Error: " + e.Message, e);
            }

            return ret != 0;
        }

        public bool verifyUser(string username, string password) {
            string query = "SELECT COUNT(*) FROM users WHERE " +
                "(username='" + username + "' AND password='" + password + "') LIMIT 1";

            return queryExists(query);
        }

        public bool userExists(string username) {
            string query = "SELECT COUNT(*) FROM users WHERE " +
                "(username='" + username + "') LIMIT 1";
            return queryExists(query);
        }
    }
}
