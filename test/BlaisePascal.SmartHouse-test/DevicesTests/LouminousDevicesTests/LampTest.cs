using SmartHouse.domain;
namespace SmartHouse_test.DevicesTests.LouminousDevicesTests

{
    public class LampTests
    {
        [Fact]
        public void switchIsOnOff_WhenIsOnIsFalse_ItChangesItToTrue()
        {

            //Arrange
            Lamp lamp = new Lamp("Lampada");

            //Act
            lamp.Toggle();

            //Assert
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void switchIsOnOff_WhenIsOnIsTrue_ItChangesItToFalse()
        {
            //Arrange
            Lamp lamp = new Lamp("Lampada");

            //Act
            lamp.Toggle();
            lamp.Toggle();

            //Assert
            Assert.False(lamp.IsOn);
        }

        [Fact]

        public void increaseBrightness_WhenBrightnessIsLessThanMax_ItIncreasesByOne()
        {
            //Arrange
            Lamp lamp = new Lamp("Lampada");

            //Act
            lamp.Toggle();
            lamp.decreaseBrightness();
            lamp.increaseBrightness();

            //Assert
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void increaseBrightness_WhenBrightnessIsMax_ItRemainsMax()
        {
            //Arrange
            Lamp lamp = new Lamp("Lampada");

            //Act
            lamp.Toggle();
            lamp.increaseBrightness();

            //Assert
            Assert.Equal(10, lamp.Brightness);
        }

        [Fact]
        public void decreaseBrightness_WhenBrightnessIsMoreThanMin_ItDecreasesByOne()
        {

            //Arrange
            Lamp lamp = new Lamp("Lampada");

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
            Lamp lamp = new Lamp("Lampada");

            //Act
            lamp.Toggle();
            for (int i = 0; i < 11; i++)
            {
                lamp.decreaseBrightness();
            }

            //Assert
            Assert.Equal(1, lamp.Brightness);
        }
    }
}