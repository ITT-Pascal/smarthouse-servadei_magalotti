using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices.Climates
{
    public interface IClimateDevices
    {
        void IncreaseTemperature(double increment);
        void SetTemperature(double temperature);
        void DecreaseTemperature(double decrement);


    }
}
