using System;
using Npgsql;
using pebeo.Controller;
using pebeo.Models;

namespace pebeo.Controllers
{ 

//using Npgsql;
//using SampahApp.Models;

namespace SampahApp.Controllers
{
        public class AkunController
        {
            public Akun Login(string username, string password)
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Cek Warga
                    var cmd = new NpgsqlCommand("SELECT * FROM warga WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPass = reader.GetString(reader.GetOrdinal("password"));
                            var warga = new Warga(
                                //id: reader.GetInt32(reader.GetOrdinal("warga_id")),
                                username: username,
                                password: dbPass,
                                nama: reader.GetString(reader.GetOrdinal("nama")),
                                //alamat: reader.GetString(reader.GetOrdinal("alamat")),
                                noTelp: reader.GetString(reader.GetOrdinal("no_telp"))
                            );

                            if (warga.CekPassword(password))
                                return warga;
                        }
                    }

                    // Cek Pengolah
                    cmd = new NpgsqlCommand("SELECT * FROM pengolah WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPass = reader.GetString(reader.GetOrdinal("password"));
                            var pengolah = new Pengolah(
                                //id: reader.GetInt32(reader.GetOrdinal("pengolah_id")),
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
                    INSERT INTO warga (username, password, nama, no_telp)
                    VALUES (@username, @password, @nama, @no_telp)", conn);

                    cmd.Parameters.AddWithValue("username", warga.Username);
                    cmd.Parameters.AddWithValue("password", warga.GetPassword()); // Jika kamu pakai getter
                    cmd.Parameters.AddWithValue("nama", warga.NamaLengkap);
                    //cmd.Parameters.AddWithValue("a", warga.Alamat);
                    cmd.Parameters.AddWithValue("no_telp", warga.NoTelepon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }
    }
}
//{
//    public class AkunController
//    {
//        // === LOGIN (bisa warga atau pengolah) ===
//        public Akun Login(string username, string password)
//        {
//            using (var conn = Database.GetConnection())
//            {
//                conn.Open();

//                // Coba login sebagai Warga
//                var cmdWarga = new NpgsqlCommand(@"
//                    SELECT id_warga, nama, no_telp
//                    FROM warga 
//                    WHERE username = @username AND password = @password", conn);
//                cmdWarga.Parameters.AddWithValue("username", username);
//                cmdWarga.Parameters.AddWithValue("password", password);

//                using (var reader = cmdWarga.ExecuteReader())
//                {
//                    if (reader.Read())
//                    {
//                        return new Warga(
//                            id: reader.GetInt32(0),
//                            username: username,
//                            password: password,
//                            nama: reader.GetString(1),
//                            noTelepon: reader.GetString(2)
//                        );
//                    }
//                }

//                // Coba login sebagai Pengolah
//                var cmdPengolah = new NpgsqlCommand(@"
//                    SELECT id_pengolah
//                    FROM pengolah 
//                    WHERE username = @username AND password = @password", conn);
//                cmdPengolah.Parameters.AddWithValue("username", username);
//                cmdPengolah.Parameters.AddWithValue("password", password);

//                using (var reader = cmdPengolah.ExecuteReader())
//                {
//                    if (reader.Read())
//                    {
//                        return new Pengolah(
//                            id: reader.GetInt32(0),
//                            username: username,
//                            password: password
//                        );
//                    }
//                }
//            }

//            return null; // Login gagal
//        }

//        // === REGISTER WARGA ===
//        public bool RegisterWarga(Warga warga)
//        {
//            using (var conn = Database.GetConnection())
//            {
//                conn.Open();

//                // Cek apakah username sudah ada
//                var checkCmd = new NpgsqlCommand("SELECT 1 FROM warga WHERE username = @username", conn);
//                checkCmd.Parameters.AddWithValue("username", warga.Username);
//                var exists = checkCmd.ExecuteScalar();
//                if (exists != null)
//                {
//                    return false; // Username sudah digunakan
//                }

//                // Tambahkan ke tabel warga
//                var cmd = new NpgsqlCommand(@"
//                    INSERT INTO warga (username, password, nama_lengkap, no_telepon)
//                    VALUES (@username, @password, @nama, @no_telp)", conn);
//                cmd.Parameters.AddWithValue("u", warga.Username);
//                cmd.Parameters.AddWithValue("p", warga.Password);
//                cmd.Parameters.AddWithValue("n", warga.NamaLengkap);
//                cmd.Parameters.AddWithValue("t", warga.NoTelepon);

//                return cmd.ExecuteNonQuery() > 0;
//            }
//        }
//    }
//}