using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices.LouminousDevices
{
    public interface ITwoLamp
    {
        void SwitchOnOffBothLamps();
        void AlternateStatesLamp();
        bool AreBothOn();
        void ToggleSwitchBoth();
        void IncreaseBrightnessBoth();
        void DecreaseBrightnessBoth();
        void IncreaseOneLampBrightness(LampModel currentLamp);
        void DecreaseOneLampBrightness(Lamp currentLamp);
    }
}
