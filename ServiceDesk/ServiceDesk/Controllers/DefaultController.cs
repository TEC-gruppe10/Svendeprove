using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class DefaultController : Controller
    {
        private const string DB_CONN = "server=192.168.1.253;uid=root;pwd=Passw0rd;database=servicedesk;";

        public ActionResult Index()
        {
            try
            {
                var conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = DB_CONN;
                conn.Open();
            }
            catch (Exception) { }
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