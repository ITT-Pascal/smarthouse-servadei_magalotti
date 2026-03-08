using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
                Clear();
                controller.GetAllLamps();
                controller.ShowMenu();

                ForegroundColor = ConsoleColor.Green;
                WriteLine("Select an option:");
                ResetColor();
                string? choice = ReadLine();

                WriteLine();

                switch (choice)
                {
                    case "1":
                        Clear();
                        controller.AddLamp();
                        break;
                    case "2":
                        Clear();
                        controller.RemoveLamp();
                        break;
                    case "3":
                        Clear();
                        controller.ChangeBrightness();
                        break;
                    case "4":
                        Clear();
                        controller.SwitchOn();
                        break;
                    case "5":
                        Clear();
                        controller.SwitchOff();
                        break;
                    case "6":
                        Clear();
                        controller.GetAllLamps();   
                        break;  
                    case "7":
                        Clear();
                        controller.GetLampById();
                        break;
                    case "8":
                        Clear();
                        controller.GetLampByName();
                        break;
                    case "9":
                        Clear();
                        exit = true;
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid option. Please try again.");
                        break;
                }
                if (!exit)
                {
                    Pause();
                }
            }
        }
            
            static void Pause()
            {
                WriteLine();
                WriteLine("Press any key to continue...");
                ReadKey();
            }   
   }
}
