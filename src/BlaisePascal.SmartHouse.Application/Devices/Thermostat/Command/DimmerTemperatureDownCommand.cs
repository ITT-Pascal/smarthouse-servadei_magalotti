using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Command
{
    public class DimmerTemperatureDownCommand
    {
        private readonly IClimateRepository _thermostatRepository;

        public DimmerTemperatureDownCommand(IClimateRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            var thermostat = (ThermostatDomain)_thermostatRepository.GetById(id);
            thermostat.DimmerTemperatureDown();
            _thermostatRepository.Update(thermostat);
        }
    }
}
