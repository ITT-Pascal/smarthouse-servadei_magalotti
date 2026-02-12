using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Doors.ValueObjects
{
    public record DoorCode
    {
        public string Value { get; }

        public DoorCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Door code cannot be empty.");

            if (value.Length < 4 || value.Length > 8)
                throw new ArgumentException("Door code must contain between 4 and 8 digits.");

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    throw new ArgumentException("Door code must contain only numeric digits.");
                }
            }

            Value = value;
        }

        public bool Match(string candidate)
        {
            return Value == candidate;
        }
    }
}
