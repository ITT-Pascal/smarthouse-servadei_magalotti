using System;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;

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
            // Ora GetLampById restituisce un AbstractLamp
            var lamp = _lampRepository.GetLampById(lampId);

            // Possiamo verificare in sicurezza se l'astrazione è in realtà una EcoLamp
            if (lamp != null && lamp is EcoLamp ecoLamp)
            {
                ecoLamp.ShouldBeActivatedPowerSaveMode();
                _lampRepository.UpdateLamp(ecoLamp);
            }
        }
    }
}