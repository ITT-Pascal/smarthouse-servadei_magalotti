using SmartHouse.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_test
{
    public class EcolampTest
    {
          
            [Fact]
            public void switchIsOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
            {
                //Arrange
                Ecolamp ecolamp = new Ecolamp("EcoLampada", true);

                //Act
                ecolamp.SwitchOnOff();

                //Assert
                Assert.True(ecolamp.IsOn);
            }

            [Fact]
            public void switchIsOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
            {
                //Arrange
                Ecolamp ecolamp = new Ecolamp("EcoLampada", true);

                //Act
                ecolamp.SwitchOnOff();
                ecolamp.SwitchOnOff();

                //Assert
                Assert.False(ecolamp.IsOn);
            }

            [Fact]
            public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
            {
                //Assert
                Ecolamp ecolamp = new Ecolamp("EcoLampada", true);
                //Act
                ecolamp.SwitchOnOff();
                ecolamp.decreaseBrightness();
                ecolamp.increaseBrightness();

                //Assert
                Assert.Equal(10, ecolamp.Brightness);
            }

            [Fact]
            public void increaseBrightness_WhenBrightnessIsMax_ItRemainsMax()
            {
                //Arrange
                Ecolamp lamp = new Ecolamp("EcoLampada", true);

                //Assert
                lamp.SwitchOnOff();
                lamp.increaseBrightness();

                //Act
                Assert.Equal(10, lamp.Brightness);
            }

            [Fact]
            public void decreaseBrightness_WhenBrightnessIsMoreThanMin_ItDecreasesByOne()
            {
                //Arrrange
                Ecolamp lamp = new Ecolamp("EcoLampada", true);

                //Act
                lamp.SwitchOnOff();
                lamp.decreaseBrightness();

                //Assert
                Assert.Equal(9, lamp.Brightness);
            }

            [Fact]
            public void decreaseBrightness_WhenBrightnessIsMin_ItRemainsMin()
            {
                //Arrange
                Ecolamp lamp = new Ecolamp("EcoLampada", true);

                //Act
                lamp.SwitchOnOff();
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
                Ecolamp lamp = new Ecolamp("EcoLampada", true);

                //Act
                lamp.SwitchOnOff();
                lamp.SwitchPowerSaveMode();

                
                //Assert
                Assert.Equal(5, lamp.maxBrightness);
            }

            




    }



}

