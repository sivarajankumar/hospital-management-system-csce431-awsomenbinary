using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;
using System.Configuration.Provider;

namespace Hospital.Providers
{
    public sealed class BillingProvider : BaseProvider
    {
        public void addBill(Bill b)
        {
            int patient_id = getUserIdFromName(b.patient);
            if (patient_id < 0)
            {
                throw new Exception("Invalid User ID: User does not exist in system, please register an account");
            }

            if (b.bill_date == null)
            {
                b.bill_date = DateTime.Now;
            }

            string query = "insert into Billing (patient_id, bill_total, for_text, bill_date) " +
                String.Format("VALUES ({0}, {1}, '{2}', '{3:yyyy-MM-dd}')", patient_id, b.bill_total, b.for_text, b.bill_date);


            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand addUser = new MySqlCommand(query, connection);
                addUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Could not add user. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }
        }

        //Updating Bill function
        public void updateBill(int UserId, DateTime Date, double BillTotal, string Item)
        {
            //Check for UserId in the system database
            if (UserId < 0)
            {
                throw new Exception("Invalid User ID: User does not exist in system, please have them register an account");
            }
            Date = DateTime.Today;

            string query = "Billing information(UserId, BillTotal, Item) " +
                String.Format("VALUES ({0}, '{2:yyyy-MM-dd HH:mm:ss}', '{3}', '{4}')", UserId, Date, BillTotal, Item);

            //open a connection to the MySQL database
            //error handling included
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand addBill = new MySqlCommand(query, connection);
                addBill.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Could not add Bill for patient. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }
        }

      
        public List<Bill> getBilling(string query)
        {

            List<Bill> records = new List<Bill>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand verifyUser = new MySqlCommand(query, connection);
                verifyUser.ExecuteNonQuery();

                object[] values = new object[5];
                MySqlDataReader response = verifyUser.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        int num = response.GetValues(values);
                        if (num == values.Length)
                        {
                            Bill r = new Bill();
                            r.id = (int)values[0];
                            r.patient = getUserNameFromID((int)values[1]);
                            r.bill_total = (double)values[2];
                            r.for_text = (String)values[3];
                            r.bill_date = (DateTime)values[4];
                            records.Add(r);
                        }

                    }
                }
                finally
                {
                    response.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not access billing records. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }
            return records;
        }

        public Bill patient_getBill(int userID)
        {
            string patient_name = null;
            patient_name = getUserNameFromID(userID);

            if (!Roles.IsUserInRole(patient_name, "patient"))
            {
                throw new Exception("You are not a patient");
            }

            ///separate patient string into first and last name.

            string query = "SELECT registration.firstname + registration.lastname FROM registration WHERE firstname= " + patient_name;
            List<Bill> records  = getBilling(query);
            if (records.Count < 1)
            {
                return null;
            }
            return records[0];

        }
        private Bill getBill(int id)
        {
            string query = "SELECT * FROM Billing WHERE UserID = " + id;
            List<Bill> records = getBilling(query);
            if (records.Count < 1)
            {
                return null;
            }
            return records[0];

        }

        public bool deleteRecords(int id)
        {
           return deleteRecords(id, true);
                      
        }

        public bool deleteRecords(int id, bool restrict)
        {
            Bill records = getBill(id);

            if (!restrict)
            {
                return false;
            }
            string query = String.Format("DELETE FROM billing records WHERE id={0}", records.id);

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand addUser = new MySqlCommand(query, connection);
                addUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Could not clear billing records. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }


    }
}
