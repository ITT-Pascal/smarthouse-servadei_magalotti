using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    internal class Door
    {
        public bool IsOpen { get; private set; }
        public string Name { get; private set; }
        public bool IsLocked { get; private set; }
        public Guid IdDoor { get; private set; }
        public Door(string name)
        {
            Name = name;
            IdDoor = Guid.NewGuid();
            IsLocked = false;
            IsOpen = false;
        }
         public Door(string name, Guid idDoor, bool isLocked, bool isOpen)
        {
            Name = name;
            IdDoor = idDoor;
            IsLocked = isLocked;
            IsOpen = isOpen;
        }

        public Door() {}

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void Open()
        {
            if (IsLocked)
            {
                throw new InvalidOperationException("Cannot open a locked door.");
            }
            IsOpen = true;

        }
        public void Close()
        {
            IsOpen = false;
        }

        public void Lock()
        {
            if (IsOpen)
            {
                throw new InvalidOperationException("Cannot lock an open door.");
            }
            IsLocked = true;
        }

        public void Unlock()
        {
            if (IsLocked) 
            {
                IsLocked = false;
            }
            throw new InvalidOperationException("Door is already unlocked.");

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
