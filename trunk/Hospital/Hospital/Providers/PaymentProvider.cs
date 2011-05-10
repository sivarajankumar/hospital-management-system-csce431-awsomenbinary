using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;
using System.Configuration.Provider;


namespace Hospital.Providers
{
    public sealed class PaymentProvider: BaseProvider
    {

        public double makePayment(int docID)
        {

            List<PaymentRecords> records = new List<PaymentRecords>();
        

            MySqlConnection connection = new MySqlConnection(connectionString);
            double payment=0;
            try
            {


                string query = "select doctor_id, pay_rate, hours" + "from Payment where doctor_id=" + docID;
                connection.Open();
                MySqlCommand verifyUser = new MySqlCommand(query, connection);
                verifyUser.ExecuteNonQuery();
                

                object[] values = new object[3];
                MySqlDataReader response = verifyUser.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        int num = response.GetValues(values);
                        if (num == 3)
                        {
                            PaymentRecords r = new PaymentRecords();
                            r.DocID = (int)values[0];
                            r.PayRate = (double)values[1];
                            r.Hours = (int)values[2];
                            records.Add(r);

                        }

                    }

                    for (int i = 1; i < records.Count; i++)
                    {
                       
                        payment+=(records[0].PayRate*records[0].Hours);

                        
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

            return payment;
        }


     

        


    }
}