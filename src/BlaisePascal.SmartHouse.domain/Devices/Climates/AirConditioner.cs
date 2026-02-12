using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates
{
    public class AirConditioner : ClimateDevice
    {
        public AirConditionerMode Mode { get; private set; }

        public AirConditioner(string name, double initialTemp) : base(name, initialTemp)
        {
            Mode = AirConditionerMode.Auto;
        }

        public AirConditioner(Guid id, string name, DeviceStatus status, double currentTemp, AirConditionerMode mode)
            : base(id, name, status, currentTemp)
        {
            Mode = mode;
        }

        public AirConditioner(string name) : base(name)
        {
        }

        public void SetMode(AirConditionerMode mode)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot change mode when device is off.");

            Mode = mode;
            UpdateLastModified();
        }
    }
}
