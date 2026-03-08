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
        Console.WriteLine("Lamp added successfully.");
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
            Console.WriteLine("Lamp removed successfully.");
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
    public void GetLampById()
    {
        Console.WriteLine("Enter the ID of the lamp:");
        string? idString = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(idString))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        try
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();
            LampDto? selectedLamp = null;

            foreach (var l in lamps)
            {
                if (l.Id.ToString() == idString)
                {
                    selectedLamp = l;
                    break;
                }
            }

            if (selectedLamp != null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n !Lamp Found! ");
                Console.ResetColor();
                PrintLampDetails(selectedLamp);
            }
            else
            {
                Console.WriteLine("Lamp not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving lamp: {ex.Message}");
        }
    }
    public void GetLampByName()
    {
        Console.WriteLine("Enter the name of the lamp:");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid input. Lamp name cannot be empty.");
            return;
        }

        try
        {
            var lamps = new GetAllLampsQuery(_repository).Execute();
            LampDto? selectedLamp = null;

            foreach (var l in lamps)
            {
                if (l.Name.ToLower() == name.ToLower())
                {
                    selectedLamp = l;
                    break;
                }
            }

            if (selectedLamp != null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n !Lamp Found! ");
                Console.ResetColor();
                PrintLampDetails(selectedLamp);
            }
            else
            {
                Console.WriteLine("Lamp not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving lamp: {ex.Message}");
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

        for (int i = 0; i < lamps.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {lamps[i].Name}");
        }

        Console.WriteLine("-----------------------");

        Console.WriteLine("Enter the name or the number of the lamp:");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Selection cannot be empty.");
            return null;
        }

        LampDto? selectedLamp = null;

        if (int.TryParse(input, out int index))
        {
            if (index > 0 && index <= lamps.Count)
            {
                selectedLamp = lamps[index - 1];
            }
        }
        else
        {
            foreach (var l in lamps)
            {
                if (l.Name.ToLower() == input.ToLower())
                {
                    selectedLamp = l;
                    break;
                }
            }
        }

        if (selectedLamp == null)
        {
            Console.WriteLine("Invalid selection. Lamp '" + input + "' not found.");
            return null;
        }

        return selectedLamp;
    }
    public void ChangeBrightness()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;

        Console.WriteLine("Enter new brightness (0-10):");
        int brightness;

        if (!int.TryParse(Console.ReadLine(), out brightness))
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 10.");
            return;
        }

        try
        {
            new SetLampBrightnessCommand(_repository).Execute(lamp.Id, brightness);
            Console.WriteLine("Lamp brightness updated successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error updating lamp brightness: {ex.Message}");

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
        Console.WriteLine("7. Get Lamp by ID");
        Console.WriteLine("8. Get Lamp by Name");
        Console.WriteLine("9. Exit");
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    private void PrintLampDetails(LampDto lamp)
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
    }
}




