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

        public void makePayment()
        {

            List<PaymentRecords> records = new List<PaymentRecords>();
            List<PaymentRecords> Payments = new List<PaymentRecords>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            double pay;
            try
            {

                string query = "Payment information(UserId, BillTotal, Item) " +
                String.Format("VALUES ({0}, '{2:yyyy-MM-dd}', '{3}', '{4}')", UserId, Date, BillTotal, Item);
                connection.Open();
                MySqlCommand verifyUser = new MySqlCommand(query, connection);
                verifyUser.ExecuteNonQuery();

                object[] values = new object[6];
                MySqlDataReader response = verifyUser.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        int num = response.GetValues(values);
                        if (num == 6)
                        {
                            PaymentRecords r = new PaymentRecords();
                            r.DocID = (int)values[0];
                            r.AptType = (String)values[1];
                            r.PayRate = (double)values[2];
                            r.Hours = (int)values[3];
                            r.ForText = (String)values[4];
                            r.PayDate = (DateTime)values[5];

                            DateTime today = DateTime.now;

                            if (today.Day == PayDate.Day && today.month == PayDate.month)
                            {
                                records.Add(r);

                            }
                            

                        }

                    }

                    for (int i = 1; i < records.Count; i++)
                    {
                        Payments.Add(records[0].DocID);
                        Payments.Add(records[0].PayRate*records[0].Hours);

                        for (int j = 0; j < Payments.Count; j++)
                        {
                            if (records[i].DocID == Payments[j * 2])
                            {
                                Payments[j * 2 + 1] += (records[0].PayRate * records[0].Hours);

                            }
                            else
                            {
                                Payments.Add(records[i].DocID);
                                Payments.Add(records[i].PayRate * records[i].Hours);

                            }

                        }


                    }

                    for (int i = 0; i < Payments.Count / 2; i++)
                    {
                        Pay(Payments[2*i],Payments[2*i+1];
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
 
        }


        public void Pay(int DocID, double amount)
        {
            //Add to Pay Database


        }

        


    }
}