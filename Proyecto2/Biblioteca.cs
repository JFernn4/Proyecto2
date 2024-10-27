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
            Console.WriteLine("Libro agregado exitosamente.");
        }

        public int BusquedaSecuencialLista(LinkedList<Libro> listaDeLibros, string isbn)
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
         public bool RetirarLibro(LinkedList<Libro> listaDeLibros, string isbn)
        {
            LinkedListNode<Libro> nodoActual = listaDeLibros.First;
            LinkedListNode<Libro> anterior = null;

            while (nodoActual != null)
            {
                if (nodoActual.ValueRef.Isbn == isbn)
                {
                    if (anterior == null)
                    {
                        listaDeLibros.RemoveFirst();
                        Console.WriteLine("Libro retirado éxitosamente.");
                    }
                    else
                    {
                        listaDeLibros.Remove(nodoActual);
                        Console.WriteLine("Libro retirado éxitosamente.");
                    }
                    return true;
                }
                anterior = nodoActual;
                nodoActual = nodoActual.Next;
            }
            Console.WriteLine("Libro no encontrado.");
            return false;

        }
    
        public void RegistrarUsuario(LinkedList<Usuario> listaDeUsuarios, Usuario usuario)
        {
            listaDeUsuarios.AddLast(usuario);
            Console.WriteLine("Usuario agregado exitosamente");
        }

        public void EditarUsuario(LinkedList<Usuario> listaDeUsuarios,int id )
        {
            int indice = 0;
            Usuario NodoEditar;
            LinkedListNode<Usuario> nodoActualUsuario = listaDeUsuarios.First;
            while (nodoActualUsuario != null)
            {

                if (nodoActualUsuario.ValueRef.ID == id)
                {
            Console.WriteLine("¿Qué desea editar?");
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Rol");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el nuevo nombre: ");
                    string nuevonombre = Console.ReadLine();
                    nodoActualUsuario.ValueRef.Nombre = nuevonombre;
                    Console.WriteLine($"Nombre editado exitosamente a {nodoActualUsuario.ValueRef.Nombre}");
                    break;
                case 2:
                    Console.WriteLine("Ingrese el nuevo Rol: ");
                    string nuevorol = Console.ReadLine();
                    nodoActualUsuario.ValueRef.Rol = nuevorol;
                    Console.WriteLine($"Rol editado exitosamente a {nodoActualUsuario.ValueRef.Rol}");
                    break;
            }
                   
                }
                nodoActualUsuario = nodoActualUsuario.Next;
                indice++;
            }
        }
        public void GenerarÏnforme(LinkedList<Libro> listaDeLibros)
        {
            LinkedListNode<Libro> nodoquepasa = listaDeLibros.First;
            Console.WriteLine("PRESTAMOS ACTIVOS");
            while (nodoquepasa != null)
            {
                if (nodoquepasa.ValueRef.Disponibilidad == false)
                {

                    Console.WriteLine($"Título del libro: {nodoquepasa.ValueRef.Titulo}, Autor: {nodoquepasa.ValueRef.Autor}, Genero: {nodoquepasa.ValueRef.Genero}, ISBN: {nodoquepasa.ValueRef.Isbn}");
                    Console.WriteLine("");
                }
                nodoquepasa = nodoquepasa.Next;
            }
        }
        public bool EliminarUsuario(LinkedList<Usuario> listaDeUsuarios, int id)
        {
            LinkedListNode<Usuario> nodoActual = listaDeUsuarios.First;
            LinkedListNode<Usuario> anterior = null;

            while (nodoActual != null)
            {
                if (nodoActual.ValueRef.ID == id)
                {
                    if (anterior == null)
                    {

                        listaDeUsuarios.RemoveFirst();
                        Console.WriteLine("Usuario retirado exitosamente.");
                        return true;
                    }
                    else
                    {
                        listaDeUsuarios.Remove(nodoActual);
                        Console.WriteLine("Usuario retirado exitosamente.");
                        return true;
                    }

                }


                anterior = nodoActual;
                nodoActual = nodoActual.Next;
            }
            Console.WriteLine("Usuario no encontrado.");
            return false;

        }


    }
}

