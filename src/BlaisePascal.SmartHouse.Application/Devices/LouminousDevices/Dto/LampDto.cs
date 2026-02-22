using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Dto
{
    public record LampDto
    {
        public Guid Id { get; init; }
        public string ?Name { get; init; }
        public string ?DeviceStatus { get; init; }
        public int Brightness { get; init; }
        public DateTime CreatedAtUtc { get; init; }
        public DateTime LastModifiedAtUtc { get; init; }
    }
}
