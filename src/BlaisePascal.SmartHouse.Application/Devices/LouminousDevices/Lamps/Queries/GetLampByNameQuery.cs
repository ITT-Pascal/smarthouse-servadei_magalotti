using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetLampByNameQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampByNameQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<LampModel> Execute(string name)
        {
            var lamps = _lampRepository.GetAllLamps();
            return lamps.Where(l => l.Name == name).ToList();
        }
    }
}