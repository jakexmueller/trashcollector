﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trashcollector.Models;

namespace trashcollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index(string pickupDay)
        {
           

            var currentUserName = User.Identity.GetUserName();
            var currentEmployee = db.Employee.Where(i => i.UserName == currentUserName).FirstOrDefault();
            var customerMatches = db.Customer.Where(n => n.ZipCode == currentEmployee.ZipCode).ToList();
            ViewBag.PickupDay = (from r in db.Customer
                                 select r.PickupDay).Distinct();

            var model = from r in customerMatches
                        orderby r.LastName
                        where r.PickupDay == pickupDay || pickupDay == null || pickupDay == ""
                        select r;

            return View(model.ToList());
        }

        //GET Customers/GetTodaysPickups
        public ActionResult GetTodaysPickups()
        {
            var currentUserName = User.Identity.GetUserName();
            var currentEmployee = db.Employee.Where(i => i.UserName == currentUserName).FirstOrDefault();
            var customerMatches = db.Customer.Where(n => n.ZipCode == currentEmployee.ZipCode).ToList();
            var todaysPickups = customerMatches.Where(i => i.PickupDay == DateTime.Today.DayOfWeek.ToString()).ToList();

            return View(todaysPickups.ToList());
        }

        public ActionResult Details()
        {
            var currentUserName = User.Identity.GetUserName();
            var customer = db.Customer.Where(x => x.UserName == currentUserName).FirstOrDefault();
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            //make list of days of week
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,ZipCode,PickupDay,UserName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,ZipCode,PickupDay,UserName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customers/ChangePickupDay
        public ActionResult ChangePickupDay(int? id)
        {
            var currentUserName = User.Identity.GetUserName();
            var customer = db.Customer.Where(x => x.UserName == currentUserName).FirstOrDefault();
            //Customer customer = db.Customer.Find(id);
            return View(customer);
        }

        //POST: Customers/ChangePickupDay
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePickUpDay([Bind(Include = "ID,PickupDay")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = User.Identity.GetUserName();
                var currentCustomer = db.Customer.Where(x => x.UserName == currentUserName).FirstOrDefault();
                currentCustomer.PickupDay = customer.PickupDay;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(customer);
        }

        ////GET: Customers/ConfirmPickup
        //public ActionResult ConfirmPickup(int? id)
        //{
        //    var currentUserName = User.Identity.GetUserName();
        //    var customer = db.Customer.Where(x => x.UserName == currentUserName).FirstOrDefault();
        //    return View(customer);
        //}

        ////POST: Customers/ConfirmPickup
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ConfirmPickup(int? id)
        {
            if (ModelState.IsValid)
            {
                Customer customer = db.Customer.Find(id);

                //var currentUserName = User.Identity.GetUserName();
                //var currentCustomer = db.Customer.Where(x => x.UserName == currentUserName).FirstOrDefault();

                customer.PickupComplete = true;
                int chargePrice = 10;
                customer.Balance += chargePrice;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
