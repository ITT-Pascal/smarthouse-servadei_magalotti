using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository
{
    public interface ClimateRepository
    {
        void AddClimate(ClimateDevices climate);
        void UpdateClimate(ClimateDevices climate);
        void DeleteClimate(Guid id);
        ClimateDevices GetClimateById(Guid id);
        List<ClimateDevices> GetAllClimates();
    }
}
