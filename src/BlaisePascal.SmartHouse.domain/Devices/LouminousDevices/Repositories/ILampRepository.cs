using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(Lamp lamp);
        void UpdateLamp(Lamp lamp);
        void DeleteLamp(Guid id);
        Lamp GetLampById(Guid id);
        List<Lamp> GetAllLamps();
    }
}
