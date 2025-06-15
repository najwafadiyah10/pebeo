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
    public partial class UpdateStatus : UserControl
    {
        public UpdateStatus()
        {
            InitializeComponent();
            LoadData(this, EventArgs.Empty);
        }








    private void SetupDataGridView()
    {
            // Hapus dulu kolom status lama jika ada
            if (dataGridView1.Columns.Contains("status"))
                dataGridView1.Columns.Remove("status");

            // Buat ComboBox column
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "status";
            statusColumn.HeaderText = "Status";
            statusColumn.DataPropertyName = "id_status"; // kolom dari database
            statusColumn.DisplayMember = "Value";
            statusColumn.ValueMember = "Key";

            // Tambahkan pilihan status
            statusColumn.Items.Add(new KeyValuePair<int, string>(1, "Belum"));
            statusColumn.Items.Add(new KeyValuePair<int, string>(2, "Sudah"));

            dataGridView1.Columns.Add(statusColumn);
    }



        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "statusComboBox")
            {
                try
                {
                    int idSetor = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_setor"].Value);
                    int idStatusBaru = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["statusComboBox"].Value);

                    UpdateStatusKeDatabase(idSetor, idStatusBaru);

                    // (Opsional) Update kolom teks kalau kamu masih pakai kolom "status"
                    if (dataGridView1.Columns.Contains("status"))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["status"].Value = GetStatusTextById(idStatusBaru);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update status: " + ex.Message);
                }
            }
        
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "status")
            //{
            //    int idSetor = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_setor"].Value);
            //    var selectedStatus = (KeyValuePair<int, string>)dataGridView1.Rows[e.RowIndex].Cells["status"].Value;

            //    int idStatusBaru = selectedStatus.Key;

            //    UpdateStatusKeDatabase(idSetor, idStatusBaru);
            //}
        }




        private void UpdateStatusKeDatabase(int idSetor, int idStatus)
        {
            using (var conn = new NpgsqlConnection(Database.connString))
            {
                conn.Open();
                string query = "UPDATE setor_sampah SET id_status = @status WHERE id_setor = @id_setor";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_setor", idSetor);
                    cmd.Parameters.AddWithValue("@status", idStatus);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //    using (var conn = new NpgsqlConnection(Database.connString))
        //    {
        //        conn.Open();
        //        string query = "UPDATE setor_sampah SET id_status = @status WHERE id_setor = @id";

        //        using (var cmd = new NpgsqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@id", idSetor);
        //            cmd.Parameters.AddWithValue("@status", idStatus);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
        //private void UpdateStatusKeDatabase(int idSetor, int idStatus)

        //{
        //    string connString = Database.connString;

        //    using (var conn = new Npgsql.NpgsqlConnection(connString))
        //    {
        //        conn.Open();
        //        string query = "UPDATE setor_sampah SET id_status = 2 WHERE id_setor = @id";

        //        using (var cmd = new Npgsql.NpgsqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@id", idSetor);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }

        //    MessageBox.Show("Status berhasil diperbarui!");
        //    LoadData(); // reload agar tampilan status ikut berubah
        //}



        private void LoadData()
        {
            LoadData(null, null); // memanggil versi yang pakai parameter
        }

        private void LoadData(object sender, EventArgs e)
        {
            try
            {

                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    string statusQuery = "SELECT id_status, status FROM status_pengambilan";
                    var statusAdapter = new NpgsqlDataAdapter(statusQuery, conn);
                    var statusTable = new DataTable();
                    statusAdapter.Fill(statusTable);

                    string query = @"SELECT 
                     ss.id_setor,
                     w.nama,
                     j.hari || ' ' || j.jam AS jadwal,
                     nr.nomor_rumah, 
	                 ja.nama_jalan||', '||d.nama_dusun as Alamat,
                     sp.status,
                     ss.id_status
                     FROM setor_sampah ss
                     JOIN warga w ON ss.id_warga = w.id_warga
                     JOIN jadwal_pengambilan j ON ss.id_jadwal = j.id_jadwal
                     
                     join nomor_rumah nr on w.id_nomor_rumah=nr.id_nomor_rumah
                     join jalan ja on nr.id_jalan=ja.id_jalan
                     join dusun d on ja.id_dusun=d.id_dusun
                     join status_pengambilan sp ON ss.id_status = sp.id_status";



                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        var adapter = new NpgsqlDataAdapter(cmd);
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        // Hapus kolom jika sudah ada
                        if (dataGridView1.Columns.Contains("statusComboBox"))
                        {
                            dataGridView1.Columns.Remove("statusComboBox");
                        }

                        // Ambil data status dari tabel status_pengambilan
                        var dtStatus = new DataTable();
                        using (var statusCmd = new NpgsqlCommand("SELECT id_status, status FROM status_pengambilan", conn))
                        {
                            var Adapter = new NpgsqlDataAdapter(statusCmd);
                            statusAdapter.Fill(dtStatus);
                        }

                        // Tambahkan kolom ComboBox yang bind ke database
                        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                        comboBoxColumn.HeaderText = "Edit Status";
                        comboBoxColumn.Name = "statusComboBox";
                        comboBoxColumn.DataSource = dtStatus;
                        comboBoxColumn.DisplayMember = "status";
                        comboBoxColumn.ValueMember = "id_status";
                        comboBoxColumn.DataPropertyName = "id_status"; // supaya otomatis sinkron
                        dataGridView1.Columns.Add(comboBoxColumn);

                        dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                        dataGridView1.CurrentCellDirtyStateChanged += (s, e) =>
                        {
                            if (dataGridView1.IsCurrentCellDirty)
                            {
                                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            }
                        };


                        //    var dtStatus = new DataTable();
                        //    using (var statusCmd = new NpgsqlCommand("SELECT id_status, status FROM status_pengambilan", conn))
                        //    {
                        //        var statusAdapter = new NpgsqlDataAdapter(statusCmd);
                        //        statusAdapter.Fill(dtStatus);
                        //    }

                        //    // Pakai ini untuk comboBoxColumn:
                        //    comboBoxColumn.DataSource = dtStatus;



                        //    // Tambahkan kolom ComboBox yang bind ke database
                        //    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                        //    comboBoxColumn.HeaderText = "Edit Status";
                        //    comboBoxColumn.Name = "statusComboBox";
                        //    comboBoxColumn.DataSource = statusTable;
                        //    comboBoxColumn.DisplayMember = "status";
                        //    comboBoxColumn.ValueMember = "id_status";
                        //    comboBoxColumn.DataPropertyName = "id_status"; // penting agar isi otomatis
                        //    dataGridView1.Columns.Add(comboBoxColumn);
                        //}

                    }
                }
            }





            //using (var cmd = new NpgsqlCommand(query, conn))
            //{
            //    var adapter = new NpgsqlDataAdapter(cmd);
            //    var dt = new DataTable();
            //    adapter.Fill(dt);
            //    dataGridView1.DataSource = dt;

            //    if (!dataGridView1.Columns.Contains("statusComboBox"))
            //    {
            //        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            //        comboBoxColumn.HeaderText = "Edit Status";
            //        comboBoxColumn.Name = "statusComboBox";
            //        comboBoxColumn.Items.AddRange("Belum Diambil", "Sudah Diambil");
            //        dataGridView1.Columns.Add(comboBoxColumn);

            //        foreach (DataGridViewRow row in dataGridView1.Rows)
            //        {
            //            if (row.Cells["status"] != null && row.Cells["statusComboBox"] != null)
            //            {
            //                row.Cells["statusComboBox"].Value = row.Cells["status"].Value.ToString();






            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "statusComboBox")
            {
                var idSetor = dataGridView1.Rows[e.RowIndex].Cells["id_setor"].Value;
                var newStatusId = dataGridView1.Rows[e.RowIndex].Cells["statusComboBox"].Value;

                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("UPDATE setor_sampah SET id_status = @status WHERE id_setor = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatusId);
                        cmd.Parameters.AddWithValue("@id", idSetor);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Optional: Update status teks biar tampilan ikut berubah
                string statusText = GetStatusTextById(Convert.ToInt32(newStatusId));
                dataGridView1.Rows[e.RowIndex].Cells["status"].Value = statusText;
            }
        }
            
            private string GetStatusTextById(int id)
        {
            switch (id)
            {
                case 1: return "Belum Diambil";
                case 2: return "Sudah Diambil";
                default: return "-";
            }
        }
        

        // Panggil fungsi update

        //dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        //    dataGridView1.Dock = DockStyle.Fill;
        //    this.Controls.Add(dataGridView1);
        //    dataGridView1.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //}
        // atau manual

        //if (dataGridView1.Columns[e.ColumnIndex].Name == "btnUpdate" && e.RowIndex >= 0)
        //{
        //    int idSetor = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_setor"].Value);

        //    // Update ke database
        //    UpdateStatusKeDatabase(idSetor, idStatus);
        //}
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dataGridView1.Columns.Contains("status"))
            {
                dataGridView1.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["status"].Width = 150;
            }

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string selectedStatus = row.Cells["statusComboBox"].Value?.ToString();
                if (string.IsNullOrEmpty(selectedStatus)) continue;

                int idSetor = Convert.ToInt32(row.Cells["id_setor"].Value);
                int idStatus = (selectedStatus == "Sudah Diambil") ? 2 : 1; // 1 = Belum, 2 = Sudah

                UpdateStatusKeDatabase(idSetor, idStatus);
            }

            MessageBox.Show("Status berhasil diperbarui.");
            LoadData(this, EventArgs.Empty); // refresh DataGridView
        }
    }
}
    




        
    

