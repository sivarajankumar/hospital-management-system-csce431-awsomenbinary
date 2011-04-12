using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;
using Hospital.Providers;

namespace Hospital.Models
{
    #region models
    public class Appointment
    {
        public int id { get; set; }
        public String patient { get; set; }
        public String doctor { get; set; }
        public String appt_area { get; set; }
        public DateTime appt_time { get; set; }
    }
    #endregion

    #region services
    public class AppointmentProviderService
    {
        private readonly AppointmentProvider _provider;

        public AppointmentProviderService() : this(null)
        {
        }

        public AppointmentProviderService(AppointmentProvider provider)
        {
            _provider = provider ?? new AppointmentProvider();
        }

        public void scheduleAppointment(string user, string specialization, string doctor, DateTime time)
        {
           
            _provider.addAppointment(user, specialization, doctor, time);
        }

        public List<Appointment> getAppointments()
        {
            return _provider.getAppointments();
        }

        public List<Appointment> getAppointments(string patient)
        {
            return _provider.getAppointmentsForPatient(patient);
        }

        public void cancelAppointment(int id)
        {
            _provider.cancelAppointment(id);
        }

        public void cancelAppointment(int id, bool restrict)
        {
            _provider.cancelAppointment(id, restrict);
        }

    }
    #endregion

}