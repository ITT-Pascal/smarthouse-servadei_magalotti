using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Mappers;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LouminousDevices.Lamps.Queries
{
    public class GetLampBrightnessQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampBrightnessQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public LampDto Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetLampById(lampId);

            if (lamp == null)
            {
                throw new ArgumentException("Lamp not found");
            }

            return LampMapper.ToDto(lamp);
        }
    }
}