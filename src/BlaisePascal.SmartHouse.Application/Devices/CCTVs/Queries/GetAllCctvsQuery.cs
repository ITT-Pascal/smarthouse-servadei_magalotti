using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Queries
{
    public class GetAllCctvsQuery
    {
        private readonly ICctvRepository _cctvRepository;

        public GetAllCctvsQuery(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public List<Cctv> Execute()
        {
            return _cctvRepository.GetAll();
        }
    }
}