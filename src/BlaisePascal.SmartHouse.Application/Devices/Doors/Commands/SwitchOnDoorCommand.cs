using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class SwitchOnDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public SwitchOnDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }
        public void Execute(Guid id)
        {
            var door = _doorRepository.GetById(id);
            door.TurnOn();
            _doorRepository.Update(door);
        }
    }
}
