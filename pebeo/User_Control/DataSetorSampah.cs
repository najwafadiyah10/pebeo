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
    public partial class DataSetorSampah : UserControl
    {
        public DataSetorSampah()
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
                    string query = "SELECT * FROM setor_sampah"; // ganti kalau nama tabel beda
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

        }

        private void DataSetorSampah_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    string query = @"
                
                    SELECT 
                     ss.id_setor,
                     w.nama,
                     j.hari || ' ' || j.jam AS jadwal,
                     js.nama,
                     ss.deskripsi, nr.nomor_rumah, 
	                 ja.nama_jalan||', '||d.nama_dusun as Alamat
                     FROM setor_sampah ss
                     JOIN warga w ON ss.id_warga = w.id_warga
                     JOIN jadwal_pengambilan j ON ss.id_jadwal = j.id_jadwal
                     JOIN jenis_sampah js ON ss.id_jenis = js.id_jenis
                     join nomor_rumah nr on w.id_nomor_rumah=nr.id_nomor_rumah
                     join jalan ja on nr.id_jalan=ja.id_jalan
                     join dusun d on ja.id_dusun=d.id_dusun

                        ";


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
    }
    }

