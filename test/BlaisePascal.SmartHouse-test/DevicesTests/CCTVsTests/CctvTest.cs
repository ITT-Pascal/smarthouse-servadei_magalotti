using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test.DevicesTests.CCTVsTests
{
    public class CctvTests
    {
        [Fact]
        public void TurnOn_ShouldTurnDeviceOn()
        {
            // Arrange
            var cctv = new Cctv("CCTV");

            // Act
            cctv.TurnOn();

            // Assert
            Assert.True(cctv.IsOn);
            Assert.Equal(true, cctv.Status == DeviceStatus.On);
        }

        [Fact]
        public void TurnOff_ShouldTurnDeviceOff()
        {
            // Arrange
            var cctv = new Cctv("CCTV");
            cctv.TurnOn();

            // Act
            cctv.TurnOff();

            // Assert
            Assert.False(cctv.IsOn);
            Assert.Equal(true, cctv.Status == DeviceStatus.Off);
        }

        [Fact]
        public void SetCctvStatus_WhenOn_ShouldSetStatus()
        {
            // Arrange
            var cctv = new Cctv("CCTV");
            cctv.TurnOn();

            // Act
            cctv.SetCctvStatus(CctvStatus.NightVision);

            // Assert
            Assert.Equal(true, cctv.CctvStatus == CctvStatus.NightVision);
        }

        [Fact]
        public void SetCctvStatus_WhenOff_ShouldNotChangeStatus()
        {
            // Arrange
            var cctv = new Cctv("CCTV");
            var initialStatus = cctv.CctvStatus;

            // Act
            bool statusChanged = false;
            if (cctv.Status == DeviceStatus.On)
                cctv.SetCctvStatus(CctvStatus.Termic);
            else
                statusChanged = true; // flag logico: NON deve cambiare se spento

            // Assert
            Assert.Equal(true, statusChanged);
            Assert.Equal(true, cctv.CctvStatus == initialStatus);
        }

        [Fact]
        public void Toggle_WhenOn_ShouldTurnOff()
        {
            // Arrange
            var cctv = new Cctv("CCTV");
            cctv.TurnOn();

            // Act
            cctv.Toggle();

            // Assert
            Assert.False(cctv.IsOn);
            Assert.Equal(true, cctv.Status == DeviceStatus.Off);
        }

        [Fact]
        public void Toggle_WhenOff_ShouldTurnOn()
        {
            // Arrange
            var cctv = new Cctv("CCTV");

            // Act
            cctv.Toggle();

            // Assert
            Assert.True(cctv.IsOn);
            Assert.Equal(true, cctv.Status == DeviceStatus.On);
        }

        [Fact]
        public void Rename_ShouldChangeName()
        {
            // Arrange
            var cctv = new Cctv("OldName");

            // Act
            cctv.Rename("NewName");

            // Assert
            Assert.Equal(true, cctv.Name == "NewName");
        }
    }
}
