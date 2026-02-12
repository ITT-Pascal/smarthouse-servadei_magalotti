using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.LouminousDevicesTests
{
    public class LedMatrixTests
    {
        [Fact]
        public void Constructor_ValidDimensions_SetsProperties()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 5, 10);
            Assert.Equal(50, ledMatrix.Matrix.Length);
        }

        [Fact]
        public void Constructor_InvalidHeight_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new LedMatrix("Matrix", 0, 5));
        }

        [Fact]
        public void Constructor_InvalidWidth_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new LedMatrix("Matrix", 5, -1));
        }

        [Fact]
        public void AddLamp_ValidPosition_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 3, 3);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 1, 1);
            Assert.Equal(lamp, ledMatrix.Matrix[1, 1]);
        }

        [Fact]
        public void AddLamp_OutOfRange_ThrowsException()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Assert.Throws<IndexOutOfRangeException>(() => ledMatrix.AddLampInPosition(new Lamp("L"), 5, 0));
        }

        [Fact]
        public void AddLamp_OccupiedPosition_ThrowsException()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            ledMatrix.AddLampInPosition(new Lamp("L1"), 0, 0);
            Assert.Throws<ArgumentException>(() => ledMatrix.AddLampInPosition(new Lamp("L2"), 0, 0));
        }

        [Fact]
        public void RemoveLamp_ByName_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            ledMatrix.AddLampInPosition(new Lamp("Target"), 0, 0);
            ledMatrix.RemoveLamp("Target");
            Assert.Null(ledMatrix.Matrix[0, 0]);
        }

        [Fact]
        public void RemoveLamp_ById_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.RemoveLamp(lamp.Id);
            Assert.Null(ledMatrix.Matrix[0, 0]);
        }

        [Fact]
        public void RemoveLampInPosition_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            ledMatrix.AddLampInPosition(new Lamp("L"), 0, 0);
            ledMatrix.RemoveLampInPosition(0, 0);
            Assert.Null(ledMatrix.Matrix[0, 0]);
        }

        [Fact]
        public void TurnOn_TurnsOnAllInternalLamps()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.TurnOn();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void TurnOff_TurnsOffAllInternalLamps()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.TurnOn();
            ledMatrix.TurnOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void SetBrightness_UpdatesAllLamps()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.TurnOn();
            ledMatrix.SetBrightness(9);
            Assert.Equal(9, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetBrightnessOneLamp_ById_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.TurnOn();
            ledMatrix.SetBrightnessOneLamp(4, lamp.Id);
            Assert.Equal(4, lamp.CurrentBrightness.Value);
        }

        [Fact]
        public void FindLampWithMaxBrightness_ReturnsHighest()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            ledMatrix.AddLampInPosition(l1, 0, 0);
            ledMatrix.AddLampInPosition(l2, 1, 1);
            ledMatrix.TurnOn();
            l1.SetBrightness(2);
            l2.SetBrightness(8);
            Assert.Equal(l2, ledMatrix.FindLampWithMaxBrightness());
        }

        [Fact]
        public void FindLampWithMinBrightness_ReturnsLowest()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            ledMatrix.AddLampInPosition(l1, 0, 0);
            ledMatrix.AddLampInPosition(l2, 1, 1);
            ledMatrix.TurnOn();
            l1.SetBrightness(2);
            l2.SetBrightness(8);
            Assert.Equal(l1, ledMatrix.FindLampWithMinBrightness());
        }

        [Fact]
        public void NotNullValidator_WhenEmpty_ThrowsException()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Assert.Throws<InvalidOperationException>(() => ledMatrix.NotNullValidator());
        }

        [Fact]
        public void SwitchOnOneLamp_ById_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.SwitchOnOneLamp(lamp.Id);
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void SwitchOffOneLamp_ById_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("L");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            lamp.TurnOn();
            ledMatrix.SwitchOffOneLamp(lamp.Id);
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void SwitchOnOneLamp_ByName_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("Target");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            ledMatrix.SwitchOnOneLamp("Target");
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void SwitchOffOneLamp_ByName_Works()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Lamp lamp = new Lamp("Target");
            ledMatrix.AddLampInPosition(lamp, 0, 0);
            lamp.TurnOn();
            ledMatrix.SwitchOffOneLamp("Target");
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void Rename_UpdatesProperty()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            ledMatrix.Rename("NuovaMatrice");
            Assert.Equal("NuovaMatrice", ledMatrix.Name);
        }

        [Fact]
        public void Id_IsGeneratedCorrectly()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Assert.NotEqual(Guid.Empty, ledMatrix.Id);
        }

        [Fact]
        public void CreatedAt_IsSetOnCreation()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            Assert.NotEqual(default(DateTime), ledMatrix.CreatedAtUtc);
        }

        [Fact]
        public void Height_IsCorrectlyStored()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 7, 3);
            Assert.Equal(7, ledMatrix.Height);
        }

        [Fact]
        public void Width_IsCorrectlyStored()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 7, 3);
            Assert.Equal(3, ledMatrix.Width);
        }

        [Fact]
        public void LastModified_UpdatesOnAdd()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            DateTime marker = ledMatrix.LastModifiedAtUtc;
            ledMatrix.AddLampInPosition(new Lamp("L"), 0, 0);
            Assert.NotEqual(marker, ledMatrix.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnRemove()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            ledMatrix.AddLampInPosition(new Lamp("L"), 0, 0);
            DateTime marker = ledMatrix.LastModifiedAtUtc;
            ledMatrix.RemoveLampInPosition(0, 0);
            Assert.NotEqual(marker, ledMatrix.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnTurnOn()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            DateTime marker = ledMatrix.LastModifiedAtUtc;
            ledMatrix.TurnOn();
            Assert.NotEqual(marker, ledMatrix.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnChessboard()
        {
            LedMatrix ledMatrix = new LedMatrix("Matrix", 2, 2);
            DateTime marker = ledMatrix.LastModifiedAtUtc;
            ledMatrix.SetChessboardPattern();
            Assert.NotEqual(marker, ledMatrix.LastModifiedAtUtc);
        }
    }
}
