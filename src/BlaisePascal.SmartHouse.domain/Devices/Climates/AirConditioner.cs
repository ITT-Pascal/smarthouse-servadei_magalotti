using SmartHouse.domain.Devices;
using SmartHouse.domain.Devices.Abstractions;
using SmartHouse.domain.Devices.Climates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class AirConditioner: ClimateDevices
    {
        //Properties 
        public AirConditionerStatus AirConditionerStatus { get; private set; }
        //Constructors
        public AirConditioner(string name): base(name) { }
        public AirConditioner(string name, Guid id, bool isOn, double temperature): base(name, id, isOn, temperature) { }
        public AirConditioner(): base() { }
        //Methods
        public void SetAirConditionerStatus(AirConditionerStatus status)
        {
            if (Status == DeviceStatus.On)
            { 
                AirConditionerStatus = status;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
            else 
                throw new InvalidOperationException("Cannot set air conditioner status when the air conditioner is not on.");           
        }
    }
}
