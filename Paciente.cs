namespace RegistroPacientes;

/// <summary>
/// Representa a un paciente del sistema. Reune en un solo objeto todos los datos
/// que antes estaban separados en listas y diccionarios.
/// </summary>
public class Paciente
{
    // ---------- Propiedades ----------
    // Id solo se puede cambiar desde la propia clase (private set), a traves de AsignarId
    public int Id { get; private set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Cedula { get; set; } = "";
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; } = "";
    public string TipoSangre { get; set; } = "";
    public string Direccion { get; set; } = "";

    // ---------- Propiedades calculadas (no se guardan, se calculan al consultarlas) ----------
    public string NombreCompleto => Nombre + " " + Apellido;

    public int Edad
    {
        get
        {
            int edad = DateTime.Today.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }
    }

    // ---------- Constructores ----------
    // Vacio: crea el objeto y luego se llenan las propiedades
    public Paciente()
    {
    }

    // Basico: solo nombre y apellido
    public Paciente(string nombre, string apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
    }

    // Completo: todos los datos
    public Paciente(int id, string nombre, string apellido, string cedula, DateTime fechaNacimiento,
                    string telefono, string tipoSangre, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Cedula = cedula;
        FechaNacimiento = fechaNacimiento;
        Telefono = telefono;
        TipoSangre = tipoSangre;
        Direccion = direccion;
    }

    // ---------- Metodos ----------
    public void AsignarId(int id)
    {
        Id = id;
    }

    // Metodo estatico: no necesita un objeto para usarse (Paciente.ObtenerEncabezado())
    public static string ObtenerEncabezado()
    {
        return "Id    Nombre completo             Cédula       Nacimiento   Edad  Teléfono    Sangre Dirección\n"
             + "-----------------------------------------------------------------------------------------------";
    }

    // Devuelve los datos del paciente en una linea para mostrarlos en la tabla
    public string ObtenerFila()
    {
        return Id.ToString().PadRight(6)
             + NombreCompleto.PadRight(28)
             + Cedula.PadRight(13)
             + FechaNacimiento.ToString("dd/MM/yyyy").PadRight(13)
             + Edad.ToString().PadRight(6)
             + Telefono.PadRight(12)
             + TipoSangre.PadRight(7)
             + Direccion;
    }
}
