﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileBrowsingWebSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Server.MapPath("");
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
