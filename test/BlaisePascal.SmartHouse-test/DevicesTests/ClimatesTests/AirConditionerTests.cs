using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Climates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.ClimatesTests
{
    public class AirConditionerComprehensiveTests
    {
        [Fact]
        public void SetAirConditionerStatus_WhenOff_ShouldThrow()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            Assert.Throws<InvalidOperationException>(() => airConditioner.SetMode(AirConditionerMode.Cooling));
        }

        [Fact]
        public void SetTemperature_WhenOff_ShouldThrow()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            Assert.Throws<InvalidOperationException>(() => airConditioner.SetTemperature(20.0));
        }

        [Fact]
        public void IncreaseTemperature_WhenOff_ShouldThrow()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            Assert.Throws<InvalidOperationException>(() => airConditioner.IncreaseTemperature(1.0));
        }

        [Fact]
        public void DecreaseTemperature_WhenOff_ShouldThrow()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            Assert.Throws<InvalidOperationException>(() => airConditioner.DecreaseTemperature(1.0));
        }

        [Fact]
        public void TurnOn_SetsIsOnToTrue()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            airConditioner.TurnOn();
            Assert.True(airConditioner.IsOn);
        }

        [Fact]
        public void TurnOff_SetsIsOnToFalse()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            airConditioner.TurnOn();
            airConditioner.TurnOff();
            Assert.False(airConditioner.IsOn);
        }

        [Fact]
        public void Rename_WorksNormally()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            airConditioner.Rename("AC_Soggiorno");
            Assert.Equal("AC_Soggiorno", airConditioner.Name);
        }

        [Fact]
        public void Toggle_CyclesCorrectly()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            airConditioner.Toggle();
            Assert.Equal(DeviceStatus.On, airConditioner.Status);
        }

        [Fact]
        public void LastModified_UpdatesOnTemperatureChange()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            airConditioner.TurnOn();
            DateTime marker = airConditioner.LastModifiedAtUtc;
            airConditioner.SetTemperature(22.0);
            Assert.NotEqual(marker, airConditioner.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnStatusChange()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            airConditioner.TurnOn();
            DateTime marker = airConditioner.LastModifiedAtUtc;
            airConditioner.SetMode(AirConditionerMode.Dry);
            Assert.NotEqual(marker, airConditioner.LastModifiedAtUtc);
        }

        [Fact]
        public void Constructor_SetsId()
        {
            AirConditioner airConditioner = new AirConditioner("AirConditioner");
            Assert.NotEqual(Guid.Empty, airConditioner.Id);
        }
    }
}
