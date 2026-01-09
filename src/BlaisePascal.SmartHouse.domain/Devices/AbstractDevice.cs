using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices
{
    public abstract class AbstractDevice : IDevice
    {
        public Guid Id { get; protected set; }
        //Properties
        public bool IsOn { get; protected set; } 
        public string Name { get; protected set; }
        public DeviceStatus Status { get;  protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        //Constructors
        public AbstractDevice(string name)
        {
            if (name == "")
                throw new InvalidOperationException("Name cannot be empty");
            else
                Name = name;
            Id = Guid.NewGuid();
            IsOn = false;
            Status = DeviceStatus.Unknown;
            CreatedAtUtc = DateTime.UtcNow;
        }
        public AbstractDevice(string name, Guid id)
        {
            if (  name == "")
                throw new InvalidOperationException("Name cannot be empty");
            else
                Name = name;
            Id = id;
            IsOn = false;                
            Status = DeviceStatus.Unknown;
            CreatedAtUtc = DateTime.UtcNow;
        }
        public AbstractDevice() 
        {
            CreatedAtUtc = DateTime.UtcNow; 
            IsOn = false; 
        }
        //Methods
        public virtual void Rename(string newName)
        {
            if (Name == newName&&newName=="")
                throw new InvalidOperationException("Name cannot be the same and cannot be empty");
            Name = newName;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void TurnOn()
        {
            if ((Status == DeviceStatus.On))
                 throw new InvalidOperationException("Device already on.");
            
            IsOn = true;
            Status = DeviceStatus.On;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public virtual void TurnOff()
        {
            if (Status == DeviceStatus.On)
            {
                IsOn = false;
                Status = DeviceStatus.Off;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
                throw new InvalidOperationException("Device already off.");
        }

        public virtual void Toggle()
        {
            if (Status == DeviceStatus.On)
                TurnOff(); 
            else
                TurnOn();   
        }
    }
}
