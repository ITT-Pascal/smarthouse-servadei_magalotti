using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Commands
{
    public class SwitchOnCctvCommand
    {
        private readonly ICctvRepository _cctvRepository;

        public SwitchOnCctvCommand(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId)
        {
            var cctv = _cctvRepository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.TurnOn();
                _cctvRepository.Update(cctv);
            }
        }
    }
}