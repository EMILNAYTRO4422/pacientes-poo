namespace RegistroPacientes;

/// <summary>
/// Administra los pacientes en memoria: una sola lista de objetos Paciente
/// reemplaza a los diccionarios individuales de la version anterior.
/// </summary>
public class GestorPacientes
{
    private List<Paciente> _pacientes = new List<Paciente>();
    private int _siguienteId = 1;

    // ===================== AGREGAR =====================
    public void Agregar()
    {
        Console.WriteLine("--- AGREGAR PACIENTE ---");
        Paciente paciente = new Paciente();
        paciente.Nombre = Entrada.PedirTextoObligatorio("Nombre");
        paciente.Apellido = Entrada.PedirTextoObligatorio("Apellido");
        paciente.Cedula = PedirCedulaUnica(0);
        paciente.FechaNacimiento = Entrada.PedirFechaNacimiento();
        paciente.Telefono = Entrada.PedirTelefono();
        paciente.TipoSangre = Entrada.PedirTipoSangre();
        paciente.Direccion = Entrada.PedirTextoObligatorio("Dirección");

        paciente.AsignarId(_siguienteId);
        _siguienteId++;
        _pacientes.Add(paciente);

        Console.WriteLine("Paciente agregado correctamente con el Id " + paciente.Id + ".");
    }

    // ===================== LISTAR =====================
    public void Listar()
    {
        Console.WriteLine("--- LISTADO DE PACIENTES ---");
        if (_pacientes.Count == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
        }
        else
        {
            MostrarTabla(_pacientes);
        }
    }

    // ===================== BUSCAR =====================
    public void Buscar()
    {
        List<Paciente> encontrados = new List<Paciente>();
        int criterio = 0;

        Console.WriteLine("--- BUSCAR PACIENTE ---");
        Console.WriteLine("1. Por Id");
        Console.WriteLine("2. Por nombre o apellido");
        Console.WriteLine("3. Por cédula");
        Console.WriteLine("4. Por tipo de sangre");
        criterio = Entrada.PedirEntero("Elija el criterio de búsqueda: ");

        switch (criterio)
        {
            case 1:
                int idBuscado = Entrada.PedirEntero("Digite el Id: ");
                Paciente porId = BuscarPacientes(idBuscado);
                if (porId != null)
                {
                    encontrados.Add(porId);
                }
                break;
            case 2:
                Console.Write("Digite el nombre o apellido (o parte de él): ");
                encontrados = BuscarPacientes(Entrada.Leer());
                break;
            case 3:
                Console.Write("Digite la cédula: ");
                string cedula = Entrada.Leer();
                foreach (Paciente paciente in _pacientes)
                {
                    if (paciente.Cedula == cedula)
                    {
                        encontrados.Add(paciente);
                    }
                }
                break;
            case 4:
                string tipoSangre = Entrada.PedirTipoSangre();
                foreach (Paciente paciente in _pacientes)
                {
                    if (paciente.TipoSangre == tipoSangre)
                    {
                        encontrados.Add(paciente);
                    }
                }
                break;
            default:
                Console.WriteLine("Criterio inválido. Digite un número del 1 al 4.");
                break;
        }

        if (criterio >= 1 && criterio <= 4)
        {
            if (encontrados.Count == 0)
            {
                Console.WriteLine("No se encontraron pacientes con ese criterio.");
            }
            else
            {
                Console.WriteLine("Resultados encontrados: " + encontrados.Count);
                MostrarTabla(encontrados);
            }
        }
    }

    // Sobrecarga 1: busca un paciente por su Id (devuelve null si no existe)
    private Paciente BuscarPacientes(int id)
    {
        return _pacientes.FirstOrDefault(p => p.Id == id);
    }

    // Sobrecarga 2: busca pacientes cuyo nombre o apellido contenga el texto
    private List<Paciente> BuscarPacientes(string texto)
    {
        List<Paciente> resultado = new List<Paciente>();
        string textoMinuscula = texto.ToLower();
        foreach (Paciente paciente in _pacientes)
        {
            if (paciente.Nombre.ToLower().Contains(textoMinuscula) || paciente.Apellido.ToLower().Contains(textoMinuscula))
            {
                resultado.Add(paciente);
            }
        }
        return resultado;
    }

