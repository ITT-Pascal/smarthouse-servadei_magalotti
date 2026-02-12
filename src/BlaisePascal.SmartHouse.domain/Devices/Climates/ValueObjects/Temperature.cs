using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }

        public Temperature(double value)
        {
            if (value < -50 || value > 60)
                throw new ArgumentOutOfRangeException(nameof(value), "Temperature must be between -50°C and 60°C.");

            Value = value;
        }

        public static Temperature FromCelsius(double value) => new Temperature(value);

        public Temperature Add(double amount) => new Temperature(Value + amount);

        public Temperature Subtract(double amount) => new Temperature(Value - amount);
    }
}
