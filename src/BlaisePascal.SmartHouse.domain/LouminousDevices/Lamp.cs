namespace SmartHouse.domain
{
    public class Lamp : LampModel
    {
        //Costants
        private const int MIN_BRIGHTNESS = 1;
        private const int MAX_BRIGHTNESS = 10;
        //Constructor
        public Lamp(string name, Guid id, bool isOn, bool isEco) : base(name, id, isOn, isEco)
        {
            IsEco = isEco;
            Brightness = MAX_BRIGHTNESS;
        }
        public Lamp(string name) : base(name)
        {
            Brightness = MAX_BRIGHTNESS;
        }
        //Methods
        public override void Toggle()
        {
            base.Toggle();
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
    
