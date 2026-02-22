using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands
{
    public class CheckAndActivateAutoPowerSaveCommand
    {
        private readonly ILampRepository _lampRepository;

        public CheckAndActivateAutoPowerSaveCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetLampById(lampId);
            if (lamp != null && lamp is EcoLamp ecoLamp)
            {
                ecoLamp.ShouldBeActivatedPowerSaveMode();
                _lampRepository.UpdateLamp(ecoLamp);
            }
        }
    }
}