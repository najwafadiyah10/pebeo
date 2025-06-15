using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pebeo.User_Control;


namespace pebeo.Dashboard
{
    public partial class DashboardWarga : Form
    {
        public DashboardWarga()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DashboardWarga_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlihatjadwal_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowControl(UserControl uc)
        {
            panel2.Controls.Clear();      // kosongkan panel2
            uc.Dock = DockStyle.Fill;     // biar full
            panel2.Controls.Add(uc);      // tambahkan ke panel2
            uc.BringToFront();            // tampilkan paling depan
        }

        private void btnsetorjadwal_Click(object sender, EventArgs e)
        {
            Jadwal jadwal = new Jadwal();  // Buat instance user control
            ShowControl(jadwal);
        }

        private void btncek_Click(object sender, EventArgs e)
        {
            LihatStatuscs lihatStatuscs = new LihatStatuscs();
            ShowControl(lihatStatuscs);
        }
    }
}
