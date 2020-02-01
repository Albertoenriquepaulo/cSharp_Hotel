using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SetRooms.Class.Helpers
{
    class HpBooks
    {
        //Carga Cliente en la DB
        public static bool InsertBook(SQLDBConnection myDB, string strDNI, int intRoomNumber)
        {
            int result; //Para los resultados de las consultas RUDI
            string strClientID = null;
            int intRoomID = 0;

            DataTable dTable;
            Console.WriteLine($"REGISTRANDO CLIENTE BAJO EL DNI: {strDNI}");
            string strFirstName, strLastName;
            
            // Con el DNI debo obtener el ClientID
            if (HpClients.ClientExist(myDB,strDNI))
            {
                dTable = RUDI.Read(myDB, "Clients", "ClientID", $"LIKE DNI = '{strDNI}'");
                strClientID = dTable.Rows[0]["ClientID"].ToString();
            }

            //Con el RoomNumber debo obtener el RoomID
            if (HpRooms.RoomExist(myDB, intRoomNumber))
            {
                dTable = RUDI.Read(myDB, "Rooms", "RoomID", $"RoomNumber={intRoomNumber}");
                intRoomID = Convert.ToInt32(dTable.Rows[0]["ClientID"]);
            }

            //Debo verificar con los chequines si la hab esta disponible para reserva
            //Obtengo habitaciones disponibles segun fechas
            dTable = RUDI.Read(myDB, "Bookings", "*", $"RoomID={intRoomID}");


            if (strDNI != "0" && strDNI.Length == 9 && !BookExist(myDB, 1)) //TODO: Fix the number of BookExist
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
                    return true;
                }
                return false;
            }
            else
            {
                if (strDNI == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR -> El DNI del cliente no puede ser Cero (0)");
                    Console.ResetColor();
                }
                else if (strDNI.Length != 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR -> El DNI del cliente debe contener 9 caracteres");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR -> El cliente Ya existe en la BD. Intente con otro DNI");
                    Console.ResetColor();
                }
            }
            return false;
        }

        public static bool IsTheRoomAvailable(SQLDBConnection myDB, string strDNI) //TODO: Revisar aqui, hay que hacer este metodo
        {
            DataTable dTable;
            if (strDNI.Length == 9)
            {
                if (HpClients.ClientExist(myDB, strDNI))
                {

                }
                dTable = RUDI.Read(myDB, "Clients", "ClientID", $"DNI LIKE '{strDNI.ToUpper()}'");  //SELECT ClientID FROM Clients WHERE DNI = strDNI
                if (dTable != null && dTable.Rows.Count > 0)
                    return true;
            }
            return false;
        }

        public static bool BookExist(SQLDBConnection myDB, int intBookingID)
        {
            DataTable dTable;
            if (intBookingID > 0)
            {
                dTable = RUDI.Read(myDB, "Bookings", "BookingID", $"BookinID={intBookingID}");  //SELECT BookingID FROM Bookings WHERE BookinID = intBookingID
                if (dTable != null && dTable.Rows.Count > 0)
                    return true;
            }
            return false;
        }

        // Muestra las habitaciones disponibles según Fecha Indicada en el array checkIN_OUT
        public static void ShowNotBookedRoom(SQLDBConnection myDB, DateTime[] checkIN_OUT)
        {
            DataTable dTable;
            Console.WriteLine($"\nHABITACIONES DISPONIBLES PARA LA FECHA INDICADA");
            string[] availableRoom = new string[] { "HAB-0", "HAB-" };
            dTable = RUDI.ReadFromSP(myDB, "AvailableRooms", checkIN_OUT); //AvailableRooms nombre de Proceso Almacenado

            if (dTable != null && dTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dTable.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        if (Convert.ToInt32(item) < 10)
                            Console.Write($"{availableRoom[0]}{item}");
                        else
                            Console.Write($"{availableRoom[1]}{item}");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

    }
}
