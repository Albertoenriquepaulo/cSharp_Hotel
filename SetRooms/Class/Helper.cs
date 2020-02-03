using System;
using System.Data;
using System.Drawing;

namespace SetRooms.Class
{
    class Helper
    {
        public static void LoadRooms(SQLDBConnection myDB)
        {
            int result; //Para los resultados de las consultas RUDI
            bool exit;
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

        //Carga Clienets en la DB
        public static void LoadClients(SQLDBConnection myDB)
        {
            int result; //Para los resultados de las consultas RUDI
            bool exit;
            DataTable dTable;
            Console.WriteLine("Section Para Registrar Clientes");
            do
            {
                string strFirstName, strLastName, strDNI;
                Console.Write("DNI: ");
                strDNI = Console.ReadLine();
                if (strDNI != "0" && !ClientExist1(myDB, strDNI))
                {
                    Console.Write("Name: ");
                    strFirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    strLastName = Console.ReadLine();
                    result = RUDI.Insert(myDB, "Clients", "Name, LastName, DNI", $"'{strFirstName}', '{strLastName}', '{strDNI.ToUpper()}'");
                    if (result == 1)
                    {
                        int clientID;
                        dTable = RUDI.Read(myDB, "Clients", "ClientID", $"DNI LIKE '{strDNI}'");  //SELECT ClientID FROM Clients WHERE DNI = strDNI
                        clientID = Convert.ToInt32(dTable.Rows[0]["ClientID"]);
                        Console.WriteLine($"El cliente '{strFirstName} {strLastName}' ha sido creado con exito bajo el ID#: {clientID}");
                    }
                    exit = false;
                }
                else
                {
                    if (strDNI == "0") //Este if se puede quitar, es solo para romper el do while, cuando el DNI es 0
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR -> El cliente Ya existe en la BD. Intente con otro DNI", Color.Red);
                        Menu.WriteContinue();
                        exit = false;
                    }
                }
            } while (!exit);
        }

        // Recibe DNI y busca si el cliente existe en la DB
        public static bool ClientExist1(SQLDBConnection myDB, string strDNI)
        {
            DataTable dTable;
            if (strDNI.Length == 9)
            {
                dTable = RUDI.Read(myDB, "Clients", "ClientID", $"DNI LIKE '{strDNI.ToUpper()}'");  //SELECT ClientID FROM Clients WHERE DNI = strDNI
                if (dTable != null && dTable.Rows.Count > 0)
                    return true;
            }
            return false;
        }

    }
}
