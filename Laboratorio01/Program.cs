using System;

namespace Laboratorio01
{
    class Program
    {
        static void Main(string[] args)
        {
            int pinCorrecto = 1234; // Establece aquí el PIN correcto
            double saldoInicial = 1000;
            int numeroCuenta = 123456789;
            string titularCuenta = "Juan Pérez";
            double limiteDiarioRetiro = 500;

            Console.WriteLine("Bienvenido al Cajero Automático");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Ingrese su PIN para acceder al sistema.");
            int intentos = 0;
            bool accesoPermitido = false;

            while (intentos < 3 && !accesoPermitido)
            {
                Console.Write("PIN: ");
                string pinStr = Console.ReadLine();

                if (int.TryParse(pinStr, out int pinIngresado))
                {
                    if (pinIngresado == pinCorrecto)
                    {
                        accesoPermitido = true; // Corrección: Se debe establecer accesoPermitido en true
                    }
                    else
                    {
                        intentos++;
                        Console.WriteLine("PIN incorrecto. Intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                }
            }

            if (accesoPermitido)
            {
                CajeroAutomatico cajero = new CajeroAutomatico(pinCorrecto, saldoInicial, numeroCuenta, titularCuenta, limiteDiarioRetiro);
                Console.WriteLine("Acceso concedido. Opciones disponibles:");

                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Consultar saldo");
                    Console.WriteLine("2. Agregar fondos");
                    Console.WriteLine("3. Retirar efectivo");
                    Console.WriteLine("4. Cambiar PIN");
                    Console.WriteLine("0. Salir");
                    Console.Write("Ingrese el número de opción deseada: ");
                    string opcionStr = Console.ReadLine();

                    if (int.TryParse(opcionStr, out int opcion))
                    {
                        switch (opcion)
                        {
                            case 0:
                                salir = true;
                                Console.WriteLine("Gracias por utilizar el Cajero Automático. ¡Hasta luego!");
                                break;
                            case 1:
                                double saldoActual = cajero.ConsultarSaldo();
                                Console.WriteLine("El saldo actual de la cuenta es: " + saldoActual);
                                break;
                            case 2:
                                Console.Write("Ingrese la cantidad de fondos a agregar (0 para cancelar): ");
                                string fondosStr = Console.ReadLine();
                                if (double.TryParse(fondosStr, out double fondos))
                                {
                                    if (fondos > 0)
                                    {
                                        cajero.AgregarFondos(fondos);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Operación cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida. Intente nuevamente.");
                                }
                                break;
                            case 3:
                                Console.Write("Ingrese la cantidad de efectivo a retirar (0 para cancelar): ");
                                string cantidadRetiroStr = Console.ReadLine();
                                if (double.TryParse(cantidadRetiroStr, out double cantidadRetiro))
                                {
                                    if (cantidadRetiro > 0)
                                    {
                                        cajero.RetirarEfectivo(cantidadRetiro);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Operación cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida. Intente nuevamente.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Ingrese el nuevo PIN actual:");
                                string nuevoPinStr = Console.ReadLine();
                                if (int.TryParse(nuevoPinStr, out int nuevoPin))
                                {
                                    if (nuevoPin == pinCorrecto)
                                    {
                                        Console.WriteLine("Ingrese el nuevo PIN:");
                                        string nuevoPinConfirmStr = Console.ReadLine();
                                        if (int.TryParse(nuevoPinConfirmStr, out int nuevoPinConfirm))
                                        {
                                            pinCorrecto = nuevoPinConfirm;
                                            Console.WriteLine("PIN cambiado exitosamente.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Entrada inválida. Intente nuevamente.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El PIN actual no coincide.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                                }
                                break;
                            default:
                                Console.WriteLine("Opción inválida. Intente nuevamente.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ha excedido el número máximo de intentos permitidos. El acceso ha sido bloqueado.");
            }
        }
    }
}
