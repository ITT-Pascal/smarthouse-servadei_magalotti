using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices
{
    public class ClimateDevices: AbstractDevice
    {
        //Properties
        public double Temperature { get; protected set; }
        //Constructors
        public ClimateDevices(string name) : base(name) { }
        public ClimateDevices(string name, Guid id, bool isOn, double temperature) : base(name, id)
        {
            Temperature = temperature;
        }
        public ClimateDevices() : base() { }
        //Methods
        public virtual void SetTemperature(double temperature)
        {
            if (!(Status == DeviceStatus.On)) { throw new InvalidOperationException("Cannot set temperature when the device is off."); }
            else
            {
                Temperature = temperature;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
        public virtual void IncreaseTemperature(double increment)
        {
            if (!(Status == DeviceStatus.On)) { throw new InvalidOperationException("Cannot increase temperature when the thermostat is off."); }
            else
            {
                Temperature += increment;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
        public virtual void DecreaseTemperature(double decrement)
        {
            if (!(Status == DeviceStatus.On)) { throw new InvalidOperationException("Cannot decrease temperature when the thermostat is off."); }
            else
            {
                Temperature -= decrement;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
    }
}
