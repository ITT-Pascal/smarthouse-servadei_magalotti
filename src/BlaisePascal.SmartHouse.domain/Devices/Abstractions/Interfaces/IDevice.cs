using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces
{
    public interface IDevice
    {
        void Rename(string newName);
        void TurnOn();
        void TurnOff();
        void Toggle();
    }
}
