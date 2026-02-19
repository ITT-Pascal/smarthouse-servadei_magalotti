using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetLampsByStatusQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampsByStatusQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<LampModel> Execute(bool isOn)
        {
            var lamps = _lampRepository.GetAllLamps();
            var targetStatus = isOn ? DeviceStatus.On : DeviceStatus.Off;
            return lamps.Where(l => l.Status == targetStatus).ToList();
        }
    }
}