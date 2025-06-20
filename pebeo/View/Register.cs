﻿using Microsoft.VisualBasic.ApplicationServices;
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
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            // Ambil input user
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string nama = txtNama.Text;
            string noTelp = txtTelepon.Text;

            // Kirim data ke form RegisterAlamat
            //RegisterAlamat formAlamat = new RegisterAlamat(username, password, nama, noTelp);
            //formAlamat.Show();
            //this.Hide();

            var registerAlamat = new RegisterAlamat(username, password, nama, noTelp);
            registerAlamat.Show();
            this.Hide();




            //if (controller.RegisterWarga(warga))
            //{
            //    MessageBox.Show("Registrasi berhasil!");
            //    this.Close(); // atau buka LoginForm
            //}
            //else
            //{
            //    MessageBox.Show("Gagal registrasi.");
            //}
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
