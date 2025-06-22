using System;
using Npgsql;
using pebeo.Controller;
using pebeo.Models;

namespace pebeo.Controllers
{ 

namespace SampahApp.Controllers
{
        public class AkunController
        {
            public Akun Login(string username, string password)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand("SELECT * FROM warga WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPass = reader.GetString(reader.GetOrdinal("password"));
                            var warga = new Warga(
                                username: username,
                                password: dbPass,
                                nama: reader.GetString(reader.GetOrdinal("nama")),
                                noTelp: reader.GetString(reader.GetOrdinal("no_telp")),
                                norumah: reader.GetInt32(reader.GetOrdinal("id_nomor_rumah"))

                            );

                            if (warga.CekPassword(password))
                                return warga;
                        }
                    }

                    cmd = new NpgsqlCommand("SELECT * FROM pengolah WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPass = reader.GetString(reader.GetOrdinal("password"));
                            var pengolah = new Pengolah(
                                username: username,
                                password: dbPass
                            );

                            if (pengolah.CekPassword(password))
                                return pengolah;
                        }
                    }
                }

                return  null;
            }

            public bool RegisterWarga(Warga warga)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand(@"
                    INSERT INTO warga (username, password, nama, no_telp, id_nomor_rumah)
                    VALUES (@username, @password, @nama, @no_telp, @id_nomor_rumah)", conn);

                    cmd.Parameters.AddWithValue("username", warga.Username);
                    cmd.Parameters.AddWithValue("password", warga.GetPassword()); 
                    cmd.Parameters.AddWithValue("nama", warga.NamaLengkap);
                    cmd.Parameters.AddWithValue("no_telp", warga.NoTelepon);
                    cmd.Parameters.AddWithValue("id_nomor_rumah", warga.noRumah);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }
    }
}
