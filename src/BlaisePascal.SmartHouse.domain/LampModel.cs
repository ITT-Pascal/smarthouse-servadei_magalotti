using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class LampModel //base class
    {
        //properties
        public Guid IdLamps { get; protected set; }
        public bool IsOn { get; protected set; }
        public int Brightness { get; set; }
        public bool IsEco { get; protected set; }
        public string Name { get; protected set; }
        //constructor
        public LampModel(string lampsName, bool isEco)
        {
            IdLamps = Guid.NewGuid();
            Name = lampsName;
            IsEco = isEco;
            IsOn = false;
        }
        //methods
        public virtual void SwitchOnOff()
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

        

    

