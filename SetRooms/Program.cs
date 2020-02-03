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
            int Heigth = Console.WindowHeight; Console.WindowHeight = 40;
            int Weigth = Console.WindowWidth;

            do
            {
                menuOp = Menu.PrintMainMenu();
                switch (menuOp)
                {
                    case (int)Menu.MainOp.clients:
                        do
                        {
                            menuOp = Menu.PrintClientMenu();
                            switch (menuOp)
                            {
                                case (int)Menu.ClientOp.add:
                                    HpClients.InsertClient(myDB, Menu.GetDNIFromUser("AREA CLIENTES -> REGISTRAR CLIENTE (NUEVO CLIENTE)\n"));
                                    break;
                                case (int)Menu.ClientOp.update:
                                    HpClients.UpdateClient(myDB, Menu.GetDNIFromUser("AREA CLIENTES -> ACTUALIZAR CLIENTE\n"));
                                    break;
                                case (int)Menu.ClientOp.query:
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
                        } while (menuOp > 0 && menuOp < 4);
                        break;
                    case (int)Menu.MainOp.rooms:
                        do
                        {
                            menuOp = Menu.PrintRoomMenu();
                            switch (menuOp)
                            {
                                case (int)Menu.RoomOp.add:
                                    //Insert Room
                                    HpRooms.InsertRoom(myDB);
                                    break;
                                case (int)Menu.RoomOp.query:
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
                    case (int)Menu.MainOp.books:
                        menuOp = Menu.PrintBookingMenu();
                        switch (menuOp)
                        {
                            case (int)Menu.BookOp.add:
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
                            case (int)Menu.BookOp.update:
                                //Modificar Reservacion - ir a otro menu
                                do
                                {
                                    menuOp = Menu.PrintBookingLowLevelMenu();
                                    switch (menuOp)
                                    {
                                        case (int)Menu.BookOpUpdate.upCheckIN:
                                            //Modificar CheckIn
                                            Menu.WriteConstruction();
                                            break;
                                        case (int)Menu.BookOpUpdate.upCheckOUT:
                                            //Modificar CheckOut
                                            Menu.WriteConstruction();
                                            break;
                                        case (int)Menu.BookOpUpdate.upBoth:
                                            //Modificar Ambas
                                            Menu.WriteConstruction();
                                            break;
                                        case (int)Menu.BookOpUpdate.back:
                                            //Volver - Bajar un nivel
                                            menuOp = Menu.PrintBookingMenu();
                                            break;
                                        default:
                                            Console.WriteLine("Other");
                                            break;
                                    }
                                } while (menuOp > 0 && menuOp < 4);
                                break;
                            case (int)Menu.BookOp.delete:
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
                    case (int)Menu.MainOp.exit:
                        //Salir
                        Console.WriteLine("\n\n\tGood Bye Dude...\n\n", Color.CadetBlue);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Other");
                        break;
                }

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
