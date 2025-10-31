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

        public bool IsOn
        {
            get => default;
            set
            {
            }
        }

        public bool IsPowerSaveMode
        {
            get => default;
            set
            {
            }
        }

        public void switchOnOff()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}