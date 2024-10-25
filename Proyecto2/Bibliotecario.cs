using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Bibliotecario : Usuario
    {
        public string Rol {  get; set; }
        public Bibliotecario(int iD, string nombre) : base(iD, nombre)
        {
            Rol = "Bibliotecario";
        }
    }
}
