using SmartHouse.domain.Devices.Abstractions;
using SmartHouse.domain.Devices.LouminousDevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartHouse.domain
{
    public class LampModel: AbstractDevice, ILampModel
    {
        //properties
        public int Brightness { get; set; }
        public bool IsEco { get; protected set; }
        //constructor
        public LampModel(string name) : base(name) { }
        public LampModel(string name, Guid id, bool isOn, bool isEco) : base(name, id) 
        { 
            IsEco = isEco;
        }
        public LampModel() : base() { }
        //methods
        public override void TurnOn()
        {
            base.TurnOn();
        }
        public override void TurnOff()
        {
            base.TurnOff();
        }

        public override void Toggle() 
        {
            base.Toggle();
        }
        public virtual void increaseBrightness() { }
        public virtual void decreaseBrightness() { }   
        
        public Guid GetId() { return Id;}
        public string GetName() { return Name; } 
    }
}

        

    

