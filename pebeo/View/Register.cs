using Microsoft.VisualBasic.ApplicationServices;
using pebeo.Controller;
using pebeo.Controllers.SampahApp.Controllers;
using pebeo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pebeo.Controller;

namespace pebeo.View
{
    public partial class Register : Form
    {
        public Register() 
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string nama = txtNama.Text;
            string noTelp = txtTelepon.Text;


            if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(nama) ||
            string.IsNullOrWhiteSpace(noTelp))
            {
                MessageBox.Show("Semua data wajib diisi!");
                return;
            }

            if (nama.Any(char.IsDigit))
            {
                MessageBox.Show("Nama tidak boleh mengandung angka!");
                return;
            }

            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Password harus mengandung minimal satu angka!");
                return;
            }

            if (noTelp.Any(char.IsLetter))
            {
                MessageBox.Show("Nomor HP hanya boleh berisi angka!");
                return;
            }

            var registerAlamat = new RegisterAlamat(username, password, nama, noTelp);
            registerAlamat.Show();
            this.Hide();
        }
            

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
