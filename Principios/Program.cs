using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trabajo2; // Agrega la referencia al espacio de nombres Trabajo2

class Program
{
    static void Main(string[] args)
    {
        // Obtener la ruta completa del archivo CSV en el directorio de trabajo actual.
        string directorioDeTrabajo = Directory.GetCurrentDirectory();
        string csvFilePath = Path.Combine(directorioDeTrabajo, "empleados.csv");

        // Verificar si el archivo CSV existe.
        if (!File.Exists(csvFilePath))
        {
            // Si el archivo no existe, crearlo con un encabezado opcional.
            File.WriteAllText(csvFilePath, "Nombre,Cargo\n");
        }

        List<Empleado> empleados = new List<Empleado>();

        // Variable booleana para controlar el ciclo principal del programa.
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Listar empleados");
            Console.WriteLine("2. Consultar sueldo");
            Console.WriteLine("3. Crear nuevo empleado");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Nombres de empleados disponibles:");
                        foreach (var empleado in empleados)
                        {
                            Console.WriteLine(empleado.Nombre);
                        }
                        break;
                    case 2:
                        Console.Write("Escribe el nombre del empleado para obtener su sueldo: ");
                        string nombreEmpleado = Console.ReadLine();
                        Empleado empleadoSeleccionado = empleados.FirstOrDefault(e => e.Nombre.Equals(nombreEmpleado, StringComparison.OrdinalIgnoreCase));

                        if (empleadoSeleccionado != null)
                        {
                            // Crear una instancia de Persona y utilizar el método caculoSueldo
                            Persona persona = new Persona();
                            int sueldo = persona.caculoSueldo(empleadoSeleccionado.Cargo);
                            if (sueldo > 0)
                            {
                                Console.WriteLine($"Sueldo de {empleadoSeleccionado.Nombre} ({empleadoSeleccionado.Cargo}): {sueldo:C}");
                            }
                            else
                            {
                                Console.WriteLine($"No se encontró un sueldo para {empleadoSeleccionado.Nombre} ({empleadoSeleccionado.Cargo}).");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró un empleado con el nombre {nombreEmpleado}.");
                        }
                        break;
                    case 3:
                        Console.Write("Escribe el nombre del nuevo empleado: ");
                        string nuevoNombre = Console.ReadLine();
                        Console.Write("Escribe el cargo del nuevo empleado: ");
                        string nuevoCargo = Console.ReadLine();

                        empleados.Add(new Empleado { Nombre = nuevoNombre, Cargo = nuevoCargo });

                        // Actualizar el archivo CSV con el nuevo empleado.
                        File.AppendAllText(csvFilePath, $"{nuevoNombre},{nuevoCargo}\n");
                        break;
                    case 4:
                        continuar = false; // Salir del programa.
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
            }
        }
    }

    // Resto del programa...

    public class Empleado
    {
        public string Nombre { get; set; }
        public string Cargo { get; set; }
    }
}

