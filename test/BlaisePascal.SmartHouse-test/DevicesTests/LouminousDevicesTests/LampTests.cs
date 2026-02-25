using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.LouminousDevicesTests
{
    public class LampTests
    {
        [Fact]
        public void MaxBrightness_IsExactlyTen()
        {
            Assert.Equal(10, Lamp.MaxBrightness.Value);
        }

        [Fact]
        public void Constructor_SetsIsEcoToFalse()
        {
            Lamp lamp = new Lamp("Lamp");
            Assert.False(lamp.IsEco);
        }

        [Fact]
        public void SetBrightness_ValidValue_Updates()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(8));
            Assert.Equal(8, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetBrightness_TooHigh_ClampsToTen()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(15));
            Assert.Equal(10, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetBrightness_TooLow_ClampsToOne()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(0));
            Assert.Equal(1, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void IncreaseBrightness_IncrementsByOne()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(5));
            lamp.IncreaseBrightness();
            Assert.Equal(6, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void IncreaseBrightness_AtTen_StaysAtTen()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(10));
            lamp.IncreaseBrightness();
            Assert.Equal(10, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void DecreaseBrightness_DecrementsByOne()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(5));
            lamp.DecreaseBrightness();
            Assert.Equal(4, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void DecreaseBrightness_AtOne_StaysAtOne()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.SetBrightness(new Brightness(1));
            lamp.DecreaseBrightness();
            Assert.Equal(1, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void TurnOn_SetsStatusOn()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void TurnOff_SetsStatusOff()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void Toggle_SwitchesState()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.Toggle();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void Rename_UpdatesNameCorrectly()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.Rename("LampadaSoggiorno");
            Assert.Equal("LampadaSoggiorno", lamp.Name.String);
        }

        [Fact]
        public void LastModified_UpdatesOnSetBrightness()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            DateTime marker = lamp.LastModifiedAtUtc;
            lamp.SetBrightness(new Brightness(3));
            Assert.NotEqual(marker, lamp.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnIncrease()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            DateTime marker = lamp.LastModifiedAtUtc;
            lamp.IncreaseBrightness();
            Assert.NotEqual(marker, lamp.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnDecrease()
        {
            Lamp lamp = new Lamp("Lamp");
            lamp.TurnOn();
            DateTime marker = lamp.LastModifiedAtUtc;
            lamp.DecreaseBrightness();
            Assert.NotEqual(marker, lamp.LastModifiedAtUtc);
        }

        [Fact]
        public void Id_IsGeneratedCorrectly()
        {
            Lamp lamp = new Lamp("Lamp");
            Assert.NotEqual(Guid.Empty, lamp.Id);
        }
    }
}