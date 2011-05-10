﻿using System.Configuration;
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
        //
        // GET: /BillingProvider/

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

      
        public List<BillingRecords> getBilling(string query)
        {

            List<BillingRecords> records = new List<BillingRecords>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand verifyUser = new MySqlCommand(query, connection);
                verifyUser.ExecuteNonQuery();

                object[] values = new object[4];
                MySqlDataReader response = verifyUser.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        int num = response.GetValues(values);
                        if (num == 4)
                        {
                            BillingRecords r = new BillingRecords();
                            r.UserID = (int)values[0];
                            r.Date = (DateTime)values[1];
                            r.BillTotal = (double)values[2];
                            r.Item = (String)values[3];
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

        public BillingRecords patient_getBillingRecords(int userID)
        {
            string patient_name = null;
            patient_name = getUserNameFromID(userID);

            if (!Roles.IsUserInRole(patient_name, "patient"))
            {
                throw new Exception("You are not a patient");
            }

            ///separate patient string into first and last name.

            string query = "SELECT registration.firstname + registration.lastname FROM registration WHERE firstname= " + patient_name;
            List<BillingRecords> records  = getBilling(query);
            if (records.Count < 1)
            {
                return null;
            }
            return records[0];

        }
        private BillingRecords getBillingRecords(int id)
        {
            string query = "SELECT * FROM Billing WHERE UserID = " + id;
            List<BillingRecords> records = getBilling(query);
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
            BillingRecords records = getBillingRecords(id);

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