using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class OpenDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public OpenDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }
        public void Execute(Guid id)
        {
            var door = _doorRepository.GetById(id);
            door.Open();
            _doorRepository.Update(door);
        }
    }
}
