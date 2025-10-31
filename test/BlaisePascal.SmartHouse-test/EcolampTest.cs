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
                Ecolamp ecolamp = new Ecolamp();
                ecolamp.switchOnOff();
                Assert.True(ecolamp.IsOn);
            }

            [Fact]
            public void switchIsOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
            {
                Ecolamp ecolamp = new Ecolamp();
                ecolamp.switchOnOff();
                ecolamp.switchOnOff();
                Assert.False(ecolamp.IsOn);
            }

            [Fact]
            //&/7ecccococo
            public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
            {
                Ecolamp ecolamp = new Ecolamp();
                ecolamp.decreaseBrightness();
                ecolamp.increaseBrightness();
                Assert.Equal(10, ecolamp.Brightness);
            }

            [Fact]
            public void increaseBrightness_WhenBrightnessIsMax_ItRemainsMax()
            {
                Ecolamp lamp = new Ecolamp();
                lamp.increaseBrightness();
                Assert.Equal(10, lamp.Brightness);
            }

            [Fact]
            public void decreaseBrightness_WhenBrightnessIsMoreThanMin_ItDecreasesByOne()
            {
                Ecolamp lamp = new Ecolamp();
                lamp.decreaseBrightness();
                Assert.Equal(9, lamp.Brightness);
            }

            [Fact]
            public void decreaseBrightness_WhenBrightnessIsMin_ItRemainsMin()
            {
                Ecolamp lamp = new Ecolamp();
                for (int i = 0; i < 11; i++)
                {
                    lamp.decreaseBrightness();
                }
                Assert.Equal(1, lamp.Brightness);
            }
        




    }



}

