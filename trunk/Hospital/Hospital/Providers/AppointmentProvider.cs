using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;

namespace Hospital.Provider
{
    // AppointmentProvider is the class that actually interfaces with the MySQL server
    // All actions on the database must be defined here
    public sealed class AppointmentProvider
    {
        private string connectionString;

        public AppointmentProvider()
            : this(ConfigurationManager.ConnectionStrings["MySqlMembershipConnection"].ConnectionString)
        {
        }

        public AppointmentProvider(string conn)
        {
            connectionString = conn;
        }

        // Retrieves the integer id of a username that is given when creating the user.
        // All database actions on a specific user should identify the user by id.
        private int getUserIdFromName(string name)
        {
            int id = -1;
            string query = String.Format("SELECT id FROM my_aspnet_Users WHERE name='{0}' LIMIT 1", name);

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MySqlDataReader response = cmd.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        id = response.GetInt32(0);
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

            return id;
        }

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
                String.Format("VALUES ({0}, '{1}', {2}, '{3:yyyy-MM-dd HH:mm:ss}')",
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
            return getAppointments("");
        }

        public List<Appointment> getAppointments(string qualifier)
        {
            if (qualifier == null)
            {
                qualifier = "";
            }

            List<Appointment> apps = new List<Appointment>();
            string query = "SELECT * FROM appointments " + qualifier;

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
                            a.patient = (int)values[1];
                            a.appt_area = (String)values[2];
                            a.appt_doctor = (String)values[3];
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

            return getAppointments(String.Format("WHERE patient={0}", patient_id));
        }

        public bool cancelAppointment(Appointment app)
        {
            return cancelAppointment(app, true);
        }

        public bool cancelAppointment(Appointment app, bool restrict)
        {
            if (restrict && app.appt_time > DateTime.Now.AddDays(1))
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