using pebeo.Controller;
using pebeo.Controllers.SampahApp.Controllers;
using pebeo.Models;
using pebeo.Dashboard;
using Microsoft.VisualBasic.Logging;
using pebeo.View;

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

            var controller = new AkunController();
            var akun = controller.Login(tbusername.Text, tbpassword.Text);

            if (akun is Warga warga)
            {
                MessageBox.Show($"Selamat datang, {warga.NamaLengkap}");
                // buka dashboard warga
            }
            else if (akun is Pengolah pengolah)
            {
                MessageBox.Show("Selamat datang, Admin!");
                // buka dashboard pengolah
            }
            else
            {
                MessageBox.Show("Login gagal.");
            }
            //string username = tbusername.Text.Trim();
            //string password = tbpassword.Text.Trim();

            //if (username == "" || password == "")
            //{
            //    MessageBox.Show("Usename dan wajib diisi");
            //    return;

            //    Akun akun = akunController.Login(username, password);

            //    if (akun != null)
            //    {
            //        if (akun is Warga warga)
            //        {
            //            MessageBox.Show($"Login berhasil sebagai Warga: {warga.NamaLengkap}");
            //            this.Hide();
            //            var formWarga = new DashboardWarga(warga);
            //            formWarga.Show();
            //        }
            //        else if (akun is Pengolah pengolah)
            //        {
            //            MessageBox.Show("Login berhasil sebagai Pengolah!");
            //            this.Hide();
            //            var formPengolah = new DashboardPengolah(pengolah);
            //            formPengolah.Show();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    var controller = new AkunController();
        //    var akun = controller.Login(txtUsername.Text, txtPassword.Text);

        //    if (akun is Warga warga)
        //    {
        //        MessageBox.Show($"Selamat datang, {warga.NamaLengkap}");
        //        // buka dashboard warga
        //    }
        //    else if (akun is Pengolah pengolah)
        //    {
        //        MessageBox.Show("Selamat datang, Admin!");
        //        // buka dashboard pengolah
        //    }
        //    else
        //    {
        //        MessageBox.Show("Login gagal.");
        //    }
        //}

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
    }
}
