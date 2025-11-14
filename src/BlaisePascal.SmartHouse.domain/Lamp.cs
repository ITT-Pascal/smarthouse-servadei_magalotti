namespace SmartHouse.domain
{
    public class Lamp:MainLamps
    {
        const int MIN_BRIGHTNESS = 1;
        const int MAX_BRIGHTNESS = 10;

        //Properties   
        
        
    
        //Constructor
        public Lamp(string lampsName,bool isEco):base(lampsName,isEco)
        {
            Brightness = MAX_BRIGHTNESS;

        }

        //Methods
        

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