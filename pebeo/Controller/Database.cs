using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace pebeo.Controller

//namespace SampahApp.Controllers
{
    public class Database
    {
        private static string connString = "Host=localhost;Username=postgres;Password=jungkook;Database=projekpbo";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}


//{ 
//public class Database
//{
//private static string localhost = "localhost";
//private static string port = "5432";
//private static string username = "postgres";
//private static string password = "jungkook";
//private static string database = "projekpbo";

////private static NpgsqlConnection conn;

//public static NpgsqlConnection GetConnection()
//{
//    if (conn == null)
//    {
//        string connString = $"Host={localhost};Port={port};Username={username};Password={password};Database={database}";
//    }
//    public static NpgsqlConnection GetConnection()
//    {
//    return new NpgsqlGetConnection(connString);
//        //conn = new NpgsqlConnection(connString);
//    }
//    //return conn;
//}

////public static void CloseConnection()
//{
//    if (conn != null)
//    {
//        conn.Close();
//        conn = null;
//    }
//}
//}
//}

