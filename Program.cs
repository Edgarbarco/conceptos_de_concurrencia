using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrudConTareas
{
    class Program
    {
        static List<string> datos = new List<string>();

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Selecciona una opción:");
                Console.WriteLine("1. Crear registro");
                Console.WriteLine("2. Leer registros");
                Console.WriteLine("3. Actualizar registro");
                Console.WriteLine("4. Eliminar registro");
                Console.WriteLine("5. Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await CrearRegistro();
                        break;
                    case "2":
                        await LeerRegistros();
                        break;
                    case "3":
                        await ActualizarRegistro();
                        break;
                    case "4":
                        await EliminarRegistro();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        static async Task CrearRegistro()
        {
            Console.WriteLine("Ingrese el nuevo registro:");
            var nuevoRegistro = Console.ReadLine();
            
            await Task.Run(() =>
            {
                // Simulamos una operación de larga duración con un retardo de 2 segundos
                Thread.Sleep(2000);
                datos.Add(nuevoRegistro);
                Console.WriteLine("Registro creado exitosamente.");
            });
        }

        static async Task LeerRegistros()
        {
            await Task.Run(() =>
            {
                // Simulamos una operación de larga duración con un retardo de 1 segundo
                Thread.Sleep(1000);
                Console.WriteLine("Registros:");
                foreach (var dato in datos)
                {
                    Console.WriteLine(dato);
                }
            });
        }

        static async Task ActualizarRegistro()
        {
            Console.WriteLine("Ingrese el índice del registro a actualizar:");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("Ingrese el nuevo valor:");
                var nuevoValor = Console.ReadLine();

                await Task.Run(() =>
                {
                    // Simulamos una operación de larga duración con un retardo de 2 segundos
                    Thread.Sleep(2000);

                    if (indice >= 0 && indice < datos.Count)
                    {
                        datos[indice] = nuevoValor;
                        Console.WriteLine("Registro actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                });
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }

        static async Task EliminarRegistro()
        {
            Console.WriteLine("Ingrese el índice del registro a eliminar:");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                await Task.Run(() =>
                {
                    // Simulamos una operación de larga duración con un retardo de 1 segundo
                    Thread.Sleep(1000);

                    if (indice >= 0 && indice < datos.Count)
                    {
                        datos.RemoveAt(indice);
                        Console.WriteLine("Registro eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                });
            }
            else
            {
                Console.WriteLine("Índice inválido.");
            }
        }
    }
}
