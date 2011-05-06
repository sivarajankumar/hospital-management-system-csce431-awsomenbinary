using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;
using System.Configuration.Provider;


namespace Hospital.Providers
{
    public class PaymentProvider
    {

       /* public void makePayment()
        {

            List<PaymentRecords> records = new List<PaymentRecords>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            double pay;
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
                        if (num == 5)
                        {
                            PaymentRecords r = new PaymentRecords();
                            r.UserID = (int)values[0];
                            r.PayRate = (double)values[1];
                            r.Hours = (int)values[2];
                            r.SurgeryRate = (double)values[3];
                            r.SurgeryHours = (int)values[4];

                            pay = (r.PayRate * r.Hours) + (r.SurgeryRate * r.SurgeryHours);
                            

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

        */


    }
}