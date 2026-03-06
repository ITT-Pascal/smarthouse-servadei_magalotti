using BlaisePascal.SmartHouse.Application.Devices.Thermostat.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Thermostats.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostats.Queries
{
    public class GetAllThermostatsQuery
    {
        private readonly IClimateRepository _thermostatRepository;

        public GetAllThermostatsQuery(IClimateRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public List<ThermostatDto> Execute()
        {
            // Usiamo .OfType<Thermostat>() per prendere solo i termostati dalla lista climatica
            // e risolvere l'errore CS0029
            return _thermostatRepository.GetAll()
                .OfType<ThermostatDomain>()
                .Select(t => ThermostatMapper.ToDto(t))
                .ToList();
        }
    }
}