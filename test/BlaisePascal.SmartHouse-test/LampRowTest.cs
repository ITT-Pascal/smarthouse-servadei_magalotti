using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test
{
    public class LampRowTest
        {
            [Fact]
            public void AddLamp_AddsOneLampToList()
            {
                // Arrange
                var row = new LampRow();

                // Act
                row.AddLamp();

                // Assert
                Assert.Equal(true, row.LampsTot.Count == 1);
                Assert.Equal(true, row.LampsTot[0] is Lamp);
            }

            [Fact]
            public void AddEcoLamp_AddsOneEcoLampToList()
            {
                // Arrange
                var row = new LampRow();

                // Act
                row.AddEcoLamp();

                // Assert
                Assert.Equal(true, row.LampsTot.Count == 1);
                Assert.Equal(true, row.LampsTot[0] is EcoLamp);
            }

            [Fact]
            public void AddLampsByType_True_AddsLampAndEcoLamp()
            {
                // Arrange
                var row = new LampRow();

                // Act
                row.AddLampByType(true);

                // Assert
                Assert.Equal(true, row.LampsTot.Count == 2);
                Assert.Equal(true, row.LampsTot[0] is Lamp);
                Assert.Equal(true, row.LampsTot[1] is EcoLamp);
            }

            [Fact]
            public void TurnOnLampByPosition_TurnsOnOnlySpecifiedLamp()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();

                // Act
                row.TurnLampOnByPosition(1);

                // Assert
                Assert.Equal(false, row.LampsTot[0].IsOn);
                Assert.Equal(true, row.LampsTot[1].IsOn);
            }

            [Fact]
            public void TurnOffLampByPosition_TurnsOffOnlySpecifiedLamp()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();
                row.TurnOnAll();

                // Act
                row.TurnLampOffByPosition(0);

                // Assert
                Assert.Equal(false, row.LampsTot[0].IsOn);
                Assert.Equal(true, row.LampsTot[1].IsOn);
            }

            [Fact]
            public void TurnOnAll_TurnsOnAllLamps()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();

                // Act
                row.TurnOnAll();

                // Assert
                Assert.Equal(true, row.LampsTot[0].IsOn);
                Assert.Equal(true, row.LampsTot[1].IsOn);
            }

            [Fact]
            public void TurnOffAll_TurnsOffAllLamps()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();
                row.TurnOnAll();

                // Act
                row.TurnOffAll();

                // Assert
                Assert.Equal(false, row.LampsTot[0].IsOn);
                Assert.Equal(false, row.LampsTot[1].IsOn);
            }

            [Fact]
            public void SetIntensityForAll_SetsBrightnessForAllLamps()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();

                // Act
                row.SetIntensityForAllLamps(7);

                // Assert
                Assert.Equal(true, row.LampsTot[0].Brightness == 7);
                Assert.Equal(true, row.LampsTot[1].Brightness == 7);
            }

            [Fact]
            public void FindAllOn_ReturnsOnlyOnLamps()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();
                row.TurnLampOnByPosition(1);

                // Act
                var onLamps = row.FindAllLampOn();

                // Assert
                Assert.Equal(true, onLamps.Count == 1);
                Assert.Equal(true, onLamps[0].IsOn);
            }

            [Fact]
            public void FindAllOff_ReturnsOnlyOffLamps()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();
                row.TurnLampOnByPosition(1);

                // Act
                var offLamps = row.FindAllLampOff();

                // Assert
                Assert.Equal(true, offLamps.Count == 1);
                Assert.Equal(false, offLamps[0].IsOn);
            }

            [Fact]
            public void FindLampById_ReturnsLampWithSpecificId()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                var lampId = row.LampsTot[0].GetId();

                // Act
                var foundLamp = row.FindLampById(lampId);

                // Assert
                Assert.Equal(true, foundLamp != null);
                Assert.Equal(true, foundLamp.GetId() == lampId);
            }

            [Fact]
            public void FindLampsByIntensityRange_ReturnsLampsInRange()
            {
                // Arrange
                var row = new LampRow();
                row.AddLamp();
                row.AddEcoLamp();
                row.SetIntensityForAllLamps(5);

                // Act
                var lampsInRange = row.FindLampsByIntensityRange(4, 6);

                // Assert
                Assert.Equal(true, lampsInRange.Count == 2);
            }
        }
    }





