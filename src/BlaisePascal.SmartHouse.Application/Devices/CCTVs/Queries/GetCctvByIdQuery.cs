using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Queries
{
    public class GetCctvByIdQuery
    {
        private readonly ICctvRepository _cctvRepository;

        public GetCctvByIdQuery(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public Cctv Execute(Guid id)
        {
            return _cctvRepository.GetById(id);
        }
    }
}