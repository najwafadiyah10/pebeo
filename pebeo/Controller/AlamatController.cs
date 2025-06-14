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
        // Gunakan string koneksi dari kelas Database yang sudah kamu buat sebelumnya
        private static string connString = Database.connString;

        // Ambil data dusun
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

        // Ambil data jalan berdasarkan ID dusun
        public static DataTable GetJalanByDusun(int id_dusun)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM jalan WHERE id_dusun = @id_dusun";
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_dusun", id_dusun);
                //cmd.Parameters.AddWithValue("@nama_dusun", nama_dusun);
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
                //cmd.Parameters.AddWithValue("@nama_dusun", nama_dusun);
                var da = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
