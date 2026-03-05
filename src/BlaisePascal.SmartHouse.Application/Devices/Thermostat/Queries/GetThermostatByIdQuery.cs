using BlaisePascal.SmartHouse.Application.Devices.Thermostat.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Thermostats.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Queries
{
    public class GetThermostatByIdQuery
    {
        private readonly IClimateRepository _thermostatRepository;

        public GetThermostatByIdQuery(IClimateRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public ThermostatDto Execute(Guid id)
        {
            var thermostat = (ThermostatDomain)_thermostatRepository.GetById(id);

            return ThermostatMapper.ToDto(thermostat);
        }
    }
}
