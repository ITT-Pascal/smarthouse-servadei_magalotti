using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands
{
    public class RenameLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public RenameLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId, string newName)
        {
            var lamp = _lampRepository.GetLampById(lampId);
            if (lamp != null)
            {
                lamp.Rename(newName);
                _lampRepository.UpdateLamp(lamp);
            }
        }
    }
}