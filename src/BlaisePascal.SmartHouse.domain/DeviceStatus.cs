using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public enum DeviceStatus
    {
        Unknown = 0,
        On = 1,
        Off = 2,
        Error = 3,
        Standby = 4,
    }
}
