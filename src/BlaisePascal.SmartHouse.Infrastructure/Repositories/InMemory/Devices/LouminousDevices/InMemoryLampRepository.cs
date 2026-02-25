using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LouminousDevices
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp>? _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>();
            {
                new Lamp(new string("CrazyLamp"));
                new Lamp(new string("PulgaLamp"));
            }
        }

        public void AddLamp(AbstractLamp lamp)
        {
            throw new NotImplementedException();
        }

        public void DeleteLamp(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<AbstractLamp> GetAllLamps()
        {
            throw new NotImplementedException();
        }

        public AbstractLamp GetLampById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLamp(AbstractLamp lamp)
        {
            throw new NotImplementedException();
        }
    }
}
