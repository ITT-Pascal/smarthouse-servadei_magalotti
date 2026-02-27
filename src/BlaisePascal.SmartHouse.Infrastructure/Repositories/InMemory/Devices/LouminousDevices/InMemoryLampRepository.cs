
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
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>
            {
                new Lamp("CrazyLamp"),
                new Lamp("PulgaLamp")
            };
        }

        public void AddLamp(Lamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));

            _lamps.Add(lamp);
        }

        public void DeleteLamp(Guid id)
        {
            Lamp? lampToRemove = GetLampById(id);
            if (lampToRemove != null)
            {
                _lamps.Remove(lampToRemove);
            }
        }

        public List<Lamp> GetAllLamps()
        {
            return _lamps.ToList();
        }

        public Lamp GetLampById(Guid id)
        {
            foreach (Lamp l in _lamps)
            {
                if (l.Id == id)
                {
                    return l;
                }
            }
            throw new ArgumentException($"Lamp with id {id} not found.");
        }

        public void UpdateLamp(Lamp lamp)
        {
            //!TODO
        }
    }
}
