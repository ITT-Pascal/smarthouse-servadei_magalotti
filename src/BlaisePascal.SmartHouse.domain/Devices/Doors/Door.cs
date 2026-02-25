using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Doors.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Doors
{
    public class Door : AbstractDevice, IOpenable, ILockable
    {
        public bool IsOpen { get; private set; }
        public bool IsLocked { get; private set; }
        public DoorCode Code { get; private set; }

        public Door(Name name, string code) : base(name)
        {
            IsOpen = false;
            IsLocked = false;
            Code = new DoorCode(code);
        }

        public Door(Guid id, Name name, DeviceStatus status, bool isOpen, bool isLocked, string code)
            : base(name, id)
        {
            Status = status;
            IsOpen = isOpen;
            IsLocked = isLocked;
            Code = new DoorCode(code);
        }

        public Door(Name name) : base(name)
        {
        }

        public void Open()
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot open door when device is off.");

            if (IsLocked)
                throw new InvalidOperationException("Cannot open a locked door. Unlock it first.");

            if (IsOpen)
                throw new InvalidOperationException("Door is already open.");

            IsOpen = true;
            UpdateLastModified();
        }

        public void Close()
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot close door when device is off.");

            if (!IsOpen)
                throw new InvalidOperationException("Door is already closed.");

            IsOpen = false;
            UpdateLastModified();
        }

        public void Lock()
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot lock door when device is off.");

            if (IsOpen)
                throw new InvalidOperationException("Cannot lock an open door. Close it first.");

            if (IsLocked)
                throw new InvalidOperationException("Door is already locked.");

            IsLocked = true;
            UpdateLastModified();
        }

        public void Unlock(string codeCandidate)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot unlock door when device is off.");

            if (!IsLocked)
                throw new InvalidOperationException("Door is already unlocked.");

            if (!Code.Match(codeCandidate))
                throw new ArgumentException("Invalid code.");

            IsLocked = false;
            UpdateLastModified();
        }

        public void Unlock()
        {
            throw new InvalidOperationException("Security required. Use Unlock(string code).");
        }

        public void ChangeCode(string oldCode, string newCode)
        {
            if (!IsOn)
                throw new InvalidOperationException("Device must be on to change code.");

            if (!Code.Match(oldCode))
                throw new ArgumentException("Old code does not match.");

            Code = new DoorCode(newCode);
            UpdateLastModified();
        }

        public override void TurnOff()
        {
            if (IsOpen)
                throw new InvalidOperationException("Cannot turn off device while door is open.");

            base.TurnOff();
        }
    }
}
