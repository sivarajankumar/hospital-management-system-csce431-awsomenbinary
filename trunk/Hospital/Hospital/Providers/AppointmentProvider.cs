using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;
using System.Configuration.Provider;

namespace Hospital.Providers
{
    // AppointmentProvider is the class that actually interfaces with the MySQL server
    // All actions on the database must be defined here
    public sealed class AppointmentProvider : BaseProvider
    {

        // Add an appointment to the appointment table
        public void addAppointment(string patient, string area, string doc, DateTime time)
        {
            int patient_id = getUserIdFromName(patient);
            if (patient_id < 0)
            {
                throw new Exception("User does not exist in system.");
            }

            int doctor_id = getUserIdFromName(doc);
            if (doctor_id < 0)
            {
                throw new Exception("Doctor does not exist in system.");
            }

            string query = "INSERT INTO appointments (patient, doctor, appt_area, appt_time) " +
                String.Format("VALUES ({0}, {1}, '{2}', '{3:yyyy-MM-dd HH:mm:ss}')",
                    patient_id, doctor_id, area, time);


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

        public List<Appointment> getAppointments()
        {
            string query = "select pat.id, pat.patient, doc.doctor, " +
                              "pat.specialization, pat.time " +
                              "from ( " +
                                "select a.id as id, u.name as patient, " +
                                  "a.appt_area as specialization, " +
                                  "a.appt_time as time " +
                                  "from appointments a, my_aspnet_Users u " +
                                  "where a.patient=u.id " +
                                  ") pat " +
                            "left join " +
                              "(select a.id as id, u.name as doctor " +
                                "from appointments a, my_aspnet_Users u " +
                                  "where a.doctor=u.id " +
                                  ") doc " +
                            "on pat.id=doc.id ";
            return getAppointments(query);
        }

        public List<Appointment> getAppointments(string query)
        {

            List<Appointment> apps = new List<Appointment>();

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
                        if (num == 5)
                        {
                            Appointment a = new Appointment();
                            a.id = (int)values[0];
                            a.patient = (String)values[1];
                            a.doctor = (String)values[2];
                            a.appt_area = (String)values[3];
                            a.appt_time = (DateTime)values[4];
                            apps.Add(a);
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
                throw new Exception("Could not access appointments. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return apps;
        }

        public List<Appointment> getAppointmentsForPatient(string patient)
        {
            
            if (!Roles.IsUserInRole(patient, "patient"))
            {
                return new List<Appointment>();
            }
            
            int patient_id = getUserIdFromName(patient);
            string query = "select pat.id, pat.patient, doc.doctor, " +
                              "pat.specialization, pat.time " +
                              "from ( " +
                                "select a.id as id, u.name as patient, " +
                                  "a.appt_area as specialization, " +
                                  "a.appt_time as time " +
                                  "from appointments a, my_aspnet_Users u " +
                                  "where a.patient=u.id and a.patient=" + patient_id +
                                  " ) pat " +
                            "left join " +
                              "(select a.id as id, u.name as doctor " +
                                "from appointments a, my_aspnet_Users u " +
                                  "where a.doctor=u.id " +
                                  ") doc " +
                            "on pat.id=doc.id ";
            return getAppointments(query);
        }

        private Appointment getAppointmentById(int id)
        {
            string query = "select pat.id, pat.patient, doc.doctor, " +
                              "pat.specialization, pat.time " +
                              "from ( " +
                                "select a.id as id, u.name as patient, " +
                                  "a.appt_area as specialization, " +
                                  "a.appt_time as time " +
                                  "from appointments a, my_aspnet_Users u " +
                                  "where a.patient=u.id and a.id =" + id +
                                  " ) pat " +
                            "left join " +
                              "(select a.id as id, u.name as doctor " +
                                "from appointments a, my_aspnet_Users u " +
                                  "where a.doctor=u.id " +
                                  ") doc " +
                            "on pat.id=doc.id ";
            List<Appointment> apps = getAppointments(query);
            if (apps.Count < 1)
            {
                return null;
            }
            return apps[0];
        }

        public bool cancelAppointment(int id)
        {
            return cancelAppointment(id, true);
        }

        public bool cancelAppointment(int id, bool restrict)
        {
            Appointment app = getAppointmentById(id);
            if (restrict && DateTime.Compare(app.appt_time, DateTime.Now.AddDays(1)) < 0)
            {
                return false;
            }

            string query = String.Format("DELETE FROM appointments WHERE id={0}", app.id);


            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand addUser = new MySqlCommand(query, connection);
                addUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Could not remove appointment. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return true;
        }


    }
}