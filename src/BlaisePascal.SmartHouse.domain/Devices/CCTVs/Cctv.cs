using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVs
{
    public class Cctv: AbstractDevice, ILockable
    {
        //Properties
        public CctvStatus CctvStatus { get; private set; }
        public string Password = "admin";
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
       

        public void Login(string password)
        {
            if (Password == password)
                Unlock();
            Lock();
        }
        public void Lock() { Status = DeviceStatus.Off; }

        public void Unlock()
        {
            Status = DeviceStatus.On;
        }
    }
}
