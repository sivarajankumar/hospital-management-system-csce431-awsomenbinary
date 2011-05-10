using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using System.Web.Security;
using Microsoft.CSharp;
using Hospital.Providers;

namespace Hospital.Controllers
{
    public class PaymentController : GenericController
    {
        PaymentProvider pmp = new PaymentProvider();

        
         //GET: /Payment/

        [Authorize]
        public ActionResult Index()
        {
            //if (!User.IsInRole("Doctor"))
            {
                //ViewData["total_payment"] = pmp.makePayment();
                
            }

            return View(Roles.GetUsersInRole("patient"));
        }

        

        //
        // GET: /Payment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Payment/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Payment/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Payment/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Payment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Payment/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }



        //
        // POST: /Payment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
