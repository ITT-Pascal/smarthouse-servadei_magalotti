using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Records
{
    public record CctvPassword
    {
        public string Value { get; }

        public CctvPassword(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be empty or whitespace.");

            if (value.Length < 4)
                throw new ArgumentException("Password must be at least 4 characters long.");

            Value = value;
        }

        public bool Match(string candidate)
        {
            return Value == candidate;
        }
    }
}
