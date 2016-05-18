using MySql.Data.MySqlClient;
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

        public string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }

        public ActionResult Index()
        {
            var conn = new MySqlConnection();
            var cmd = new MySqlCommand("SELECT * FROM `bruger` LIMIT 0 , 30", conn);
            conn.ConnectionString = DB_CONN;
            conn.Open();
            var reader = cmd.ExecuteReader();
            int i = 0;
            var users = new List<string>();
            while (reader.Read())
            {
                users.Add(SafeGetString(reader, i));
                users.Add(SafeGetString(reader, i + 1));
                users.Add(SafeGetString(reader, i + 2));
                users.Add(SafeGetString(reader, i + 3));
                users.Add(SafeGetString(reader, i + 4));
                users.Add(SafeGetString(reader, i + 5));
                users.Add(SafeGetString(reader, i + 6));
                i++;
            }
            ViewBag.users = users;


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