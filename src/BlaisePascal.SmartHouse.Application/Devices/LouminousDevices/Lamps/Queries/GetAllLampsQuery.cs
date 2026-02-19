using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetAllLampsQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<LampModel> Execute()
        {
            return _lampRepository.GetAllLamps();
        }
    }
}