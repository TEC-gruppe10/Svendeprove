﻿using MySql.Data.MySqlClient;
using ServiceDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.users = db.GetValuesAsStrings("SELECT `id`, `fornavn`, `password`, `telefon`, `type`, `email` FROM `bruger` LIMIT 0, 100", 6);


            return View();
        }

        public ActionResult Kunder()
        {
            return View();
        }

        public ActionResult Maskintyper()
        {
            return View();
        }

        public ActionResult Brugere()
        {
            return View();
        }
    }
}