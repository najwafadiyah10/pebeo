using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pebeo.Models
{
        public class Warga : Akun
        {
            public string NamaLengkap { get; set; }
            //public string Alamat { get; set; }
            public string NoTelepon { get; set; }

            public Warga(string username, string password, string nama, string noTelp)
                : base(username, password)
            {
                NamaLengkap = nama;
                //Alamat = alamat;
                NoTelepon = noTelp;
            }

            //public override bool Login(string username, string password)
            //{
            //    return Username == username && password == password;
            //}
        }
    }

