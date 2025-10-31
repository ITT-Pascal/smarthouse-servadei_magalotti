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

        public DateTime Hour { get; private set; }  

        public bool IsPowerSaveMode { get; private set; }

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
                Hour = DateTime.Now;


        }

        public void increaseBrightness()
        {
            throw new System.NotImplementedException();
        }

        public void decreaseBrightness()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchPowerSaveMode()
        {
            maxBrightness = 5;
            IsPowerSaveMode =true;
            
           
        }

        public void ShuldBeActivatedPowerSaveMode()
        {
            if(Hour.Hour>=3)
                SwitchPowerSaveMode();
        }
    }
}