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
    }
}