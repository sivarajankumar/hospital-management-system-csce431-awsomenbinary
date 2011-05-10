using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Configuration;
using Hospital.Models;
using MySql.Data.MySqlClient;

namespace Hospital.Providers
{
    public sealed class RecordsProvider : BaseProvider
    {

        public MedicalRecord getMedicalRecordsForPatient(String name)
        {
            return getMedicalRecordsForPatient(getUserIdFromName(name));
        }
        
        /*
        public BillingRecords getBillingRecordsForPatient(String name)
        {
            return getBillingRecordsForPatient(getUserIdFromName(name));
        }
         */

        public MedicalRecord getMedicalRecordsForPatient(int id)
        {
            if (id < 0)
            {
                throw new Exception("User does not exist in system.");
            }

            MedicalRecord record = new MedicalRecord();
            MySqlConnection connection = new MySqlConnection(connectionString);

            string query1 = String.Format("SELECT currenthistory FROM Records WHERE id='{0}' LIMIT 1", id);
            string query2 = String.Format("SELECT operations FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query3 = String.Format("SELECT allergies FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query4 = String.Format("SELECT medication FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query5 = String.Format("SELECT pastdoctor FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query6 = String.Format("SELECT emergencycontactname FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query7 = String.Format("SELECT emergencycontactnumber FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query8 = String.Format("SELECT recenttests FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query9 = String.Format("SELECT latestbloodpressure FROM Registration WHERE id='{0}' LIMIT 1", id);
            string query10 = String.Format("SELECT previoushistory FROM Records WHERE id='{0}' LIMIT 1", id);
            
            try
            {
                connection.Open();

                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                MySqlCommand cmd4 = new MySqlCommand(query4, connection);
                MySqlCommand cmd5 = new MySqlCommand(query5, connection);
                MySqlCommand cmd6 = new MySqlCommand(query6, connection);
                MySqlCommand cmd7 = new MySqlCommand(query7, connection);
                MySqlCommand cmd8 = new MySqlCommand(query8, connection);
                MySqlCommand cmd9 = new MySqlCommand(query9, connection);
                MySqlCommand cmd10 = new MySqlCommand(query10, connection);

                MySqlDataReader response1 = cmd1.ExecuteReader();
                MySqlDataReader response2 = cmd2.ExecuteReader();
                MySqlDataReader response3 = cmd3.ExecuteReader();
                MySqlDataReader response4 = cmd4.ExecuteReader();
                MySqlDataReader response5 = cmd5.ExecuteReader();
                MySqlDataReader response6 = cmd6.ExecuteReader();
                MySqlDataReader response7 = cmd7.ExecuteReader();
                MySqlDataReader response8 = cmd8.ExecuteReader();
                MySqlDataReader response9 = cmd9.ExecuteReader();
                MySqlDataReader response10 = cmd10.ExecuteReader();

                while (response1.Read())
                {
                    record.currentMedicalHistory = response1.GetString(0);
                }

                while (response2.Read())
                {
                    record.prevMedHistory.operations = response2.GetString(0); ;
                }

                while (response3.Read())
                {
                    record.prevMedHistory.allergies = response3.GetString(0); ;
                }

                while (response4.Read())
                {
                    record.prevMedHistory.ongoingMedication = response4.GetString(0); ;
                }

                while (response5.Read())
                {
                    record.prevMedHistory.pastDoctor = response5.GetString(0); ;
                }

                while (response6.Read())
                {
                    record.prevMedHistory.familyHistory = response6.GetString(0); ;
                }

                while (response7.Read())
                {
                    record.prevMedHistory.emergencyContactName = response7.GetString(0); ;
                }

                while (response8.Read())
                {
                    record.prevMedHistory.emergencyContactNumber = response8.GetString(0); ;
                }

                while (response1.Read())
                {
                    record.prevMedHistory.recentTests = "";
                }

                while (response9.Read())
                {
                    record.prevMedHistory.lastestBloodPressure = response9.GetString(0); ;
                }

                while (response10.Read())
                {
                    record.prevMedHistory.other = response10.GetString(0); ;
                }
                

                
            }
            catch (Exception e)
            {
                throw new Exception("Could not access Medical Records. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

                return record;
            
        }

        public void updateMedicalRecordsForPatient(String patient, MedicalRecord newRecords)
        {
            //String prescriptions = "";
            //foreach (String p in newRecords.prescriptions)
            //{
            //    prescriptions += p + "\n";
            //}
            //string query = String.Format("UPDATE records SET previous='{0}', current='{1}, prescriptions={2} WHERE patient={3}",
            //    newRecords.previousMedicalHistory, newRecords.currentMedicalHistory, prescriptions, getUserIdFromName(patient));


            //MySqlConnection connection = new MySqlConnection(connectionString);
            //try
            //{
            //    connection.Open();
        

            //    MySqlCommand addUser = new MySqlCommand(query, connection);
            //    addUser.ExecuteNonQuery();
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Could not update Medical Record. Error: " + e.Message, e);
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }
        /*
        public BillingRecords getBillingRecordsForPatient(int id)
        {
            BillingRecords record = new BillingRecords();
            if (id > 0)
            {
                record.Date = DateTime.Today;
                record.BillTotal = 1000000.00;
                record.Item = "One Million Dollars";

            }

            return record;

        }
         */
    }
}