using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetEcoLampPowerSaveModeStatusQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetEcoLampPowerSaveModeStatusQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public bool Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetLampById(lampId);
            if (lamp != null && lamp is EcoLamp ecoLamp)
            {
                return ecoLamp.IsPowerSaveMode;
            }
            throw new InvalidOperationException("Lamp not found or not an EcoLamp.");
        }
    }
}