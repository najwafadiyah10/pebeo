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
            //if (e.RowIndex >= 0)
            //{
            //    int idJenis = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_jenis"].Value);
            //    TempData.IdJenisDipilih = idJenis;
            //}
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
                        cmd.Parameters.AddWithValue("@id_status", 1); // default: belum diambil

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

            //if (TempData.IdJenisDipilih == 0)
            //{
            //    MessageBox.Show("Pilih jenis sampah terlebih dahulu!");
            //    return;
            //}


            //sblm datatemp dipisah
            //int idJadwal = TempData.IdJadwalDipilih;
            //int idWarga = TempData.IdWarga;
            //int idJenis = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jenis"].Value);
            //TempData.IdJenis = idJenis;
            //// atau .SelectedItem
            //string deskripsi = tbdeskripsi.Text;

            //if (idJadwal == 0 || idJenis == 0)
            //{
            //    MessageBox.Show("Pilih jenis dan jadwal terlebih dahulu.");
            //    return;
            //}

            //using (var conn = new NpgsqlConnection(Database.connString))
            //{
            //    conn.Open();
            //    string insert = @"INSERT INTO setor_sampah 
            //              (id_jadwal, id_warga, id_jenis, deskripsi, id_status) 
            //              VALUES (@id_jadwal, @id_warga, @id_jenis, @deskripsi, @id_status)";
            //    using (var cmd = new NpgsqlCommand(insert, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@id_jadwal", idJadwal);
            //        cmd.Parameters.AddWithValue("@id_warga", idWarga);
            //        cmd.Parameters.AddWithValue("@id_jenis", idJenis);
            //        cmd.Parameters.AddWithValue("@deskripsi", (object)deskripsi ?? DBNull.Value);
            //        cmd.Parameters.AddWithValue("@id_status", 1);
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            //MessageBox.Show("Data berhasil disimpan ke setor sampah.");
            //TempData.Clear();


            //// Kembali ke halaman utama
            //DashboardWarga form = this.FindForm() as DashboardWarga;
            //if (form != null)
            //{
            //    form.ShowControl(new DashboardWarga()); // ganti dengan UC tujuan
            //}

            //            try
            //            {
            //                using (var conn = new NpgsqlConnection(Database.connString))
            //                {
            //                    conn.Open();

            //                    string insertQuery = @"""UPDATE setor_sampah 
            //SET id_jenis = @id_jenis, deskripsi = @deskripsi 
            //WHERE id_jadwal = @id_jadwal AND id_warga = @id_warga"";
            //";

            //                    using (var cmd = new NpgsqlCommand(insertQuery, conn))
            //                    {



            //                        cmd.Parameters.AddWithValue("@id_jadwal", TempData.IdJadwalDipilih);
            //                        cmd.Parameters.AddWithValue("@id_jenis", TempData.IdJenisDipilih);

            //                        //cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);
            //                        //cmd.Parameters.AddWithValue("@id_jadwal", int.Parse(cmbJadwal.SelectedValue.ToString()));
            //                        //cmd.Parameters.AddWithValue("@id_jenis", int.Parse(cmbJenis.SelectedValue.ToString()));
            //                        //cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);
            //                        //cmd.Parameters.AddWithValue("@status", "menunggu");

            //                        cmd.ExecuteNonQuery();
            //                    }

            //                    MessageBox.Show("Data berhasil disimpan!");

            //                    // Refresh DataGridView
            //                    LoadSetoranTerakhir(); // Buat method ini untuk SELECT terbaru
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            //            }








            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int idJenis = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jenis"].Value);
            //    string deskripsi = tbdeskripsi.Text.Trim();

            //    TempData.IdJenisDipilih = idJenis;
            //    TempData.Deskripsi = deskripsi;

            //    SimpanKeDatabase();
            //    ((DashboardWarga)this.ParentForm).ShowControl(new SetorSampah());
            //    // pindah ke usercontrol ringkasan
            //}
            //else
            //{
            //    MessageBox.Show("Pilih salah satu jenis sampah terlebih dahulu.");
            //}

            //MessageBox.Show("Debug:\nID Warga = " + Session.LoggedWargaId +
            //    "\nID Jadwal = " + TempData.IdJadwalDipilih +
            //    "\nID Jenis = " + TempData.IdJenisDipilih +
            //    "\nDeskripsi = " + TempData.Deskripsi);

            ////MessageBox.Show("ID Jadwal: " + IdJadwalDipilih);




        }

        //        private void SimpanKeDatabase()
        //        {
        //            try
        //            {
        //                using (var conn = new NpgsqlConnection(Database.connString))
        //                {
        //                    conn.Open();
        //                    string insertQuery = @"UPDATE setor_sampah 
        //SET id_jenis = @id_jenis, deskripsi = @deskripsi 
        //WHERE id_jadwal = @id_jadwal AND id_warga = @id_warga";


        //                    using (var cmd = new NpgsqlCommand(insertQuery, conn))
        //                    {
        //                        cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);
        //                        cmd.Parameters.AddWithValue("@id_jadwal", TempData.IdJadwalDipilih);
        //                        cmd.Parameters.AddWithValue("@id_jenis", TempData.IdJenisDipilih);
        //                        cmd.Parameters.AddWithValue("@deskripsi", (object)TempData.Deskripsi ?? DBNull.Value);

        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Gagal menyimpan ke database: " + ex.Message);
        //            }
        //        }

    }

    //public static class TempData
    //{
    //    public static int IdJenis;
    //    public static int IdWarga => Session.LoggedWargaId;  // Shortcut

    //    public static void Clear()
    //    {
    //        IdJenis = 0;
    //    }
    //}
}
