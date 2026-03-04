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
        Console.WriteLine("Enter lamp name:");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Lamp name cannot be empty.");
            return;
        }

        new AddLampCommand(_repository).Execute(name);
    }
    private LampDto SelectLamp()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();
        if (lamps.Count == 0)
        {
            Console.WriteLine("No lamps available.");
            return null;
        }
        Console.WriteLine("Select a lamp:");
        int index;

        if (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return null;
        }
        if (index < 1 || index > lamps.Count)
        {
            Console.WriteLine("Invalid selection. Please select a valid lamp number.");
            return null;
        }
        return lamps[index - 1];

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
        throw new NotImplementedException();
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
        Console.WriteLine("1. Add Lamp");
        Console.WriteLine("2. Change Lamp Intensity");
        Console.WriteLine("3. Exit");
    }
}




