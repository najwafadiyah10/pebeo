using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pebeo.Controller
{
    public class AlamatController
    {
        private static string connString = Database.connString;

        
        public static DataTable GetDusun()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT id_dusun, nama_dusun from dusun";
                var cmd = new NpgsqlCommand(query, conn);
                var da = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetJalanByDusun(int id_dusun)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM jalan WHERE id_dusun = @id_dusun";
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_dusun", id_dusun);
                var da = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetNoRumah(int id_jalan)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM nomor_rumah WHERE id_jalan = @id_jalan";
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_jalan", id_jalan);
                var da = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
