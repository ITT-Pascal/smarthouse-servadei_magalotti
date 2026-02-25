using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.Lamps;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.LouminousDevicesTests
{
    public class TwoLampsDeviceTests
    {
        [Fact]
        public void Constructor_NullLamp1_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new TwoLampsDevice("Device", null, new Lamp("L2")));
        }

        [Fact]
        public void TurnOn_TurnsBothLampsOn()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            twoLampsDevice.TurnOn();
            Assert.True(l1.IsOn && l2.IsOn);
        }

        [Fact]
        public void TurnOff_TurnsBothLampsOff()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            twoLampsDevice.TurnOn();
            twoLampsDevice.TurnOff();
            Assert.False(l1.IsOn || l2.IsOn);
        }

        [Fact]
        public void AreBothLampsOn_TrueWhenOn()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            l1.TurnOn();
            l2.TurnOn();
            Assert.True(twoLampsDevice.AreBothLampsOn());
        }

        [Fact]
        public void AreBothLampsOn_FalseWhenOneOff()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            l1.TurnOn();
            Assert.False(twoLampsDevice.AreBothLampsOn());
        }

        [Fact]
        public void IncreaseBrightnessBoth_Works()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            twoLampsDevice.TurnOn();
            l1.SetBrightness(new Brightness(5));
            l2.SetBrightness(new Brightness(5));
            twoLampsDevice.IncreaseBrightnessBoth();
            Assert.Equal(6, l1.CurrentBrightness.Value);
        }

        [Fact]
        public void DecreaseBrightnessBoth_Works()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            twoLampsDevice.TurnOn();
            l1.SetBrightness(new Brightness(5));
            l2.SetBrightness(new Brightness(5));
            twoLampsDevice.DecreaseBrightnessBoth();
            Assert.Equal(4, l2.CurrentBrightness.Value);
        }

        [Fact]
        public void ToggleBoth_SwitchesStates()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            twoLampsDevice.ToggleBothLamps();
            Assert.True(l1.IsOn && l2.IsOn);
        }

        [Fact]
        public void AlternateStates_SwitchesStates()
        {
            Lamp l1 = new Lamp("L1");
            Lamp l2 = new Lamp("L2");
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", l1, l2);
            twoLampsDevice.AlternateStatesLamp();
            Assert.True(l1.IsOn && l2.IsOn);
        }

        [Fact]
        public void Rename_Works()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", new Lamp("L1"), new Lamp("L2"));
            twoLampsDevice.Rename("NuovoNome");
            Assert.Equal("NuovoNome", twoLampsDevice.Name.String);
        }

        [Fact]
        public void Id_IsSet()
        {
            TwoLampsDevice twoLampsDevice = new TwoLampsDevice("TwoLamps", new Lamp("L1"), new Lamp("L2"));
            Assert.NotEqual(Guid.Empty, twoLampsDevice.Id);
        }
    }
}