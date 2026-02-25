using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
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
        public Name Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public bool IsOn => Status == DeviceStatus.On;
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        public AbstractDevice(Guid id, Name name, DeviceStatus status, DateTime createdAtUtc, DateTime lastModifiedAtUtc)
        {
            Id = id;
            Name = name;
            Status = status;
            CreatedAtUtc = createdAtUtc;
            LastModifiedAtUtc = lastModifiedAtUtc;
        }

        public AbstractDevice(Name name)
        {
            if (name == null)
                throw new InvalidOperationException("Name cannot be null.");

            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public AbstractDevice(Name name, Guid id)
        {
            if (name == null)
                throw new InvalidOperationException("Name cannot be null.");

            if (id == Guid.Empty)
                throw new InvalidOperationException("Id cannot be empty.");

            Id = id;
            Name = name;
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public AbstractDevice()
        {
            Id = Guid.NewGuid();
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public virtual void Rename(Name newName)
        {
            if (newName == null)
                throw new InvalidOperationException("New name cannot be null.");

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
