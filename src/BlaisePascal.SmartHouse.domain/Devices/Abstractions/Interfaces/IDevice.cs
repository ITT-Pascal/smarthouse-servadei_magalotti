using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces
{
    public interface IDevice
    {
        Guid Id { get; }
        Name Name { get; }
        DeviceStatus Status { get; }
        bool IsOn { get; }
        DateTime CreatedAtUtc { get; }
        DateTime LastModifiedAtUtc { get; }
        void Rename(string newName);
        void TurnOn();
        void TurnOff();
        void Toggle();
    }
}
