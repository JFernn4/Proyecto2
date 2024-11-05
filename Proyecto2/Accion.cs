using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class Accion
    {
        public string TipoDeAccion { get; set; }
        public Prestamo Prestamo { get; set; }
        public Libro Libro { get; set; }

        public Accion(string tipoDeAccion, Prestamo prestamo, Libro libro)
        {
            TipoDeAccion = tipoDeAccion;
            Prestamo = prestamo;
            Libro = libro;
        }
    }
}
