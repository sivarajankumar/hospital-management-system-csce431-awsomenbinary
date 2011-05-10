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
        public Bill getBillForPatient(String name)
        {
            return getBillForPatient(getUserIdFromName(name));
        }
         */

        /*public MedicalRecord getPrescriptions(int id)
        {
            if (id > 0)
            {
                MedicalRecord prescriptions = new MedicalRecord()
                
            }

            return prescriptions;
        }*/

        public MedicalRecord getMedicalRecordsForPatient(int id)
        {
            if (id < 0)
            {
                throw new Exception("User does not exist in system.");
            }

            MedicalRecord record = new MedicalRecord();
            record.prevMedHistory = "Dire fever.";
            record.currentMedicalHistory = "Clean bill of health!";
            /*MySqlConnection connection = new MySqlConnection(connectionString);

            string query = String.Format("SELECT currenthistory, operations, allergies, medication , pastdoctor, emergencycontactname, " +
                                                 "emergencycontactnumber, recenttests, latestbloodpressure, previoushistory " +
                                                 "FROM Records WHERE id='{0}' LIMIT 1", id);

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);

                object[] values = new object[11];
                MySqlDataReader response = cmd.ExecuteReader();

                while (response.Read())
                {
                    int num = response.GetValues(values);
                    if (num == values.Length)
                    {
                        record.currentMedicalHistory = (string)values[0];
                        record.prevMedHistory.operations = (string)values[1];
                        record.prevMedHistory.allergies = (string)values[2];
                        record.prevMedHistory.ongoingMedication = (string)values[3];
                        record.prevMedHistory.pastDoctor = (string)values[4];
                        record.prevMedHistory.familyHistory = (string)values[5];
                        record.prevMedHistory.emergencyContactName = (string)values[6];
                        record.prevMedHistory.emergencyContactNumber = (string)values[7];
                        record.prevMedHistory.recentTests = (string)values[8];
                        record.prevMedHistory.lastestBloodPressure = (string)values[9];
                        record.prevMedHistory.other = (string)values[10];
                    }
                }

                record.prescriptions.Add("Nasonex");
                record.prescriptions.Add("Zoloft");
            }
            catch (Exception e)
            {
                throw new Exception("Could not access Medical Records. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }*/

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
        public Bill getBillForPatient(int id)
        {
            Bill record = new Bill();
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