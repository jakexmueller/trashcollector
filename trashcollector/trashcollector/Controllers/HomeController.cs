﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trashcollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Employee"))
            {
                return RedirectToAction("GetTodaysPickups", "Customers");
            }
            if(User.IsInRole("Customer"))
            {
                return RedirectToAction("Details", "Customers");
            }
            else
            {
                return View();
            }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}