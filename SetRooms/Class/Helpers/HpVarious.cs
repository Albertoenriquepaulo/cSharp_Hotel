using System;
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
    }
}
