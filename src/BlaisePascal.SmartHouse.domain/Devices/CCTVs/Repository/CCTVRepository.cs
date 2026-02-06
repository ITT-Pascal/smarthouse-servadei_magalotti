using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Repository
{
    public interface CCTVRepository
    {
        void AddCCTV(Cctv cctv);
        void UpdateCCTV(Cctv cctv);
        void DeleteCCTV(Guid id);
        Cctv GetCCTVById(Guid id);
        List<Cctv> GetAllCCTVs();
    }
}
