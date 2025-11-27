using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class Door
    {
        public bool IsOn { get; private set; }
        public bool IsOpen { get; private set; }
        public string Name { get; private set; }
        public bool IsLocked { get; private set; }
        public Guid IdDoor { get; private set; }
        public DeviceStatus Status { get; private set; }
        public Door(string name)
        {
            Name = name;
            IdDoor = Guid.NewGuid();
            IsOn = false;
            IsOpen = false;
            IsLocked = false;
            Status = DeviceStatus.Unknown;
        }
         public Door(string name, Guid idDoor, bool isOn, bool isOpen, bool isLocked)
        {
            Name = name;
            IdDoor = idDoor;
            IsOn = isOn;         
            IsOpen = isOpen;
            IsLocked = isLocked;
            if (isOn)
                Status = DeviceStatus.On;
            else
                Status = DeviceStatus.Unknown;
        }

        public Door() {}

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void TurnOn()
        {
            IsOn = true;
            Status = DeviceStatus.On;
        }

        public void TurnOff()
        {
            IsOn = false;
            Status = DeviceStatus.Off;
        }

        public void Open()
        {
            if (Status == DeviceStatus.On && !IsLocked)
            {
                IsOpen = true;
            }
            throw new InvalidOperationException("Cannot act on a door that is not on and unlocked.");

        }
        public void Close()
        {
            if (Status == DeviceStatus.On && !IsLocked)
            {
                IsOpen = false;
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
        }

        public void Unlock()
        {
            if (!IsOpen && IsOn) 
            {
                IsLocked = false;
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
