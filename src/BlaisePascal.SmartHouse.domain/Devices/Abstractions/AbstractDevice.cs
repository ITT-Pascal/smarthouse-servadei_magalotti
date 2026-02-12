using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public abstract class AbstractDevice : IDevice
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public bool IsOn => Status == DeviceStatus.On;
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        protected AbstractDevice(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Name cannot be empty or whitespace.");

            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        protected AbstractDevice(string name, Guid id)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Name cannot be empty or whitespace.");

            if (id == Guid.Empty)
                throw new InvalidOperationException("Id cannot be empty.");

            Id = id;
            Name = name;
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        protected AbstractDevice()
        {
            Id = Guid.NewGuid();
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public virtual void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidOperationException("New name cannot be empty.");

            if (Name == newName)
                throw new InvalidOperationException("New name cannot be the same as the current name.");

            Name = newName;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void TurnOn()
        {
            if (Status == DeviceStatus.On)
                throw new InvalidOperationException("Device already on.");

            Status = DeviceStatus.On;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void TurnOff()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Device already off.");

            Status = DeviceStatus.Off;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void Toggle()
        {
            if (Status == DeviceStatus.On)
                TurnOff();
            else
                TurnOn();
        }
        public void UpdateLastModified()
        {
            LastModifiedAtUtc = DateTime.UtcNow;
        }
    }
}
