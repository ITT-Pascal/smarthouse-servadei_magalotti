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
            Thermostat thermostat = new Thermostat("Thermostat");
            Assert.Throws<InvalidOperationException>(() => thermostat.DimmerTemperatureUp());
        }

        [Fact]
        public void DimmerTemperatureDown_WhenOff_ThrowsException()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            Assert.Throws<InvalidOperationException>(() => thermostat.DimmerTemperatureDown());
        }

        [Fact]
        public void SetTemperature_ThrowsWhenOff()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperature(21.0));
        }

        [Fact]
        public void TurnOn_ChangesStatus()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();
            Assert.Equal(DeviceStatus.On, thermostat.Status);
        }

        [Fact]
        public void TurnOff_ChangesStatus()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.TurnOn();
            thermostat.TurnOff();
            Assert.Equal(DeviceStatus.Off, thermostat.Status);
        }

        [Fact]
        public void Rename_ChangesName()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.Rename("Cameretta");
            Assert.Equal("Cameretta", thermostat.Name);
        }

        [Fact]
        public void Toggle_SwitchesCorrectly()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            thermostat.Toggle();
            Assert.True(thermostat.IsOn);
        }

        [Fact]
        public void Constructor_WithName_SetsName()
        {
            Thermostat thermostat = new Thermostat("Termo");
            Assert.Equal("Termo", thermostat.Name);
        }

        [Fact]
        public void Constructor_WithEmptyName_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new Thermostat(""));
        }

        [Fact]
        public void CreatedAt_IsSet()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            Assert.NotEqual(default(DateTime), thermostat.CreatedAtUtc);
        }

        [Fact]
        public void Id_IsSet()
        {
            Thermostat thermostat = new Thermostat("Thermostat");
            Assert.NotEqual(Guid.Empty, thermostat.Id);
        }
    }
}
