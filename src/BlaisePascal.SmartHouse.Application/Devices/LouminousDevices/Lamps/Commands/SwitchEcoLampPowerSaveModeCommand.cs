using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Commands
{
    public class SwitchEcoLampPowerSaveModeCommand
    {
        private readonly ILampRepository _lampRepository;

        public SwitchEcoLampPowerSaveModeCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetLampById(lampId);
            if (lamp != null && lamp is EcoLamp ecoLamp)
            {
                ecoLamp.SwitchPowerSaveMode();
                _lampRepository.UpdateLamp(ecoLamp);
            }
            else
            {
                throw new InvalidOperationException("Lamp not found or not an EcoLamp.");
            }
        }
    }
}