using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetLampsCreatedAfterQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampsCreatedAfterQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<LampModel> Execute(DateTime date)
        {
            var lamps = _lampRepository.GetAllLamps();
            return lamps.Where(l => l.CreatedAtUtc > date).ToList();
        }
    }
}