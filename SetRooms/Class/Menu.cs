using Colorful;
using SetRooms.Class.Helpers;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace SetRooms.Class
{
    class Menu
    {
        const string APP_NAME = "BBK Hotel System";
        public enum MainOp
        {
            clients = 1,
            rooms = 2,
            books = 3,
            exit = 4
        }
        public enum ClientOp
        {
            add = 1,
            update = 2,
            query = 3,
            back = 4
        }

        public enum RoomOp
        {
            add = 1,
            query = 2,
            back = 3
        }

        public enum BookOp
        {
            add = 1,
            update = 2,
            delete = 3,
            back = 4
        }

        public enum BookOpUpdate
        {
            upCheckIN = 1,
            upCheckOUT = 2,
            upBoth = 3,
            back = 4
        }


        public static int PrintMainMenu()
        {
            ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
            ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Aqua, Color.Aquamarine);

            Console.Clear();
            //Console.WriteLine("SISTEMA RESERVA DE HOTEL BBKBOOTCAMP 2020 (6ta Edición)\n");
            HpVarious.WriteArt(APP_NAME);
            Console.WriteLineAlternating("\t(1) CLIENTES", alternator);
            Console.WriteLineAlternating("\t(2) HABITACIONES", alternator);
            Console.WriteLineAlternating("\t(3) RESERVACIONES", alternator);
            Console.WriteLineAlternating("\t(4) SALIR", alternator);
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int PrintClientMenu()
        {
            ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
            ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Aqua, Color.Aquamarine);

            Console.Clear();
            HpVarious.WriteArt(APP_NAME);
            WriteArea("AREA CLIENTES\n");
            Console.WriteLineAlternating("\t(1) REGISTRAR CLIENTE (NUEVO CLIENTE)", alternator);
            Console.WriteLineAlternating("\t(2) ACTUALIZAR CLIENTE", alternator);
            Console.WriteLineAlternating("\t(3) CONSULTAR CLIENTES", alternator);
            Console.WriteLineAlternating("\t(4) VOLVER", alternator);
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string GetDNIFromUser(string areaMenu)
        {
            string strDNI;
            Console.Clear();
            HpVarious.WriteArt(APP_NAME);
            do
            {
                WriteArea(areaMenu);
                Console.Write("DNI: ");
                strDNI = Console.ReadLine().ToUpper();
                if (strDNI != "0" && strDNI.Length == 9)
                {
                    return strDNI;
                }
                else
                {
                    Console.WriteLine("ERROR -> DNI debe ser igual a 9 caracteres y diferente de 0", Color.Red);
                }
            } while (true);
        }

        public static int PrintRoomMenu()
        {
            ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
            ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Aqua, Color.Aquamarine);

            Console.Clear();
            HpVarious.WriteArt(APP_NAME);
            WriteArea("AREA HABITACIONES\n");
            Console.WriteLineAlternating("\t(1) REGISTRAR HABITACION (INCLUIR NUEVA HABITACION)", alternator);
            Console.WriteLineAlternating("\t(2) CONSULTAR HABITACIONES", alternator);
            Console.WriteLineAlternating("\t(3) VOLVER", alternator);
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int PrintBookingMenu()
        {
            ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
            ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Aqua, Color.Aquamarine);

            Console.Clear();
            HpVarious.WriteArt(APP_NAME);
            WriteArea("AREA RESERVACIONES\n");
            Console.WriteLineAlternating("\t(1) RESERVAR (FECHA INICIAL Y FECHA FINAL)", alternator);
            Console.WriteLineAlternating("\t(2) MODIFICAR RESERVACION EXISTENTE", alternator);
            Console.WriteLineAlternating("\t(3) ELIMINAR RESERVACION EXISTENTE", alternator);
            Console.WriteLineAlternating("\t(4) VOLVER", alternator);
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int PrintBookingLowLevelMenu()
        {
            ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
            ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Aqua, Color.Aquamarine);

            Console.Clear();
            HpVarious.WriteArt(APP_NAME);
            WriteArea("AREA RESERVACIONES -> MODIFICAR RESERVACION EXISTENTE\n");
            Console.WriteLineAlternating("\t(1) MODIFICAR CHECK_IN (FECHA INICIAL)", alternator);
            Console.WriteLineAlternating("\t(2) MODIFICAR CHECK_OUT (FECHA FINAL)", alternator);
            Console.WriteLineAlternating("\t(3) MODIFICAR AMBAS CHECK_IN (FECHA INICIAL) Y CHECK_OUT (FECHA FINAL)", alternator);
            Console.WriteLineAlternating("\t(4) VOLVER", alternator);
            Console.Write("\nOpcion: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Carga un arreglo de dos posiciones:
        // [0] -> Fecha CheckIn
        // [1] -> Fecha CheckOut
        // No devuelve nada ya que los arreglos se pasan automáticamente por referencia
        public static void PrintBookingQuestions(DateTime[] Dates)
        {
            ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
            ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Aqua, Color.Aquamarine);

            bool condition;
            do
            {
                Console.WriteAlternating("FECHA INICIAL (e.g. dd/mm/yyyy): ", alternator);
                Dates[0] = DateTime.Parse(Console.ReadLine());
                Console.WriteAlternating("FECHA FINAL (e.g. dd/mm/yyyy):  ", alternator);
                Dates[1] = DateTime.Parse(Console.ReadLine());
                condition = (DateTime.Compare(Dates[0], Dates[1]) < 0 && DateTime.Compare(Dates[0], DateTime.Today) > 0 && DateTime.Compare(Dates[1], DateTime.Today) > 0);
                if (!condition)
                {
                    Console.WriteLine("ERROR -> Introduzca nuevamente las fechas. \nFECHA INICIAL no puede ser mayor que FECHA FINAL.\nFECHA FINAL no puede ser menor que FECHA INICIAL.\nNinguna de las fechas debe ser mayor que la FECHA ACTUAL.\n", Color.Red);
                }

            } while (!condition);
        }

        public static void WriteArea(string strArea)
        {
            Console.WriteLine(strArea, Color.FromArgb(0, 102, 255));
        }

        public static void WriteContinue()
        {
            Console.Write("Pulse Cualquier Tecla Para Continuar", Color.Brown);
            Console.ReadLine();
        }

        public static void WriteConstruction()
        {
            Console.WriteLine("En Construcción", Color.Brown);
            WriteContinue();
        }
    }
}
