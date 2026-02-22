using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps
{
    public class Lamp : AbstractLamp
    {
        public const int MaxBrightness = 10;

        public Lamp(Guid id, string name, DeviceStatus status, Brightness brightness, DateTime createdAtUtc, DateTime lastModifiedAtUtc)
            : base(id, name, status, brightness, createdAtUtc, lastModifiedAtUtc)
        {
        }
        public Lamp(string name) : base(name)
        {
            IsEco = false;
            if (CurrentBrightness.Value < MinBrightness)
                SetBrightness(MinBrightness);
        }

        public override void SetBrightness(int brightness)
        {
            if (Status == DeviceStatus.On)
            {
                if (brightness > MaxBrightness) brightness = MaxBrightness;
                if (brightness < MinBrightness) brightness = MinBrightness;

                CurrentBrightness = new Brightness(brightness);
                UpdateLastModified();
            }
        }

        public override void IncreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int newValue = CurrentBrightness.Value + 1;
                if (newValue > MaxBrightness) newValue = MaxBrightness;

                CurrentBrightness = new Brightness(newValue);
                UpdateLastModified();
            }
        }

        public override void DecreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int newValue = CurrentBrightness.Value - 1;
                if (newValue < MinBrightness) newValue = MinBrightness;

                CurrentBrightness = new Brightness(newValue);
                UpdateLastModified();
            }
        }
    }
}        
    
