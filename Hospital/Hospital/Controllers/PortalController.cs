using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hospital.Models;
using System.Web.Routing;
using System.Web.Profile;

namespace Hospital.Controllers
{
    public class PortalController : GenericController
    {
        public AppointmentProviderService AppointmentService;

        protected override void Initialize(RequestContext requestContext)
        {
            if(AppointmentService == null) AppointmentService = new AppointmentProviderService();
            base.Initialize(requestContext);
        }

        // GET: /Portal/
        public ActionResult Index()
        {
            return redirectToPortal();
        }

        [Authorize(Roles = "Patient")]
        public ActionResult Patient()
        {
            return View();
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Doctor()
        {
            return View();
        }

        [Authorize(Roles = "Nurse")]
        public ActionResult Nurse()
        {
            
            return View();
        }

        [Authorize(Roles = "Pharmacist")]
        public ActionResult Pharmacist()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Administrator()
        {
            return View();
        }

        [Authorize]
        public ActionResult Appointments()
        {
          return PartialView();
        }

    }
}
