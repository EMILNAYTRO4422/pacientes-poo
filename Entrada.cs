using System.Globalization;

namespace RegistroPacientes;

/// <summary>
/// Clase estatica de ayuda: captura y valida los datos que digita el usuario.
/// Al ser estatica no hace falta crear objetos de esta clase.
/// </summary>
public static class Entrada
{
    // Arreglo con los tipos de sangre permitidos
    private static readonly string[] _tiposSangreValidos = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };

    // Lee una linea, evita valores nulos y quita los espacios sobrantes
    public static string Leer()
    {
        string texto = Console.ReadLine();
        if (texto == null)
        {
            texto = "";
        }
        return texto.Trim();
    }

    // Pide un numero entero y repite hasta que el usuario digite uno valido
    public static int PedirEntero(string mensaje)
    {
        int numero = 0;
        bool valido = false;
        while (!valido)
        {
            Console.Write(mensaje);
            try
            {
                numero = Convert.ToInt32(Leer());
                valido = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Debe digitar un número entero válido.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("El número digitado es demasiado grande.");
            }
        }
        return numero;
    }

    public static string PedirTextoObligatorio(string campo)
    {
        string texto = "";
        do
        {
            Console.Write(campo + ": ");
            texto = Leer();
            if (texto == "")
            {
                Console.WriteLine("El campo no puede estar vacío.");
            }
        } while (texto == "");
        return texto;
    }

    // Valida solo el formato (11 digitos). Que no este repetida lo valida el gestor.
    public static string PedirCedula()
    {
        string cedula = "";
        bool valida = false;
        while (!valida)
        {
            Console.Write("Cédula (11 dígitos, sin guiones): ");
            cedula = Leer();
            if (cedula.Length == 11 && SoloDigitos(cedula))
            {
                valida = true;
            }
            else
            {
                Console.WriteLine("La cédula debe tener exactamente 11 dígitos numéricos.");
            }
        }
        return cedula;
    }

    public static DateTime PedirFechaNacimiento()
    {
        DateTime fecha = DateTime.Today;
        bool valida = false;
        while (!valida)
        {
            Console.Write("Fecha de nacimiento (dd/MM/aaaa): ");
            try
            {
                fecha = DateTime.ParseExact(Leer(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (fecha > DateTime.Today)
                {
                    Console.WriteLine("La fecha de nacimiento no puede ser futura.");
                }
                else if (fecha < DateTime.Today.AddYears(-120))
                {
                    Console.WriteLine("La fecha de nacimiento no es válida (más de 120 años).");
                }
                else
                {
                    valida = true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Use dd/MM/aaaa, por ejemplo 25/12/1990.");
            }
        }
        return fecha;
    }

    public static string PedirTelefono()
    {
        string telefono = "";
        bool valido = false;
        while (!valido)
        {
            Console.Write("Teléfono (10 dígitos, sin guiones): ");
            telefono = Leer();
            if (telefono.Length == 10 && SoloDigitos(telefono))
            {
                valido = true;
            }
            else
            {
                Console.WriteLine("El teléfono debe tener exactamente 10 dígitos numéricos.");
            }
        }
        return telefono;
    }

    public static string PedirTipoSangre()
    {
        string tipo = "";
        bool valido = false;
        while (!valido)
        {
            Console.Write("Tipo de sangre (A+, A-, B+, B-, AB+, AB-, O+, O-): ");
            tipo = Leer().ToUpper();
            if (Array.IndexOf(_tiposSangreValidos, tipo) >= 0)
            {
                valido = true;
            }
            else
            {
                Console.WriteLine("Tipo de sangre inválido.");
            }
        }
        return tipo;
    }

    private static bool SoloDigitos(string texto)
    {
        foreach (char caracter in texto)
        {
            if (!char.IsDigit(caracter))
            {
                return false;
            }
        }
        return true;
    }
}
