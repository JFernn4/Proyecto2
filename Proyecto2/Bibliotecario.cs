using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Bibliotecario : Usuario
    {
        public Bibliotecario(string iD, string nombre, string contrasena, string rol) : base(iD, nombre, contrasena, rol)
        {
            Rol = "Bibliotecario";
        }
    }
}
