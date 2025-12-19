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
        //Properties
        public CctvStatus CctvStatus { get; private set; }
        //Constructors
        public Cctv(string name): base(name){}
        public Cctv(string name, Guid id, bool isOn) : base(name, id) { }
        public Cctv() : base() { }
        //Methods
        public void SetCctvStatus (CctvStatus status)
        {
            if (Status == DeviceStatus.On)
            {
                CctvStatus = status;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
                throw new InvalidOperationException("Cannot set CCTV status when the device is not on.");
        }
    }
}
