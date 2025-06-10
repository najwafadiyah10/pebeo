using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pebeo.Models

    {
        public class Pengolah : Akun
        {
            public Pengolah(string username, string password) : base(username, password) { }

            //public override bool Login(string username, string password)
            //{
            //    return Username == username && password == password;
            //}
        }
    }


