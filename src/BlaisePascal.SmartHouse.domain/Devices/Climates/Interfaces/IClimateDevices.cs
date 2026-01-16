using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates.Interfaces
{
    public interface IClimateDevices
    {
        void IncreaseTemperature(double increment);
        void SetTemperature(double temperature);
        void DecreaseTemperature(double decrement);


    }
}
