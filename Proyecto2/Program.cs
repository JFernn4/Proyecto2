
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
                    break;
                }
            case 5:
                {
                    break;
                }
            case 6:
                {
                    break;
                }
            case 7:
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
static void MostrarMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--------------------------------");
    Console.WriteLine("SISTEMA DE GESTIÓN DE BIBLIOTECA");
    Console.WriteLine("--------------------------------");
    Console.ResetColor();
    Console.WriteLine("[1] Gestión de libros.");
    Console.WriteLine("[2] Getión de usuarios.");
    Console.WriteLine("[3] Gestión de préstamos.");
    Console.WriteLine("[4] Salir del sistema.");
}
