using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlejandroAguilarArce
{
    internal class Program
    {

        static readonly int N = 15; // Lo hice con el carnet de la UH

        // Aqui fue donde use los arrreglos paralelos
        // lo que hice fue que la misma posicion, relaciona al paciente con su gravedad
        static string[] paciente = new string[N];
        static int[] gravedad = new int[N];


        static int cantidad = 0; //la cantidad, para controlar cuantos pacientes hay


        static void IngresarPaciente()
        {
            if (cantidad < N)
            {
                Console.Write("Ingrese el nombre del paciente: ");
                paciente[cantidad] = Console.ReadLine();

                Console.Write("Ingrese el nivel de gravedad (1-5): ");
                int nivel = int.Parse(Console.ReadLine());

                while (nivel < 1 || nivel > 5)
                {
                    Console.WriteLine("Nivel de gravedad incorrecto");
                    Console.Write("Ingrese un nivel entre 1 y 5: ");
                    nivel = int.Parse(Console.ReadLine());
                }

                gravedad[cantidad] = nivel;

                cantidad++;

                Console.WriteLine("Paciente registrado correctamente");
            }
            else
            {
                Console.WriteLine("Se alcanzo el limite maximo de pacientes");
            }
        }


        static void MostrarPacientes()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay pacientes registrados");
            }
            else
            {
                Console.WriteLine("****** Lista de Pacientes ******");

                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine($"Paciente: {paciente[i]} - Gravedad: {gravedad[i]}");
                }
            }
        }


        static void ModificarGravedad()
        {
            Boolean pEncontrado = false;

            Console.Write("Digite un paciente: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < cantidad; i++)
            {
                if (paciente[i] == nombre)
                {
                    Console.WriteLine($"El paciente {paciente[i]} tiene una gravedad de {gravedad[i]}");

                    Console.Write("Digite el nuevo nivel de gravedad (1-5): ");
                    int nivel = int.Parse(Console.ReadLine());

                    while (nivel < 1 || nivel > 5)
                    {
                        Console.WriteLine("Nivel de gravedad incorrecto");
                        Console.Write("Digite un nivel entre 1 y 5: ");
                        nivel = int.Parse(Console.ReadLine());
                    }

                    // Se modifica la gravedad en la misma posicion del paciente.
                    gravedad[i] = nivel;

                    pEncontrado = true;
                    break;
                }
            }

            if (pEncontrado == false)
            {
                Console.WriteLine("Paciente no encontrado");
            }
            else
            {
                Console.WriteLine("Gravedad modificada correctamente");
            }
        }


        static void EliminarPaciente()
        {
            Boolean pEncontrado = false;

            Console.Write("Digite un paciente: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < cantidad; i++)
            {
                if (paciente[i] == nombre)
                {
                    for (int j = i; j < cantidad - 1; j++)
                    {
                        // Se desplazan ambos arreglos para cumplir con lo que decia
                        // en las instrucciones, de "mantener la sincronizacion"
                        // yo lo entendi como que, cuando se quita un paciente, que luego 
                        // al mover los otros, no se mezclaran las gravedades
                        paciente[j] = paciente[j + 1];
                        gravedad[j] = gravedad[j + 1];
                    }

                    cantidad--;

                    pEncontrado = true;
                    break;
                }
            }

            if (pEncontrado == false)
            {
                Console.WriteLine("Paciente no encontrado");
            }
            else
            {
                Console.WriteLine("Paciente eliminado correctamente");
            }
        }


        //// Decidi tomar 1 como la mayor prioridad y 5 como la menor,
        // basicamente porque el enunciado no especifica el orden de gravedad.
        // y he visto que usualemte asi lo manejan los hospitales, que el 1 es lo 
        // mas prioritario, incluso me parece intuitivo

        static void Menu()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("===== HOSPITAL SAN RAFAEL =====");
                Console.WriteLine("1. Ingresar Paciente");
                Console.WriteLine("2. Mostrar Pacientes");
                Console.WriteLine("3. Modificar Gravedad");
                Console.WriteLine("4. Eliminar Paciente");
                Console.WriteLine("5. Salir");

                Console.Write("Ingrese una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarPaciente();
                        break;

                    case 2:
                        MostrarPacientes();
                        break;

                    case 3:
                        ModificarGravedad();
                        break;

                    case 4:
                        EliminarPaciente();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }

            } while (opcion != 5);
        }


        static void Main(string[] args)
        {
            Menu();
        }
    }
}
