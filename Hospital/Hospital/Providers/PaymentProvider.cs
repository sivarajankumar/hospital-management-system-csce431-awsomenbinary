using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;
using System.Configuration.Provider;


namespace Hospital.Providers
{
    public class PaymentProvider : BaseProvider
    {

        public void makePayment(Payment p)
        {
            int doctor_id = getUserIdFromName(p.doctor);
            if (doctor_id < 0)
            {
                throw new Exception("Doctor does not exist in system.");
            }

            if (p.pay_date == null)
            {
                p.pay_date = DateTime.Now;
            }

            string query = "insert into Payment (doctor_id, type, pay_rate, hours, for_text, pay_date) " +
                           String.Format("values({0}, '{1}', {2}, {3}, '{4}', '{5:yyyy-MM-dd}')",
                                          doctor_id, p.type, p.pay_rate, p.hours, p.for_text, p.pay_date);


            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand addUser = new MySqlCommand(query, connection);
                addUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Could not add payment. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

        }

        public double makePayment(int docID)
        {

            List<Payment> records = new List<Payment>();


            MySqlConnection connection = new MySqlConnection(connectionString);
            double pay = 0;
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
                            Payment r = new Payment();
                            r.doctor = getUserNameFromID((int)values[0]);
                            r.type = (string)values[1];
                            r.pay_rate = (double)values[2];
                            r.hours = (double)values[3];
                            r.for_text = (string)values[4];
                            r.pay_date = (DateTime)values[5];
                            records.Add(r);

                        }

                    }

                    for (int i = 1; i < records.Count; i++)
                    {

                        pay += (records[0].pay_rate * records[0].hours);


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

            return pay;
        }


    }
}