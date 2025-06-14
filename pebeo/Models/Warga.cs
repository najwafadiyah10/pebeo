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
       
            public string NoTelepon { get; set; }
            public int noRumah { get; set; }

        public Warga(string username, string password, string nama, string noTelp, int norumah)
                : base(username, password)
            {
                NamaLengkap = nama;
               
                NoTelepon = noTelp;
                noRumah = norumah;
            }

            //public override bool Login(string username, string password)
            //{
            //    return Username == username && password == password;
            //}
        }
    }

