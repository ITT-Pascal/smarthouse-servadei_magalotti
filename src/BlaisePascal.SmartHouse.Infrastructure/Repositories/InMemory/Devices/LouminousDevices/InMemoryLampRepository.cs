
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories;
using System;
using System.Collections.Generic;

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
            AbstractLamp? lampToRemove = GetLampById(id);
            if (lampToRemove != null)
            {
                _lamps.Remove(lampToRemove);
            }
        }

        public List<AbstractLamp> GetAllLamps()
        {
            return _lamps;
        }

        public AbstractLamp GetLampById(Guid id)
        {
            foreach (AbstractLamp l in _lamps)
            {
                if (l.Id == id)
                {
                    return l;
                }
            }
            throw new ArgumentException($"Lamp with id {id} not found.");
        }

        public void UpdateLamp(AbstractLamp lamp)
        {
            //!TODO: implementazione per aggiornare la lampada nella lista
            var existingLampIndex = _lamps.FindIndex(l => l.Id == lamp.Id);
            if (existingLampIndex != -1)
            {
                _lamps[existingLampIndex] = lamp;
            }
        }
    }
}