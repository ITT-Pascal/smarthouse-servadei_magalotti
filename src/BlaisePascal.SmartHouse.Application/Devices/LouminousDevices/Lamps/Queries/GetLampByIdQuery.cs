using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetLampByIdQuery
    {
        private readonly ILampRepository _lampRepository;


        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public Lamp Execute(Guid id)
        {
            var l = _lampRepository.GetLampById(id);
            return l;

        }
    }
}
