using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Usuario(int iD, string nombre)
        {
            ID = iD;
            Nombre = nombre;
        }
    }
}
