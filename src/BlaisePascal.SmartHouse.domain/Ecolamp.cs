using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse.domain
{
    public class Ecolamp
    {
        public int maxBrightness { get; private set; } = 10;

        private const int MIN_BRIGHTNESS = 1;

        public bool IsOn { get; private set; }
        public int Brightness { get; set; }
        public DateTime TurnOnHours { get; private set; }  
        public bool IsPowerSaveMode { get; private set; }

        
        

        public Ecolamp()
        {
            IsOn = false;
            IsPowerSaveMode = false;
            Brightness = maxBrightness ; 
        }   

        public void switchOnOff()
        {
            if (IsOn)
                IsOn = false;
            else
                IsOn = true;
                TurnOnHours = DateTime.UtcNow;


        }

        public void increaseBrightness()
        {
            if (IsOn == true)
                if (Brightness +1 >= maxBrightness)
                {
                    Brightness = maxBrightness;
                }
                else
                {
                    Brightness += 1;
                }

        }

        public void decreaseBrightness()
        {
            if (IsOn == true)
                if (Brightness -1 <= MIN_BRIGHTNESS)
                {
                    Brightness = MIN_BRIGHTNESS;
                }
                else
                {
                    Brightness -= 1;
                }


        }
    

        public void SwitchPowerSaveMode()
        {
            if(IsPowerSaveMode == false)
            {
                maxBrightness = 5;
                IsPowerSaveMode = true;

                if (Brightness > maxBrightness)
                {

                    Brightness = maxBrightness;
                }
            }
            else
            {
                maxBrightness = 10;
                IsPowerSaveMode = false;

                
            }
            
            
        }

        public void ShuldBeActivatedPowerSaveMode()
        {
            if (DateTime.UtcNow - TurnOnHours >= TimeSpan.FromMinutes(180))
            {


                if (IsPowerSaveMode == false)
                {
                    SwitchPowerSaveMode();
                }
            }
        }
   
   
    }
}