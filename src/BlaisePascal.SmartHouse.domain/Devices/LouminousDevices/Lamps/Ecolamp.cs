using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices
{
    public class EcoLamp : AbstractLamp
    {
        public static readonly Brightness PowerSaveLimit = new Brightness(5);
        public static readonly Brightness StandardLimit = new Brightness(10);
        private const int AutoPowerSaveMinutes = 180;

        public Brightness MaxBrightness { get; private set; }
        public bool IsPowerSaveMode { get; private set; }
        public DateTime TurnOnHours { get; private set; }

        public EcoLamp(Name name) : base(name)
        {
            MaxBrightness = StandardLimit;
            IsPowerSaveMode = false;
            if (CurrentBrightness.Value > MaxBrightness.Value)
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
                if (nextValue >= MaxBrightness.Value)
                {
                    nextValue = MaxBrightness.Value;
                }
                base.SetBrightness(new Brightness(nextValue));
            }
        }

        public override void DecreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                int nextValue = CurrentBrightness.Value - 1;
                if (nextValue < MinBrightness.Value)
                {
                    nextValue = MinBrightness.Value;
                }
                base.SetBrightness(new Brightness(nextValue));
            }
        }

        public override void SetBrightness(Brightness brightness)
        {
            if (Status == DeviceStatus.On)
            {
                if (brightness.Value > MaxBrightness.Value) brightness = MaxBrightness;
                if (brightness.Value < MinBrightness.Value) brightness = MinBrightness;
                base.SetBrightness(brightness);
            }
        }

        public void SwitchPowerSaveMode()
        {
            if (!IsPowerSaveMode)
            {
                IsPowerSaveMode = true;
                MaxBrightness = PowerSaveLimit;
                if (CurrentBrightness.Value > MaxBrightness.Value)
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