using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pebeo.Models
{ 
    public class Pengolah : Akun
    {
        public Pengolah(string username, string password) : base(username, password)
        {

        }
        public override void TampilkanPeran()
        {
            MessageBox.Show("Login berhasil sebagai Pengolah");
        }
    }
}