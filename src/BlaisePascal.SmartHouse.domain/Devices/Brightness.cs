using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices
{
    public record Brightness
    {
        public int Value { get; }// current min max parametri

        public const int MinBrightness = 1;
        public int MaxBrightness = 10;
        public Brigthness(int value)
        {
            Value = Math.Clamp(value, MinBrightness, MaxBrightness);
        }
    }
}
