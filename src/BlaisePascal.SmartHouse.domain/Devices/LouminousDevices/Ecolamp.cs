using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse.domain
{
    public class EcoLamp : LampModel
    {
        //constants
        private const int MIN_BRIGHTNESS = 1;
        //properties
        public int maxBrightness { get; private set; } = 10;
        public bool IsPowerSaveMode { get; private set; }
        public DateTime TurnOnHours { get; private set; }
        //constructor

        public EcoLamp(string name) : base(name) 
        { 
            IsPowerSaveMode = false;
            IsOn = false;
            Brightness = maxBrightness; 
        }

        public EcoLamp(string name, Guid id, bool isOn, bool isEco) : base(name, id, isOn, isEco)
        {
            IsEco = isEco;
            IsPowerSaveMode = false;
            Brightness = maxBrightness;
            IsOn = false;
        }
        //methods

        public override void TurnOn()
        {
            base.TurnOn();
        }

        public override void TurnOff()
        {
            base.TurnOff();
        }

        public override void Toggle()
        {
            base.Toggle();
            if (Status == DeviceStatus.On)
                TurnOnHours = DateTime.UtcNow;
        }

        public override void Rename(string newName)
        {
            base.Rename(newName);
        }
        
        public override void increaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                LastModifiedAtUtc = DateTime.UtcNow;
                if (Brightness + 1 >= maxBrightness)
                    Brightness = maxBrightness;
                else
                    Brightness += 1;
            }
        }
        public override void decreaseBrightness()
        {
            if (Status == DeviceStatus.On)
            {
                LastModifiedAtUtc = DateTime.UtcNow;
                if (Brightness - 1 <= MIN_BRIGHTNESS)
                    Brightness = MIN_BRIGHTNESS;
                else
                    Brightness -= 1;
            }
        }
        public void SwitchPowerSaveMode()
        {
            if (IsPowerSaveMode == false)
            {
                LastModifiedAtUtc = DateTime.UtcNow;
                IsPowerSaveMode = true;
                maxBrightness = 5;
                Brightness = maxBrightness;
            }
            else
            {
                LastModifiedAtUtc = DateTime.UtcNow;
                IsPowerSaveMode = false;
                maxBrightness = 10;
                Brightness = maxBrightness;
            }
        }
        public void ShuldBeActivatedPowerSaveMode()
        {
            if (DateTime.UtcNow - TurnOnHours >= TimeSpan.FromMinutes(180))
            {
                if (IsPowerSaveMode == false)
                    SwitchPowerSaveMode();
                    LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
    }
}   
    
