using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public  class MainLamps
    {
        public Guid IdLamps { get; private set; }
        public bool IsOn { get;  private set; }
        public int Brightness { get; private set; }
        public bool IsEco { get; private set; }
        public void SwitchOnOff ()
        {
            {
                if (IsOn)
                    IsOn = false;
                else
                    IsOn = true;
               

            }


        }

    }
}
