using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{

    internal class Program
    {
        static int i, opcion,x, index,nCaseta, nMonto, faltante, total;
        static string nPlaca, tVehiculo, lista;
        static int[] facturas = new int[15];
        static string[] placa = new string[15];
        static string[] fecha = new string[15];
        static string[] hora = new string[15];
        static string[] vehiculo = new string[15];
        static int[] caseta = new int[15];
        static int[] monto = new int[15];
        static int[] pago = new int[15];
        static int[] vuelto = new int[15];

        static void Main(string[] args)
        {

            mostrarMenu();

        }
        public static void mostrarMenu()
        {

            do
            {
                Console.WriteLine("Menu principal del Sistema: ");
                Console.WriteLine("1 - Inicializar Vectores. \n2 - Ingresar Paso Vehicular. \n3 - Consulta de datos por Numero de Placa.");
                Console.WriteLine("4 - Modificar Datos por Numero de Placa. \n5 - Reporte todos los Datos de los Vectores. \n6 - Salir");
                Console.WriteLine("Digite la opcion que desea");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        iniciarVariable(); 
                        break;
                    case 2:
                        ingresarDatos();
                        break;
                    case 3:
                        consultaDatos();
                        break;
                    case 4:
                        modificarDatos();
                            break;
                    case 5:
                        Console.WriteLine("");
                        Console.WriteLine("                                                    Reporte de Paso");
                        Console.WriteLine("Numero de Factura " + " Placa " + " Tipo de Vehiculo " + " Caseta " + " Monto por Vehiculo " + " Monto de Pago " + " Vuelto ");
                        Console.WriteLine("=============================================================================================");
                        for (x = 0; x < facturas.Length; x++)
                        {
                            lista += facturas[x] + " " + placa[x] + " " + vehiculo[x] + " " + caseta[x] + " " + monto[x] + " " + pago[x] + " " + vuelto[i] + "\n";
                            total += monto[x];
                        }
                        Console.WriteLine("=============================================================================================");
                        Console.WriteLine("Total: " + total + "Cantidad de Vehiculos: " + facturas[x]);
                        Console.WriteLine("=============================================================================================");
                        break;
                    case 6:
                        //Salida
                        

                        break;
                    default:
                        Console.WriteLine("La opcion ingresada no es valida. \nIntente de nuevo.");
                        break;


                }
            } while (opcion != 6);
            Console.Write("Gracias por su estadia. \nVuelva pronto");
        }
        public static void iniciarVariable()
        {
            i = 0;
            Console.WriteLine("Inicializando Vectores");
            for (int i = 0; i < facturas.Length; i++)
            {
                facturas[i] = 0;
                placa[i] = "";
                vehiculo[i] = "";
                fecha[i] = "";
                hora[i] = "";
                caseta[i] = 0;
                monto[i] = 0;
                pago[i] = 0;
                vuelto[i] = 0;
            }
            Console.WriteLine("Vectores Reiniciados\n");

        }
        public static void ingresarDatos()
        {
            do
            {
                Console.WriteLine("Ingresar Datos de Paso Vehicular: ");
                Console.WriteLine("1 - Ingresar Datos. \n2 - Salir.\n");
                Console.WriteLine("Digite la opcion que desea");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    for (int i = 0; i < facturas.Length; i++)
                    {
                        facturas[i] = i + 1;
                        Console.WriteLine("\nNumero de factura: " + facturas[i]);
                        Console.WriteLine("Ingrese la fecha");
                        fecha[i] = Console.ReadLine();
                        Console.WriteLine("Ingrese la Hora");
                        hora[i] = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de Placa");
                        placa[i] = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("\nIngrese el tipo de Vehiculo. \n1= Moto. \n2= Vehículo Liviano. \n3=Camión o Pesado. \n4=Autobús");
                            opcion = int.Parse(Console.ReadLine());
                            if (opcion == 1)
                            {
                                vehiculo[i] = "Moto";
                            }
                            else if (opcion == 2)
                            {
                                vehiculo[i] = "Vehiculo Liviano";
                            }
                            else if (opcion == 3)
                            {
                                vehiculo[i] = "Camion o Pesado";
                            }
                            else if (opcion == 4)
                            {
                                vehiculo[i] = "Autobus";
                            }
                            else
                            {
                                Console.WriteLine("La opcion no existe. Intente de nuevo.\n");
                            }
                        } while (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4);
                        //Caseta
                        do
                        {
                            Console.WriteLine("\nPaso por caseta: 1, 2, or 3?");
                            caseta[i] = int.Parse(Console.ReadLine());
                            if (caseta[i] != 1 && caseta[i] != 2 && caseta[i] != 3)
                            {
                                Console.WriteLine("Seleccione entre caseta: 1, 2, o 3");
                            }

                        } while (caseta[i] != 1 && caseta[i] != 2 && caseta[i] != 3);
                        //Asignacion de Monton por vehiculo
                        if (vehiculo[i].Contains("Moto"))
                        {
                            monto[i] = 500;
                        }
                        else if (vehiculo[i].Contains("Vehiculo Liviano"))
                        {
                            monto[i] = 700;
                        }
                        else if (vehiculo[i].Contains("Camion o Pesado"))
                        {
                            monto[i] = 2700;
                        }
                        else
                        {
                            monto[i] = 3700;
                        }
                        //Recibimo el monto con el que se va a pagar
                        do{
                            Console.WriteLine("El monto a pagar es de: " + monto[i]+" por ser " + vehiculo[i]);
                            Console.WriteLine("Con cuanto cancela?");
                            pago[i] = int.Parse(Console.ReadLine());
                            if (pago[i] < monto[i])
                            {
                                Console.WriteLine("El pago de: " + pago[i] + " que agrego es menor a al monto de pago: " + monto[i] + "\n");
                            }
                        } while (pago[i] < monto[i]);
                        //Asignamos el vuelto del usuario
                        vuelto[i] = pago[i] % monto[i];
                        Console.WriteLine("El vuelto es de: " + vuelto[i]);
                        do{
                            Console.WriteLine("Desea continuar? \n1 - Si \n2 - No");
                            opcion = int.Parse(Console.ReadLine());
                            if (opcion != 1 && opcion != 2){
                                Console.WriteLine("La opcion no se reconoce; selecciones entre 1 y 2");
                            }
                        } while (opcion != 1 && opcion != 2);
                        if (opcion == 2)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Saliendo del Sistema\n");
                }
            } while (opcion != 2);
        }
        public static void consultaDatos()
        {
            Console.WriteLine("Ingrese el numero de placa que desea Consultar");
            nPlaca = Console.ReadLine();
            for (x = 0; i < placa.Length; x++)
            {
                if (placa[x].Equals(nPlaca))
                {
                    index = nPlaca.IndexOf(nPlaca[x]);
                    Console.WriteLine("\nDesgloce Numero de Placa " + nPlaca);
                    Console.WriteLine("Numero de Facutura: " + facturas[index]);
                    Console.WriteLine("Fecha de ingreso: " + fecha[index]);
                    Console.WriteLine("Hora de Ingreso: " + hora[index]);
                    Console.WriteLine("Tipo de Vehiculo: " + vehiculo[index]);
                    Console.WriteLine("Numero de Caseta Registrada: " + caseta[index]);
                    Console.WriteLine("Monto a pagar: " + monto[index]);
                    Console.WriteLine("Su monto de pago fue con: " + pago[index]);
                    Console.WriteLine("Su vuelto fue de: " + vuelto[index] + "n");
                    break;
                }
                else
                {
                    Console.WriteLine("El numero de placa no esta en sistema\n");
                    break;
                }
            }
        }
        public static void modificarDatos()
        {

            Console.WriteLine("Ingrese el numero de placa que desea Consultar");
            nPlaca = Console.ReadLine();
            for (x = 0; i < placa.Length; x++)
            {
                if (placa[x].Equals(nPlaca))
                {
                    index = nPlaca.IndexOf(nPlaca[x]);
                    Console.WriteLine("\nDesgloce Numero de Placa " + nPlaca);
                    Console.WriteLine("Numero de Facutura: " + facturas[index]);
                    Console.WriteLine("Fecha de ingreso: " + fecha[index]);
                    Console.WriteLine("Hora de Ingreso: " + hora[index]);
                    Console.WriteLine("Tipo de Vehiculo: " + vehiculo[index]);
                    Console.WriteLine("Numero de Caseta Registrada: " + caseta[index]);
                    Console.WriteLine("Monto a pagar: " + monto[index]);
                    Console.WriteLine("Su monto de pago fue con: " + pago[index]);
                    Console.WriteLine("Su vuelto fue de: " + vuelto[index] + "\n");

                    Console.WriteLine("Cual dato desea modificar?");
                    Console.WriteLine("1- Numero de Placa \n2- Tipo de vehiculo. \n3 - Numero de Caseta.");
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            //Solicitamos modificacion/correccion de placa
                            Console.WriteLine("Ingrese el nuevo numero de Placa");
                            placa[index] = Console.ReadLine();
                            Console.WriteLine("\nModifico el numero de placa de " + nPlaca + " a " + placa[index]);
                            break;
                        case 2:
                            //Solicitamos el nuevo tipo de vehiculo
                            do
                            {
                                tVehiculo = vehiculo[index];
                                Console.WriteLine("\nIngrese el nuevo tipo de Vehiculo. \n1= Moto. \n2= Vehículo Liviano. \n3=Camión o Pesado. \n4=Autobús");
                                opcion = int.Parse(Console.ReadLine());
                                if (opcion == 1)
                                {
                                    vehiculo[index] = "Moto";
                                    Console.WriteLine("\nModifico el numero de placa de " + tVehiculo + " a " + vehiculo[index]);
                                }
                                else if (opcion == 2)
                                {
                                    vehiculo[index] = "Vehiculo Liviano";
                                    Console.WriteLine("\nModifico el numero de placa de " + tVehiculo + " a " + vehiculo[index]);
                                }
                                else if (opcion == 3)
                                {
                                    vehiculo[index] = "Camion o Pesado";
                                    Console.WriteLine("\nModifico el numero de placa de " + tVehiculo + " a " + vehiculo[index]);
                                }
                                else if (opcion == 4)
                                {
                                    vehiculo[index] = "Autobus";
                                    Console.WriteLine("\nModifico el numero de placa de " + tVehiculo + " a " + vehiculo[index]);
                                }
                                else
                                {
                                    Console.WriteLine("La opcion no existe. Intente de nuevo.\n");
                                }
                            } while (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4);
                            //Asignacion de nuevo Monton por vehiculo
                            if (vehiculo[index].Contains("Moto"))
                            {
                                monto[index] = 500;
                            }
                            else if (vehiculo[index].Contains("Vehiculo Liviano"))
                            {
                                monto[index] = 700;
                            }
                            else if (vehiculo[index].Contains("Camion o Pesado"))
                            {
                                monto[index] = 2700;
                            }
                            else
                            {
                                monto[index] = 3700;
                            }
                            if (monto[index] > pago[index])
                            {
                                faltante = monto[index] % pago[index];
                                Console.WriteLine("El monto a pagar es de " + monto[index] + " por ser " + vehiculo[index] + "hay un faltante de " + faltante);
                                Console.WriteLine("Desea cancelar la diferencia? \n1 - Si \n2 - No");
                                opcion = int.Parse(Console.ReadLine());
                                switch (opcion)
                                {
                                    case 1:
                                        do
                                        {
                                            Console.WriteLine("El monto a pagar es de: " + faltante);
                                            Console.WriteLine("Con cuanto desea cancela?\n");
                                            pago[index] = int.Parse(Console.ReadLine());
                                            if (pago[index] < faltante)
                                            {
                                                Console.WriteLine("El pago de: " + pago[index] + " que agrego es menor a al monto de pago: " + faltante + "\n");
                                            }
                                        } while (pago[index] < faltante);
                                        vuelto[index] = pago[index] % faltante;
                                        Console.WriteLine("El vuelto es de: " + vuelto[index]);
                                        break;
                                    case 2:
                                        vuelto[index] *= -1;
                                        Console.WriteLine("Hace falta cancelar: " + vuelto[index]);
                                        break;
                                    default:
                                        Console.WriteLine("La opcion no existe");
                                        break;
                                }
                            }
                            break;
                        case 3:
                            do
                            {
                                nCaseta = caseta[index];
                                Console.WriteLine("\nCual es el nuevo numero caseta: 1, 2, o 3?");
                                caseta[index] = int.Parse(Console.ReadLine());
                                if (caseta[index] != 1 && caseta[index] != 2 && caseta[index] != 3)
                                {
                                    Console.WriteLine("Seleccione entre caseta: 1, 2, o 3");
                                }
                            } while (caseta[index] != 1 && caseta[index] != 2 && caseta[index] != 3);
                            Console.WriteLine("\nModifico el numero de Caseta de " + nCaseta + " a " + vehiculo[index]);

                            break;
                        default:
                            Console.WriteLine("La opcion no existe");
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("El numero de placa no esta en sistema\n");
                    break;
                }
            }

        }
        public static void mostrarDatos()
        {

        }

    }
    
    
}
