using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.DoorsTests
{
    public class DoorComprehensiveTests
    {
        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            Door door = new Door("PortaIngresso");
            Assert.False(door.IsOpen);
        }

        [Fact]
        public void Constructor_InitializesLockedFalse()
        {
            Door door = new Door("PortaIngresso");
            Assert.False(door.IsLocked);
        }

        [Fact]
        public void Open_WhenOnAndUnlocked_SetsIsOpenTrue()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Open();
            Assert.True(door.IsOpen);
        }

        [Fact]
        public void Open_WhenOff_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            Assert.Throws<InvalidOperationException>(() => door.Open());
        }

        [Fact]
        public void Open_WhenLocked_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Lock();
            Assert.Throws<InvalidOperationException>(() => door.Open());
        }

        [Fact]
        public void Close_WhenOnAndUnlocked_SetsIsOpenFalse()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Open();
            door.Close();
            Assert.False(door.IsOpen);
        }

        [Fact]
        public void Close_WhenOff_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            Assert.Throws<InvalidOperationException>(() => door.Close());
        }

        [Fact]
        public void Close_WhenLocked_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Lock();
            Assert.Throws<InvalidOperationException>(() => door.Close());
        }

        [Fact]
        public void Lock_WhenOnAndClosed_SetsIsLockedTrue()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Lock();
            Assert.True(door.IsLocked);
        }

        [Fact]
        public void Lock_WhenDoorIsOpen_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Open();
            Assert.Throws<InvalidOperationException>(() => door.Lock());
        }

        [Fact]
        public void Lock_WhenOff_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            Assert.Throws<InvalidOperationException>(() => door.Lock());
        }

        [Fact]
        public void Unlock_WhenOff_ThrowsException()
        {
            Door door = new Door("PortaIngresso");
            Assert.Throws<InvalidOperationException>(() => door.Unlock());
        }

        [Fact]
        public void TurnOn_SetsStatus()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            Assert.Equal(DeviceStatus.On, door.Status);
        }

        [Fact]
        public void TurnOff_SetsStatus()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.TurnOff();
            Assert.Equal(DeviceStatus.Off, door.Status);
        }

        [Fact]
        public void Rename_UpdatesName()
        {
            Door door = new Door("PortaIngresso");
            door.Rename("Portone");
            Assert.Equal("Portone", door.Name);
        }

        [Fact]
        public void Rename_Empty_Throws()
        {
            Door door = new Door("PortaIngresso");
            Assert.Throws<InvalidOperationException>(() => door.Rename(""));
        }

        [Fact]
        public void LastModified_UpdatesOnOpen()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            DateTime marker = door.LastModifiedAtUtc;
            door.Open();
            Assert.NotEqual(marker, door.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnClose()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            door.Open();
            DateTime marker = door.LastModifiedAtUtc;
            door.Close();
            Assert.NotEqual(marker, door.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnLock()
        {
            Door door = new Door("PortaIngresso");
            door.TurnOn();
            DateTime marker = door.LastModifiedAtUtc;
            door.Lock();
            Assert.NotEqual(marker, door.LastModifiedAtUtc);
        }

        [Fact]
        public void Toggle_WorksCorrectly()
        {
            Door door = new Door("PortaIngresso");
            door.Toggle();
            Assert.Equal(DeviceStatus.On, door.Status);
        }

        [Fact]
        public void CreatedAt_IsInitialized()
        {
            Door door = new Door("PortaIngresso");
            Assert.NotEqual(default(DateTime), door.CreatedAtUtc);
        }

        [Fact]
        public void IsOn_IsInitiallyFalse()
        {
            Door door = new Door("PortaIngresso");
            Assert.False(door.IsOn);
        }

        [Fact]
        public void IsLocked_IsInitiallyFalse()
        {
            Door door = new Door("PortaIngresso");
            Assert.False(door.IsLocked);
        }

        [Fact]
        public void IsOpen_IsInitiallyFalse()
        {
            Door door = new Door("PortaIngresso");
            Assert.False(door.IsOpen);
        }

        [Fact]
        public void Id_IsUnique()
        {
            Door door = new Door("PortaIngresso");
            Assert.NotEqual(Guid.Empty, door.Id);
        }
    }
}
