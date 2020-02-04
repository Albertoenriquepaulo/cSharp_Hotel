using System;
using System.Drawing;
using Console = Colorful.Console;
using System.Data;

namespace SetRooms.Class.Helpers
{
    public static class HpVarious
    {
        public static Boolean IsDate(String date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void WriteArt(string strToPrint)
        {
            int DA = 244;
            int V = 212;
            int ID = 255;
            Console.WriteAscii(strToPrint, Color.FromArgb(102, 255, 255));
        }

        // Convierte un DataTable a un Objeto Genérico y lo devuelve
        public static Object ConvertToObject(DataTable dTable)
        {

            var myGenericObj = dTable.AsEnumerable().Select(x =>
            new
            {
                ClientID = x.Field<int>("ClientID"),
                DNI = x.Field<string>("DNI"),
                Name = x.Field<string>("Name"),
                LastName = x.Field<string>("LastName"),

            });

            return myGenericObj;
        }
    }
}
