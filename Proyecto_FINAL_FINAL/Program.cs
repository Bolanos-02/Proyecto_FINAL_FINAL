using biblioteca_de_clases;
using Proyecto_final;
using System;



class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE TARJETAS ===");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Registrar cargo");
            Console.WriteLine("3. Registrar abono");
            Console.WriteLine("4. Ver resumen");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese dpi: ");
                    int carne = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese nombre: ");
                    string nombre = Console.ReadLine();
                    ResumenCliente nuevo = new ResumenCliente(carne, nombre);
                    EstructuraGlobal.TablaResumenClientes.Insertar(carne.ToString(), nuevo);
                    Console.WriteLine("Cliente registrado.");
                    break;

                case "2":
                    Console.Write("Ingrese dpi: ");
                    string carneCargo = Console.ReadLine();
                    Console.Write("Monto del cargo: ");
                    int montoCargo = int.Parse(Console.ReadLine());
                    var clienteCargo = (ResumenCliente)EstructuraGlobal.TablaResumenClientes.Buscar(carneCargo);
                    if (clienteCargo != null)
                    {
                        clienteCargo.AgregarCargo(montoCargo);
                        Console.WriteLine("Cargo aplicado.");
                    }
                    else Console.WriteLine("Cliente no encontrado.");
                    break;

                case "3":
                    Console.Write("Ingrese dpi: ");
                    string carneAbono = Console.ReadLine();
                    Console.Write("Monto del abono: ");
                    int montoAbono = int.Parse(Console.ReadLine());
                    var clienteAbono = (ResumenCliente)EstructuraGlobal.TablaResumenClientes.Buscar(carneAbono);
                    if (clienteAbono != null)
                    {
                        clienteAbono.AgregarAbono(montoAbono);
                        Console.WriteLine("Abono aplicado.");
                    }
                    else Console.WriteLine("Cliente no encontrado.");
                    break;

                case "4":
                    Console.Write("Ingrese dpi: ");
                    string carneResumen = Console.ReadLine();
                    var resumen = (ResumenCliente)EstructuraGlobal.TablaResumenClientes.Buscar(carneResumen);
                    if (resumen != null)
                        Console.WriteLine(resumen);
                    else
                        Console.WriteLine("Cliente no encontrado.");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}