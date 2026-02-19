using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands
{
    public class IncreaseLampBrightnessCommand
    {
        private readonly ILampRepository _lampRepository;

        public IncreaseLampBrightnessCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetLampById(lampId);
            if (lamp != null)
            {
                lamp.IncreaseBrightness();
                _lampRepository.UpdateLamp(lamp);
            }
        }
    }
}