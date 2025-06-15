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
using pebeo.View;
using static System.Collections.Specialized.BitVector32;

namespace pebeo.User_Control
{
    public partial class Jadwal : UserControl
    {
        public Jadwal()
        {
            InitializeComponent();
        }

        //private void LoadData()
        //{
        //    try
        //    {
        //        using (var conn = new NpgsqlConnection(Database.connString))
        //        {
        //            conn.Open();
        //            string query = "SELECT * FROM jadwal_pengambilan"; // ganti kalau nama tabel beda
        //            using (var cmd = new NpgsqlCommand(query, conn))
        //            {
        //                var adapter = new NpgsqlDataAdapter(cmd);
        //                var dt = new DataTable();
        //                adapter.Fill(dt);
        //                dataGridView1.DataSource = dt; // ganti sesuai nama DataGridView kamu
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Gagal memuat data: " + ex.Message);
        //    }
        //}


        private void Jadwal_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM jadwal_pengambilan"; // ganti sesuai nama tabelmu
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        var adapter = new NpgsqlDataAdapter(cmd);
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt; // pastikan nama dataGridView sesuai
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data jadwal: " + ex.Message);
            }
        }

        //        private void ShowControl(UserControl uc)
        //{
        //    panel2.Controls.Clear();      // kosongkan panel2
        //    uc.Dock = DockStyle.Fill;     // biar full
        //    panel2.Controls.Add(uc);      // tambahkan ke panel2
        //    uc.BringToFront();            // tampilkan paling depan
        //}

        //public static class Session
        //{
        //    public static int LoggedWargaId { get; set; }
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnPilih")
            //{
            //    int id_jadwal = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_jadwal"].Value);
            //    TempData.IdJadwalDipilih = id_jadwal;
            //    DialogResult result = MessageBox.Show("Yakin pilih jadwal ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        // Simpan ke tabel setor_sampah
            //        int id_warga = Session.LoggedWargaId;

            //        using (var conn = new NpgsqlConnection(Database.connString))
            //        {
            //            conn.Open();
            //            string insert = "INSERT INTO setor_sampah (id_jadwal, id_warga, id_status) VALUES (@id_jadwal, @id_warga, @id_status)";
            //            using (var cmd = new NpgsqlCommand(insert, conn))
            //            {
            //                cmd.Parameters.AddWithValue("@id_jadwal", id_jadwal);
            //                cmd.Parameters.AddWithValue("@id_warga", id_warga);
            //                cmd.Parameters.AddWithValue("@id_status", 1); // misalnya 1 = 'belum diambil'
            //                cmd.ExecuteNonQuery();
            //            }
            //        }
            //    }
            //}






            //if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "btnPilih")
            //{
            //    int idJadwal = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_jadwal"].Value);

            //    // Simpan id jadwal terpilih ke variabel global (misalnya di kelas Session)
            //    Session.SelectedJadwalId = idJadwal;

            //    // Tampilkan form untuk memilih jenis sampah
            //    FormPilihJenisSampah formJenis = new FormPilihJenisSampah();
            //    formJenis.Show();
            //}


            //if (e.RowIndex >= 0 && e.ColumnIndex == 0) // misal kolom ke-0 itu tombol hapus
            //{
            //    int idJadwal = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_jadwal"].Value);

            //    var confirm = MessageBox.Show("Yakin pilih jadwal ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            //    if (confirm == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            using (var conn = new NpgsqlConnection(Database.connString))
            //            {
            //                conn.Open();
            //                string query = "DELETE FROM jadwal_pengambilan WHERE id_jadwal = @id";
            //                using (var cmd = new NpgsqlCommand(query, conn))
            //                {
            //                    cmd.Parameters.AddWithValue("@id", idJadwal);
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }

            //            // Refresh data setelah hapus
            //            LoadData(); // buat method ini seperti Jadwal_Load isinya ambil data
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Gagal menghapus: " + ex.Message);
            //        }
            //    }

            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //private void ShowControl(UserControl uc)
        //{
        //    Jadwal.Controls.Clear();      // kosongkan panel2
        //    uc.Dock = DockStyle.Fill;     // biar full
        //    panel2.Controls.Add(uc);      // tambahkan ke panel2
        //    uc.BringToFront();            // tampilkan paling depan
        //}

        private void btnpilih_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idJadwal = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jadwal"].Value);
                TempData.IdJadwalDipilih = idJadwal;

                // Arahkan ke UserControl Jenis
                DashboardWarga form = this.FindForm() as DashboardWarga;
                if (form != null)
                {
                    Jenis jenis = new Jenis();
                    form.ShowControl(jenis);
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu jadwal terlebih dahulu.");
            }
        }

            //sebelum tempdata dipisah
            //int idJadwal = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jadwal"].Value);
            //TempData.IdJadwalDipilih = idJadwal;

            //// Arahkan ke Jenis
            //DashboardWarga form = this.FindForm() as DashboardWarga;
            //if (form != null)
            //{
            //    Jenis jenis = new Jenis();
            //    form.ShowControl(jenis);
            //}







            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int idJadwal = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jadwal"].Value);
            //    TempData.IdJadwalDipilih = idJadwal;

            //    // Insert ke setor_sampah juga kalau perlu
            //    using (var conn = new NpgsqlConnection(Database.connString))
            //    {
            //        conn.Open();
            //        string insert = "INSERT INTO setor_sampah (id_jadwal, id_warga, id_status) VALUES (@id_jadwal, @id_warga, @id_status)";
            //        using (var cmd = new NpgsqlCommand(insert, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@id_jadwal", idJadwal);
            //            cmd.Parameters.AddWithValue("@id_warga", Session.LoggedWargaId);
            //            cmd.Parameters.AddWithValue("@id_status", 1);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //    DashboardWarga form = this.FindForm() as DashboardWarga;
            //    if (form != null)
            //    {
            //        Jenis jenis = new Jenis();
            //        form.ShowControl(jenis);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Pilih salah satu jadwal terlebih dahulu.");
            //}
            //DashboardWarga form = this.FindForm() as DashboardWarga;
            //if (form != null)
            //{
            //    Jenis jenis = new Jenis();  // buat usercontrol Jenis
            //    form.ShowControl(jenis);    // tampilkan Jenis ke panel2
            //}


            //Jenis jenis = new Jenis();  // Buat instance user control
            //ShowControl(jenis);
            //if (!dataGridView1.Columns.Contains("Pilih"))
            //{
            //    //Jadwal.Controls.Clear();
            //    //Jenis uc = new Jenis(); // UserControl Jenis
            //    //this.Parent.Controls.Add(uc);

            //    Jenis jenis = new Jenis();  // Buat instance user control
            //    ShowControl(jenis);
            //}
        

        //public static class TempData
        //{
        //    public static int IdJadwalDipilih;
        //    public static int IdWarga => Session.LoggedWargaId;

        //    public static void Clear()
        //    {
        //        IdJadwalDipilih = 0;
        //    }
        //}



    }
}
