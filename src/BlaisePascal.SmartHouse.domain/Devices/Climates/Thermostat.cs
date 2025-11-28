using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices
{
    public class Thermostat: ClimateDevices
    {
        public const double DefoultDimmer = 0.5;

        public Thermostat(string name) : base(name) { }
        public Thermostat(string name, Guid id, bool isOn, double temperature) : base(name, id, isOn, temperature) { }
        public Thermostat() : base() { }

        

        public void DimmerTemperatureUp()
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot dimmer temperature when the thermostat is off.");
            }
            Temperature += DefoultDimmer;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void DimmerTemperatureDown()
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot dimmer temperature when the thermostat is off.");
            }
            Temperature -= DefoultDimmer;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
