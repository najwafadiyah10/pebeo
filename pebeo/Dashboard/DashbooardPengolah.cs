using pebeo.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
            uc.BringToFront();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashbooardPengolah_Load(object sender, EventArgs e)
        {

        }
    }
}
