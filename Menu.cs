using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    internal class Menu
    {
        int opcion;
        bool estadia = true;

        public Menu()
        {

        }

        public void mostrarMenu()
        {
            do
            {
                Console.WriteLine("Menu principal del Sistema: ");
                Console.WriteLine("1 - Inicializar Verctores. \n2 - Ingresar Paso Vehicular. \n3 - COnsulta de Vehiculos x Numero de Placa.");
                Console.WriteLine("4 - Modificar Datos Vehiculo x numero de Placa. \n5 - Reporte todos los Datos de los Vectores. \n6 - Salir");
                Console.WriteLine("Digite la opcion que desea");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: break;
                    case 2: break;
                    case 3: break;
                    case 4: break;
                    case 5: break;
                    case 6:
                        Console.WriteLine("Gracias por su estadia. \nVuelva pronto");
                        break;
                    default:
                        Console.WriteLine("La opcion ingresada no es valida. \nIntente de nuevo.");
                        break;


                }
                       



            } while (opcion != 6);
            

        }
    }
}
