using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Dto
{
    public record ThermostatDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? DeviceStatus { get; init; }
        public double CurrentTemperature { get; init; }
        public string? CurrentMode { get; init; }




    }
}
