/*
    Tarea: Proyecto transformado a Programación Orientada a Objetos
    Sistema de Registro de Pacientes (consola)
    Autor: Emil Gomez Rodriguez - 2026-0935

    Clases:
      - Paciente         : modelo de datos (propiedades, constructores y metodos)
      - Entrada          : clase estatica que captura y valida los datos del usuario
      - GestorPacientes  : logica del sistema (agregar, listar, buscar, modificar, eliminar)
    Los datos se guardan en memoria en una List<Paciente>.
    El programa no se cierra hasta que el usuario elige la opcion Salir.
*/

using RegistroPacientes;

GestorPacientes gestor = new GestorPacientes();
int opcion = 0;

Console.WriteLine("========================================");
Console.WriteLine("      REGISTRO DE PACIENTES");
Console.WriteLine("========================================");

while (opcion != 6)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("-------------- MENÚ PRINCIPAL --------------");
        Console.WriteLine("1. Agregar paciente");
        Console.WriteLine("2. Listar pacientes");
        Console.WriteLine("3. Buscar paciente");
        Console.WriteLine("4. Modificar paciente");
        Console.WriteLine("5. Eliminar paciente");
        Console.WriteLine("6. Salir");
        opcion = Entrada.PedirEntero("Elija una opción: ");
        Console.WriteLine();

        switch (opcion)
        {
            case 1:
                gestor.Agregar();
                break;
            case 2:
                gestor.Listar();
                break;
            case 3:
                gestor.Buscar();
                break;
            case 4:
                gestor.Modificar();
                break;
            case 5:
                gestor.Eliminar();
                break;
            case 6:
                Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                break;
            default:
                Console.WriteLine("Opción inválida. Digite un número del 1 al 6.");
                break;
        }
    }
    catch (Exception ex)
    {
        // Red de seguridad: cualquier error no previsto se muestra y el programa continua
        Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
    }
    finally
    {
        Console.WriteLine("--------------------------------------------");
    }
}
