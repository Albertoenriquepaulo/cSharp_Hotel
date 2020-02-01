﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SetRooms.Class.Helpers
{
    class HpClients
    {
        //Carga Cliente en la DB
        public static bool InsertClient(SQLDBConnection myDB, string strDNI)
        {
            int result = 1; //Para los resultados de las consultas RUDI
            DataTable dTable;
            Console.WriteLine($"REGISTRANDO CLIENTE BAJO EL DNI: {strDNI}");
            string strFirstName, strLastName;

            if (strDNI != "0" && strDNI.Length == 9 && !ClientExist(myDB, strDNI))
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

        //Carga Cliente en la DB
        public static bool UpdateClient(SQLDBConnection myDB, string strDNI)
        {
            int result = 1; //Para los resultados de las consultas RUDI
            DataTable dTable;
            string strFirstName, strLastName;
            Console.WriteLine($"ACTUALIZANDO CLIENTE CON DNI: {strDNI}");
            if (strDNI != "0" && strDNI.Length == 9 && ClientExist(myDB, strDNI))
            {
                Console.Write("Name: ");
                strFirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                strLastName = Console.ReadLine();
                result = RUDI.Update(myDB, "Clients", $"Name='{strFirstName}',LastName='{strLastName}'", $"DNI LIKE '{strDNI}'");
                if (result == 1)
                {
                    int clientID;
                    dTable = RUDI.Read(myDB, "Clients", "ClientID", $"DNI LIKE '{strDNI}'");  //SELECT ClientID FROM Clients WHERE DNI = strDNI
                    clientID = Convert.ToInt32(dTable.Rows[0]["ClientID"]);
                    Console.WriteLine($"El cliente '{strFirstName} {strLastName}' ha sido ACTUALIZADO con exito bajo el ID#: {clientID}");
                    return true;
                }
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
                    Console.WriteLine("ERROR -> El cliente NO existe en la BD. Intente con otro DNI");
                    Console.ResetColor();
                }
            }
            return false;
        }


        //Mostrar todos los clientes de la DB
        public static void ShowClients(SQLDBConnection myDB)
        {
            DataTable dTable;
            Console.WriteLine($"MOSTRANDO TODOS LOS CLIENTES");

            dTable = RUDI.Read(myDB, "Clients");
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

        // Recibe DNI y busca si el cliente existe en la DB
        public static bool ClientExist(SQLDBConnection myDB, string strDNI)
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