    // ===================== MODIFICAR =====================
    public void Modificar()
    {
        Console.WriteLine("--- MODIFICAR PACIENTE ---");
        if (_pacientes.Count == 0)
        {
            Console.WriteLine("No hay pacientes para modificar.");
            return;
        }

        MostrarTabla(_pacientes);
        int id = Entrada.PedirEntero("Digite el Id del paciente a modificar: ");
        Paciente paciente = BuscarPacientes(id);

        if (paciente == null)
        {
            Console.WriteLine("No existe un paciente con ese Id.");
            return;
        }

        int campo = -1;
        while (campo != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Paciente: " + paciente.NombreCompleto);
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Apellido");
            Console.WriteLine("3. Cédula");
            Console.WriteLine("4. Fecha de nacimiento");
            Console.WriteLine("5. Teléfono");
            Console.WriteLine("6. Tipo de sangre");
            Console.WriteLine("7. Dirección");
            Console.WriteLine("0. Terminar de modificar");
            campo = Entrada.PedirEntero("¿Qué dato desea modificar?: ");

            switch (campo)
            {
                case 1:
                    paciente.Nombre = Entrada.PedirTextoObligatorio("Nuevo nombre");
                    Console.WriteLine("Nombre actualizado.");
                    break;
                case 2:
                    paciente.Apellido = Entrada.PedirTextoObligatorio("Nuevo apellido");
                    Console.WriteLine("Apellido actualizado.");
                    break;
                case 3:
                    paciente.Cedula = PedirCedulaUnica(paciente.Id);
                    Console.WriteLine("Cédula actualizada.");
                    break;
                case 4:
                    paciente.FechaNacimiento = Entrada.PedirFechaNacimiento();
                    Console.WriteLine("Fecha de nacimiento actualizada.");
                    break;
                case 5:
                    paciente.Telefono = Entrada.PedirTelefono();
                    Console.WriteLine("Teléfono actualizado.");
                    break;
                case 6:
                    paciente.TipoSangre = Entrada.PedirTipoSangre();
                    Console.WriteLine("Tipo de sangre actualizado.");
                    break;
                case 7:
                    paciente.Direccion = Entrada.PedirTextoObligatorio("Nueva dirección");
                    Console.WriteLine("Dirección actualizada.");
                    break;
                case 0:
                    Console.WriteLine("Modificación finalizada.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Digite un número del 0 al 7.");
                    break;
            }
        }
    }

    // ===================== ELIMINAR =====================
    public void Eliminar()
    {
        Console.WriteLine("--- ELIMINAR PACIENTE ---");
        if (_pacientes.Count == 0)
        {
            Console.WriteLine("No hay pacientes para eliminar.");
            return;
        }

        MostrarTabla(_pacientes);
        int id = Entrada.PedirEntero("Digite el Id del paciente a eliminar: ");
        Paciente paciente = BuscarPacientes(id);

        if (paciente == null)
        {
            Console.WriteLine("No existe un paciente con ese Id.");
            return;
        }

        int confirmacion = 0;
        while (confirmacion != 1 && confirmacion != 2)
        {
            Console.WriteLine("¿Seguro que desea eliminar a " + paciente.NombreCompleto + "? 1. Sí  2. No");
            confirmacion = Entrada.PedirEntero("Opción: ");
            if (confirmacion != 1 && confirmacion != 2)
            {
                Console.WriteLine("Opción inválida. Digite 1 para Sí o 2 para No.");
            }
        }

        if (confirmacion == 1)
        {
            _pacientes.Remove(paciente);
            Console.WriteLine("Paciente eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Eliminación cancelada.");
        }
    }

    // ===================== METODOS AUXILIARES =====================
    private void MostrarTabla(List<Paciente> lista)
    {
        Console.WriteLine(Paciente.ObtenerEncabezado());
        foreach (Paciente paciente in lista)
        {
            Console.WriteLine(paciente.ObtenerFila());
        }
    }

    // idExcluir: Id del paciente que se esta modificando (0 si se esta agregando uno nuevo)
    private string PedirCedulaUnica(int idExcluir)
    {
        string cedula = "";
        bool repetida = true;
        while (repetida)
        {
            cedula = Entrada.PedirCedula();
            repetida = false;
            foreach (Paciente paciente in _pacientes)
            {
                if (paciente.Cedula == cedula && paciente.Id != idExcluir)
                {
                    repetida = true;
                }
            }
            if (repetida)
            {
                Console.WriteLine("Ya existe un paciente registrado con esa cédula.");
            }
        }
        return cedula;
    }
}
