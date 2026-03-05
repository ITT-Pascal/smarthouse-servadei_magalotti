using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(AbstractLamp lamp);
        void UpdateLamp(AbstractLamp lamp);
        void DeleteLamp(Guid id);
        AbstractLamp GetLampById(Guid id);
        List<AbstractLamp> GetAllLamps();
    }
}
