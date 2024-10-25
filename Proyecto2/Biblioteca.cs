using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    internal class Biblioteca
    {
            static void AgregarLibro(LinkedList<Libro> listaDeLibros, Libro libro)
            {
            listaDeLibros.AddLast(libro);
            }            
    }
}

