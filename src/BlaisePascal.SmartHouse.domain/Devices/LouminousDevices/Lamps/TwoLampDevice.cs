using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices
{
    public class TwoLampsDevice : AbstractDevice
    {
        public AbstractLamp Lamp1 { get; private set; }
        public AbstractLamp Lamp2 { get; private set; }

        public TwoLampsDevice(Name name, AbstractLamp lamp1, AbstractLamp lamp2) : base(name)
        {
            if (lamp1 == null) throw new ArgumentNullException(nameof(lamp1));
            if (lamp2 == null) throw new ArgumentNullException(nameof(lamp2));

            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }

        public TwoLampsDevice(Name name, Guid id, AbstractLamp lamp1, AbstractLamp lamp2)
            : base(name, id)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }
        public bool AreBothLampsOn()
        {

            {
                return Lamp1.Status == DeviceStatus.On && Lamp2.Status == DeviceStatus.On;
            }
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Lamp1.TurnOn();
            Lamp2.TurnOn();
            UpdateLastModified();
        }

        public override void TurnOff()
        {
            base.TurnOff();
            Lamp1.TurnOff();
            Lamp2.TurnOff();
            UpdateLastModified();
        }

        public void ToggleBothLamps()
        {
            Lamp1.Toggle();
            Lamp2.Toggle();
            UpdateLastModified();
        }

        public void AlternateStatesLamp()
        {
            Lamp1.Toggle();
            Lamp2.Toggle();
            UpdateLastModified();
        }

        public void IncreaseBrightnessBoth()
        {
            Lamp1.IncreaseBrightness();
            Lamp2.IncreaseBrightness();
            UpdateLastModified();
        }

        public void DecreaseBrightnessBoth()
        {
            Lamp1.DecreaseBrightness();
            Lamp2.DecreaseBrightness();
            UpdateLastModified();
        }
    }
}
