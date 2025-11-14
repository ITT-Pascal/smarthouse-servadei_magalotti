using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test
{
    public class TwoLampDeviceTests
    {

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

            //TODO testare caso in cui entrembo sono spente/accese 
            


            // Assert
            Assert.False(device.lamp1.IsOn);
            Assert.True(device.lamp2.IsOn);

            // Act: ora spegniamo lamp2 e accendiamo lamp1
            device.AlternateStatesLamp();

            // Assert
           
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
            device.lamp1.SwitchOnOff(); // solo lamp1 accesa

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
            

            // Act

            device.DecreaseBrightnessBoth(); // Questo per evitare eccezioni se la lampada era gia al massimo della luminosità
           
            device.IncreaseBrightnessBoth();
            // Assert
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
