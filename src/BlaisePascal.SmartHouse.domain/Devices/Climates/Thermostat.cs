using SmartHouse.domain.Devices.Climates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices
{
    public class Thermostat: ClimateDevices
    {
        //Properties
        public const double DefaultDimmer = 0.5;
        //Constructors
        public Thermostat(string name) : base(name) { }
        public Thermostat(string name, Guid id, bool isOn, double temperature) : base(name, id, isOn, temperature) { }
        public Thermostat() : base() { }
        //Methods
        public void DimmerTemperatureUp()
        {
            if (!(Status == DeviceStatus.On)) { throw new InvalidOperationException("Cannot dimmer temperature when the device is off."); }
            else
            {
                Temperature += DefaultDimmer;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
        public void DimmerTemperatureDown()
        {
            if (!(Status == DeviceStatus.On)) { throw new InvalidOperationException("Cannot dimmer temperature when the device is off."); }
            else
            {
                Temperature -= DefaultDimmer;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
    }
}
