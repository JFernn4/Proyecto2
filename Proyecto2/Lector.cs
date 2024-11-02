using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Lector:Usuario
    {
        public Lector(int iD, string nombre, string rol) : base(iD, nombre,rol)
        {
            rol = "Lector";
        }
    }
}
