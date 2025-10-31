namespace SmartHouse.domain
{
    public class Lamp
    {
        const int MIN_BRIGHTNESS = 1;
        const int MAX_BRIGHTNESS = 10;

        //Properties
        public  bool IsOn { get; private set; }
        public int Brightness { get; private set; }

        //Constructor
        public Lamp()
        {
            IsOn = false;
            Brightness = MAX_BRIGHTNESS;
        }

        //Methods
        public void switchOnOff()
        {
            if (IsOn)
                IsOn = false;
            else
                IsOn = true;
        }

        public void increaseBrightness()
        {
            Brightness = Math.Min(Brightness + 1, MAX_BRIGHTNESS);
        }

        public void decreaseBrightness()
        {
            Brightness = Math.Max(Brightness - 1, MIN_BRIGHTNESS);
        }
    }

    public class Lampclasse
    {
    }
}