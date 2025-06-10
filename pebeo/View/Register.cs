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

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            var controller = new AkunController();

            var warga = new Warga(
                //id: 0, // ID akan otomatis oleh DB
                username: txtUsername.Text,
                password: txtPassword.Text,
                nama: txtNama.Text,
                //alamat: txtAlamat.Text,
                noTelp: txtTelepon.Text
            );

            if (controller.RegisterWarga(warga))
            {
                MessageBox.Show("Registrasi berhasil!");
                this.Close(); // atau buka LoginForm
            }
            else
            {
                MessageBox.Show("Gagal registrasi.");
            }


        }
    }
}
