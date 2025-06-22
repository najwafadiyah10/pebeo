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
using static pebeo.User_Control.Jadwal;
using pebeo.Dashboard;

namespace pebeo.User_Control
{
    public partial class Jenis : UserControl
    {
        public Jenis()
        {
            InitializeComponent();
            this.Load += Jenis_Load;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void Jenis_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    string query = "SELECT id_jenis, nama FROM jenis_sampah";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data jenis sampah: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void tbdeskripsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadSetoranTerakhir()
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();

                    string query = @"SELECT j.hari, j.jam, js.nama, s.deskripsi, st.status
                             FROM setor_sampah s
                             JOIN jadwal_pengambilan j ON s.id_jadwal = j.id_jadwal
                             JOIN jenis_sampah js ON s.id_jenis = js.id_jenis
							 join status_pengambilan st on s.id_status=st.id_status
                             WHERE s.id_warga = @id_warga ORDER BY s.id_setor DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);
                        var dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }


        private void btnsimpan_Click(object sender, EventArgs e)
        {
            try
            {

                int idJenis = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jenis"].Value);
                TempData.IdJenisDipilih = idJenis;


                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();

                    string insertQuery = @"INSERT INTO setor_sampah 
            (id_jadwal, id_warga, id_jenis, deskripsi, id_status) 
            VALUES (@id_jadwal, @id_warga, @id_jenis, @deskripsi, @id_status)";

                    using (var cmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_jadwal", TempData.IdJadwalDipilih);
                        cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);
                        cmd.Parameters.AddWithValue("@id_jenis", TempData.IdJenisDipilih);
                        cmd.Parameters.AddWithValue("@deskripsi", (object)tbdeskripsi.Text ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_status", 1); 

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil disimpan!");
                LoadSetoranTerakhir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }

        }

     
    }


}
