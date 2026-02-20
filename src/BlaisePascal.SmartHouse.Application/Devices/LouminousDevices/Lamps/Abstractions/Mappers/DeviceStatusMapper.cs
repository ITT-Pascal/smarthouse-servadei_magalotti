using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Abstractions.Mappers
{
    public static class DeviceStatusMapper
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                DeviceStatus.Standby => "STANDBY",
                DeviceStatus.Error => "ERROR",
                _ => "UNKNOWN"
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                "STANDBY" => DeviceStatus.Standby,
                "ERROR" => DeviceStatus.Error,
                _ => DeviceStatus.Unknown
            };
        }
    }
}
