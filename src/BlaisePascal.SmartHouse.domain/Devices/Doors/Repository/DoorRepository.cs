using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Doors.DoorRepository
{
    public interface DoorRepository
    {
        void AddDoor(Door door);
        void UpdateDoor(Door door);
        void DeleteDoor(Guid id);
        Door GetDoorById(Guid id);
        List<Door> GetAllDoors();
    }
}
