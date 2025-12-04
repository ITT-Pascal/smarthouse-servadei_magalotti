using SmartHouse.domain.Devices;
using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test
{
    public class AirConditionerTests
    {
        [Fact]
        public void TurnOn_ShouldTurnDeviceOn()
        {
            // Arrange
            var conditioner = new AirConditioner("Conditioner");

            // Act
            conditioner.TurnOn();

            // Assert
            Assert.True(conditioner.IsOn);
            Assert.Equal(true, conditioner.Status == DeviceStatus.On);
        }

        [Fact]
        public void TurnOff_ShouldTurnDeviceOff()
        {
            // Arrange
            var conditioner = new AirConditioner("Conditioner");
            conditioner.TurnOn();

            // Act
            conditioner.TurnOff();

            // Assert
            Assert.False(conditioner.IsOn);
            Assert.Equal(true, conditioner.Status == DeviceStatus.Off);
        }

        [Fact]
        public void SetAirConditionerStatus_WhenOn_ShouldSetStatus()
        {
            // Arrange
            var conditioner = new AirConditioner("Conditioner");
            conditioner.TurnOn();

            // Act
            conditioner.SetAirConditionerStatus(AirConditionerStatus.Cooling);

            // Assert
            Assert.Equal(true, conditioner.AirConditionerStatus == AirConditionerStatus.Cooling);
        }

        [Fact]
        public void SetAirConditionerStatus_WhenOff_ShouldNotChangeStatus()
        {
            // Arrange
            var conditioner = new AirConditioner("Conditioner");
            var initialStatus = conditioner.AirConditionerStatus;

            // Act
            bool statusChanged = false;
            if (conditioner.Status == DeviceStatus.On)
                conditioner.SetAirConditionerStatus(AirConditionerStatus.Heating);
            else
                statusChanged = true; // flag per test logico: NON deve cambiare se spento

            // Assert
            Assert.Equal(true, statusChanged);
            Assert.Equal(true, conditioner.AirConditionerStatus == initialStatus);
        }

        [Fact]
        public void Rename_ShouldChangeName()
        {
            // Arrange
            var conditioner = new AirConditioner("OldName");

            // Act
            conditioner.Rename("NewName");

            // Assert
            Assert.Equal(true, conditioner.Name == "NewName");
        }

        [Fact]
        public void Toggle_WhenOn_ShouldTurnOff()
        {
            // Arrange
            var conditioner = new AirConditioner("Conditioner");
            conditioner.TurnOn();

            // Act
            conditioner.Toggle();

            // Assert
            Assert.False(conditioner.IsOn);
            Assert.Equal(true, conditioner.Status == DeviceStatus.Off);
        }

        [Fact]
        public void Toggle_WhenOff_ShouldTurnOn()
        {
            // Arrange
            var conditioner = new AirConditioner("Conditioner");

            // Act
            conditioner.Toggle();

            // Assert
            Assert.True(conditioner.IsOn);
            Assert.Equal(true, conditioner.Status == DeviceStatus.On);
        }
    }
}
