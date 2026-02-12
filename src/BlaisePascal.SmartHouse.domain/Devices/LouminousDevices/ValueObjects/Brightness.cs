using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects
{
    public record Brightness
    {
        public int Value { get; }

        public Brightness(int value)
        {
            Value = Math.Clamp(value, 1, 10);
        }
    }
}
