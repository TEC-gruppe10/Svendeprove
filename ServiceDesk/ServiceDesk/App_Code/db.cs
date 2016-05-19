using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDesk
{
    public static class db
    {
        public const string DB_CONN = "server=192.168.1.253;uid=root;pwd=Passw0rd;database=servicedesk;";

        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }

        public static string[] GetValuesAsStrings(string sqlcmd, int columns)
        {
            var conn = new MySqlConnection();
            var cmd = new MySqlCommand(sqlcmd, conn);
            conn.ConnectionString = DB_CONN;
            conn.Open();
            var reader = cmd.ExecuteReader();
            var array = new string[columns];
            while (reader.Read())
            {
                for (int i = 0; i < columns; i++)
                {
                    array[i] = SafeGetString(reader, i);
                }
            }
            return array;
        }
    }
}