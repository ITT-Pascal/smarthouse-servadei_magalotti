using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Dto
{
    public class LampDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public int Brightness { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }
    }
}
