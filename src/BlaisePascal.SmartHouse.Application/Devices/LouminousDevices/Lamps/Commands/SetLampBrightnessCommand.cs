using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands
{
    public class SetLampBrightnessCommand
    {
        private readonly ILampRepository _lampRepository;

        public SetLampBrightnessCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId, int brightness)
        {
            var lamp = _lampRepository.GetLampById(lampId);
            if (lamp != null)
            {
                lamp.SetBrightness(brightness);
                _lampRepository.UpdateLamp(lamp);
            }
        }
    }
}
