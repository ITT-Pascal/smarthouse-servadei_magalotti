using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Command
{
    public class SetThermostatModeCommand
    {
        private readonly IClimateRepository _thermostatRepository;

        public SetThermostatModeCommand(IClimateRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id, ThermostatMode mode)
        {
            var thermostat = (ThermostatDomain)_thermostatRepository.GetById(id);
            thermostat.SetMode(mode);
            _thermostatRepository.Update(thermostat);
        }
    }
}
