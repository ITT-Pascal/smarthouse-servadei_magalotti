using BlaisePascal.SmartHouse.Application.Devices.Doors.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Doors.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Queries
{
    public class GetDoorByIdQuery
    {
        private readonly IDoorRepository _doorRepository;

        public GetDoorByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public DoorDto Execute(Guid id)
        {
            var door = _doorRepository.GetById(id);
            return DoorMapper.ToDto(door);
        }
    }
}
