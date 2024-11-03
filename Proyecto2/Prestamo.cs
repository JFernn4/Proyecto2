using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Prestamo
    {
        public Libro LibroPrestado { get; set; }
        public Usuario Usuario { get; set; }

        public Prestamo(Libro libroPrestado, Usuario usuario)
        {
            LibroPrestado = libroPrestado;
            Usuario = usuario;
        }
    }
}
