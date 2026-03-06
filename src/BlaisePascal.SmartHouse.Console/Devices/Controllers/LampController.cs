using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System.Runtime.InteropServices;
public class LampController
{
    private readonly ILampRepository _repository;

    public LampController(ILampRepository repository)
    {
        _repository = repository;
    }

    public void AddLamp()
    {
        string LampForName = "Lamp";
        Console.WriteLine("Enter lamp name:");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Lamp name cannot be empty.");
            return;
        }
        if(!name.Contains(LampForName))
        {
            name = name + LampForName;
        }

        new AddLampCommand(_repository).Execute(name);
    }
    private LampDto? SelectLamp()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        
        if (lamps.Count == 0)
        {
            Console.WriteLine("No lamps available.");
            return null;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n<<<< AVAILABLE LAMPS >>>> ");
        Console.ResetColor();

        //TODO: Correct


        foreach (var l in lamps)
        {
            for (int i = 0; i < lamps.Count; i++)
            {
                    Console.WriteLine($"{i + 1} - {l.Name}");
            }
        }
        Console.WriteLine("-----------------------");

        Console.WriteLine("Enter the name of the lamp:");
        string lampName = Console.ReadLine();

        
        if (lampName == null || lampName == "")
        {
            Console.WriteLine("Invalid input. Lamp name cannot be empty.");
            return null;
        }

        
        LampDto selectedLamp = null;
        foreach (var l in lamps)
        {
            
            if (l.Name.ToLower() == lampName.ToLower())
            {
                selectedLamp = l;
                break; 
            }
        }

        
        if (selectedLamp == null)
        {
            Console.WriteLine("Invalid selection. Lamp with name '" + lampName + "' not found.");
            return null;
        }

        return selectedLamp;
    }
    public void ChangeIntensity()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;

        Console.WriteLine("Enter new intensity (0-100):");
        int intensity;

        if (!int.TryParse(Console.ReadLine(), out intensity))
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            return;
        }

        try
        {
            new SetLampBrightnessCommand(_repository).Execute(lamp.Id, intensity);
            Console.WriteLine("Lamp intensity updated successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error updating lamp intensity: {ex.Message}");

        }
    }
    public void GetAllLamps()
    {
        try
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();

            if (lamps == null || lamps.Count == 0)
            {
                Console.WriteLine("No lamps available.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n<<<< AVAILABLE LAMPS >>>>");
            Console.ResetColor();
            foreach (var lamp in lamps)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Name: ");
                Console.ResetColor();
                Console.WriteLine(lamp.Name);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ID: ");
                Console.ResetColor();
                Console.WriteLine(lamp.Id);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Brightness: ");
                Console.ResetColor();
                Console.WriteLine(lamp.Brightness);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Status: ");
                Console.ResetColor();
                Console.WriteLine(lamp.DeviceStatus);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Created at: ");
                Console.ResetColor();
                Console.WriteLine(lamp.CreatedAtUtc);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Last modified: ");
                Console.ResetColor();
                Console.WriteLine(lamp.LastModifiedAtUtc + "\n"); 
                //Console.WriteLine($"Name: {lamp.Name} \n ID: {lamp.Id} \n Brightness: {lamp.Brightness} \n Status: {lamp.DeviceStatus} \n Created at: {lamp.CreatedAtUtc} \n Last modified: {lamp.LastModifiedAtUtc}\n\n");
            }
            Console.WriteLine("=========================");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving lamps: {ex.Message}");
        }
    }
    public void SwitchOff()
    {
        try
        {
            var Lamp = SelectLamp();
            if (Lamp == null)
                return;

            new SwitchOffLampCommand(_repository).Execute(Lamp.Id);
            Console.WriteLine("Lamp switched off successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error switching off lamp: {ex.Message}");
        }
    }
    public void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n==== Chose an option ====");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Add Lamp");
        Console.WriteLine("2. Remove Lamp");
        Console.WriteLine("3. Change Lamp Brightness");
        Console.WriteLine("4. Switch On Lamp");
        Console.WriteLine("5. Switch Off Lamp");
        Console.WriteLine("6. Get available Lamps");
        Console.WriteLine("7. Exit");
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    public void RemoveLamp()
    {
        try
        {
            var lamp = SelectLamp();
            if (lamp == null)
                return;
            new RemoveLampCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Lamp removed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing lamp: {ex.Message}");
        }
    }
    public void SwitchOn()
    {
        try
        {
            var Lamp = SelectLamp();
            if (Lamp == null)
                return;
            new SwitchOnLampCommand(_repository).Execute(Lamp.Id);
            Console.WriteLine("Lamp switched on successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error switching on lamp: {ex.Message}");
        }
    }

}




