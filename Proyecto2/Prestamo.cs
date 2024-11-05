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
        public Libro LibroPrestado { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechadePrestamo { get; set; }

        public Prestamo(Libro libroPrestado, Usuario usuario, DateTime fechadePrestamo)
        {
            LibroPrestado = libroPrestado;
            Usuario = usuario;
            FechadePrestamo = fechadePrestamo;
        }



        public void PrestarLibro(Biblioteca biblioteca, LinkedList<Libro> listaDeLibros, LinkedList<Usuario> listaDeUsuarios, Stack<Prestamo> historialAcciones, Queue<Prestamo> colaEspera)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             SOLICITAR PRÉSTAMO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
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
                        Console.Write("                                             o Ingrese su ID: ");
                        string idBuscar = Console.ReadLine();
                        foreach (var usuarioBuscar in listaDeUsuarios)
                        {
                            if (usuarioBuscar.ID == idBuscar)
                            {
                                if (libro.Disponibilidad)
                                {
                                    Prestamo prestamo = new Prestamo(libro, usuarioBuscar, DateTime.Now);
                                    libro.Stock = libro.Stock - 1;
                                    if (libro.Stock == 0)
                                    {
                                        libro.Disponibilidad = false;
                                    }
                                    historialAcciones.Push(prestamo);
                                    libro.VecesSolicitado = libro.VecesSolicitado + 1;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("");
                                    Console.WriteLine($"                                             - {usuarioBuscar.Nombre} ha tomado en préstamo el libro '{libro.Titulo}'");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    libro.VecesSolicitado = libro.VecesSolicitado + 1;
                                    Prestamo prestamoEnCola = new Prestamo (libro,usuarioBuscar,DateTime.Now);
                                    colaEspera.Enqueue(prestamoEnCola);
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

        public void DevolverLibro(Stack<Prestamo> historialAcciones, LinkedList<Libro> listaDeLibros, Queue<Prestamo> colaEspera)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             DEVOLVER LIBRO");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("                                             o ISBN del libro prestado: ");
            string isbnLibroBuscar = Console.ReadLine();
            Console.Write("                                             o Ingrese su ID: ");
            string idUsuarioBuscar= Console.ReadLine();

            Prestamo prestamoEncontrado = null;
            foreach (var prestamo in historialAcciones)
            {
                if (prestamo.Usuario.ID==idUsuarioBuscar && prestamo.LibroPrestado.Isbn == isbnLibroBuscar)
                {
                    prestamoEncontrado = prestamo;
                    break;
                }
            }

            if (prestamoEncontrado == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                             - No se encontró el préstamo.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            foreach (var libro in listaDeLibros)
            {
                if (libro.Isbn == prestamoEncontrado.LibroPrestado.Isbn)
                {
                    libro.Stock = libro.Stock + 1;
                    libro.Disponibilidad = true;
                    historialAcciones.Pop();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("");
                    Console.WriteLine($"                                             - {prestamoEncontrado.Usuario.Nombre} ha devuelto el libro '{libro.Titulo}'");
                    // Asignar el libro al primer usuario en cola de espera, si existe
                    foreach (var prestamoEnCola in colaEspera)
                    {
                        if (prestamoEnCola.LibroPrestado.Isbn == libro.Isbn)
                        {
                            Usuario siguienteUsuario = prestamoEnCola.Usuario;
                            historialAcciones.Push(new Prestamo(libro, siguienteUsuario, DateTime.Now));
                            libro.Stock = libro.Stock - 1;
                            libro.Disponibilidad = libro.Stock > 0;

                            Console.WriteLine("");
                            Console.WriteLine($"                                             - {siguienteUsuario.Nombre} ha tomado prestado el libro '{libro.Titulo}'");
                            colaEspera.Dequeue();  // Remueve de la cola de espera
                            break;
                        }
                    }
                    break;
                }
            }

            Console.ResetColor();
            Console.ReadKey();
        }

        public void DeshacerUltimaAccion(Stack<Prestamo> historialAcciones, LinkedList<Libro> listaDeLibros, Queue<Prestamo> colaEspera)
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


       