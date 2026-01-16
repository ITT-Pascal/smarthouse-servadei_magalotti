using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.DoorsTests
{
    public class DoorTest
    {
        [Fact]
        public void TurnOn_ShouldTurnDeviceOn()
        {
            // Arrange
            Door door = new Door("Door");

            // Act
            door.TurnOn();

            // Assert
            Assert.True(door.IsOn);
            Assert.True(door.Status == DeviceStatus.On);
        }

        [Fact]
        public void TurnOff_ShouldTurnDeviceOff()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();

            // Act
            door.TurnOff();

            // Assert
            Assert.False(door.IsOn);
            Assert.True(door.Status == DeviceStatus.Off);
        }

        [Fact]
        public void Open_WhenOnAndUnlocked_ShouldOpenDoor()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();

            // Act
            bool canOpen = false;
            if (door.Status == DeviceStatus.On && !door.IsLocked)
            {
                door.Open();
                canOpen = true;
            }

            // Assert
            Assert.True(canOpen);
            Assert.True(door.IsOpen);
        }

        [Fact]
        public void Close_WhenOnAndUnlocked_ShouldCloseDoor()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();
            door.Open();

            // Act
            bool canClose = false;
            if (door.Status == DeviceStatus.On && !door.IsLocked)
            {
                door.Close();
                canClose = true;
            }

            // Assert
            Assert.True(canClose);
            Assert.False(door.IsOpen);
        }

        [Fact]
        public void Lock_WhenClosedAndOn_ShouldLockDoor()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();
            door.Close();

            // Act
            bool canLock = false;
            if (!door.IsOpen && door.IsOn)
            {
                door.Lock();
                canLock = true;
            }

            // Assert
            Assert.True(canLock);
            Assert.True(door.IsLocked);
        }

        [Fact]
        public void Unlock_WhenClosedAndOn_ShouldUnlockDoor()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();
            door.Lock();

            // Act
            bool canUnlock = false;
            if (!door.IsOpen && door.IsOn)
            {
                door.Unlock();
                canUnlock = true;
            }

            // Assert
            Assert.True(canUnlock);
            Assert.False(door.IsLocked);
        }

        [Fact]
        public void SwitchOpenClose_ShouldToggleDoorState()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();
            door.Close();

            // Act
            door.SwitchOpenClose(); // opens
            bool firstState = door.IsOpen;

            door.SwitchOpenClose(); // closes
            bool secondState = door.IsOpen;

            // Assert
            Assert.True(firstState);
            Assert.False(secondState);
        }

        [Fact]
        public void SwitchLockUnlock_ShouldToggleLockState()
        {
            // Arrange
            Door door = new Door("Door");
            door.TurnOn();
            door.Close();

            // Act
            door.SwitchLockUnlock(); // locks
            bool firstState = door.IsLocked;

            door.SwitchLockUnlock(); // unlocks
            bool secondState = door.IsLocked;

            // Assert
            Assert.True(firstState);
            Assert.False(secondState);
        }

        [Fact]
        public void Rename_ShouldChangeName()
        {
            // Arrange
            Door door = new Door("OldDoor");

            // Act
            door.Rename("NewDoor");

            // Assert
            Assert.True(door.Name == "NewDoor");
        }
    }
}
