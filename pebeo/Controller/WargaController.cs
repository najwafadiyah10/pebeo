using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pebeo.Controller
{
    
        public static class WargaController
        {
            public static bool RegisterWarga(string username, string password, string nama, string noTelp)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(Database.connString))
                    {
                        conn.Open();
                        string query = "INSERT INTO warga (username, password, nama, no_telp) VALUES (@username, @password, @nama, @noTelp)";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@noTelp", noTelp);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            return rowsAffected > 0; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saat register warga: " + ex.Message);
                    return false;
                }
            }
        }
    }
