using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain
{
    internal class AirConditioner
    {
        public bool IsOn { get; private set; }
        public string Name { get; private set; }
        public Guid IdAirConditioner { get; private set; }
        public DeviceStatus Status { get; private set; }
        public double Temperature { get; private set; }

        public AirConditioner(string name)
        {
            Name = name;
            IdAirConditioner = Guid.NewGuid();
            IsOn = false;
        }
         public AirConditioner(string name, Guid idAirConditioner, bool isOn)
        {
            Name = name;
            IdAirConditioner = idAirConditioner;
            IsOn = isOn;
        }
        public AirConditioner() {}
        
        public void Rename(string newName)
        {
            Name = newName;
        }

        public void TurnOn()
        {
            if (IsOn)
            {
                throw new InvalidOperationException("Air conditioner is already on.");
            }
            IsOn = true;
            Status = DeviceStatus.On;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Status = DeviceStatus.Off;
            }
            throw new InvalidOperationException("Air conditioner is already off.");
            
        }

        public void Toggle()
        {
            if (IsOn)
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
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot set temperature when the air conditioner is off.");
            }
            Temperature = temperature;
        }

        public void IncreaseTemperature(double increment)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot increase temperature when the air conditioner is off.");
            }
            Temperature += increment;
        }

        public void DecreaseTemperature(double decrement)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Cannot decrease temperature when the air conditioner is off.");
            }
            Temperature -= decrement;
        }
    }
}
