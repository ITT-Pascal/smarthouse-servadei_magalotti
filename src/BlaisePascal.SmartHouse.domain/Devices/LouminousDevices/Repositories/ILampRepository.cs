using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Repositories
{
    public interface ILampRepository
    {
        void AddLamp(LampModel lamp);
        void UpdateLamp(LampModel lamp);
        void DeleteLamp(Guid id);
        LampModel GetLampById(Guid id);
        List<LampModel> GetAllLamps();
    }
}
