using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


using System.Web.Security;namespace Hospital.Controllers
{
    public partial class GenericController : Controller
    {
        protected ActionResult redirectToPortal()
        {
            string[] roles = Roles.GetRolesForUser();
            string[] default_roles = { "Patient", "Doctor", "Nurse", "Pharmacist", "Administrator" };
            if (roles.Length > 0)
            {
                foreach (string role in default_roles)
                {
                    if (roles.Contains(role))
                    {
                        return RedirectToAction(role, "Portal");
                    }
                }

            }

            throw new HttpException(403, "Not authorized");
        }
    }
}
