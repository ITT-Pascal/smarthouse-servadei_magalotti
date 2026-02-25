using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps
{
    public class Lamp : AbstractLamp
    {
        public static readonly Brightness MaxBrightness = new Brightness(10);

        public Lamp(Guid id, Name name, DeviceStatus status, Brightness brightness, DateTime createdAtUtc, DateTime lastModifiedAtUtc)
            : base(id, name, status, brightness, createdAtUtc, lastModifiedAtUtc)
        {
        }
        public Lamp(Name name) : base(name)
        {
            IsEco = false;
            if (CurrentBrightness.Value < MinBrightness.Value)
                SetBrightness(brightness: new Brightness(MinBrightness.Value));
        }

        public override void SetBrightness(Brightness brightness)
        {
            if (Status == DeviceStatus.On)
            {
                CurrentBrightness = brightness;
                UpdateLastModified();
            }
        }

        public override void IncreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int newValue = CurrentBrightness.Value + 1;
                if (newValue > MaxBrightness.Value) newValue = MaxBrightness.Value;

                CurrentBrightness = new Brightness(newValue);
                UpdateLastModified();
            }
        }

        public override void DecreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int newValue = CurrentBrightness.Value - 1;
                if (newValue < MinBrightness.Value) newValue = MinBrightness.Value;

                CurrentBrightness = new Brightness(newValue);
                UpdateLastModified();
            }
        }
    }
}        
    
