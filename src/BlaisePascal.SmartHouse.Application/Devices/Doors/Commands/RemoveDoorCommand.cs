using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class RemoveDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public RemoveDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            _doorRepository.Remove(doorId);
        }
    }
}
