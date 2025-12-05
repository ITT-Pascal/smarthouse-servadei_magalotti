using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test.DevicesTests.LouminousDevicesTests
{
    public class LampRowTest
    {
        [Fact]
        public void AddLamp_AddsOneLampToList()
        {
            // Arrange
            LampRow row = new LampRow();

            // Act
            row.AddLamp();

            // Assert
            Assert.True(row.LampsTot.Count == 1);
            Assert.True(row.LampsTot[0] is Lamp);
        }

        [Fact]
        public void AddEcoLamp_AddsOneEcoLampToList()
        {
            // Arrange
            LampRow row = new LampRow();

            // Act
            row.AddEcoLamp();

            // Assert
            Assert.True(row.LampsTot.Count == 1);
            Assert.True(row.LampsTot[0] is EcoLamp);
        }

        [Fact]
        public void AddLampsByType_True_AddsLampAndEcoLamp()
        {
        // Arrange
            LampRow row = new LampRow();

            // Act
            row.AddLampByType(true);

            // Assert
            Assert.True(row.LampsTot.Count == 2);
            Assert.True(row.LampsTot[0] is Lamp);
            Assert.True(row.LampsTot[1] is EcoLamp);
        }

        [Fact]
        public void TurnOnLampByPosition_TurnsOnOnlySpecifiedLamp()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();

            // Act
            row.TurnLampOnByPosition(1);

            // Assert
            Assert.Equal(false, row.LampsTot[0].IsOn);
            Assert.True(row.LampsTot[1].IsOn);
        }

        [Fact]
        public void TurnOffLampByPosition_TurnsOffOnlySpecifiedLamp()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();
            row.TurnOnAll();

            // Act
            row.TurnLampOffByPosition(0);

            // Assert
            Assert.Equal(false, row.LampsTot[0].IsOn);
            Assert.True(row.LampsTot[1].IsOn);
        }

        [Fact]
        public void TurnOnAll_TurnsOnAllLamps()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();

            // Act
            row.TurnOnAll();

            // Assert
            Assert.True(row.LampsTot[0].IsOn);
            Assert.True(row.LampsTot[1].IsOn);
        }

        [Fact]
        public void TurnOffAll_TurnsOffAllLamps()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();
            row.TurnOnAll();

            // Act
            row.TurnOffAll();

            // Assert
            Assert.False(row.LampsTot[0].IsOn);
            Assert.False(row.LampsTot[1].IsOn);
        }

        [Fact]
        public void SetIntensityForAll_SetsBrightnessForAllLamps()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();

            // Act
            row.SetIntensityForAllLamps(7);

            // Assert
            Assert.True(row.LampsTot[0].Brightness == 7);
            Assert.True(row.LampsTot[1].Brightness == 7);
        }

        [Fact]
        public void FindAllOn_ReturnsOnlyOnLamps()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();
            row.TurnLampOnByPosition(1);

            // Act
            var onLamps = row.FindAllLampOn();

            // Assert
            Assert.True(onLamps.Count == 1);
            Assert.True(onLamps[0].IsOn);
        }

        [Fact]
        public void FindAllOff_ReturnsOnlyOffLamps()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();
            row.TurnLampOnByPosition(1);

            // Act
            var offLamps = row.FindAllLampOff();

            // Assert
            Assert.True(offLamps.Count == 1);
            Assert.Equal(false, offLamps[0].IsOn);
        }

        [Fact]
        public void FindLampById_ReturnsLampWithSpecificId()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            var lampId = row.LampsTot[0].GetId();

            // Act
            var foundLamp = row.FindLampById(lampId);

            // Assert
            Assert.True(foundLamp != null);
            Assert.True(foundLamp.GetId() == lampId);
        }

        [Fact]
        public void FindLampsByIntensityRange_ReturnsLampsInRange()
        {
            // Arrange
            LampRow row = new LampRow();
            row.AddLamp();
            row.AddEcoLamp();
            row.SetIntensityForAllLamps(5);

            // Act
            var lampsInRange = row.FindLampsByIntensityRange(4, 6);

            // Assert
            Assert.True(lampsInRange.Count == 2);
        }
    }
}





