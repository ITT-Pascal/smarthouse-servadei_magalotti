using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console
{
   class Program
   {
        static void Main()
        {
            ILampRepository repository = new InMemoryLampRepository();
            LampController controller = new LampController(repository);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                controller.GetAllLamps();
                ShowMenu();

                Console.WriteLine("Select an option:");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        controller.AddLamp();
                        break;
                    case "2":
                        controller.RemoveLamp();
                        break;
                    case "3":
                        controller.SwitchOn();
                        break;
                    case "4":
                        controller.SwitchOff();
                        break;
                    case "5":
                        controller.ChangeIntensity();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Pause();
            }
        }
            
            static void Pause()
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine
                
            }   




        }


   }
