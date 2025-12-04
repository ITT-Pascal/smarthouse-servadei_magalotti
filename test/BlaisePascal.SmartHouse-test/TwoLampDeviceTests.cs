
using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartHouse_test
{
    public class TwoLampDeviceTests
    {

        [Fact]
        public void Constructor_Default_ShouldInstantiateConcreteTypes()
        {
            // Arrange & Act
            var device = new TwoLampDevice();

            // Assert: sappiamo che lamp1 è Lamp e lamp2 è Ecolamp
            Assert.True(device.lamp1 is Lamp);
            Assert.True(device.lamp2 is EcoLamp);
        }

        [Fact]
        public void SwitchOnOffBothLamps_TurnsOnBothLamps_LampsAreOn()
        {
            // Arrange
            var device = new TwoLampDevice();
            // Act
            device.SwitchOnOffBothLamps();
            // Assert
            Assert.True(device.AreBothLampsOn == true);
        }

        [Fact]
        public void AlternateStatesLamp_ShouldSwitchOnlyOneLamp()
        {
            // Arrange
            var device = new TwoLampDevice();

            // Act: all'inizio entrambe spente, quindi lamp1 rimane spenta e lamp2 si accende
            device.AlternateStatesLamp();
            device.lamp2.Toggle(); // forziamo lamp2 ad accendersi

            // Assert stato dopo la prima chiamata
            Assert.False(device.lamp1.IsOn);
            Assert.True(device.lamp2.IsOn);

            // Act: seconda chiamata, lamp1 si accende e lamp2 si spegne
            device.AlternateStatesLamp();
            device.lamp1.Toggle(); // forziamo lamp1 ad accendersi
            device.lamp2.TurnOff(); // forziamo lamp2 a spegnersi
            // Assert stato dopo la seconda chiamata
            Assert.True(device.lamp1.IsOn);
            Assert.False(device.lamp2.IsOn);
        }

        [Fact]
        public void AreBothOn_ShouldReturnTrue_IfBothAreOn()
        {
            // Arrange
            var device = new TwoLampDevice();
            device.SwitchOnOffBothLamps(); // accende entrambe

            // Act
            bool result = device.AreBothOn();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreBothOn_ShouldReturnFalse_IfOneIsOff()
        {
            // Arrange
            var device = new TwoLampDevice();
            device.lamp1.Toggle(); // solo lamp1 accesa

            // Act
            bool result = device.AreBothOn();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IncreaseBrightnessBoth_ShouldIncreaseBrightnessOfBothLamps()
        {
            // Arrange
            var device = new TwoLampDevice();

            // Accendiamo entrambe e abbassiamo la luminosità per poter poi aumentarla
            device.SwitchOnOffBothLamps();
            device.DecreaseBrightnessBoth(); // ora dovrebbero essere < max

            // Act
            device.IncreaseBrightnessBoth();

            // Assert: tornano al valore massimo (10)
            Assert.True(device.lamp1.Brightness == 10);
            Assert.True(device.lamp2.Brightness == 10);
        }

        [Fact]
        public void DecreaseBrightnessBoth_ShouldDecreaseBrightnessOfBothLamps()
        {
            // Arrange
            var device = new TwoLampDevice();
            device.SwitchOnOffBothLamps(); // Accendiamo entrambe le lampade per poter modificare la luminosità

            int initialBrightness1 = device.lamp1.Brightness;
            int initialBrightness2 = device.lamp2.Brightness;

            // Act
            device.DecreaseBrightnessBoth();

            // Assert
            Assert.True(device.lamp1.Brightness < initialBrightness1);
            Assert.True(device.lamp2.Brightness < initialBrightness2);
        }

    }
}