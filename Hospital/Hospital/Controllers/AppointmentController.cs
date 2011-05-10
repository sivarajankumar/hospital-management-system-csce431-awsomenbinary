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

        [Authorize(Roles="Doctor")]
        public ActionResult Finalize(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public ActionResult SubmitPayment(int id, double hours)
        {
            if (Request.HttpMethod == "POST")
            {
              Appointment app = svc.getAppointmentById(id);
              Payment p = new Payment();
              p.doctor = app.doctor;
              p.type = "appointment";
              p.hours = hours;
              p.pay_rate = 10;
              p.for_text = app.patient;
              p.pay_date = DateTime.Now;
                
              PaymentProviderService paysvc = new PaymentProviderService();
              paysvc.makePayment(p);


              Bill b = new Bill();
              b.patient = app.patient;
              b.bill_total = p.pay_rate * p.hours;
              b.for_text = "appointment: " + p.doctor;
              b.bill_date = DateTime.Now;

              BillingProviderService billsvc = new BillingProviderService();
              billsvc.addBill(b);
                
              svc.cancelAppointment(id, false);
            }
            return RedirectToAction("Index");
        }
    }
}
