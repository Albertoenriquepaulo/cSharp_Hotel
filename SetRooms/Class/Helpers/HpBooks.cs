﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SetRooms.Class.Helpers
{
    class HpBooks
    {
        //Carga Cliente en la DB
        public static bool InsertBook(SQLDBConnection myDB, string strDNI, int intRoomNumber, DateTime[] checkIN_OUT)
        {
            int result; //Para los resultados de las consultas RUDI
            int intClientID = 0;
            int intRoomID = 0;

            DataTable dTable;
            Console.WriteLine($"REGISTRANDO RESERVACION DE HAB-{intRoomNumber}");
            string strFirstName, strLastName;
            
            // Con el DNI debo obtener el ClientID
            if (HpClients.ClientExist(myDB,strDNI))
            {
                dTable = RUDI.Read(myDB, "Clients", "ClientID", $"DNI LIKE '{strDNI}'");
                intClientID = Convert.ToInt32(dTable.Rows[0]["ClientID"]);
            }

            //Con el RoomNumber debo obtener el RoomID
            if (HpRooms.RoomExist(myDB, intRoomNumber))
            {
                dTable = RUDI.Read(myDB, "Rooms", "RoomID", $"RoomNumber={intRoomNumber}");
                intRoomID = Convert.ToInt32(dTable.Rows[0]["RoomID"]);
            }

            //Debo verificar con los chequines si la hab esta disponible para reserva
            //El comment de arriba es innecesario ya que si llamo a esta función ya validé que la hab está disponible
            //Obtengo habitaciones disponibles segun fechas
            result = RUDI.Insert(myDB, "Bookings", "ClientID, RoomID, CheckIn, CheckOut", $"{intClientID}, {intRoomID}, '{checkIN_OUT[0].ToString("MM/dd/yyyy")}', '{checkIN_OUT[1].ToString("MM/dd/yyyy")}'");
            if (result > 0)
            {
                Console.WriteLine("LA RESERVA FUE AÑADIDA CON ÉXITO.");
                return true;
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
            dTable = RUDI.ReadFromSP(myDB, "AvailableRoomsNumber", checkIN_OUT); //AvailableRooms nombre de Proceso Almacenado

            if (dTable != null && dTable.Rows.Count > 0)
            {
                //foreach (DataRow dataRow in dTable.Rows)
                //{

                //    foreach (var item in dataRow.ItemArray)
                //    {
                //        if (Convert.ToInt32(item) < 10)
                //            Console.Write($"{availableRoom[0]}{item}");
                //        else
                //            Console.Write($"{availableRoom[1]}{item}");
                //    }

                //    Console.WriteLine();
                //}
                foreach (DataRow row in dTable.Rows)
                {
                    // ... Write value of first field as integer.
                    Console.WriteLine($"{availableRoom[1]}{row.Field<int>(1)}");
                }
            }
        }

    }
}
