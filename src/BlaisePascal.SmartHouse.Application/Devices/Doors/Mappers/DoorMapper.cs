using BlaisePascal.SmartHouse.Application.Devices.Doors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Mappers
{
    public static class DoorMapper
    {
        public static DoorDto ToDto(DoorDto door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name,
                Password = door.Password,
                IsLocked = door.IsLocked,
                CreatedAtUtc = door.CreatedAtUtc,
                LastModifiedAtUtc = door.LastModifiedAtUtc,

            };
        }


    }
}
