using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class TwoLampDevice
    {
        //Properties
        public LampModel lamp1 { get; private set; }
        public LampModel lamp2 { get; private set; }
        public bool AreBothLampsOn  => AreBothOn();
        //Constructor
        public TwoLampDevice()
        {
            lamp1 = new LampModel("LampadaNormale", false);
            lamp2 = new LampModel("LampadaEco", true);
        }
        //Methods
        public void SwitchOnOffBothLamps()
        {
            lamp1.SwitchOnOff();
            lamp2.SwitchOnOff();
        }
        public void AlternateStatesLamp()
        {
            if (lamp1.IsOn == true )
            {
                if (lamp2.IsOn == true)
                {
                    lamp2.SwitchOnOff();
                }
            }
            else
            {
                if (lamp2.IsOn == false)
                {
                    lamp2.SwitchOnOff();
                }        
            }
        }
        public bool AreBothOn()
        {
            if (lamp1.IsOn == true && lamp2.IsOn == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
        public void SwitchBothOn()
        {
            if ( AreBothLampsOn == true)
            {
                if (lamp1.IsOn == true)
                {
                    lamp1.SwitchOnOff();
                }

                if (lamp2.IsOn == true)
                {
                    lamp2.SwitchOnOff();
                }
            }
            else
            {
                if (lamp1.IsOn == false)
                {
                    lamp1.SwitchOnOff();
                }
                if (lamp2.IsOn == false)
                {
                    lamp2.SwitchOnOff();
                }
            }
        }
        public void IncreaseBrightnessBoth()
        {
            lamp1.increaseBrightness();
            lamp2.increaseBrightness();
        }
        public void DecreaseBrightnessBoth()
        {
            lamp1.decreaseBrightness();
            lamp2.decreaseBrightness();
        }

        public void IncreaseOneLampBrightness(Lamp currentLamp )
        {
            currentLamp.increaseBrightness();
        }

        public void DecreaseOneLampBrightness(Lamp currentLamp)
        {
            currentLamp.decreaseBrightness();
        }
    }
}
