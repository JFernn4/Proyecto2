﻿using Proyecto2;
LinkedList<Usuario> listaDeUsuarios = new LinkedList<Usuario>();
Biblioteca biblioteca = new Biblioteca();
LinkedList<Libro> listaDeLibros = new LinkedList<Libro>();
bool menu = true;
int opcion = 0;
while (menu)
{
    try
    {
        MostrarMenu();
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                {
                    MenuGestionLibros(biblioteca,listaDeLibros);
                    break;
                }
            case 2:
                {
                    MenuGestionUsuarios();
                    break;
                }
            case 3:
                {
                    MenuGestionPrestamos();
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
                    menu = false;
                    break;
                }
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ingresa un número del 1 al 7.");
        Console.ResetColor();
        Console.ReadKey();
    }
}
static void MenuGestionLibros(Biblioteca biblioteca, LinkedList<Libro> listaDeLibros)
{
    int opcion;
    bool menu = true;
    while (menu)
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
}
static void MenuGestionUsuarios()
{
    int opcion;
    bool menu = true;
    while (menu)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                             GESTIÓN DE USUARIOS");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine("                                             [1] Registrar nuevo usuario");
        Console.WriteLine("                                             [2] Editar usuario");
        Console.WriteLine("                                             [3] Eliminar usuario");
        Console.WriteLine("                                             [4] Regresar a menú principal ");
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                {
                    break;
                }
            case 2:
                {
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    menu = false;
                    break; ;
                }
        }
    }
}
static void MenuGestionPrestamos()
{
    int opcion;
    bool menu = true;
    while (menu)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                             GESTIÓN DE PRESTAMOS");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("");
        Console.ResetColor();
        Console.WriteLine("                                             [1] Solicitar préstamo");
        Console.WriteLine("                                             [2] Devolver libro"); ;
        Console.WriteLine("                                             [3] Regresar a menú principal ");
        opcion = Convert.ToInt32(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                {
                    break;
                }
            case 2:
                {
                    break;
                }
            case 3:
                {
                    menu = false;
                    break; ;
                }
        }
    }
}
static void MostrarMenu()
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
    Console.WriteLine("                                             [5] Salir del sistema.");
}
