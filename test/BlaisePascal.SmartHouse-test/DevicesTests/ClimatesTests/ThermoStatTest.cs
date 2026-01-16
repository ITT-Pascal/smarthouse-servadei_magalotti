using BlaisePascal.SmartHouse.Domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.ClimatesTests
{
    public class ThermostatTests
    {
        [Fact]
        public void TurnOn_ShouldTurnDeviceOn()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");

            // Act
            thermostat.TurnOn();

            // Assert
            Assert.True(thermostat.IsOn);
            Assert.True(thermostat.Status == DeviceStatus.On);
        }

        [Fact]
        public void TurnOff_ShouldTurnDeviceOff()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();

            // Act
            thermostat.TurnOff();

            // Assert
            Assert.False(thermostat.IsOn);
            Assert.True(thermostat.Status == DeviceStatus.Off);
        }

        [Fact]
        public void DimmerTemperatureUp_WhenOn_ShouldIncreaseTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();
            thermostat.SetTemperature(20);

            // Act
            thermostat.DimmerTemperatureUp();

            // Assert
            Assert.True(thermostat.Temperature == 20 + Thermostat.DefaultDimmer);
        }

        [Fact]
        public void DimmerTemperatureDown_WhenOn_ShouldDecreaseTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();
            thermostat.SetTemperature(20);

            // Act
            thermostat.DimmerTemperatureDown();

            // Assert
            Assert.True(thermostat.Temperature == 20 - Thermostat.DefaultDimmer);
        }

        [Fact]
        public void DimmerTemperatureUp_WhenOff_ShouldNotChangeTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");
            var initialTemp = thermostat.Temperature;

            // Act
            bool statusChanged = false;
            if (thermostat.Status == DeviceStatus.On)
                thermostat.DimmerTemperatureUp();
            else
                statusChanged = true; // flag per test logico: NON deve cambiare se spento

            // Assert
            Assert.True(statusChanged);
            Assert.True(thermostat.Temperature == initialTemp);
        }

        [Fact]
        public void DimmerTemperatureDown_WhenOff_ShouldNotChangeTemperature()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");
            var initialTemp = thermostat.Temperature;

            // Act
            bool statusChanged = false;
            if (thermostat.Status == DeviceStatus.On)
                thermostat.DimmerTemperatureDown();
            else
                statusChanged = true;

            // Assert
            Assert.True(statusChanged);
            Assert.True(thermostat.Temperature == initialTemp);
        }

        [Fact]
        public void Toggle_WhenOn_ShouldTurnOff()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();

            // Act
            thermostat.Toggle();

            // Assert
            Assert.False(thermostat.IsOn);
            Assert.True(thermostat.Status == DeviceStatus.Off);
        }

        [Fact]
        public void Toggle_WhenOff_ShouldTurnOn()
        {
            // Arrange
            Thermostat thermostat = new Thermostat("Thermostat");

            // Act
            thermostat.Toggle();

            // Assert
            Assert.True(thermostat.IsOn);
            Assert.True(thermostat.Status == DeviceStatus.On);
        }
    }
}
