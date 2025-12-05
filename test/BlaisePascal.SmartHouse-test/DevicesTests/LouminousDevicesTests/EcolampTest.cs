using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test.DevicesTests.LouminousDevicesTests
{
    public class EcolampTest
    {
          
        [Fact]
        public void TurnOn_WhenIsOnIsFalse_ItChangesItToTrue()
        {
         //Arrange
        EcoLamp ecoLamp = new EcoLamp("EcoLampada");

        //Act
        ecoLamp.TurnOn();
            
        //Assert
        Assert.Equal(DeviceStatus.On, ecoLamp.Status);
        }

        [Fact]    
        public void TurnOn_WhenIsOnIsTrue_RemainsTrue()
        {
            //Arrange
            EcoLamp ecolamp = new EcoLamp("EcoLampada");

            //Act
            ecolamp.TurnOn();

            //Assert
            Assert.True(ecolamp.IsOn);
        }

        [Fact]
        public void TurnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            //Arrange
            EcoLamp ecolamp = new EcoLamp("EcoLampada");

            //Act
            ecolamp.TurnOn();
            ecolamp.TurnOff();

            //Assert
            Assert.False(ecolamp.IsOn);
        }

        [Fact]
        public void TurnOff_WhenIsOnIsFalse_RemainsFalse()
        {
            //Arrange
            EcoLamp ecolamp = new EcoLamp("EcoLampada");

            //Assert e act
            Assert.Throws<InvalidOperationException>(() => ecolamp.TurnOff());
        }

        [Fact]
        public void Toggle_WhenIsOnIsFalse_TurnsItTrue()
        {
            //Arrange
            EcoLamp ecolamp = new EcoLamp("EcoLampada");
            
            //Act
            ecolamp.Toggle();

            //Assert
            Assert.True(ecolamp.IsOn);
        }

        [Fact]
        public void Toggle_WhenIsOnIsTrue_TurnsItFalse()
        {
            //Arrange
            EcoLamp ecolamp = new EcoLamp("EcoLampada");

            //Act
            ecolamp.TurnOn();
            ecolamp.Toggle();

            //Assert
            Assert.False(ecolamp.IsOn);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
        {
            //Assert
            EcoLamp ecolamp = new EcoLamp("EcoLampada");
            //Act
            ecolamp.Toggle();
            ecolamp.decreaseBrightness();
            ecolamp.increaseBrightness();

            //Assert
            Assert.Equal(10, ecolamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsMax_ItRemainsMax()
        {
            //Arrange
            EcoLamp lamp = new EcoLamp("EcoLampada");

            //Assert
            lamp.Toggle();
            lamp.increaseBrightness();

            //Act
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMoreThanMin_ItDecreasesByOne()
        {
            //Arrrange
            EcoLamp lamp = new EcoLamp("EcoLampada");

            //Act
            lamp.Toggle();
            lamp.decreaseBrightness();

            //Assert
            Assert.Equal(9, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMin_ItRemainsMin()
        {
            //Arrange
            EcoLamp lamp = new EcoLamp("EcoLampada");

            //Act
            lamp.Toggle();
            for (int i = 0; i < 11; i++)
            {
                lamp.decreaseBrightness();
            }

                //Assert
            Assert.Equal(1, lamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenPowerSaveModeIsActiveted_ItMaxBrightnessIs5()
        {

            //Arrange
            EcoLamp lamp = new EcoLamp("EcoLampada");

            //Act
            lamp.Toggle();
            lamp.SwitchPowerSaveMode();

                
            //Assert
            Assert.Equal(5, lamp.maxBrightness);
        }

            




    }



}

