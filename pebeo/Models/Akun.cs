using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pebeo.Models
{
    public abstract class Akun
    {
        public string Username { get; set; }
        private string password { get; set; }

        protected Akun(string username, string password)
        {
            Username = username;
            this.password = password;
        }

        public bool CekPassword(string input) => password == input;

        public string GetPassword() => password;
    }
}
