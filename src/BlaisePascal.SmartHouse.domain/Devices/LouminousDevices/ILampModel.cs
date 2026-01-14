using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices.LouminousDevices
{
    public interface ILampModel : IDevice
    {
        void TurnOn();
        void TurnOff();
        void Toggle();
        void increaseBrightness();
        void decreaseBrightness();
        string GetName();
        Guid GetId();
    }
}
