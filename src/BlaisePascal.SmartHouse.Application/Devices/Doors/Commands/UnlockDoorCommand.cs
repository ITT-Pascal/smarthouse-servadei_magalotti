using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class UnlockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public UnlockDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId, string password, Door door)
        {
            var doorVar = _doorRepository.GetById(doorId);
            if (door != null)
            {
                door.Unlock(password);
                _doorRepository.Update(door);
            }
        }
    }
}

