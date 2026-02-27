using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Dto
{
    public record DoorDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? DeviceStatus { get; init; }
        public string? CurrentMode { get; init; }
        public string? Password { get; init; }
        public bool IsLocked { get; init; }
        public DateTime CreatedAtUtc { get; init; }
        public DateTime LastModifiedAtUtc { get; init; }
    }
}
