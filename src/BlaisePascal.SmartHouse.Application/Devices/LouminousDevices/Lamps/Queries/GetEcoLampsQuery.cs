using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetEcoLampsQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetEcoLampsQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<LampModel> Execute()
        {
            var lamps = _lampRepository.GetAllLamps();
            return lamps.Where(l => l.IsEco).ToList();
        }
    }
}