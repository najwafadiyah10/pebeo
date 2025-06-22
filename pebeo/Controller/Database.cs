using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace pebeo.Controller
{
    public class Database
    {
        public static string connString = "Host=localhost;Username=postgres;Password=jungkook;Database=projekpbo";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}