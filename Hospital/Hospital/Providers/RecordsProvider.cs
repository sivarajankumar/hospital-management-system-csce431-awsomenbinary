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

        public BillingRecords getBillingRecordsForPatient(String name)
        {
            return getBillingRecordsForPatient(getUserIdFromName(name));
        }

        public MedicalRecord getMedicalRecordsForPatient(int id)
        {
            MedicalRecord record = new MedicalRecord();
            if (id > 0)
            {
                //#TODO get medical records
                record.currentMedicalHistory = "Sudden Adult Death Syndrome";
                record.previousMedicalHistory = "Death, taxes.";
                record.prescriptions = new List<string>();
                record.prescriptions.Add("Lots and lots of cocaine.");
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
    }
}