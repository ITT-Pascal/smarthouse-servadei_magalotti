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

        public static implicit operator int(Brightness brightness) => brightness?.Value ?? 0;
        public static implicit operator Brightness(int value) => new Brightness(value);

        //OPERATORI DI CONFRONTO (Brightness vs Brightness)
        public static bool operator >(Brightness a, Brightness b) => a.Value > b.Value;
        public static bool operator <(Brightness a, Brightness b) => a.Value < b.Value;
        public static bool operator >=(Brightness a, Brightness b) => a.Value >= b.Value;
        public static bool operator <=(Brightness a, Brightness b) => a.Value <= b.Value;

        //OPERATORI DI CONFRONTO (Brightness vs int)
        public static bool operator >(Brightness a, int b) => a.Value > b;
        public static bool operator <(Brightness a, int b) => a.Value < b;
        public static bool operator >=(Brightness a, int b) => a.Value >= b;
        public static bool operator <=(Brightness a, int b) => a.Value <= b;

        //OPERATORI DI CONFRONTO (int vs Brightness)
        public static bool operator >(int a, Brightness b) => a > b.Value;
        public static bool operator <(int a, Brightness b) => a < b.Value;
        public static bool operator >=(int a, Brightness b) => a >= b.Value;
        public static bool operator <=(int a, Brightness b) => a <= b.Value;
    }
}
