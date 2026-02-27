
using BlaisePascal.SmartHouse.Application.Devices.Doors.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Doors.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Queries
{
    public class GetAllDoorsQuery
    {
        private readonly IDoorRepository _doorRepository;

        public GetAllDoorsQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public List<DoorDto> Execute()
        {
            List<DoorDto> doors = new List<DoorDto>();
            //return doors.Select(cctv => DoorMapper.ToDto(doors)).ToList();
            foreach(Door door in _doorRepository.GetAll())
            {
                doors.Add(DoorMapper.ToDto(door));
            }
            return doors;
        }
    }
}
