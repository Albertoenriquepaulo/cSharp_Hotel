using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SetRooms.Class.Helpers
{
    class HpRooms
    {
        public static void InsertRoom(SQLDBConnection myDB)
        {
            int result; //Para los resultados de las consultas RUDI
            bool exit = true;
            DataTable dTable;
            Console.WriteLine($"REGISTRANDO HABITACION");
            //Console.WriteLine("Section Para Cargar Las Habitaciones (RoomID -> Automatic, Disponibilidad -> 0/1)");
            do
            {
                string strAvailable, roomNumber;
                Console.Write("Room Number: ");
                roomNumber = Console.ReadLine();
                Console.Write("Disponibilidad: ");
                strAvailable = Console.ReadLine();
                if (strAvailable == "0" || strAvailable == "1")
                {
                    //result = RUDI.Insert(myDB, "Rooms", "RoomID, Available", $"{roomID},{Convert.ToString( (Convert.ToInt32(strAvailable) == 1) ? 0 : 1)}");
                    result = RUDI.Insert(myDB, "Rooms", "RoomNumber, Available", $"{roomNumber},{strAvailable}");
                    if (result == 1)
                    {
                        int roomID;
                        dTable = RUDI.Read(myDB, "Rooms", "RoomID", $"RoomNumber = {roomNumber}");  //SELECT RoomID FROM Rooms WHERE RoomNumber = roomNumber
                        roomID = Convert.ToInt32(dTable.Rows[0]["RoomID"]);
                        Console.WriteLine($"La Habitación {roomNumber} ha sido añadida con exito bajo el ID#: {roomID}");

                    }
                    exit = false;
                }
                else
                {
                    exit = true;
                }
            } while (!exit);
        }

        //Mostrar clientes de la DB
        // availability = 0 = false, muestra las habitaciones NO disponibles
        // availability = 1 = false, muestra las habitaciones SI disponibles
        // availability = 2 , muestra todas las habitaciones, disponibles y no disponibles
        public static void ShowRooms(SQLDBConnection myDB, int availability)
        {
            DataTable dTable;
            string disponibles = "DISPONIBLES";
            
            if (availability < 0 && availability > 2)
            {
                availability = 2;
            }
            if (availability == 0)
            {
                disponibles = "NO DISPONIBLES";
            }
            else if (availability == 2)
            {
                disponibles = "Y SU ESTATUS";
            }

            Console.WriteLine($"MOSTRANDO TODAS LAS HABITACIONES {disponibles}");

            if (availability <= 1)
                dTable = RUDI.Read(myDB, "Rooms", "RoomNumber, Available", $"Available = {availability}"); //Mostrar las habitaciones disponibles o las no disponibles
            else
                dTable = RUDI.Read(myDB, "Rooms"); // Mostrar todas las habitaciones
            
            if (dTable != null && dTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dTable.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        public static bool RoomExist(SQLDBConnection myDB, int intRoomID)
        {
            DataTable dTable;
            if (intRoomID > 0)
            {
                dTable = RUDI.Read(myDB, "Rooms", "RoomID", $"RoomID={intRoomID}");  //SELECT RoomID FROM Rooms WHERE RoomID = intRoomID
                if (dTable != null && dTable.Rows.Count > 0)
                    return true;
            }
            return false;
        }
    }
}
