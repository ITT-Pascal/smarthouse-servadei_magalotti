namespace SmartHouse.domain
{
    public class Lamp
    {
        const int MIN_BRIGHTNESS = 1;
        const int MAX_BRIGHTNESS = 10;

        //Properties   
        public bool IsOn { get; private set; }
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
            Brightness = MAX_BRIGHTNESS;

        }

        public void increaseBrightness()
        {
            if (IsOn == true)
                if (Brightness >= MAX_BRIGHTNESS)
                {
                    Brightness = MAX_BRIGHTNESS;
                }
                else
                {
                    Brightness += 1;
                }

        }

        public void decreaseBrightness()
        {
            if (IsOn == true)
                if (Brightness <= MIN_BRIGHTNESS)
                {
                    Brightness = MIN_BRIGHTNESS; 
                }
                else
                {
                    Brightness -= 1;
                }
                

        }
    }
}