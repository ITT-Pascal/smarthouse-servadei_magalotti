using SmartHouse.domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    public class AirConditioner
    {
        public bool IsOn { get; private set; }
        public string Name { get; private set; }
        public Guid IdAirConditioner { get; private set; }
        public DeviceStatus Status { get; private set; }
        public double Temperature { get; private set; }
        public AirConditionerStatus AirConditionerStatus { get; private set; }

        public AirConditioner(string name)
        {
            Name = name;
            IdAirConditioner = Guid.NewGuid();
            IsOn = false;
            Status = DeviceStatus.Unknown;

        }
         public AirConditioner(string name, Guid idAirConditioner, bool isOn, double temperature)
        {
            Name = name;
            IdAirConditioner = idAirConditioner;
            IsOn = isOn;
            Temperature = temperature;
            if (isOn)
                Status = DeviceStatus.On;
            else
                Status = DeviceStatus.Unknown;
        }
        public AirConditioner() {}
        
        public void Rename(string newName)
        {
            Name = newName;
        }

        public void TurnOn()
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Air conditioner is already on.");
            }
            IsOn = true;
            Status = DeviceStatus.On;
        }

        public void TurnOff()
        {
            if (Status == DeviceStatus.On)
            {
                IsOn = false;
                Status = DeviceStatus.Off;
            }
            throw new InvalidOperationException("Air conditioner is already off.");
            
        }

        public void Toggle()
        {
            if (Status == DeviceStatus.On)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }

        public void SetTemperature(double temperature)
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot set temperature when the air conditioner is off.");
            }
            Temperature = temperature;
        }

        public void IncreaseTemperature(double increment)
        {
            if (!(Status == DeviceStatus.On))
            {
                throw new InvalidOperationException("Cannot increase temperature when the air conditioner is off.");
            }
            Temperature += increment;
        }

        public void DecreaseTemperature(double decrement)
        {
            if (!(Status == DeviceStatus.On))
                {
                throw new InvalidOperationException("Cannot decrease temperature when the air conditioner is off.");
            }
            Temperature -= decrement;
        }

        public void SetAirConditionerStatus(AirConditionerStatus status)
        {
            if (Status == DeviceStatus.On )
            {
                AirConditionerStatus = status;
            }
            throw new InvalidOperationException("Cannot set air conditioner status when the air conditioner is not on.");           
        }
    }
}
