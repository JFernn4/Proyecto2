using System.Collections.Generic;
using Proyecto2;
Libro libro1 = new Libro(1, "Don Quijote", "Miguel de Cervantes", "123B", "Épico", true);


Stack<Prestamo> historialAcciones = new Stack<Prestamo>();
Queue<(Usuario, Libro)> colaEspera = new Queue<(Usuario, Libro)>();
LinkedList<Usuario> listaDeUsuarios = new LinkedList<Usuario>();
Biblioteca biblioteca = new Biblioteca();
LinkedList<Libro> listaDeLibros = new LinkedList<Libro>();
Bibliotecario bibliotecarioPorDefecto = new Bibliotecario("1232", "bibliotecario1","bibliotecario123", "Bibliotecario");
Lector lectorPorDefecto = new Lector("4321", "lector1", "lector123", "Lector");
Prestamo prestamo = new Prestamo("1234", libro1, bibliotecarioPorDefecto, DateTime.Now);
bool menu = true;
int opcion = 0;
while (menu)
{
    Console.Clear();
    MostrarMenuPrincipal();
    opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                             INICIO DE SESIÓN");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("");
                Console.Write("                                             o Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("                                             o Contraseña: ");
                string contrasena = Console.ReadLine();
                bool verificacion = biblioteca.InicioSesionBibliotecario(listaDeUsuarios, nombre, contrasena);
                if (verificacion == true || (nombre == bibliotecarioPorDefecto.Nombre && contrasena == bibliotecarioPorDefecto.Contrasena))
                {
                    bool menuBibliotecario = true;
                    int opcionBibliotecario = 0;
                    while (menuBibliotecario)
                    {
                        try
                        {
                            MostrarMenuBibliotecarios();
                            opcion = Convert.ToInt32(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1:
                                    {
                                        MenuGestionLibros(biblioteca, listaDeLibros);
                                        break;
                                    }
                                case 2:
                                    {
                                        MenuGestionUsuarios(biblioteca, listaDeUsuarios);
                                        break;
                                    }
                                case 3:
                                    {
                                        MenuGestionPrestamos(prestamo, biblioteca, listaDeLibros, listaDeUsuarios, historialAcciones, colaEspera);
                                        break;
                                    }
                                case 4:
                                    {
                                        biblioteca.GenerarInforme(listaDeLibros);
                                        break;
                                    }
                                case 5:
                                    {
                                        Console.Clear();
                                        menuBibliotecario = false;
                                        break;
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                             - Ingresa un número del 1 al 5.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                             INICIO DE SESIÓN");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                             - Credenciales incorrectas o permiso denegado");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                break;
            }
        case 2:
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                             INICIO DE SESIÓN");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("");
                Console.Write("                                             o Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("                                             o Contraseña: ");
                string contrasena = Console.ReadLine();
                bool verificacion = biblioteca.InicioSesionLector(listaDeUsuarios, nombre, contrasena);
                if (verificacion == true || (nombre == lectorPorDefecto.Nombre && contrasena == lectorPorDefecto.Contrasena))
                {
                    bool menuLector = true;
                    int opcionLector = 0;
                    while (menuLector)
                    {
                        try
                        {
                            MostrarMenuLectores();
                            opcion = Convert.ToInt32(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1:
                                    {
                                        MenuGestionPrestamos(prestamo, biblioteca, listaDeLibros, listaDeUsuarios, historialAcciones, colaEspera);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        menuLector = false;
                                        break;
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                             - Ingresa un número del 1 al 5.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                             INICIO DE SESIÓN");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                             - Credenciales incorrectas");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                break;
            }
        case 3:
            {
                biblioteca.RegistrarLector(listaDeUsuarios); 
                break;
            }
        case 4:
            {
                Console.Clear ();
                menu = false;
                break;
            }
    }
}
static void MostrarMenuPrincipal()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("                                             SISTEMA BIBLIOTECA");
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.ResetColor();
    Console.WriteLine("");
    Console.WriteLine("                                             [1] Ingresar como bibliotecario");
    Console.WriteLine("                                             [2] Ingresar como lector");
    Console.WriteLine("                                             [3] Registrarse");
    Console.WriteLine("                                             [4] Salir ");
}
static void MenuGestionLibros(Biblioteca biblioteca, LinkedList<Libro> listaDeLibros)
{
    int opcion;
    bool menu = true;
    while (menu)
    {
        try
        {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                             GESTIÓN DE LIBROS");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("                                             [1] Agregar un libro");
        Console.WriteLine("                                             [2] Buscar un libro");
        Console.WriteLine("                                             [3] Eliminar un libro");
        Console.WriteLine("                                             [4] Regresar a menú principal ");
        opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    {
                        biblioteca.AgregarLibro(listaDeLibros);
                        break;
                    }
                case 2:
                    {
                        biblioteca.BuscarLibro(listaDeLibros);
                        break;
                    }
                case 3:
                    {
                        biblioteca.EliminarLibro(listaDeLibros);
                        break;
                    }
                case 4:
                    {
                        menu = false;
                        break; ;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                                             - Ingresa un número del 1 al 4.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
static void MenuGestionUsuarios(Biblioteca biblioteca, LinkedList<Usuario> listaDeUsuarios)
{
    int opcion;
    bool menu = true;
    while (menu)
    {
        try
        {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                             GESTIÓN DE USUARIOS");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("");
        Console.ResetColor();
        Console.WriteLine("                                             [1] Registrar nuevo usuario (lector)");
        Console.WriteLine("                                             [2] Registrar nuevo usuario (bibliotecario)");
        Console.WriteLine("                                             [3] Editar usuario");
        Console.WriteLine("                                             [4] Eliminar usuario");
        Console.WriteLine("                                             [5] Regresar a menú principal ");
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
            {
            case 1:
                {
                    biblioteca.RegistrarLector(listaDeUsuarios);
                    break;
                }
            case 2:
                {
                    biblioteca.RegistrarBibliotecario(listaDeUsuarios);
                    break;
                }
            case 3:
                {
                    biblioteca.EditarUsuario(listaDeUsuarios);
                    break;
                }
            case 4:
                {
                    biblioteca.EliminarUsuario(listaDeUsuarios);
                    break;
                }
            case 5:
                {
                    menu = false;
                    break; ;
                }
            }
        }
        catch (Exception ex)
        {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("                                             - Ingresa un número del 1 al 5.");
        Console.ResetColor();
        Console.ReadKey();
        }
}
}
static void MenuGestionPrestamos(Prestamo prestamo, Biblioteca biblioteca, LinkedList<Libro> listaDeLibros, LinkedList<Usuario> listaDeUsuarios, Stack<Prestamo> historialAcciones, Queue<(Usuario, Libro)> colaEspera)
{
    int opcion;
    bool menu = true;
    while (menu)
    {
        try
        {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                             GESTIÓN DE PRESTAMOS");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("");
        Console.ResetColor();
        Console.WriteLine("                                             [1] Solicitar préstamo");
        Console.WriteLine("                                             [2] Devolver libro"); 
        Console.WriteLine("                                             [3] Regresar a menú principal ");
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
            {
            case 1:
                {

                        prestamo.PrestarLibro(biblioteca, listaDeLibros, listaDeUsuarios, historialAcciones, colaEspera);
                        Console.WriteLine("Libro prestado exitosamente");
                        Console.ReadKey();
                        
                        break;
                }
            case 2:
                {
                        prestamo.DevolverLibro(historialAcciones, listaDeLibros);
                        Console.WriteLine("Libro devuelto exitosamente");
                        Console.ReadKey();

                        break;
                }
            case 3:
                {
                    menu = false;
                    break; ;
                }
            }
        }
        catch (Exception ex)
        {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("                                             - Ingresa un número del 1 al 3.");
        Console.ResetColor();
        Console.ReadKey();
    }
}
}
static void MostrarMenuBibliotecarios()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("                                             SISTEMA DE GESTIÓN DE BIBLIOTECA");
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.ResetColor();
    Console.WriteLine("");
    Console.WriteLine("                                             [1] Gestión de libros.");
    Console.WriteLine("                                             [2] Gestión de usuarios.");
    Console.WriteLine("                                             [3] Gestión de préstamos.");
    Console.WriteLine("                                             [4] Generar informe.");
    Console.WriteLine("                                             [5] Cerrar sesión.");
}
static void MostrarMenuLectores()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("                                             SISTEMA DE GESTIÓN DE BIBLIOTECA");
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.ResetColor();
    Console.WriteLine("");
    Console.WriteLine("                                             [1] Gestión de préstamos.");
    Console.WriteLine("                                             [2] Cerrar sesión.");
}