using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.Climates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates
{
    public abstract class ClimateDevice : AbstractDevice
    {
        public Temperature CurrentTemperature { get; protected set; }

        protected ClimateDevice(string name, double initialTemp) : base(name)
        {
            CurrentTemperature = new Temperature(initialTemp);
        }

        protected ClimateDevice(Guid id, string name, DeviceStatus status, double currentTemp)
            : base(name, id)
        {
            Status = status;
            CurrentTemperature = new Temperature(currentTemp);
        }

        public virtual void SetTemperature(double value)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot set temperature when device is off.");

            CurrentTemperature = new Temperature(value);
            UpdateLastModified();
        }

        public virtual void IncreaseTemperature(double amount)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot increase temperature when device is off.");

            CurrentTemperature = CurrentTemperature.Add(amount);
            UpdateLastModified();
        }

        public virtual void DecreaseTemperature(double amount)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot decrease temperature when device is off.");

            CurrentTemperature = CurrentTemperature.Subtract(amount);
            UpdateLastModified();
        }
    }
}
