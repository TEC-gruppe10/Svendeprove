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

        private static MySqlConnection DefaultConnection()
        {
            var conn = new MySqlConnection();
            conn.ConnectionString = DB_CONN;

            return conn;
        }

        public static List<string[]> GetValuesAsStrings(string sqlcmd, int columns)
        {            
            using (var conn = DefaultConnection())
            {
                var cmd = new MySqlCommand(sqlcmd, conn);                
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    return null;

                var list = new List<string[]>();

                while (reader.Read())
                {
                    var array = new string[columns];
                    for (int i = 0; i < columns; i++)
                    {
                        array[i] = SafeGetString(reader, i);
                    }
                    list.Add(array);
                }

                reader.Close();
                return list;
            }
        }

        public static void SQLNonQuery(string sqlcmd)
        {
            var conn = new MySqlConnection();
            var cmd = new MySqlCommand(sqlcmd, conn);
            conn.ConnectionString = DB_CONN;
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}