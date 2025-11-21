namespace SmartHouse.domain
{
    public class Lamp : LampModel
    {
        //Costants
        private const int MIN_BRIGHTNESS = 1;
        private const int MAX_BRIGHTNESS = 10;
        //Constructor
        public Lamp(string lampsName, bool isEco) : base(lampsName, isEco)
        {
            Brightness = MAX_BRIGHTNESS;
        }
        //Methods
        public override void SwitchOnOff()
        {
            {
                if (IsOn)
                    IsOn = false;
                else
                    IsOn = true;
            }
        }
        public override void increaseBrightness()
        {
            if (IsOn == true)
            {
                if (Brightness >= MAX_BRIGHTNESS)
                    Brightness = MAX_BRIGHTNESS;
                else
                    Brightness += 1;
            }
        }
        public override void decreaseBrightness()
        {
            if (IsOn == true)
            {
                if (Brightness <= MIN_BRIGHTNESS)
                        Brightness = MIN_BRIGHTNESS;
                else
                        Brightness -= 1;
            }
        }

        
    }
}        
    
