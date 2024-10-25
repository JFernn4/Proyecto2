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
            static void BuscarLibro(LinkedList<Libro> listaDeLibros, Libro libro)
            {
            }
        public int BusquedaSecuencial(LinkedList<Libro> listaDeLibros, string isbn)
        {
            int indice = 0;
            LinkedListNode<Libro> nodoActual = listaDeLibros.First;
            while (nodoActual != null)
            {
                if (nodoActual.ValueRef.Isbn == isbn)
                {
                    return indice;
                }
                nodoActual = nodoActual.Next;
                indice++;
            }
            return -1;
        }

    }
}

