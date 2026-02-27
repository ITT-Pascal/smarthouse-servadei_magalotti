using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository
{
    public interface IDoorRepository
    {

        void Add(Door door);
        void Update(Door door);
        void Remove(Guid id);
        Door GetById(Guid id);
        List<Door> GetAll();
       
    }
}
