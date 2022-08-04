using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMAAPI.Model
{
    public class Login
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public String Role { get; set; }
    }
}
