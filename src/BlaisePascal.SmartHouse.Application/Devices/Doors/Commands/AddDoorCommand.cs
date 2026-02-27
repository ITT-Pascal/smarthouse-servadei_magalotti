using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Doors.Commands
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public AddDoorCommand(Door doorRepository)
        {
            _doorRepository = (IDoorRepository?)doorRepository;
        }

        public void Execute(string name, string password)
        {
            var door = new Door(name, password);
            _doorRepository.Add(door);
        }
    }
}

