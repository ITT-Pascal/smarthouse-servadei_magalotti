using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Commands
{
    public class RemoveCctvCommand
    {
        private readonly ICctvRepository _cctvRepository;

        public RemoveCctvCommand(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId)
        {
            _cctvRepository.Remove(cctvId);
        }
    }
}
