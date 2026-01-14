using SmartHouse.domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class Door: AbstractDevice , IDevice
    {
        //Properties
        public bool IsOpen { get; private set; }
        public bool IsLocked { get; private set; }
        //Constructors
        public Door(string name): base(name) 
        {
            IsOpen = false;
            IsLocked = false;
            CreatedAtUtc = DateTime.UtcNow;
        }
        public Door(string name, Guid id, bool isOn) : base(name, id) 
        {
            IsOpen = false;
            IsLocked = false;
            CreatedAtUtc = DateTime.UtcNow;
        }
        public Door() : base() 
        {
            IsOpen = false;
            IsLocked = false;
            CreatedAtUtc = DateTime.UtcNow;
        }
        //Methods
        public void Open()
        {
            if (Status == DeviceStatus.On && !IsLocked)
            {
                IsOpen = true;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
                throw new InvalidOperationException("Cannot act on a door that is not on and unlocked.");
        }
        public void Close()
        {
            if (Status == DeviceStatus.On && !IsLocked)
            {
                IsOpen = false;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else
                throw new InvalidOperationException("Cannot act on a door that is not on and unlocked.");
        }

        public void Lock()
        {
            if (IsOpen || !IsOn)
            {
                throw new InvalidOperationException("Cannot lock a door that is not closed or on.");
            }
            else
            {
                IsLocked = true;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
        public void Unlock()
        {
            if (IsOpen || !IsOn)
            {
                throw new InvalidOperationException("Cannot unlock a door that is not closed or on.");

            }
            else
            {
                IsLocked = false;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
        }
        public void SwitchOpenClose()
        {
            if (IsOpen)
                Close();
            else
                Open();      
        }
        public void SwitchLockUnlock()
        {
            if (IsLocked==true)
                Unlock();
            else
                Lock();   
        }
    }
}
