using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse.domain
{
    public class Ecolamp : LampModel
    {
        //constants
        private const int MIN_BRIGHTNESS = 1;
        //properties
        public int maxBrightness { get; private set; } = 10;
        public bool IsPowerSaveMode { get; private set; }
        public DateTime TurnOnHours { get; private set; }
        //constructor
        public Ecolamp(string lampsName, bool isEco) : base(lampsName, isEco)
        {
            IsPowerSaveMode = false;
            Brightness = maxBrightness;
        }
        //methods
        public override void SwitchOnOff()
        {
            if (IsOn)
                IsOn = false;
            IsOn = true;
            
            if (IsOn)
                TurnOnHours = DateTime.UtcNow;
        }
        public override void increaseBrightness()
        {
            if (IsOn == true)
            {
                if (Brightness + 1 >= maxBrightness)
                    Brightness = maxBrightness;

                Brightness += 1;
            }
        }
        public override void decreaseBrightness()
        {
            if (IsOn == true)
            {
                if (Brightness - 1 <= MIN_BRIGHTNESS)
                    Brightness = MIN_BRIGHTNESS;
                Brightness -= 1;
            }
        }
        public void SwitchPowerSaveMode()
        {
            if (IsPowerSaveMode == false)
            {
                maxBrightness = 5;
                IsPowerSaveMode = true;
                if (Brightness > maxBrightness)
                    Brightness = maxBrightness;
            }
            maxBrightness = 10;
            IsPowerSaveMode = false;    
        }
        public void ShuldBeActivatedPowerSaveMode()
        {
            if (DateTime.UtcNow - TurnOnHours >= TimeSpan.FromMinutes(180))
            {
                if (IsPowerSaveMode == false)
                    SwitchPowerSaveMode();      
            }
        }
    }
}   
    
