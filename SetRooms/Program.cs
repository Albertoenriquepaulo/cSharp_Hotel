using SetRooms.Class;
using SetRooms.Class.Helpers;
using System;
using System.Drawing;
using Console = Colorful.Console;
//using System.Data;

namespace SetRooms
{
    class Program
    {
        public static SQLDBConnection myDB;
        static void Main(string[] args)
        {
            //int result; //Para los resultados de las consultas RUDI
            string strDNI;
            ConfigFile myConfigFile = new ConfigFile();
            myDB = new SQLDBConnection(myConfigFile.GetKeyValue("Data Source"), myConfigFile.GetKeyValue("Catalog"),
                                     Convert.ToBoolean(myConfigFile.GetKeyValue("Integrated Security")));
            //DataTable dTable;
            DateTime[] checkIN_OUT = new DateTime[2];
            bool exit = false;
            int intRoomNumber;

            //MENU
            int menuOp;
            //FIN MENU
            //exit = HpVarious.IsDate("3/9/2008");
            Console.Title = "BBK Hotel Reservation System, By Alberto Paulo";
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
                                HpClients.ShowClientsInTable(myDB);
                                break;
                            //case 4:
                            //    //Volver
                            //    //menuOp = Menu.PrintMainMenu();
                            //    break;
                            default:
                                Console.WriteLine("Other");
                                break;
                        }
                        break;
                    case 2:
                        do
                        {
                            menuOp = Menu.PrintRoomMenu();
                            switch (menuOp)
                            {
                                case 1:
                                    //Insert Room
                                    HpRooms.InsertRoom(myDB);
                                    break;
                                case 2:
                                    //Show Rooms -- TODO: Preguntar DNI y dejarlo ver las habitaciones solo si esta registrado
                                    HpRooms.ShowRoomsInTable(myDB, 2);

                                    break;
                                //case 3:
                                //    //Volver
                                //    //menuOp = Menu.PrintMainMenu();  //TODO: Quizas haya que quitarla
                                //    break;
                                default:
                                    Console.WriteLine("Other");
                                    break;
                            }
                        } while (menuOp > 0 && menuOp < 3);
                        break;
                    case 3:
                        menuOp = Menu.PrintBookingMenu();
                        switch (menuOp)
                        {
                            case 1:
                                //Reservar
                                strDNI = Menu.GetDNIFromUser("AREA RESERVACIONES -> RESERVAR HABITACION\n");
                                if (HpClients.ClientExist(myDB, strDNI))
                                {
                                    Menu.PrintBookingQuestions(checkIN_OUT);
                                    HpBooks.ShowNotBookedRoomInTable(myDB, checkIN_OUT);//IMPRIME habitaciones disponibles
                                    Console.Write("\n INDIQUE NUMERO DE HABITACIÓN A RESERVAR (Sólo el número): ");
                                    intRoomNumber = Convert.ToInt32(Console.ReadLine());
                                    HpBooks.InsertBook(myDB, strDNI, intRoomNumber, checkIN_OUT);
                                }
                                else
                                {
                                    Console.WriteLine("NO ES UN CLIENTE VALIDO, NO PUEDE HACER LA RESERVA", Color.Red);
                                    Menu.WriteContinue();
                                    // Menu.PrintBookingMenu(); //TODO: imprime nuevamente el menu pero hay que trabajarlo porque cuando imprime nuevamente no funciona bien
                                }
                                break;
                            case 2:
                                //Modificar Reservacion - ir a otro menu
                                do
                                {
                                    menuOp = Menu.PrintBookingLowLevelMenu();
                                    switch (menuOp)
                                    {
                                        case 1:
                                            //Modificar CheckIn
                                            Menu.WriteConstruction();
                                            break;
                                        case 2:
                                            //Modificar CheckOut
                                            Menu.WriteConstruction();
                                            break;
                                        case 3:
                                            //Modificar Ambas
                                            Menu.WriteConstruction();
                                            break;
                                        case 4:
                                            //Volver - Bajar un nivel
                                            menuOp = Menu.PrintBookingMenu();
                                            break;
                                        default:
                                            Console.WriteLine("Other");
                                            break;
                                    }
                                } while (menuOp > 0 && menuOp < 4);
                                break;
                            case 3:
                                //Eliminar Reservacion
                                Menu.WriteConstruction();
                                break;
                            //case 4:
                            //    //Eliminar Reservacion
                            //    Menu.WriteConstruction();
                            //    break;
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
