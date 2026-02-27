using BlaisePascal.SmartHouse.Application.Devices.Doors.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Mappers
{
    public static class DoorMapper
    {
        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name,
                IsLocked = door.IsLocked,
                CreatedAtUtc = door.CreatedAtUtc,
                LastModifiedAtUtc = door.LastModifiedAtUtc,

            };
        }


    }
}
