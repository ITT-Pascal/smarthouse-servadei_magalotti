using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Abstractions.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.Thermostat.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using System;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostats.Mappers
{
    public static class ThermostatMapper
    {
        public static ThermostatDto ToDto(ThermostatDomain thermostat)
        {
            return new ThermostatDto
            {
                Id = thermostat.Id,
                Name = thermostat.Name.ToString(),
                DeviceStatus = DeviceStatusMapper.ToDto(thermostat.Status),
                CurrentTemperature = thermostat.CurrentTemperature.Value,
                CurrentMode = thermostat.Mode.ToString()
            };
        }

        public static ThermostatDomain ToDomain(ThermostatDto dto)
        {
            return new ThermostatDomain(
                dto.Id,
                dto.Name!,
                DeviceStatusMapper.ToDomain(dto.DeviceStatus!),
                dto.CurrentTemperature,
                Enum.Parse<ThermostatMode>(dto.CurrentMode!)
            );
        }
    }
}