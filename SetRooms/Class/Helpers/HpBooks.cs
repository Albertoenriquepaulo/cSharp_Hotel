using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SetRooms.Class.Helpers
{
    class HpBooks
    {
        //Carga Cliente en la DB
        public static bool InsertBook(SQLDBConnection myDB, string strDNI)
        {
            int result = 1; //Para los resultados de las consultas RUDI
            DataTable dTable;
            Console.WriteLine($"REGISTRANDO CLIENTE BAJO EL DNI: {strDNI}");
            string strFirstName, strLastName;

            if (strDNI != "0" && strDNI.Length == 9 && !BookExist(myDB, strDNI))
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

        public static bool IsTheRoomAvailable(SQLDBConnection myDB, string strDNI)
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
    }
}
