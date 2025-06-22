using pebeo.Controller;
using pebeo.Controllers.SampahApp.Controllers;
using pebeo.Models;
using pebeo.Dashboard;
using Microsoft.VisualBasic.Logging;
using pebeo.View;
using Npgsql;
using static pebeo.User_Control.Jadwal;

namespace pebeo
{
    public partial class Form1 : Form
    {
        private AkunController akunController;
        public Form1()
        {
            InitializeComponent();
            akunController = new AkunController();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkregis_LinkClicked(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void btnloginn_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;


            try
            {
                using (var conn = new NpgsqlConnection(Database.connString))
                {
                    conn.Open();

                    string query = "SELECT id_warga FROM warga WHERE username = @username AND password = @password";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            Session.LoggedWargaId = Convert.ToInt32(result);
                            MessageBox.Show("Login berhasil sebagai WARGA");

                            DashboardWarga form = new DashboardWarga();
                            form.Show();
                            this.Hide();
                            return;
                        }
                        else
                        {
                        }
                    }

                    string queryPengolah = "SELECT * FROM pengolah WHERE username = @username AND password = @password";
                    using (var cmd2 = new NpgsqlCommand(queryPengolah, conn))
                    {
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@password", password);

                        using (var reader2 = cmd2.ExecuteReader())
                        {
                            if (reader2.HasRows)
                            {
                                MessageBox.Show("Login berhasil sebagai PENGOLAH");
                                DashbooardPengolah formPengolah = new DashbooardPengolah();
                                formPengolah.Show();
                                this.Hide();
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
