using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(AbstractLamp lamp);
        void UpdateLamp(AbstractLamp lamp);
        void RemoveLamp(Guid id);
        List<AbstractLamp> GetAllLamps();
        AbstractLamp GetLampById(Guid id);
        AbstractLamp GetLampByName(Name name);
    }
}
