using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetMinBrightnessLampQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetMinBrightnessLampQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public LampModel Execute()
        {
            var lamps = _lampRepository.GetAllLamps();
            if (!lamps.Any()) return null;

            return lamps.OrderBy(l => l.CurrentBrightness.Value).First();
        }
    }
}