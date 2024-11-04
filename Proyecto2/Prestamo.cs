using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Proyecto2;

namespace Proyecto2
{
    public class Prestamo
    {
        public string ID { get; set; }
        public Libro LibroPrestado { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechadePrestamo { get; set; }

        public Prestamo(string id, Libro libroPrestado, Usuario usuario, DateTime fechadePrestamo)
        {
            ID = id;
            LibroPrestado = libroPrestado;
            Usuario = usuario;
            FechadePrestamo = fechadePrestamo;
        }



        public void PrestarLibro(Biblioteca biblioteca, LinkedList<Libro> listaDeLibros, LinkedList<Usuario> listaDeUsuarios, Stack<Prestamo> historialAcciones, Queue<(Usuario, Libro)> colaEspera)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             SOLICITAR PRÉSTAMO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o ID del préstamo: ");
            string idprestamo = Console.ReadLine();
            Console.Write("                                             o ISBN del libro que desea prestar: ");
            string isbnbuscar = Console.ReadLine();
            int indice = biblioteca.BusquedaSecuencialLibros(listaDeLibros, listaDeLibros.First, isbnbuscar, 0);
            if (indice != -1)
            {
                int indiceActual = 0;
                foreach (var libro in listaDeLibros)
                {
                    if (indiceActual == indice)
                    {

                        Console.WriteLine("Ingrese el ID del usuario que ha solicitado el libro:");
                        string Idbuscar = Console.ReadLine();
                        foreach (var usuariobuscar in listaDeUsuarios)

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
                        Console.WriteLine($"Disponibilidad: {(libro.Disponibilidad ? "En biblioteca" : "Prestado")}");
                        Console.WriteLine("");
                        Console.Write("                                             o Ingrese su ID: ");
                        string idBuscar = Console.ReadLine();
                        foreach (var usuarioBuscar in listaDeUsuarios)

                        {
                            if (usuarioBuscar.ID == idBuscar)
                            {
                                if (libro.Disponibilidad)
                                {

                                    var prestamo = new Prestamo(idprestamo, libro, usuarioBuscar, DateTime.Now);


                                    libro.Stock = libro.Stock - 1;
                                    if (libro.Stock == 0)
                                    {
                                        libro.Disponibilidad = false;
                                    }
                                    historialAcciones.Push(prestamo);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("");
                                    Console.WriteLine($"                                             - {usuarioBuscar.Nombre} ha tomado en préstamo el libro '{libro.Titulo}'");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    colaEspera.Enqueue((usuarioBuscar, libro));
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"                                             - {usuarioBuscar.Nombre} ha sido añadido a la cola de espera para el libro '{libro.Titulo}'");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                                }
                            }
                        }
                        if (historialAcciones == null)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                             - No se encontró al usuario");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        indiceActual++;
                    }
                }
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                             - No se ha encontrado el libro");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void DevolverLibro(Stack<Prestamo> historialAcciones, LinkedList<Libro> listaDeLibros, Queue<(Usuario, Libro)> colaEspera, Biblioteca biblioteca, LinkedList<Usuario> listaDeUsuarios)
        {
            bool encontrado = false;
            Console.WriteLine("Ingrese el id del prestamo: ");
            string idevolver = Console.ReadLine();
            foreach (var prestamo in historialAcciones)
            {
                if (prestamo.ID == idevolver)
                {
                    encontrado = true;
                    foreach (var libro in listaDeLibros)
                    {
                        if (prestamo.LibroPrestado.Isbn == libro.Isbn)
                        {
                            libro.Stock = libro.Stock + 1;
                            libro.Disponibilidad = true;
                            if (libro.Stock == 1)
                            {
                          
                                foreach (var nuevoprestamo in colaEspera)
                                {
                                    if (nuevoprestamo.Item2.Isbn == libro.Isbn)
                                    {
                                        // PrestarLibro(biblioteca, listaDeLibros, listaDeUsuarios, historialAcciones, colaEspera);
                                        string Idbuscar = nuevoprestamo.Item1.ID;
                                        foreach (var usuariobuscar in listaDeUsuarios)
                                        {
                                            if (usuariobuscar.ID == Idbuscar)
                                            {
                                                if (libro.Disponibilidad)
                                                {
                                                    Console.WriteLine("Ingrese el ID del prestamo: ");
                                                    string idprestamo = Console.ReadLine();
                                                    var prestamocola = new Prestamo(idprestamo, libro, usuariobuscar, DateTime.Now);
                                                    libro.Stock = libro.Stock - 1;
                                                    if (libro.Stock == 0)
                                                    {
                                                        libro.Disponibilidad = false;
                                                    }
                                                    historialAcciones.Push(prestamocola);//Salio?
                                                    Console.WriteLine($"{usuariobuscar.Nombre} ha tomado en préstamo el libro '{libro.Titulo}'");
                                                }
                                            }
                                        }
                                    }


                                }

                            }
                        }

                    }
                }
                if (encontrado == false)
                {
                    Console.WriteLine("No se encontró el id del prestamo.");
                }
            }
        }

        public void DeshacerUltimaAccion(Stack<Prestamo> historialAcciones, LinkedList<Libro> listaDeLibros, Queue<(Usuario, Libro)> colaEspera)
        {
            if (historialAcciones.Count > 0)
            {
                var ultimaAccion = historialAcciones.Pop();

                if (ultimaAccion.FechadePrestamo.Date == DateTime.Now.Date)
                {

                    if (colaEspera.Contains((ultimaAccion.Usuario, ultimaAccion.LibroPrestado)))
                    {

                        colaEspera.Enqueue((ultimaAccion.Usuario, ultimaAccion.LibroPrestado));
                        Console.WriteLine($"Se ha deshecho el préstamo del libro '{ultimaAccion.LibroPrestado.Titulo}' a {ultimaAccion.Usuario.Nombre}, quien ha vuelto a la cola de espera.");
                    }
                    else
                    {

                        ultimaAccion.LibroPrestado.Disponibilidad = true;
                        Console.WriteLine($"Se ha deshecho el préstamo del libro '{ultimaAccion.LibroPrestado.Titulo}' por {ultimaAccion.Usuario.Nombre}.");
                    }
                }
                else
                {
                    // Si la acción fue una devolución, deshacerla marcando el libro como no disponible
                    ultimaAccion.LibroPrestado.Disponibilidad = false;
                    Console.WriteLine($"Se ha deshecho la devolución del libro '{ultimaAccion.LibroPrestado.Titulo}' por {ultimaAccion.Usuario.Nombre}.");
                }
            }
            else
            {
                Console.WriteLine("No hay acciones para deshacer.");
            }
        }
    }
}


       