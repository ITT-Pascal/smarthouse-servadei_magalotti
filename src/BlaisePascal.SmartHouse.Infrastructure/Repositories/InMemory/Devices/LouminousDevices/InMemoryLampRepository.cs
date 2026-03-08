
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
                new Lamp("PestoLamp"),
                new Lamp("PeloLamp")
            };
        }

        public void AddLamp(AbstractLamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));

            _lamps.Add(lamp);
        }

        public void RemoveLamp(Guid id)
        {
            try
            {
                AbstractLamp? lampToRemove = GetLampById(id);
                if (lampToRemove != null)
                {
                    _lamps.Remove(lampToRemove);
                }
            }
            catch (ArgumentException)
            {
 
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

        public AbstractLamp GetLampByName(Name name)
        {
            foreach (AbstractLamp l in _lamps)
            {
                if (l.Name.ToString().ToLower() == name.ToString().ToLower())
                {
                    return l;
                }
            }
            throw new ArgumentException($"Lamp with name '{name}' not found.");
        }

        public void UpdateLamp(AbstractLamp lamp)
        {
            if (lamp == null) return;

            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Id == lamp.Id)
                {
                    _lamps[i] = lamp;
                    return; 
                }
            }
        }
    }
}