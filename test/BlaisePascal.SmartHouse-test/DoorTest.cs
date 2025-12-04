using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test
{
    public class DoorTest
    {
        [Fact]
        public void TurnOn_ShouldTurnDeviceOn()
        {
            // Arrange
            var door = new Door("Door");

            // Act
            door.TurnOn();

            // Assert
            Assert.True(door.IsOn);
            Assert.Equal(true, door.Status == DeviceStatus.On);
        }

        [Fact]
        public void TurnOff_ShouldTurnDeviceOff()
        {
            // Arrange
            var door = new Door("Door");
            door.TurnOn();

            // Act
            door.TurnOff();

            // Assert
            Assert.False(door.IsOn);
            Assert.Equal(true, door.Status == DeviceStatus.Off);
        }

        [Fact]
        public void Open_WhenOnAndUnlocked_ShouldOpenDoor()
        {
            // Arrange
            var door = new Door("Door");
            door.TurnOn();

            // Act
            bool canOpen = false;
            if (door.Status == DeviceStatus.On && !door.IsLocked)
            {
                door.Open();
                canOpen = true;
            }

            // Assert
            Assert.Equal(true, canOpen);
            Assert.True(door.IsOpen);
        }

        [Fact]
        public void Close_WhenOnAndUnlocked_ShouldCloseDoor()
        {
            // Arrange
            var door = new Door("Door");
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
            Assert.Equal(true, canClose);
            Assert.False(door.IsOpen);
        }

        [Fact]
        public void Lock_WhenClosedAndOn_ShouldLockDoor()
        {
            // Arrange
            var door = new Door("Door");
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
            Assert.Equal(true, canLock);
            Assert.True(door.IsLocked);
        }

        [Fact]
        public void Unlock_WhenClosedAndOn_ShouldUnlockDoor()
        {
            // Arrange
            var door = new Door("Door");
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
            Assert.Equal(true, canUnlock);
            Assert.False(door.IsLocked);
        }

        [Fact]
        public void SwitchOpenClose_ShouldToggleDoorState()
        {
            // Arrange
            var door = new Door("Door");
            door.TurnOn();
            door.Close();

            // Act
            door.SwitchOpenClose(); // opens
            bool firstState = door.IsOpen;

            door.SwitchOpenClose(); // closes
            bool secondState = door.IsOpen;

            // Assert
            Assert.Equal(true, firstState);
            Assert.Equal(false, secondState );
        }

        [Fact]
        public void SwitchLockUnlock_ShouldToggleLockState()
        {
            // Arrange
            var door = new Door("Door");
            door.TurnOn();
            door.Close();

            // Act
            door.SwitchLockUnlock(); // locks
            bool firstState = door.IsLocked;

            door.SwitchLockUnlock(); // unlocks
            bool secondState = door.IsLocked;

            // Assert
            Assert.Equal(true, firstState);
            Assert.Equal(false, secondState);
        }

        [Fact]
        public void Rename_ShouldChangeName()
        {
            // Arrange
            var door = new Door("OldDoor");

            // Act
            door.Rename("NewDoor");

            // Assert
            Assert.Equal(true, door.Name == "NewDoor");
        }
    }
}
