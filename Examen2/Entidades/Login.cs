using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        public string Idusuarios { get; set; }
        public string Contraseña { get; set; }

        public Login()
        {
        }

        public Login(string idusuarios, string contraseña)
        {
            Idusuarios = idusuarios;
            Contraseña = contraseña;
        }
    }
}
