using SmartHouse.domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class Door: AbstractDevice
    {
        public bool IsOpen { get; private set; }
        public bool IsLocked { get; private set; }

        public Door(string name): base(name) { }
        public Door(string name, Guid id, bool isOn) : base(name, id, isOn) 
        {
            IsOpen = false;
            IsLocked = false;
        }
        public Door() : base() { }

        public void Open()
        {
            if (Status == DeviceStatus.On && !IsLocked)
            {
                IsOpen = true;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            throw new InvalidOperationException("Cannot act on a door that is not on and unlocked.");

        }
        public void Close()
        {
            if (Status == DeviceStatus.On && !IsLocked)
            {
                IsOpen = false;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            throw new InvalidOperationException("Cannot act on a door that is not on and unlocked.");
        }

        public void Lock()
        {
            if (!IsOpen && IsOn)
            {
                throw new InvalidOperationException("Cannot lock a door that is not closed and on.");
            }
            IsLocked = true;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void Unlock()
        {
            if (!IsOpen && IsOn) 
            {
                IsLocked = false;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            throw new InvalidOperationException("Cannot unlock a door that is not closed and on.");

        }

        public void SwitchOpenClose()
        {
            if (IsOpen)
            {
                Close();
               
            }
            else
            {
                Open();
            }
        }

        public void SwitchLockUnlock()
        {
            if (IsLocked)
            {
                Unlock();

            }
            else
            {
                Lock();
            }
        }
    }
}
