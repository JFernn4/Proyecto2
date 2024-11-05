using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class Biblioteca
    {
        public bool InicioSesionBibliotecario(LinkedList<Usuario>listaDeUsuarios, string nombre, string contrasena)
        {
            int indice = BusquedaSecuencialBibliotecarios(listaDeUsuarios, listaDeUsuarios.First, nombre, contrasena, 0);
            if (indice != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InicioSesionLector(LinkedList<Usuario> listaDeUsuarios, string nombre, string contrasena)
        {
            int indice = BusquedaSecuencialLectores(listaDeUsuarios,listaDeUsuarios.First, nombre,contrasena, 0);
            if (indice != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AgregarLibro(LinkedList<Libro> listaDeLibros)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             AGREGAR LIBRO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("                                             o Título: ");
            string titulo= Console.ReadLine();
                Console.Write("                                             o Autor: ");
            string autor= Console.ReadLine();
                Console.Write("                                             o ISBN: ");
            string iBSN= Console.ReadLine();
            int indice = BusquedaSecuencialLibros(listaDeLibros, listaDeLibros.First, iBSN, 0);
            if (indice != -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("                                             - ISBN ya existente");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.Write("                                             o Género: ");
                string genero = Console.ReadLine();
                bool disponibilidad = true;
                int vecesSolicitado = 0;
                Libro libro = new Libro(stock,titulo, autor, iBSN, genero, disponibilidad, vecesSolicitado);
                listaDeLibros.AddLast(libro);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("                                             - Libro agregado exitosamente");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void BuscarLibro(LinkedList<Libro> listaDeLibros)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             BUSCAR LIBRO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
                Console.Write("                                             o Título, autor o ISBN del libro que desea buscar: ");
            string entradaBusqueda= Console.ReadLine();
            int indice= BusquedaSecuencialLibros(listaDeLibros, listaDeLibros.First,entradaBusqueda,0);
            if (indice != -1)
            {
                int indiceActual = 0;
                foreach (var libro in listaDeLibros)
                {
                    //Si indiceactual igual a indice
                    if (indiceActual == indice)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                             BUSCAR LIBRO");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.ForegroundColor=ConsoleColor.DarkGreen;
                        Console.WriteLine("                                             - Se ha encontrado el libro");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("                                             Detalles del libro encontrado:");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Stock: {libro.Stock}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Título: {libro.Titulo}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Autor: {libro.Autor}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"ISBN: {libro.Isbn}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Género: {libro.Genero}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Disponibilidad: {(libro.Disponibilidad ? "En biblioteca" : "Sin stock")}");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        indiceActual++;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                             BUSCAR LIBRO");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                             - No se ha encontrado el libro");
                Console.ResetColor();
                Console.ReadKey (); 
            }

        }
        public void EliminarLibro(LinkedList<Libro> listaDeLibros)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             ELIMINAR LIBRO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o Título, autor o ISBN del libro que desea eliminar: ");
            string entradaBusqueda = Console.ReadLine();
            int indice = BusquedaSecuencialLibros(listaDeLibros, listaDeLibros.First, entradaBusqueda,0);
            if (indice != -1)
            {
                int indiceActual = 0;
                foreach (var libro in listaDeLibros)
                {
                    if (indiceActual == indice)
                    {
                        string confirmacion = "";
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                             ELIMINAR LIBRO");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("                                             Detalles del libro encontrado:");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Stock: {libro.Stock}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Título: {libro.Titulo}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Autor: {libro.Autor}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"ISBN: {libro.Isbn}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Género: {libro.Genero}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Disponibilidad: {(libro.Disponibilidad ? "En biblioteca" : "Sin stock")}");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                             ¿Está seguro que desea eliminar el libro? S/N");
                        confirmacion = Console.ReadLine();
                        switch (confirmacion)
                        {
                            case "s":
                                {
                                    Console.ForegroundColor= ConsoleColor.DarkGreen;
                                    listaDeLibros.Remove(libro);
                                    Console.WriteLine("                                             - Se ha eliminado el libro");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                                }
                            case "n":
                                {
                                    Console.ResetColor();
                                    break;
                                }
                        }
                        break;
                    }
                    else
                    {
                        indiceActual++;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                             ELIMINAR LIBRO");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                             - No se ha encontrado el libro");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public int BusquedaSecuencialLibros(LinkedList<Libro> listaDeLibros, LinkedListNode<Libro> nodoActual, string entradaBusqueda, int indice)
        {
            //caso base
            if (nodoActual == null)
            {
                return -1;
            }
            if (nodoActual.Value.Isbn == entradaBusqueda || nodoActual.Value.Titulo == entradaBusqueda || nodoActual.Value.Autor == entradaBusqueda)
            {
                return indice;
            }
            //llamada recursiva
            return BusquedaSecuencialLibros(listaDeLibros, nodoActual.Next, entradaBusqueda, indice+1);
        }
        public void RegistrarLector(LinkedList<Usuario> listaDeUsuarios)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             REGISTRAR USUARIO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o ID: ");
            string iD = Console.ReadLine();
            int indice = BusquedaSecuencialUsuarios(listaDeUsuarios, listaDeUsuarios.First, iD, 0);
            if (indice != -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("                                             - Usuario existente");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.Write("                                             o Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("                                             o Contraseña: ");
                string contrasena = Console.ReadLine();
                string rol = "Lector";
                Lector lector = new Lector(iD, nombre,contrasena,rol);
                listaDeUsuarios.AddLast(lector);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("                                             - Usuario registrado exitosamente");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void RegistrarBibliotecario(LinkedList<Usuario> listaDeUsuarios)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             REGISTRAR USUARIO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o ID: ");
            string iD = Console.ReadLine();
            int indice = BusquedaSecuencialUsuarios(listaDeUsuarios, listaDeUsuarios.First, iD, 0);
            if (indice != -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("                                             - Usuario existente");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.Write("                                             o Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("                                             o Contraseña: ");
                string contrasena = Console.ReadLine();
                string rol = "Bibliotecario";
                Bibliotecario bibliotecario= new Bibliotecario(iD, nombre, contrasena, rol);
                listaDeUsuarios.AddLast(bibliotecario);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("                                             - Usuario registrado exitosamente");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void EditarUsuario(LinkedList<Usuario> listaDeUsuarios)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             EDITAR USUARIO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o ID del usuario que desea editar: ");
            string iD = Console.ReadLine();
            int indice = BusquedaSecuencialUsuarios(listaDeUsuarios, listaDeUsuarios.First, iD, 0);
            if (indice != -1)
            {
                int indiceActual = 0;
                foreach (var usuario in listaDeUsuarios)
                {
                    if (indiceActual == indice)
                    {
                        string confirmacion = "";
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                             EDITAR USUARIO");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("                                             Detalles del usuario encontrado:");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"ID: {usuario.ID}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Nombre: {usuario.Nombre}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Rol: {usuario.Rol}");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                             ¿Editar? S/N");
                        confirmacion = Console.ReadLine();
                        Console.ResetColor();
                        switch (confirmacion)
                        {
                            case "s":
                                {
                                    Console.WriteLine("");
                                    Console.Write("                                             o Nuevo nombre: ");
                                    string nuevoNombre = Console.ReadLine();
                                    Console.Write("                                             o Nuevo rol (Lector/Bibliotecario): ");
                                    string nuevoRol = Console.ReadLine();
                                    usuario.Nombre = nuevoNombre;
                                    usuario.Rol = nuevoRol;
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("                                             - Usuario editado exitosamente");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                                }
                            case "n":
                                {
                                    Console.ResetColor();
                                    break;
                                }
                        }
                        break;
                    }
                    else
                    {
                        indiceActual++;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                             EDITAR USUARIO");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                             - No se ha encontrado al usuario");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void EliminarUsuario(LinkedList<Usuario>listaDeUsuarios)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             ELIMINAR USUARIO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o ID del usuario que desea eliminar: ");
            string iD = Console.ReadLine();
            int indice = BusquedaSecuencialUsuarios(listaDeUsuarios, listaDeUsuarios.First, iD, 0);
            if (indice != -1)
            {
                int indiceActual = 0;
                foreach (var usuario in listaDeUsuarios)
                {
                    if (indiceActual == indice)
                    {
                        string confirmacion = "";
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                             ELIMINAR USUARIO");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("                                             Detalles del usuario encontrado:");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"ID: {usuario.ID}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Nombre: {usuario.Nombre}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("                                             o "); Console.ResetColor();
                        Console.WriteLine($"Rol: {usuario.Rol}");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                             ¿Está seguro que desea eliminar al usuario? S/N");
                        confirmacion = Console.ReadLine();
                        Console.ResetColor();
                        switch (confirmacion)
                        {
                            case "s":
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    listaDeUsuarios.Remove(usuario);
                                    Console.WriteLine("                                             - Se ha eliminado al usuario");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                                }
                            case "n":
                                {
                                    Console.ResetColor();
                                    break;
                                }
                        }
                        break;

                    }
                    else
                    {
                        indiceActual++;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                             ELIMINAR USUARIO");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                             - No se ha encontrado al usuario");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public int BusquedaSecuencialUsuarios(LinkedList<Usuario> listaDeUsuarios, LinkedListNode<Usuario>nodoActual, string iD, int indice)
        {
            //caso base
            if (nodoActual == null)
            {
                return -1;
            }
            if (nodoActual.Value.ID==iD)
            {
                return indice;
            }
            //llamada recursiva
            return BusquedaSecuencialUsuarios(listaDeUsuarios, nodoActual.Next, iD, indice + 1);
        }
        public void GenerarInforme(LinkedList<Libro> listaDeLibros)
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
        public int BusquedaSecuencialLectores(LinkedList<Usuario> listaDeUsuarios,LinkedListNode<Usuario> nodoActual, string nombre, string contrasena, int indice)
        {
            //caso base
            if (nodoActual == null)
            {
                return -1;
            }
            if (nodoActual.Value.Nombre == nombre && nodoActual.Value.Contrasena == contrasena)
            {
                return indice;
            }
            //llamada recursiva
            return BusquedaSecuencialLectores(listaDeUsuarios, nodoActual.Next, nombre, contrasena, indice + 1);
        }
        public int BusquedaSecuencialBibliotecarios(LinkedList<Usuario> listaDeUsuarios, LinkedListNode<Usuario> nodoActual, string nombre,string contrasena, int indice)
        {
            //caso base
            if (nodoActual == null)
            {
                return -1;
            }
            if (nodoActual.Value.Nombre == nombre && nodoActual.Value.Contrasena == contrasena && nodoActual.Value.Rol == "Bibliotecario")
            {
                return indice;
            }
            //llamada recursiva
            return BusquedaSecuencialBibliotecarios(listaDeUsuarios, nodoActual.Next, nombre,contrasena, indice + 1);
        }
    }
}

