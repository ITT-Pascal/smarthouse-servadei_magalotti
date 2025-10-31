using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse.domain
{
    public class Ecolamp
    {
        private int maxBrightness = 10;
        private const int MIN_BRIGHTNESS = 1;

        public bool IsOn { get; private set; }

        public DateTime TurnOnHour { get; private set; }  

        public bool IsPowerSaveMode { get; private set; }

        public int Brightness { get; set; }
        

        public Ecolamp()
        {
            IsOn = false;
            IsPowerSaveMode = false;
        }   

        public void switchOnOff()
        {
            if (IsOn)
                IsOn = false;
            else
                IsOn = true;
                TurnOnHour = DateTime.Now;


        }

        public void increaseBrightness()
        {
            if (IsOn == true)
                if (Brightness >= maxBrightness) { throw new ArgumentOutOfRangeException("You can't ecxeed the Max Brightness"); }
                Brightness += 1;
        }

        public void decreaseBrightness()
        {
            if (IsOn == true)
                if (Brightness <= MIN_BRIGHTNESS) { throw new ArgumentOutOfRangeException("You can't ecxeed the Min Brightness"); }
                Brightness -= 1;
        }

        public void SwitchPowerSaveMode()
        {
            maxBrightness = 5;
            IsPowerSaveMode =true;
            
            throw new System.NotImplementedException();
        }

        public void ShuldBeActivatedPowerSaveMode()
        {
            if(TurnOnHour.Hour>=3)
                SwitchPowerSaveMode();
        }
    }
}