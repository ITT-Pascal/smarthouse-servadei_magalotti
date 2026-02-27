using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class ChangeCodeDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public ChangeCodeDoorCommand(Door doorRepository)
        {
            _doorRepository = (IDoorRepository)doorRepository;
        }
        public void Execute(string oldCode, string newCode, Guid id)
        {
            Door door = _doorRepository.GetById(id);
            
            door.ChangeCode(oldCode, newCode);
        }
    }
}
