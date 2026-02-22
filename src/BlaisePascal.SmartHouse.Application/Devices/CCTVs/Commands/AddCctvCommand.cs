using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Commands
{
    public class AddCctvCommand
    {
        private readonly ICctvRepository _cctvRepository;

        public AddCctvCommand(ICctvRepository cctvRepository)
        {
            _cctvRepository = cctvRepository;
        }

        public void Execute(string name, string password)
        {
            var cctv = new Cctv(name, password);
            _cctvRepository.Add(cctv);
        }
    }
}