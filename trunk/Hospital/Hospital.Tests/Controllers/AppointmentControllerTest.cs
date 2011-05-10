using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hospital;
using Hospital.Providers;
using Hospital.Models;

namespace Hospital.Tests.Controllers
{
  [TestClass]
  public class AppointmentControllerTest
  {
    [TestMethod]
    public void AddAppointment()
    {
      AppointmentProvider provider = new AppointmentProvider();
      int initial_length = provider.getAppointmentsForPatient("nemec").Count;
      provider.addAppointment("nemec", "no area", "doctor", DateTime.Now);
      Assert.IsTrue(initial_length + 1 == provider.getAppointmentsForPatient("nemec").Count);
    }

    [TestMethod]
    public void CancelAppointment()
    {
      AppointmentProvider provider = new AppointmentProvider();
      List<Appointment> apps = provider.getAppointmentsForPatient("nemec");
      if(apps.Count == 0)
      {
        AddAppointment();
      }
      provider.cancelAppointment(apps[0].id, true);
      Assert.AreEqual(apps.Count - 1, provider.getAppointmentsForPatient("nemec").Count);
    }
  }
}
