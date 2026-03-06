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
                        controller.AddLamp();
                        break;
                    case "2":
                        controller.RemoveLamp();
                        break;
                    case "3":
                        controller.ChangeIntensity();
                        break;
                    case "4":
                        controller.SwitchOn();
                        break;
                    case "5":
                        controller.SwitchOff();
                        break;
                    case "6":
                        controller.GetAllLamps();   
                        break;  
                    case "7":
                        exit = true;
                        break;
                    default:
                        WriteLine("Invalid option. Please try again.");
                        break;
                }
                Pause();
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
