using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repositories
{
    public interface ICctvRepository
    {
        void Add(Cctv cctv);
        void Update(Cctv cctv);
        void Remove(Guid id);
        Cctv GetById(Guid id);
        List<Cctv> GetAll();
    }
}
