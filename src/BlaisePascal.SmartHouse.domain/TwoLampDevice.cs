using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class TwoLampDevice
    {
        public Lamp lamp1 { get; private set; }
        public Lamp lamp2 { get; private set; }
        public bool AreBothLampsOn { get; private set; }    
        public TwoLampDevice()
        {
            lamp1 = new Lamp();
            lamp2 = new Lamp();
        }
        public void SwitchOnOffBothLamps()
        {
            lamp1.switchOnOff();
            lamp2.switchOnOff();
        }
        public void AlternateStatesLamp()
        {
            if (lamp1.IsOn != false)
            {
                lamp1.switchOnOff();
            }
            else
            {
                lamp2.switchOnOff();


            }
        }
        public bool AreBothOn()
        {
            if (lamp1.IsOn == true && lamp2.IsOn == true)
            { 
                AreBothLampsOn = true;

            }
            else
            {
                AreBothLampsOn = false;
            }
                return AreBothLampsOn;  

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
    }
}
