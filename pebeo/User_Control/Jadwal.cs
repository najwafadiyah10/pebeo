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

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnpilih_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idJadwal = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_jadwal"].Value);
                TempData.IdJadwalDipilih = idJadwal;

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
    }
}
