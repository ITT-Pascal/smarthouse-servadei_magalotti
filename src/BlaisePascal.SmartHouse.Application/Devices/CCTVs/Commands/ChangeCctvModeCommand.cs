using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Commands
{
    public class ChangeCctvModeCommand
    {
        private readonly ICctvRepository _cctvRepository;

        public ChangeCctvModeCommand(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId, CctvMode newMode)
        {
            var cctv = _cctvRepository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.SetMode(newMode);
                _cctvRepository.Update(cctv);
            }
        }
    }
}