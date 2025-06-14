using pebeo.Controller;
using pebeo.Controllers.SampahApp.Controllers;
using pebeo.Models;
using pebeo.View;
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
    public partial class RegisterAlamat : Form
    {
        private string _username;
        private string _password;
        private string _nama;
        private string _noTelp;

        public RegisterAlamat(string username, string password, string nama, string noTelp)
        {
            InitializeComponent();
            _username = username;
            _password = password;
            _nama = nama;
            _noTelp = noTelp;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void cbrtrw_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    if (cbdusun.SelectedIndex >= 0)
            //    {
            //        int id_dusun = Convert.ToInt32(cbdusun);
            //        cbjalan.DataSource = AlamatController.GetJalanByDusun(id_dusun );
            //        cbjalan.DisplayMember = "nama_jalan";
            //        cbjalan.ValueMember = "id_jalan";
            //        cbjalan.SelectedIndex = -1;
            //    }
            //}

            if (cbdusun.SelectedIndex >= 0)
            {
                int id_dusun = Convert.ToInt32(cbdusun.SelectedValue);
                string nama_dusun = cbdusun.Text;
                cbjalan.DisplayMember = "nama_jalan";
                cbjalan.ValueMember = "id_jalan";
                cbjalan.DataSource = AlamatController.GetJalanByDusun(id_dusun);
                cbjalan.SelectedIndex = -1;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbjalan.SelectedIndex >= 0)
            {
                int id_jalan = Convert.ToInt32(cbjalan.SelectedValue);
                string nama_jalan = cbdusun.Text;
                cbnorumah.DisplayMember = "nomor_rumah";
                cbnorumah.ValueMember = "id_nomor_rumah";
                cbnorumah.DataSource = AlamatController.GetNoRumah(id_jalan);
                cbnorumah.SelectedIndex = -1;
            }
        }

        private void RegisterAlamat_Load(object sender, EventArgs e)
        {
            LoadDusun();

            try
            {
                cbdusun.DataSource = AlamatController.GetDusun();
                cbdusun.DisplayMember = "nama_dusun";
                cbdusun.ValueMember = "id_dusun";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dusun: " + ex.Message);
            }
        }
        private void LoadDusun()
        {

            if (cbdusun.SelectedValue != null && int.TryParse(cbdusun.SelectedValue.ToString(), out int id_dusun))
                //int id_dusun = Convert.ToInt32(cbdusun.SelectedValue);
                cbdusun.DataSource = AlamatController.GetDusun();
            cbdusun.DisplayMember = "nama_dusun";
            cbdusun.ValueMember = "id_dusun";
            cbdusun.SelectedIndex = -1;

            foreach (DataRowView item in cbdusun.Items)
            {
                Console.WriteLine(item["nama_dusun"].ToString()); // atau MessageBox.Show

            }

            cbdusun.Refresh();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            //RegisterAlamat registeralamat = new RegisterAlamat();
            //registeralamat.Show();
            //this.Hide();

            //int idDusun = Convert.ToInt32(cbdusun.SelectedValue);
            //int idJalan = Convert.ToInt32(cbjalan.SelectedValue);
            //int nomor = Convert.ToInt32(cbnorumah.SelectedValue);

            //Form1 login = new Form1();
            //login.Show();
            //this.Hide();

            try
            {
                if (cbnorumah.SelectedValue != null)
                {
                    int nomorRumah = Convert.ToInt32(cbnorumah.SelectedValue);

                    var warga = new Warga(
                        username: _username,
                        password: _password,
                        nama: _nama,
                        noTelp: _noTelp,
                        norumah: nomorRumah
                    );

                    var controller = new AkunController();

                    if (controller.RegisterWarga(warga))
                    {
                        MessageBox.Show("Registrasi berhasil!");

                        Form1 login = new Form1();
                        login.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Gagal registrasi.");
                    }
                }
                else
                {
                    MessageBox.Show("Pilih nomor rumah terlebih dahulu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error: " + ex.Message);
            }
        }
    
    }
}
