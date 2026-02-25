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
        private readonly List<AbstractLamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<AbstractLamp>
            {
                new Lamp("CrazyLamp"),
                new Lamp("PulgaLamp")
            };
        }

        public void AddLamp(AbstractLamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));

            _lamps.Add(lamp);
        }

        public void DeleteLamp(Guid id)
        {
            var lampToRemove = GetLampById(id);
            if (lampToRemove != null)
            {
                _lamps.Remove(lampToRemove);
            }
        }

        public List<AbstractLamp> GetAllLamps()
        {
            return _lamps.ToList();
        }

        public AbstractLamp GetLampById(Guid id)
        {
            return _lamps.FirstOrDefault(lamp => lamp.Id == id);
        }

        public void UpdateLamp(AbstractLamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));

            int index = _lamps.FindIndex(l => l.Id == lamp.Id);

            if (index != -1)
            {
                _lamps[index] = lamp;
            }
        }
    }
}
