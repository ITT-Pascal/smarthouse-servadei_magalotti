using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.ClimatesTests
{
    public class ThermostatComprehensiveTests
    {
        [Fact]
        public void DimmerTemperatureUp_WhenOff_ThrowsException()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            Assert.Throws<InvalidOperationException>(() => thermostat.DimmerTemperatureUp());
        }

        [Fact]
        public void DimmerTemperatureDown_WhenOff_ThrowsException()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            Assert.Throws<InvalidOperationException>(() => thermostat.DimmerTemperatureDown());
        }

        [Fact]
        public void SetTemperature_ThrowsWhenOff()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperature(21.0));
        }

        [Fact]
        public void TurnOn_ChangesStatus()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            thermostat.TurnOn();
            Assert.Equal(DeviceStatus.On, thermostat.Status);
        }

        [Fact]
        public void TurnOff_ChangesStatus()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            thermostat.TurnOn();
            thermostat.TurnOff();
            Assert.Equal(DeviceStatus.Off, thermostat.Status);
        }

        [Fact]
        public void Rename_ChangesName()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            thermostat.Rename("Cameretta");
            Assert.Equal("Cameretta", thermostat.Name);
        }

        [Fact]
        public void Toggle_SwitchesCorrectly()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            thermostat.Toggle();
            Assert.True(thermostat.IsOn);
        }

        [Fact]
        public void Constructor_WithName_SetsName()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Termo");
            Assert.Equal("Termo", thermostat.Name);
        }

        [Fact]
        public void Constructor_WithEmptyName_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new ThermostatDomain(""));
        }

        [Fact]
        public void CreatedAt_IsSet()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            Assert.NotEqual(default(DateTime), thermostat.CreatedAtUtc);
        }

        [Fact]
        public void Id_IsSet()
        {
            ThermostatDomain thermostat = new ThermostatDomain("Thermostat");
            Assert.NotEqual(Guid.Empty, thermostat.Id);
        }
    }
}
