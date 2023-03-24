using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public string idclientes { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public Cliente()
        {
        }

        public Cliente(string idclientes, string nombre, string correo)
        {
            this.idclientes = idclientes;
            Nombre = nombre;
            Correo = correo;
        }
    }
}
