using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices
{
    public abstract class AbstractLamp : AbstractDevice
    {
        public const int MinBrightness = 1;

        public Brightness CurrentBrightness { get; protected set; }
        public bool IsEco { get; protected set; }

        public AbstractLamp(Guid id, string name, DeviceStatus status, Brightness brightness, DateTime createdAtUtc, DateTime lastModifiedAtUtc): base(id, name, status, createdAtUtc, lastModifiedAtUtc) 
        {
            Id = id;
            Name = name;
            Status = status;
            CurrentBrightness = brightness;
            CreatedAtUtc = createdAtUtc;
            LastModifiedAtUtc = lastModifiedAtUtc;
        }

        public AbstractLamp(string name) : base(name)
        {
            CurrentBrightness = new Brightness(MinBrightness);
            IsEco = false;
        }

        public AbstractLamp(Guid id, string name, bool isEco) : base(name, id)
        {
            IsEco = isEco;
            CurrentBrightness = new Brightness(MinBrightness);
        }

        protected AbstractLamp(Guid id, string name, DeviceStatus status, DateTime createdAtUtc)
        {
            Id = id;
            Name = name;
            Status = status;
            CreatedAtUtc = createdAtUtc;
        }

        public virtual void SetBrightness(int value)
        {
            if (Status == DeviceStatus.On)
            {
                CurrentBrightness = new Brightness(value);
                UpdateLastModified();
            }
        }

        public virtual void IncreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                CurrentBrightness = new Brightness(CurrentBrightness.Value + 1);
                UpdateLastModified();
            }
        }

        public virtual void DecreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                CurrentBrightness = new Brightness(CurrentBrightness.Value - 1);
                UpdateLastModified();
            }
        }

        public override void Toggle()
        {
            base.Toggle();
        }

        public Guid GetId() { return Id; }
        public string GetName() { return Name; }
    }
}