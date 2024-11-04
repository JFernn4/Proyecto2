using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        s
        public Usuario(string iD, string nombre, string contrasena, string rol)
        {
            ID = iD;
            Nombre = nombre;
            Contrasena = contrasena;
            Rol = rol;
        }
    }
}
