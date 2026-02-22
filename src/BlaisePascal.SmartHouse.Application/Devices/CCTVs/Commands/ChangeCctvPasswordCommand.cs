using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Commands
{
    public class ChangeCctvPasswordCommand
    {
        private readonly ICctvRepository _cctvRepository;

        public ChangeCctvPasswordCommand(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(Guid cctvId, string oldPassword, string newPassword)
        {
            var cctv = _cctvRepository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.ChangePassword(oldPassword, newPassword);
                _cctvRepository.Update(cctv);
            }
        }
    }
}