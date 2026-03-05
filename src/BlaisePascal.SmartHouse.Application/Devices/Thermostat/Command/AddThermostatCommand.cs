using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Interfaces; // Assumendo che l'interfaccia sia qui
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostats.Command
{
    public class AddThermostatCommand
    {
        private readonly IClimateRepository _thermostatRepository;

        public AddThermostatCommand(IClimateRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }
        public void Execute(string name, double initialTemp)
        {
            var thermostat = new ThermostatDomain(name, initialTemp);
            _thermostatRepository.Add(thermostat);
        }
    }
}