using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Command
{
    public class DimmerTemperatureUpCommand
    {
        private readonly IClimateRepository _thermostatRepository;

        public DimmerTemperatureUpCommand(IClimateRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            var thermostat = (ThermostatDomain)_thermostatRepository.GetById(id);
            thermostat.DimmerTemperatureUp();
            _thermostatRepository.Update(thermostat);
        }

    }
}
