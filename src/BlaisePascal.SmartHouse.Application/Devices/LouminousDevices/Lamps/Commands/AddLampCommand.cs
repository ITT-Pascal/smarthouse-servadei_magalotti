using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands
{
    public class AddLampCommand
    {
        private ILampRepository _lampRepository;

        public AddLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(string lampName)
        {

            _lampRepository.AddLamp(new Lamp(new Device(name));
        }





    }
}
