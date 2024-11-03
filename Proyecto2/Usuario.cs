using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public Usuario(string iD, string nombre, string rol)
        {
            ID = iD;
            Nombre = nombre;
            Rol = rol;
        }
    }
}
