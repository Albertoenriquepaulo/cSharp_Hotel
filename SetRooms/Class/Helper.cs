using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SetRooms.Class
{
    class Helper
    {
        public static void LoadRooms(SQLDBConnection myDB)
        {
            int result; //Para los resultados de las consultas RUDI
            bool exit = true;
            DataTable dTable;
            Console.WriteLine("Section Para Cargar Las Habitaciones (RoomID -> Automatic, Disponibilidad -> 0/1)");
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
                    result = RUDI.Insert(myDB, "Rooms", "RoomNumber, Available", $"{roomNumber},{Convert.ToString((Convert.ToInt32(strAvailable) == 1) ? 0 : 1)}");
                    if (result == 1)
                    {
                        int roomID;
                        dTable = RUDI.Read(myDB, "Rooms", "RoomID", $"RoomNumber = {roomNumber}");  //SELECT RoomID FROM Rooms WHERE RoomNumber = roomNumber
                        roomID = Convert.ToInt32(dTable.Rows[0]["RoomID"]);
                        Console.WriteLine($"La Habitación {roomNumber} ha sido añadida con exito bajo el ID {roomID}");

                    }
                    exit = false;
                }
                else
                {
                    exit = true;
                }
            } while (!exit);
        }

        public static void LoadClients(SQLDBConnection myDB)
        {
            int result; //Para los resultados de las consultas RUDI
            bool exit = true;
            DataTable dTable;
            Console.WriteLine("Section Para Registrar Clientes");
            do
            {
                string strFirstName, strLastName, strDNI;
                Console.Write("DNI: ");
                strDNI = Console.ReadLine();
                Console.Write("Name: ");
                strFirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                strLastName = Console.ReadLine();
                if (strDNI != "0")
                {
                    result = RUDI.Insert(myDB, "Clients", "Name, LastName, DNI", $"{strFirstName}, {strLastName}, {strDNI}");
                    if (result == 1)
                    {
                        int clientID;
                        dTable = RUDI.Read(myDB, "Clients", "ClientID", $"DNI = {strDNI}");  //SELECT RoomID FROM Rooms WHERE RoomNumber = roomNumber
                        clientID = Convert.ToInt32(dTable.Rows[0]["RoomID"]);
                        Console.WriteLine($"El cliente '{strFirstName} {strLastName}' ha sido creado con exito bajo el ID {clientID}");
                    }
                    exit = false;
                }
                else
                {
                    exit = true;
                }
            } while (!exit);
        }
    }
}
