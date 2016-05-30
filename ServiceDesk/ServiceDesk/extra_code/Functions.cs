using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDesk.extra_code
{
    public static class Functions
    {
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
    }
}