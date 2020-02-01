using System;
using System.Collections.Generic;
using System.Text;

namespace SetRooms.Class
{
    class Menu
    {
        public static int PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("SISTEMA RESERVA DE HOTEL BBKBOOTCAMP 2020 (6ta Edición)\n");
            Console.WriteLine("\t(1) CLIENTES");
            Console.WriteLine("\t(2) HABITACIONES");
            Console.WriteLine("\t(3) RESERVACIONES");
            Console.WriteLine("\t(4) SALIR");
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int PrintClientMenu()
        {
            Console.Clear();
            Console.WriteLine("AREA CLIENTES\n");
            Console.WriteLine("\t(1) REGISTRAR CLIENTE (NUEVO CLIENTE)");
            Console.WriteLine("\t(2) ACTUALIZAR CLIENTE");
            Console.WriteLine("\t(3) CONSULTAR CLIENTES");
            Console.WriteLine("\t(4) VOLVER");
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string GetDNIFromUser(string areaMenu)
        {
            string strDNI = null;
            Console.Clear();
            do
            {
                Console.WriteLine(areaMenu);
                Console.Write("DNI: ");
                strDNI = Console.ReadLine().ToUpper();
                if (strDNI != "0" && strDNI.Length == 9)
                {
                    return strDNI;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR -> DNI debe ser igual a 9 caracteres y diferente de 0");
                    Console.ResetColor();
                }
            } while (true);
        }

        public static int PrintRoomMenu()
        {
            Console.Clear();
            Console.WriteLine("AREA HABITACIONES\n");
            Console.WriteLine("\t(1) REGISTRAR HABITACION (INCLUIR NUEVA HABITACION)");
            Console.WriteLine("\t(2) CONSULTAR HABITACIONES");
            Console.WriteLine("\t(3) VOLVER");
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int PrintBookingMenu()
        {
            Console.Clear();
            Console.WriteLine("AREA RESERVACIONES\n");
            Console.WriteLine("\t(1) RESERVAR (FECHA INICIAL Y FECHA FINAL)");
            Console.WriteLine("\t(2) MODIFICAR RESERVACION EXISTENTE");
            Console.WriteLine("\t(3) ELIMINAR RESERVACION EXISTENTE");
            Console.WriteLine("\t(3) VOLVER");
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int PrintBookingLowLevelMenu()
        {
            Console.Clear();
            Console.WriteLine("AREA RESERVACIONES -> MODIFICAR RESERVACION EXISTENTE\n");
            Console.WriteLine("\t(1) MODIFICAR CHECK_IN (FECHA INICIAL)");
            Console.WriteLine("\t(2) MODIFICAR CHECK_OUT (FECHA FINAL)");
            Console.WriteLine("\t(3) MODIFICAR AMBAS CHECK_IN (FECHA INICIAL) Y CHECK_OUT (FECHA FINAL)");
            Console.WriteLine("\t(4) VOLVER");
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Carga un arreglo de dos posiciones:
        // [0] -> Fecha CheckIn
        // [1] -> Fecha CheckOut
        // No devuelve nada ya que los arreglos se pasan automáticamente por referencia
        public static void PrintBookingQuestions(DateTime[] Dates)
        {
            bool condition = false;
            do
            {
                Console.Write("FECHA INICIAL (e.g. dd/mm/yyyy): ");
                Dates[0] = DateTime.Parse(Console.ReadLine());
                Console.Write("FECHA FINAL (e.g. dd/mm/yyyy):  ");
                Dates[1] = DateTime.Parse(Console.ReadLine());
                condition = (DateTime.Compare(Dates[0], Dates[1]) < 0 && DateTime.Compare(Dates[0], DateTime.Today) > 0 && DateTime.Compare(Dates[1], DateTime.Today) > 0);
                if (!condition)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR -> Introduzca nuevamente las fechas. \nFECHA INICIAL no puede ser mayor que FECHA FINAL.\nFECHA FINAL no puede ser menor que FECHA INICIAL.\nNinguna de las fechas debe ser mayor que la FECHA ACTUAL.\n");
                    Console.ResetColor();
                }

            } while ( !condition );
        }

    }
}
