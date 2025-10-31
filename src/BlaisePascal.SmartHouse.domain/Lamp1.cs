using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse.domain
{
    public class Lamp1
    {

        public bool IsOn { get; private set; }
        

        public int Brightness
        {
            get => default;
            set
            {
            }
        }

        public void switchOnOff()
        {
            throw new System.NotImplementedException();
        }

        public void increaseBrightness()
        {
            throw new System.NotImplementedException();
        }

        public void decreaseBrightness()
        {
            throw new System.NotImplementedException();
        }
    }
}