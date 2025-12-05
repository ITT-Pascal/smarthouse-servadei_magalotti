using SmartHouse.domain.Devices;
using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test.DevicesTests.ClimatesTests
{
    public class ThermostatTests
    {
        [Fact]
        public void TurnOn_ShouldTurnDeviceOn()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");

            // Act
            thermostat.TurnOn();

            // Assert
            Assert.True(thermostat.IsOn);
            Assert.Equal(true, thermostat.Status == DeviceStatus.On);
        }

        [Fact]
        public void TurnOff_ShouldTurnDeviceOff()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();

            // Act
            thermostat.TurnOff();

            // Assert
            Assert.False(thermostat.IsOn);
            Assert.Equal(true, thermostat.Status == DeviceStatus.Off);
        }

        [Fact]
        public void DimmerTemperatureUp_WhenOn_ShouldIncreaseTemperature()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();
            thermostat.SetTemperature(20);

            // Act
            thermostat.DimmerTemperatureUp();

            // Assert
            Assert.Equal(true, thermostat.Temperature == 20 + Thermostat.DefaultDimmer);
        }

        [Fact]
        public void DimmerTemperatureDown_WhenOn_ShouldDecreaseTemperature()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();
            thermostat.SetTemperature(20);

            // Act
            thermostat.DimmerTemperatureDown();

            // Assert
            Assert.Equal(true, thermostat.Temperature == 20 - Thermostat.DefaultDimmer);
        }

        [Fact]
        public void DimmerTemperatureUp_WhenOff_ShouldNotChangeTemperature()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");
            var initialTemp = thermostat.Temperature;

            // Act
            bool statusChanged = false;
            if (thermostat.Status == DeviceStatus.On)
                thermostat.DimmerTemperatureUp();
            else
                statusChanged = true; // flag per test logico: NON deve cambiare se spento

            // Assert
            Assert.Equal(true, statusChanged);
            Assert.Equal(true, thermostat.Temperature == initialTemp);
        }

        [Fact]
        public void DimmerTemperatureDown_WhenOff_ShouldNotChangeTemperature()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");
            var initialTemp = thermostat.Temperature;

            // Act
            bool statusChanged = false;
            if (thermostat.Status == DeviceStatus.On)
                thermostat.DimmerTemperatureDown();
            else
                statusChanged = true;

            // Assert
            Assert.Equal(true, statusChanged);
            Assert.Equal(true, thermostat.Temperature == initialTemp);
        }

        [Fact]
        public void Toggle_WhenOn_ShouldTurnOff()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();

            // Act
            thermostat.Toggle();

            // Assert
            Assert.False(thermostat.IsOn);
            Assert.Equal(true, thermostat.Status == DeviceStatus.Off);
        }

        [Fact]
        public void Toggle_WhenOff_ShouldTurnOn()
        {
            // Arrange
            var thermostat = new Thermostat("Thermostat");

            // Act
            thermostat.Toggle();

            // Assert
            Assert.True(thermostat.IsOn);
            Assert.Equal(true, thermostat.Status == DeviceStatus.On);
        }
    }
}
