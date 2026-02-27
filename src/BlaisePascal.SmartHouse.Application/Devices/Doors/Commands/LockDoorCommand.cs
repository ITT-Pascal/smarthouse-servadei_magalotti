using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class LockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public LockDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            var door  = _doorRepository.GetById(doorId);
            if (door != null)
            {
                door.Lock();
                _doorRepository.Update(door);
            }
        }
    }
}
