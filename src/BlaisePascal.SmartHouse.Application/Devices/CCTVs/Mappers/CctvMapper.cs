using BlaisePascal.SmartHouse.Application.Devices.CCTVs.Abstractions.Mappers;
using BlaisePascal.SmartHouse.Application.Devices.CCTVs.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Abstractions.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Mappers
{
    public static class CctvMapper
    {
        public static CctvDto ToDto(Cctv cctv)
        {
            return new CctvDto
            {
                Id = cctv.Id,
                Name = cctv.Name,
                DeviceStatus = DeviceStatusMapper.ToDto(cctv.Status),
                CurrentMode = CctvModeMapper.ToDto(cctv.CurrentMode),
                Password = cctv.Password.Value,
                IsLocked = cctv.IsLocked,
                CreatedAtUtc = cctv.CreatedAtUtc,
                LastModifiedAtUtc = cctv.LastModifiedAtUtc
            };
        }

        public static Cctv ToDomain(CctvDto dto)
        {
            return new Cctv(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.DeviceStatus),
                CctvModeMapper.ToDomain(dto.CurrentMode),
                dto.Password,
                dto.IsLocked
            );
        }
    }
}
