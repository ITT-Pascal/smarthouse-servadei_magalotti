using SmartHouse.domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class TwoLampDevice: LampModel, ITwoLamp
    {
        //Properties
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }
        public LampModel lamp1 { get; private set; }
        public LampModel lamp2 { get; private set; }
        public bool AreBothLampsOn  => AreBothOn();
        //Constructor
        public TwoLampDevice()
        {
            // Default sensato per i test: si possono comunque passare tipi diversi con l'overload sotto
            lamp1 = new Lamp("LampadaNormale");
            lamp2 = new EcoLamp("LampadaEco");
            CreatedAtUtc = DateTime.UtcNow;
        }
        //Methods
        public void SwitchOnOffBothLamps()
        {
            lamp1.Toggle();
            lamp2.Toggle();
        }
        public void AlternateStatesLamp()
        {
            if (lamp1.IsOn == true)
                if (lamp2.IsOn == true)
                    lamp2.Toggle();
                else
                if (lamp2.IsOn == false)
                    lamp2.Toggle();
        }
        public bool AreBothOn()
        {
            if (lamp1.IsOn == true && lamp2.IsOn == true)
                return true;
            else
                return false;    
        }        
        public void ToggleSwitchBoth()
        {
            if ( AreBothLampsOn == true)
                 if (lamp1.IsOn == true)
                     lamp1.Toggle();
                 if (lamp2.IsOn == true)
                     lamp2.Toggle();
            else
                if (lamp1.IsOn == false)
                    lamp1.Toggle();
                if (lamp2.IsOn == false)
                    lamp2.Toggle();
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
        public void IncreaseOneLampBrightness(LampModel currentLamp)
        {
            currentLamp.increaseBrightness();
        }
        public void DecreaseOneLampBrightness(Lamp currentLamp)
        {
            currentLamp.decreaseBrightness();
        }
    }
}
