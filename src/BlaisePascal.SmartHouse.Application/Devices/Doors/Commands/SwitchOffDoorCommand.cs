using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class SwitchOffDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public SwitchOffDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id)
        {
            var door = _doorRepository.GetById(id);
            door.TurnOff();
            _doorRepository.Update(door);
        }
    }
}
