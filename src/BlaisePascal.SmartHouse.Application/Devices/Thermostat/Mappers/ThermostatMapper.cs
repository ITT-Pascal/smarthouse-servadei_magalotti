using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.ValueObjects;
using BlaisePascal.SmartHouse.Application.Devices.Thermostat.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Abstractions.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.Thermostat.Dto;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostats.Mappers;

public static class ThermostatMapper
{
    public static ThermostatDto ToDto(ThermostatDomain thermostat)
    {
        return new ThermostatDto
        {
            Id = thermostat.Id,
            Name = thermostat.Name.ToString(), // Estrae la stringa dal Value Object Name
            DeviceStatus = DeviceStatusMapper.ToDto(thermostat.Status),
            CurrentTemperature = thermostat.CurrentTemperature.Value, // Estrae il double da Temperature
            CurrentMode = thermostat.Mode.ToString(),
            
        };
    }

    public static ThermostatDomain ToDomain(ThermostatDto dto)
    {
        // Utilizza il costruttore completo del Thermostat
        return new ThermostatDomain(
            dto.Id,
            Name.Create(dto.Name!), // Ricrea il Value Object Name
            DeviceStatusMapper.ToDomain(dto.DeviceStatus),
            dto.CurrentTemperature, // Il costruttore accetta double e crea internamente il VO Temperature
            Enum.Parse<ThermostatMode>(dto.CurrentMode!) // Converte la stringa in Enum
        );
    }
}