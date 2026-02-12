using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates
{
    public enum AirConditionerMode
    {
        Auto = 0,
        Cooling = 1,
        Heating = 2,
        Dry = 3,
        FanOnly = 4,
        Dehumidify = 5
    }
}
