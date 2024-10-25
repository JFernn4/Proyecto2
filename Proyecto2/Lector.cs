using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Lector:Usuario
    {
        public string Rol { get; set; }
        public Lector(int iD, string nombre) : base(iD, nombre)
        {
            Rol = "Lector";
        }
    }
}
