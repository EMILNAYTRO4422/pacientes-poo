# Registro de Pacientes - Programación Orientada a Objetos

El mismo proyecto de la versión estructurada, transformado a **POO**. Los datos siguen en memoria, ahora dentro de una `List<Paciente>`.

**Autor:** Emil Gómez Rodríguez - 2026-0935

## Clases
| Clase | Responsabilidad |
|---|---|
| `Paciente` | Modelo: propiedades, propiedades calculadas (`NombreCompleto`, `Edad`), constructores (vacío, básico y completo) y métodos |
| `Entrada` | Clase estática que captura y valida lo que digita el usuario |
| `GestorPacientes` | Lógica: agregar, listar, buscar (sobrecarga de métodos), modificar y eliminar |
| `Program` | Menú principal. No se cierra hasta elegir Salir |

## Conceptos aplicados
Encapsulación (`private set`), propiedades auto-implementadas y calculadas, constructores, sobrecarga de métodos, métodos y clase estática, `List<T>`, LINQ (`FirstOrDefault`), `try/catch`, `switch`, `while` / `do-while`.

## Cómo ejecutar
1. Abrir `TareaPOO.csproj` en Visual Studio.
2. Presionar **F5**.
