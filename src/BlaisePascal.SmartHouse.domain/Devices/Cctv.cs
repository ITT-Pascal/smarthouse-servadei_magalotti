using SmartHouse.domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class Cctv
    {
        public bool IsOn { get; private set; }
        public string Name { get; private set; }
        public Guid IdCctv { get; private set; }
        public DeviceStatus Status { get; private set; }
        public CctvStatus CctvStatus { get; private set; }

        public Cctv(string name)
        {
            Name = name;
            IdCctv = Guid.NewGuid();
            IsOn = false;
            Status = DeviceStatus.Unknown;
        }
        public Cctv(string name, Guid idCctv, bool isOn)
        {
            Name = name;
            IdCctv = idCctv;
            IsOn = isOn;
            if (isOn)
                Status = DeviceStatus.On;
            else
                Status = DeviceStatus.Unknown;
        }

        public Cctv() { }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void TurnOn()
        {
            if (IsOn)
            {
                throw new InvalidOperationException("CCTV is already on.");
            }
            IsOn = true;
            Status = DeviceStatus.On;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Status = DeviceStatus.Off;
            }
            throw new InvalidOperationException("CCTV is already off.");

        }

        public void Toggle()
        {
            if (IsOn)
                TurnOff();
            TurnOn();         
        }

        public void SetCctvStatus (CctvStatus status)
        {
            if (Status == DeviceStatus.On)
            {
                CctvStatus = status;
            }
            throw new InvalidOperationException("Cannot set CCTV status when the air conditioner is not on.");
        }
    }
}
