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
    public class LampRowTests
    {
        [Fact]
        public void AddLamp_IncreasesLampCount()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("Lamp");
            lampRow.AddLamp(lamp);
            Assert.NotNull(lampRow.FindLampById(lamp.Id));
        }

        [Fact]
        public void AddLamp_Null_DoesNothing()
        {
            LampRow lampRow = new LampRow("LampRow");
            lampRow.AddLamp(null);
            Assert.Empty(lampRow.FindAllOn());
        }

        [Fact]
        public void SwitchOn_TurnsOnAllLamps()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp1 = new Lamp("L1");
            Lamp lamp2 = new Lamp("L2");
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.SwitchOn();
            Assert.True(lamp1.IsOn && lamp2.IsOn);
        }

        [Fact]
        public void SwitchOff_TurnsOffAllLamps()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn();
            lampRow.SwitchOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void SwitchOn_ById_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn(lamp.Id);
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void SwitchOn_ByName_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("LampName");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn("LampName");
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void SwitchOff_ById_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn();
            lampRow.SwitchOff(lamp.Id);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void SwitchOff_ByName_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("LampName");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn();
            lampRow.SwitchOff("LampName");
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void RemoveLamp_ById_RemovesCorrectLamp()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L");
            lampRow.AddLamp(lamp);
            lampRow.RemoveLamp(lamp.Id);
            Assert.Null(lampRow.FindLampById(lamp.Id));
        }

        [Fact]
        public void RemoveLamp_ByName_RemovesCorrectLamp()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("LampToRemove");
            lampRow.AddLamp(lamp);
            lampRow.RemoveLamp("LampToRemove");
            Assert.Null(lampRow.FindLampById(lamp.Id));
        }

        [Fact]
        public void SetIntensityForAll_UpdatesAllLamps()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp1 = new Lamp("L1");
            Lamp lamp2 = new Lamp("L2");
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lampRow.SwitchOn();
            lampRow.SetIntensityForAllLamps(new Brightness(9));
            Assert.True(lamp1.CurrentBrightness.Value == 9 && lamp2.CurrentBrightness.Value == 9);
        }

        [Fact]
        public void FindLampWithMaxIntensity_ReturnsCorrectOne()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lampLow = new Lamp("Low");
            Lamp lampHigh = new Lamp("High");
            lampRow.AddLamp(lampLow);
            lampRow.AddLamp(lampHigh);
            lampRow.SwitchOn();
            lampLow.SetBrightness(new Brightness(2));
            lampHigh.SetBrightness(new Brightness(8));
            Assert.Equal(lampHigh.Id, lampRow.FindLampWithMaxIntensity().Id);
        }

        [Fact]
        public void FindLampWithMinIntensity_ReturnsCorrectOne()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lampLow = new Lamp("Low");
            Lamp lampHigh = new Lamp("High");
            lampRow.AddLamp(lampLow);
            lampRow.AddLamp(lampHigh);
            lampRow.SwitchOn();
            lampLow.SetBrightness(new Brightness(2));
            lampHigh.SetBrightness(new Brightness(8));
            Assert.Equal(lampLow.Id, lampRow.FindLampWithMinIntensity().Id);
        }

        [Fact]
        public void FindAllOn_ReturnsCorrectCount()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp1 = new Lamp("L1");
            Lamp lamp2 = new Lamp("L2");
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lamp1.TurnOn();
            Assert.Single(lampRow.FindAllOn());
        }

        [Fact]
        public void FindAllOff_ReturnsCorrectCount()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp1 = new Lamp("L1");
            Lamp lamp2 = new Lamp("L2");
            lampRow.AddLamp(lamp1);
            lampRow.AddLamp(lamp2);
            lamp1.TurnOn();
            Assert.Single(lampRow.FindAllOff());
        }

        [Fact]
        public void FindLampsByIntensityRange_ReturnsMatchingLamps()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp1 = new Lamp("L1");
            lampRow.AddLamp(lamp1);
            lampRow.SwitchOn();
            lamp1.SetBrightness(new Brightness(5));
            Assert.Single(lampRow.FindLampsByIntensityRange(4, 6));
        }

        [Fact]
        public void SortByIntensity_Ascending_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            lampRow.AddLamp(l1); lampRow.AddLamp(l2);
            lampRow.SwitchOn();
            l1.SetBrightness(new Brightness(8)); l2.SetBrightness(new Brightness(3));
            List<AbstractLamp> sorted = lampRow.SortByIntensity(false);
            Assert.Equal(3, sorted[0].CurrentBrightness.Value);
        }

        [Fact]
        public void SortByIntensity_Descending_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            lampRow.AddLamp(l1); lampRow.AddLamp(l2);
            lampRow.SwitchOn();
            l1.SetBrightness(new Brightness(8)); l2.SetBrightness(new Brightness(3));
            List<AbstractLamp> sorted = lampRow.SortByIntensity(true);
            Assert.Equal(8, sorted[0].CurrentBrightness.Value);
        }

        [Fact]
        public void RemoveLampInPosition_ValidIndex_Removes()
        {
            LampRow lampRow = new LampRow("LampRow");
            lampRow.AddLamp(new Lamp("L1"));
            lampRow.RemoveLampInPosition(0);
            Assert.Empty(lampRow.FindAllOff());
        }

        [Fact]
        public void AddLampInPosition_ValidIndex_Adds()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L1");
            lampRow.AddLampInPosition(lamp, 0);
            Assert.NotNull(lampRow.FindLampById(lamp.Id));
        }

        [Fact]
        public void SetIntensityForLamp_ById_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L1");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn();
            lampRow.SetIntensityForLamp(lamp.Id, new Brightness(4));
            Assert.Equal(4, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetIntensityForLamp_ByName_Works()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("LampName");
            lampRow.AddLamp(lamp);
            lampRow.SwitchOn();
            lampRow.SetIntensityForLamp("LampName", new Brightness(7));
            Assert.Equal(7, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void Constructor_WithName_InitializesList()
        {
            LampRow lampRow = new LampRow("RowName");
            Assert.Empty(lampRow.FindAllOff());
        }

        [Fact]
        public void LastModified_UpdatesOnAdd()
        {
            LampRow lampRow = new LampRow("LampRow");
            DateTime marker = lampRow.LastModifiedAtUtc;
            lampRow.AddLamp(new Lamp("L"));
            Assert.NotEqual(marker, lampRow.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnRemove()
        {
            LampRow lampRow = new LampRow("LampRow");
            Lamp lamp = new Lamp("L");
            lampRow.AddLamp(lamp);
            DateTime marker = lampRow.LastModifiedAtUtc;
            lampRow.RemoveLamp(lamp.Id);
            Assert.NotEqual(marker, lampRow.LastModifiedAtUtc);
        }

        [Fact]
        public void FindLampWithMaxIntensity_EmptyList_ReturnsNull()
        {
            LampRow lampRow = new LampRow("LampRow");
            Assert.Null(lampRow.FindLampWithMaxIntensity());
        }

        [Fact]
        public void FindLampWithMinIntensity_EmptyList_ReturnsNull()
        {
            LampRow lampRow = new LampRow("LampRow");
            Assert.Null(lampRow.FindLampWithMinIntensity());
        }

        [Fact]
        public void Id_IsGenerated()
        {
            LampRow lampRow = new LampRow("LampRow");
            Assert.NotEqual(Guid.Empty, lampRow.Id);
        }
    }
}
