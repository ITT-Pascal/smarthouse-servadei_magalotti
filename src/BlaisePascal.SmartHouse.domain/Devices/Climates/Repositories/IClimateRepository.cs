using BlaisePascal.SmartHouse.Domain.Devices.Climates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Climates.Repository
{
    public interface IClimateRepository
    {
        void Add(ClimateDevice device);
        void Update(ClimateDevice device);
        void Remove(Guid id);
        ClimateDevice GetById(Guid id);
        List<ClimateDevice> GetAll();
    }
}
