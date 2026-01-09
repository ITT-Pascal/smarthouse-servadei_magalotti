using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices.LouminousDevices
{
    public interface IEcoLamp
    {
        void TurnOn();
        void TurnOff();
        void Toggle();
        void Rename(string newName);
        void increaseBrightness();
        void decreaseBrightness();
        void SwitchPowerSaveMode();
        void ShuldBeActivatedPowerSaveMode();
    }
}
