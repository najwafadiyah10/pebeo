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
using pebeo.Dashboard;

namespace pebeo.User_Control
{
    public partial class LihatStatuscs : UserControl
    {
        public LihatStatuscs()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dataGridView1);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            DashboardWarga dbwarga = new DashboardWarga();
            dbwarga.Show();
            this.Hide();
        }

        private void LihatStatuscs_Load(object sender, EventArgs e)
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
        }
    }
}
