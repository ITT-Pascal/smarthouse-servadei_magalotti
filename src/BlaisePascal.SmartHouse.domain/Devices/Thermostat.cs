using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices
{
    public class Thermostat
    {
        public bool IsOn { get; private set; }
        public string Name { get; private set; }
        public Guid IdThermostat { get; private set; }
        public DeviceStatus Status { get; private set; }
        public double Temperature { get; private set; }
        public const double DefoultDimmer = 0.5;
        public Thermostat(string name)
        {
            Name = name;
            IdThermostat = Guid.NewGuid();
            IsOn = false;
            Status = DeviceStatus.Unknown;

        }
        public Thermostat(string name, Guid idThermostat, bool isOn, double temperature)
        {
            Name = name;
            IdThermostat = idThermostat;
            IsOn = isOn;
            Temperature = temperature;
            if (isOn)
                Status = DeviceStatus.On;
            else
                Status = DeviceStatus.Unknown;
        }
        public Thermostat() { }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void TurnOn()
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Thermostat is already on.");
            }
            IsOn = true;
            Status = DeviceStatus.On;
        }

        public void TurnOff()
        {
            if (Status == DeviceStatus.On)
            {
                IsOn = false;
                Status = DeviceStatus.Off;
            }
            throw new InvalidOperationException("Thermostat is already off.");

        }

        public void Toggle()
        {
            if (Status == DeviceStatus.On)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }

        public void SetTemperature(double temperature)
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot set temperature when the thermostat is off.");
            }
            Temperature = temperature;
        }

        public void IncreaseTemperature(double increment)
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot increase temperature when the thermostat is off.");
            }
            Temperature += increment;
        }

        public void DecreaseTemperature(double decrement)
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot decrease temperature when the thermostat is off.");
            }
            Temperature -= decrement;
        }

        public void DimmerTemperatureUp()
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot dimmer temperature when the thermostat is off.");
            }
            Temperature += DefoultDimmer;
        }

        public void DimmerTemperatureDown()
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot dimmer temperature when the thermostat is off.");
            }
            Temperature -= DefoultDimmer;
        }
    }
}
