using pebeo.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pebeo.Dashboard
{
    public partial class DashbooardPengolah : Form
    {
        public DashbooardPengolah()
        {
            InitializeComponent();
        }

        private void btneditjadwal_Click(object sender, EventArgs e)
        {
            JadwalPengolah jadwalpengolah = new JadwalPengolah();
            ShowControl(jadwalpengolah);
        }
        private void ShowControl(UserControl uc)
        {
            panel2.Controls.Clear();      // kosongkan panel2
            uc.Dock = DockStyle.Fill;     // biar full
            panel2.Controls.Add(uc);      // tambahkan ke panel2
            uc.BringToFront();            // tampilkan paling depan
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSetorSampah datasetorsampah = new DataSetorSampah();
            ShowControl(datasetorsampah);

        }

        private void btnupadate_Click(object sender, EventArgs e)
        {
            UpdateStatus updatestatus = new UpdateStatus();
            ShowControl(updatestatus);

        }
    }
}
