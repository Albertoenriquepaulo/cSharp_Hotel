using SetRooms.Class;
using System;
using System.Data.SqlClient;

using FastMember;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using SetRooms.Class.Helpers;

namespace SetRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            int result; //Para los resultados de las consultas RUDI
            string strDNI;
            ConfigFile myConfigFile = new ConfigFile();
            SQLDBConnection myDB = new SQLDBConnection(myConfigFile.GetKeyValue("Data Source"), myConfigFile.GetKeyValue("Catalog"),
                                     Convert.ToBoolean(myConfigFile.GetKeyValue("Integrated Security")));
            DataTable dTable;
            bool exit = false;

            //MENU
            int menuOp;
            //FIN MENU
            
            //Helper.LoadRooms(myDB);
            //HpClients.InsertClient(myDB, strDNI);
            //exit = Helper.ClientExist(myDB, "111111111");

            //HpClients.UpdateClient(myDB, strDNI);

            do
            {
                menuOp = Menu.PrintMainMenu();
                switch (menuOp)
                {
                    case 1:
                        menuOp = Menu.PrintClientMenu();
                        switch (menuOp)
                        {
                            case 1:
                                HpClients.InsertClient(myDB, Menu.GetDNIFromUser("AREA CLIENTES -> REGISTRAR CLIENTE (NUEVO CLIENTE)\n"));
                                break;
                            case 2:
                                HpClients.UpdateClient(myDB, Menu.GetDNIFromUser("AREA CLIENTES -> ACTUALIZAR CLIENTE\n"));
                                break;
                            case 3:
                                HpClients.ShowClients(myDB);
                                break;
                            case 4:
                                //Volver
                                menuOp = Menu.PrintMainMenu();
                                break;
                            default:
                                Console.WriteLine("Other");
                                break;
                        }
                        break;
                    case 2:
                        menuOp = Menu.PrintRoomMenu();
                        switch (menuOp)
                        {
                            case 1:
                                //Insert Room
                                HpRooms.InsertRoom(myDB);
                                break;
                            case 2:
                                //Show Rooms -- TODO: Preguntar DNI y dejarlo ver las habitaciones solo si esta registrado
                                HpRooms.ShowRooms(myDB, 1);
                                break;
                            case 3:
                                //Volver
                                menuOp = Menu.PrintMainMenu();
                                break;
                            default:
                                Console.WriteLine("Other");
                                break;
                        }
                        break;
                    case 3:
                        menuOp = Menu.PrintBookingMenu();
                        switch (menuOp)
                        {
                            case 1:
                                //Reservar
                                break;
                            case 2:
                                //Modificar Reservacion - ir a otro menu
                                menuOp = Menu.PrintBookingLowLevelMenu();
                                switch (menuOp)
                                {
                                    case 1:
                                        //Modificar CheckIn
                                        break;
                                    case 2:
                                        //Modificar CheckOut
                                        break;
                                    case 3:
                                        //Modificar Ambas
                                        break;
                                    case 4:
                                        //Volver - Bajar un nivel
                                        menuOp = Menu.PrintBookingMenu();
                                        break;
                                    default:
                                        Console.WriteLine("Other");
                                        break;
                                }
                                break;
                            case 3:
                                //Eliminar Reservacion
                                break;
                            case 4:
                                //Eliminar Reservacion
                                menuOp = Menu.PrintMainMenu();
                                break;
                            default:
                                Console.WriteLine("Other");
                                break;
                        }
                        break;
                    case 4:
                        //Salir
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Other");
                        break;
                }

                //Console.Write("DNI: ");
                //strDNI = Console.ReadLine().ToUpper();
                //if (strDNI != "0")
                //{
                //    //HpClients.InsertClient(myDB, strDNI);
                //    HpClients.UpdateClient(myDB, strDNI);
                //    exit = false;
                //}
                //else
                //{
                //    exit = true;
                //}
                
            } while (!exit);
        }
    }

    internal class T
    {
        public T()
        {
        }
    }

}
