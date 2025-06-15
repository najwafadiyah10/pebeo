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

namespace pebeo.User_Control
{
    public partial class JadwalPengolah : UserControl
    {
        public JadwalPengolah()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM view_jadwal_urut_hari"; // ganti kalau nama tabel beda
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        var adapter = new NpgsqlDataAdapter(cmd);
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt; // ganti sesuai nama DataGridView kamu
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // misal kolom ke-0 itu tombol hapus
            {
                int idJadwal = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_jadwal"].Value);

                var confirm = MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(Database.connString))
                        {
                            conn.Open();
                            string query = "DELETE FROM jadwal_pengambilan WHERE id_jadwal = @id";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idJadwal);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh data setelah hapus
                        LoadData(); // buat method ini seperti Jadwal_Load isinya ambil data
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus: " + ex.Message);
                    }
                }
            }
        }

        private void JadwalPengolah_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM view_jadwal_urut_hari";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        var adapter = new NpgsqlDataAdapter(cmd);
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ambil baris yang dipilih
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Ambil id_jadwal dari baris itu
                int idJadwal = Convert.ToInt32(selectedRow.Cells["id_jadwal"].Value);

                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(Database.connString))
                        {
                            conn.Open();
                            string query = "DELETE FROM jadwal_pengambilan WHERE id_jadwal = @id";
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idJadwal);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh tabel
                        LoadData();

                        MessageBox.Show("Data berhasil dihapus.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih dulu baris yang ingin dihapus.");
            }
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;


                        // Karena View, kolom id_jadwal mungkin tidak bisa dideteksi sebagai null, jadi sebaiknya cek dengan cara lain
                        if (row.Cells["id_jadwal"].Value == null || string.IsNullOrEmpty(row.Cells["id_jadwal"].Value.ToString()))
                        {
                            string hari = row.Cells["hari"].Value?.ToString();
                            string jamStr = row.Cells["jam"].Value?.ToString();

                            if (!string.IsNullOrEmpty(hari) && !string.IsNullOrEmpty(jamStr))
                            {
                                using (var cmd = new NpgsqlCommand("INSERT INTO jadwal_pengambilan (hari, jam) VALUES (@hari, @jam)", conn))
                                {
                                    cmd.Parameters.AddWithValue("@hari", hari);
                                    cmd.Parameters.AddWithValue("@jam", TimeSpan.Parse(jamStr));
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Data berhasil ditambahkan.");
                LoadData(); // reload dari View agar tetap urut
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }
        }

    }
}


