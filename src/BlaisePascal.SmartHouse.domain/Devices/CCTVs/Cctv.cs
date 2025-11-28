using SmartHouse.domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class Cctv: AbstractDevice
    {
        public CctvStatus CctvStatus { get; private set; }

        public Cctv(string name): base(name){}
        public Cctv(string name, Guid id, bool isOn) : base(name, id, isOn) { }
        public Cctv() : base() { }

        public void SetCctvStatus (CctvStatus status)
        {
            if (Status == DeviceStatus.On)
            {
                CctvStatus = status;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            throw new InvalidOperationException("Cannot set CCTV status when the air conditioner is not on.");
        }
    }
}
