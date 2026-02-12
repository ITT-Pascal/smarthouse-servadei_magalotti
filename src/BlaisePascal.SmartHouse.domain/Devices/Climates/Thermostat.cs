using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates
{
    public class Thermostat : ClimateDevice
    {
        private const double DefaultDimmerStep = 0.5;
        public ThermostatMode Mode { get; private set; }

        public Thermostat(string name, double initialTemp) : base(name, initialTemp)
        {
            Mode = ThermostatMode.Standby;
        }

        public Thermostat(Guid id, string name, DeviceStatus status, double currentTemp, ThermostatMode mode)
            : base(id, name, status, currentTemp)
        {
            Mode = mode;
        }

        public Thermostat(string name) : base(name)
        {
        }

        public void SetMode(ThermostatMode mode)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot change mode when device is off.");

            Mode = mode;
            UpdateLastModified();
        }

        public void DimmerTemperatureUp()
        {
            IncreaseTemperature(DefaultDimmerStep);
        }

        public void DimmerTemperatureDown()
        {
            DecreaseTemperature(DefaultDimmerStep);
        }
    }
}
