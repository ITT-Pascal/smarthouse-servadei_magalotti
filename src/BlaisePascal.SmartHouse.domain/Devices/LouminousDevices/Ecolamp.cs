using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices
{
    public class EcoLamp : LampModel
    {
        private const int PowerSaveLimit = 5;
        private const int StandardLimit = 10;
        private const int AutoPowerSaveMinutes = 180;

        public int MaxBrightness { get; private set; }
        public bool IsPowerSaveMode { get; private set; }
        public DateTime TurnOnHours { get; private set; }

        public EcoLamp(string name) : base(name)
        {
            MaxBrightness = StandardLimit;
            IsPowerSaveMode = false;
            if (CurrentBrightness.Value > MaxBrightness)
            {
                base.SetBrightness(MaxBrightness);
            }
        }

        public override void TurnOn()
        {
            base.TurnOn();
            TurnOnHours = DateTime.UtcNow;
        }

        public override void TurnOff()
        {
            base.TurnOff();
        }

        public override void Toggle()
        {
            base.Toggle();
            if (Status == DeviceStatus.On)
            {
                TurnOnHours = DateTime.UtcNow;
            }
        }

        public override void IncreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int nextValue = CurrentBrightness.Value + 1;
                if (nextValue >= MaxBrightness)
                {
                    nextValue = MaxBrightness;
                }
                base.SetBrightness(nextValue);
            }
        }

        public override void DecreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int nextValue = CurrentBrightness.Value - 1;
                if (nextValue < MinBrightness)
                {
                    nextValue = MinBrightness;
                }
                base.SetBrightness(nextValue);
            }
        }

        public override void SetBrightness(int brightness)
        {
            if (Status == DeviceStatus.On)
            {
                if (brightness > MaxBrightness) brightness = MaxBrightness;
                if (brightness < MinBrightness) brightness = MinBrightness;
                base.SetBrightness(brightness);
            }
        }

        public void SwitchPowerSaveMode()
        {
            if (!IsPowerSaveMode)
            {
                IsPowerSaveMode = true;
                MaxBrightness = PowerSaveLimit;
                if (CurrentBrightness.Value > MaxBrightness)
                {
                    base.SetBrightness(MaxBrightness);
                }
            }
            else
            {
                IsPowerSaveMode = false;
                MaxBrightness = StandardLimit;
            }
            UpdateLastModified();
        }

        public void ShouldBeActivatedPowerSaveMode()
        {
            if (Status == DeviceStatus.On && !IsPowerSaveMode)
            {
                if ((DateTime.UtcNow - TurnOnHours).TotalMinutes >= AutoPowerSaveMinutes)
                {
                    SwitchPowerSaveMode();
                }
            }
        }
    }
}