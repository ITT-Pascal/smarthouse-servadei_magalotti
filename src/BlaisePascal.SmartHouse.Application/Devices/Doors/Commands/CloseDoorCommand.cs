using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class CloseDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public CloseDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid Id)
        {
            Door door = _doorRepository.GetById(Id);

            door.Close();
        }
    }
}
