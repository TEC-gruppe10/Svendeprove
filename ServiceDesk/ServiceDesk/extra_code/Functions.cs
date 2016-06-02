using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ServiceDesk
{
    public static class Functions
    {
        public static string SELECTuser = "SELECT `id`, `fornavn`, `efternavn`, `telefon`, `type`, `email` FROM `bruger` LIMIT 0, 100";

        public static void select(string data)
        {
            
        }

        public static void CreateUser(string data)
        {
            string SQLComm = "Insert into bruger (fornavn,efternavn,password,telefon,type,email) VALUES (" + data + ")";
            db.SQLNonQuery(SQLComm);
        }

        public static void Deleteuser(int id)
        {
            string SQLComm = "Delete from brugere where id=" + id;
            db.SQLNonQuery(SQLComm);
        }

        public static MySqlConnection test()
        {
            var conn = new MySqlConnection();
            conn.ConnectionString = db.DB_CONN;

            return conn;
        }
    }
}