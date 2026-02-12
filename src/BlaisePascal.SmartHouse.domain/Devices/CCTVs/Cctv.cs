using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVs
{
    public class Cctv : AbstractDevice, ILockable
    {
        public CctvMode CurrentMode { get; private set; }
        public CctvPassword Password { get; private set; }
        public bool IsLocked { get; private set; }

        public Cctv(string name, string password) : base(name)
        {
            CurrentMode = CctvMode.Idle;
            Password = new CctvPassword(password);
            IsLocked = true;
        }

        public Cctv(Guid id, string name, DeviceStatus status, CctvMode mode, string password, bool isLocked)
            : base(name, id)
        {
            Status = status;
            CurrentMode = mode;
            Password = new CctvPassword(password);
            IsLocked = isLocked;
        }

        public void SetMode(CctvMode mode)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot change mode when device is off.");

            if (IsLocked)
                throw new InvalidOperationException("Cannot change mode when device is locked.");

            CurrentMode = mode;
            UpdateLastModified();
        }

        public void Unlock(string passwordCandidate)
        {
            if (!IsOn)
                throw new InvalidOperationException("Cannot unlock device when it is off.");

            if (Password.Match(passwordCandidate))
            {
                IsLocked = false;
                UpdateLastModified();
            }
            else
            {
                throw new ArgumentException("Invalid password.");
            }
        }

        public void Lock()
        {
            IsLocked = true;
            UpdateLastModified();
        }

        public void Unlock()
        {
            throw new InvalidOperationException("This device requires a password to unlock. Use Unlock(string password).");
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (!IsOn)
                throw new InvalidOperationException("Device must be on to change password.");

            if (IsLocked)
                throw new InvalidOperationException("Device must be unlocked to change password.");

            if (Password.Match(oldPassword))
            {
                Password = new CctvPassword(newPassword);
                UpdateLastModified();
            }
            else
            {
                throw new ArgumentException("Old password does not match.");
            }
        }

        public override void TurnOff()
        {
            base.TurnOff();
            Lock();
        }
    }
}
