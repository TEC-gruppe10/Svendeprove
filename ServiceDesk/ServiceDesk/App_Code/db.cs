using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ServiceDesk
{
    public static class db
    {
        public const string DB_CONN = "server=192.168.1.253;uid=root;pwd=Passw0rd;database=servicedesk;";


        #region SafeGetString
        /// <summary>
        /// Used to safely get string values from sql data reader. Returns empty strings if null.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }
        #endregion

        #region DefaultConnection
        /// <summary>
        /// Used to establish a default connection
        /// </summary>
        /// <returns></returns>
        private static MySqlConnection DefaultConnection()
        {
            var conn = new MySqlConnection();
            conn.ConnectionString = DB_CONN;

            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            

            return conn;
        }
        #endregion

        #region GetValuesAsStrings
        /// <summary>
        /// Used to extract values from db as strings. Null values will be empty strings.
        /// Need a column count to work.
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static List<string[]> GetValuesAsStrings(string sqlcmd, int columns)
        {            
            using (var conn = DefaultConnection())
            {
                if (conn == null)
                    return new List<string[]>();

                var cmd = new MySqlCommand(sqlcmd, conn);     

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

        public async static Task<List<string[]>> GetValuesAsStringsAsync(string sqlcmd, int columns)
        {
            using (var conn = DefaultConnection())
            {
                var cmd = new MySqlCommand(sqlcmd, conn);
                await conn.OpenAsync();

                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    return null;

                var list = new List<string[]>();

                while (await reader.ReadAsync())
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
        #endregion

        #region SQLNonQuery
        /// <summary>
        /// Executes a query that does not return results
        /// </summary>
        /// <param name="sqlcmd"></param>
        public static void SQLNonQuery(string sqlcmd)
        {
            using (var conn = DefaultConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(sqlcmd, conn);
                cmd.ExecuteNonQuery();
            }
            
        }
        #endregion

        #region CheckUser
        /// <summary>
        /// Check for valid user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int CheckUser(string email, string password)
        {
            var sqlcmd = "SELECT type FROM bruger WHERE email = '";
            sqlcmd += email;
            sqlcmd += "' and password = '";
            sqlcmd += password;
            sqlcmd += "' LIMIT 0,1";

            using (var conn = DefaultConnection())
            {
                if (conn == null)
                    return 0;

                var cmd = new MySqlCommand(sqlcmd, conn);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return reader.GetUInt16(0) == 0 ? 1 : 2;
                }
                else
                {
                    sqlcmd = "SELECT id FROM kunder WHERE email = '";
                    sqlcmd += email;
                    sqlcmd += "' and password = '";
                    sqlcmd += password;
                    sqlcmd += "' LIMIT 0,1";
                    reader.Close();
                    cmd.Dispose();
                    reader.Dispose();
                    cmd = new MySqlCommand(sqlcmd, conn);
                    reader = cmd.ExecuteReader();
                    return reader.HasRows ? 3 : 0;
                }
            }
        }
        #endregion


    }
}