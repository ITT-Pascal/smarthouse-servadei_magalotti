using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetLampsByBrightnessRangeQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampsByBrightnessRangeQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<AbstractLamp> Execute(int minBrightness, int maxBrightness)
        {
            var lamps = _lampRepository.GetAllLamps();
            return lamps.Where(l => l.CurrentBrightness.Value >= minBrightness && l.CurrentBrightness.Value <= maxBrightness).ToList();
        }
    }
}
