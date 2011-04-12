using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Microsoft.CSharp;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentProviderService svc = new AppointmentProviderService();

        //
        // GET: /Appointment/

        public ActionResult Index()
        {
            return View(svc.getAppointments());
        }

        public ActionResult Delete(int id)
        {
            if (User.IsInRole("Doctor"))
            {
                svc.cancelAppointment(id, false);
            }
            else
            {
                svc.cancelAppointment(id, true);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create(String doctor, String specialization, DateTime time)
        {
            svc.scheduleAppointment(User.Identity.Name, specialization, doctor, time);
            return RedirectToAction("Index");
        }
    }
}
