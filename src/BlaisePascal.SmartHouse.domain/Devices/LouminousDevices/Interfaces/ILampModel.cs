using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Interfaces
{
    public interface ILampModel : IDevice
    {
        void increaseBrightness();
        void decreaseBrightness();
        string GetName();
    }
}
