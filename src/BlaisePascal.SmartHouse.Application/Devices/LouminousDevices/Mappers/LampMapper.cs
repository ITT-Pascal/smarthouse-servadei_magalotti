using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Abstractions.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Mappers
{
    public static class LampMapper
    {
        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name,
                DeviceStatus = DeviceStatusMapper.ToDto(lamp.Status),
                Brightness = lamp.CurrentBrightness.Value,
                CreatedAtUtc = lamp.CreatedAtUtc,
                LastModifiedAtUtc = lamp.LastModifiedAtUtc
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.DeviceStatus),
                new Brightness(dto.Brightness),
                dto.CreatedAtUtc,
                dto.LastModifiedAtUtc);
        }
    }
}
