using System.Configuration;
using Hospital.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System;
using System.Configuration.Provider;

namespace Hospital.Providers
{
    public sealed class RegistrationProvider : BaseProvider
    {

        public void registerUser(string user, string email, string password, string firstname, string middleinital, string lastname, string age, string sex, string mailingaddress, string phonenumber, string creditcardname, string creditcardtype, string creditcardnumber, string creditcardsecuritynumber, string insurancecompany, string insurancepolicynumber, string insurancepolicyholder, string martialstatus, string ssn, string dob, string operations, string allergies, string medication, string pastdoctor, string familyhistory, string emergencycontactname, string emergencycontactnumber, string recenttests, string latestbloodpressure)
        {
            int user_id = getUserIdFromName(user);

            if (user_id < 0)
            {
                throw new Exception("User does not exist in system.");

            }

            string query = "INSERT INTO Registration(id,username,email,password,firstname,middleinitial,lastname,age,sex,mailingaddress,phonenumber,creditcardname,creditcardtype,creditcardnumber,creditcardsecuritynumber,insurancecompany,insurancepolicynumber,insurancepolicyholder,martialstatus,ssn,dob,operations,allergies,medication,pastdoctor,familyhistory,emergencycontactname,emergencycontactnumber,recenttests,latestbloodpressure)";
            query += String.Format(" Values({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')", user_id,user, email, password, firstname, middleinital, lastname, age, sex, mailingaddress, phonenumber, creditcardname, creditcardtype, creditcardnumber, creditcardsecuritynumber, insurancecompany, insurancepolicynumber, insurancepolicyholder, martialstatus, ssn, dob, operations, allergies, medication, pastdoctor, familyhistory, emergencycontactname, emergencycontactnumber, recenttests, latestbloodpressure);
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand registerUser = new MySqlCommand(query,connection);
                registerUser.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("could not add user. Error:"+e.Message, e);
            }
            finally
            {
                connection.Close();
            }

        }


        public List<Registration> getRegistration()
        {
            Registration r = new Registration();
            string query = "SELECT * FROM Registration WHERE user_id="+r.id;
            return getRegistration(query);
        }


        public List<Registration> getRegistration(string query)
        {
            List<Registration> reg = new List<Registration>();
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand verifyUser = new MySqlCommand(query, connection);
                verifyUser.ExecuteNonQuery();

                object[] values = new object[30];
                MySqlDataReader response = verifyUser.ExecuteReader();
                try
                {
                    while (response.Read())
                    {
                        int num = response.GetValues(values);
                        if (num == 30)
                        {
                            Registration r = new Registration();
                            r.id = (int)values[0];
                            r.username = (String)values[1];
                            r.email = (String)values[2];
                            r.password = (String)values[3];
                            r.firstname = (String)values[4];
                            r.middleinital = (String)values[5];
                            r.lastname = (String)values[6];
                            r.age = (String)values[7];
                            r.sex = (String)values[8];
                            r.mailingaddress = (String)values[9];
                            r.phonenumber = (String)values[10];
                            r.creditcardname = (String)values[11];
                            r.creditcardtype = (String)values[12];
                            r.creditcardnumber = (String)values[13];
                            r.creditcardsecuritynumber = (String)values[14];
                            r.insurancecompany = (String)values[15];
                            r.insurancepolicynumber = (String)values[16];
                            r.insurancepolicyholder = (String)values[17];
                            r.martialstatus = (String)values[18];
                            r.ssn = (String)values[19];
                            r.dob = (String)values[20];
                            r.operations = (String)values[21];
                            r.allergies = (String)values[22];
                            r.medication = (String)values[23];
                            r.pastdoctor = (String)values[24];
                            r.familyhistory = (String)values[25];
                            r.emergencycontactname = (String)values[26];
                            r.emergencycontactnumber = (String)values[27];
                            r.recenttests = (String)values[28];
                            r.latestbloodpressure = (String)values[29];

                            reg.Add(r);

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
                throw new Exception("Could not access registrations. Error: " + e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return reg;
            
        }

        public Registration getRegistrationForUser(string user)
        {
            if (!Roles.IsUserInRole(user, "patient"))
            {
                return new Registration();
            }

            int user_id = getUserIdFromName(user);
            string query = "SELECT * FROM Registration WHERE user_id="+user_id;
            List<Registration> r = getRegistration(query);
            if (r.Count < 1) return null;

            return r[0];
        }

        public Registration getRegistrationById(int id)
        {
            string query = "SELECT * FROM Registration WHERE id="+id;
            List<Registration> reg = getRegistration(query);
            if (reg.Count < 1)
            {
                return null;
            }
            return reg[0];
        }




    }
}