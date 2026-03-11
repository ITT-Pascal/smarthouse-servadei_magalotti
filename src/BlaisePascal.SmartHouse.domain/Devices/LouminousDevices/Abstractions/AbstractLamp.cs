using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
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
        public static readonly Brightness MinBrightness = new Brightness(1);

        public Brightness CurrentBrightness { get; protected set; }
        public bool IsEco { get; protected set; }

        public AbstractLamp(Guid id, Name name, DeviceStatus status, Brightness brightness, DateTime createdAtUtc, DateTime lastModifiedAtUtc) : base(id, name, status, createdAtUtc, lastModifiedAtUtc)
        {
            Id = id;
            Name = name;
            Status = status;
            CurrentBrightness = brightness;
            CreatedAtUtc = createdAtUtc;
            LastModifiedAtUtc = lastModifiedAtUtc;
        }

        public AbstractLamp(Name name) : base(name)
        {
            CurrentBrightness = new Brightness(MinBrightness.Value);
            IsEco = false;
        }

        public AbstractLamp(Guid id, Name name, bool isEco) : base(name, id)
        {
            IsEco = isEco;
            CurrentBrightness = new Brightness(MinBrightness.Value);
        }

        public AbstractLamp(Guid id, Name name, DeviceStatus status, DateTime createdAtUtc)
        {
            Id = id;
            Name = name;
            Status = status;
            CreatedAtUtc = createdAtUtc;
        }
        public virtual void SetBrightness(Brightness value)
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness when the lamp is off.");
            }

            CurrentBrightness = value;
            UpdateLastModified();
        }

        public virtual void IncreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness when the lamp is off.");   
            }
            
            CurrentBrightness = new Brightness(CurrentBrightness.Value + 1);
            UpdateLastModified();
        }

        public virtual void DecreaseBrightness()
        {
            if (Status == DeviceStatus.Off)
            {
                throw new InvalidOperationException("Cannot change brightness when the lamp is off.");
            }

            CurrentBrightness = new Brightness(CurrentBrightness.Value - 1);
            UpdateLastModified();
        }
        public virtual void DimmerBrightness(Brightness brightness)
        {
            if (Status == DeviceStatus.On)
            {
                int newBrightness = CurrentBrightness.Value + brightness;

                if (newBrightness < MinBrightness.Value)
                {
                    newBrightness = MinBrightness.Value;
                }

                SetBrightness(new Brightness(newBrightness));
                UpdateLastModified();
            }
        }

        public override void Toggle()
        {
            base.Toggle();
        }

        public Guid GetId() { return Id; }
        public string GetName() { return Name.ToString(); }
    }
}