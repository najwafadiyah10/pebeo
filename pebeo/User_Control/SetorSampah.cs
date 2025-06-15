using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using pebeo.Controller;
using pebeo.User_Control;

namespace pebeo.User_Control
{
    public partial class SetorSampah : UserControl
    {
        public SetorSampah()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dataGridView1);
        }


        private void SetorSampah_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();

                    string query = @"
                SELECT j.hari, j.jam, js.nama AS nama_jenis, s.deskripsi, st.status AS status
                FROM setor_sampah s
                JOIN jadwal_pengambilan j ON s.id_jadwal = j.id_jadwal
                JOIN jenis_sampah js ON s.id_jenis = js.id_jenis
                JOIN status_pengambilan st ON s.id_status = st.id_status
                WHERE s.id_warga = @id_warga
                ORDER BY s.id_setor DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);

                        var dt = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }

            //            try
            //            {
            //                using (var conn = new NpgsqlConnection(Database.connString))
            //                {
            //                    conn.Open();

            //                    string query = @"SELECT j.hari, j.jam, js.nama AS nama_jenis, s.deskripsi, st.nama_status
            //FROM setor_sampah s
            //JOIN jadwal_pengambilan j ON s.id_jadwal = j.id_jadwal
            //JOIN jenis_sampah js ON s.id_jenis = js.id_jenis
            //JOIN status_setor st ON s.id_status = st.id_status
            //WHERE s.id_warga = @id_warga
            //ORDER BY s.id_setor DESC;
            //";

            //                    using (var cmd = new NpgsqlCommand(query, conn))
            //                    {
            //                        cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);

            //                        var dt = new DataTable();
            //                        using (var adapter = new NpgsqlDataAdapter(cmd))
            //                        {
            //                            adapter.Fill(dt);
            //                        }

            //                        // ✅ Tampilkan isi tabel ke datagrid
            //                        dataGridView1.DataSource = dt;

            //                        // ✅ Debug: tampilkan info kalau ada data
            //                        if (dt.Rows.Count > 0)
            //                        {
            //                            var row = dt.Rows[0];
            //                            string hari = row["hari"].ToString();
            //                            string jam = row["jam"].ToString();
            //                            string jenis = row["nama_jenis"].ToString();
            //                            string deskripsi = row["deskripsi"].ToString();
            //                            string status = row["status"].ToString();

            //                            MessageBox.Show($"Hari: {hari}\nJam: {jam}\nJenis: {jenis}\nDeskripsi: {deskripsi}");
            //                        }
            //                        else
            //                        {
            //                            MessageBox.Show("Tidak ada data yang ditemukan.");
            //                        }
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Gagal memuat ringkasan: " + ex.Message);
            //            }






















            //try
            //{
            //    using (var conn = new NpgsqlConnection(Database.connString))
            //    {
            //        conn.Open();

            //        string query = @"SELECT j.hari, j.jam, js.nama, s.deskripsi
            //                 FROM setor_sampah s
            //                 JOIN jadwal_pengambilan j ON s.id_jadwal = j.id_jadwal
            //                 JOIN jenis_sampah js ON s.id_jenis = js.id_jenis
            //                 WHERE s.id_warga = @id_warga ORDER BY s.id_setor DESC LIMIT 1";

            //        using (var cmd = new NpgsqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);
            //            using (var reader = cmd.ExecuteReader())
            //            {
            //                if (reader.Read())
            //                {
            //                    string hari = reader["hari"].ToString();
            //                    string jam = reader["jam"].ToString();
            //                    string jenis = reader["nama_jenis"].ToString();
            //                    string deskripsi = reader["deskripsi"].ToString();
            //                    string status = reader["status"].ToString();

            //                    MessageBox.Show($"Hari: {hari}\nJam: {jam}\nJenis: {jenis}\nDeskripsi: {deskripsi}\nStatus: {status}");

            //                    var dt = new DataTable();
            //                    new NpgsqlDataAdapter(cmd).Fill(dt);
            //                    dataGridView1.DataSource = dt;
            //                }

            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message);
            //}
        }
    }
}
