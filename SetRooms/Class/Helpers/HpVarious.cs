using System;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;
using System.Text;

namespace SetRooms.Class.Helpers
{
    class HpVarious
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
    }


}
