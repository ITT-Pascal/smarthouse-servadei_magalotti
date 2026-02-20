using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.LouminousDevicesTests
{
    public class EcoLampComprehensiveTests
    {
        [Fact]
        public void Constructor_InitializesStandardLimit()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.Equal(10, ecoLamp.MaxBrightness);
        }

        [Fact]
        public void TurnOn_UpdatesTurnOnHours()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            DateTime before = DateTime.UtcNow.AddSeconds(-1);
            ecoLamp.TurnOn();
            Assert.True(ecoLamp.TurnOnHours > before);
        }

        [Fact]
        public void SwitchPowerSaveMode_ActivatesCorrectly()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.SwitchPowerSaveMode();
            Assert.True(ecoLamp.IsPowerSaveMode);
        }

        [Fact]
        public void SwitchPowerSaveMode_LimitsMaxToFive()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.SwitchPowerSaveMode();
            Assert.Equal(5, ecoLamp.MaxBrightness);
        }

        [Fact]
        public void SwitchPowerSaveMode_ClampsCurrentBrightness()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(10);
            ecoLamp.SwitchPowerSaveMode();
            Assert.Equal(5, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SwitchPowerSaveMode_DeactivatesCorrectly()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.SwitchPowerSaveMode();
            ecoLamp.SwitchPowerSaveMode();
            Assert.False(ecoLamp.IsPowerSaveMode);
        }

        [Fact]
        public void SwitchPowerSaveMode_RestoresLimitTen()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.SwitchPowerSaveMode();
            ecoLamp.SwitchPowerSaveMode();
            Assert.Equal(10, ecoLamp.MaxBrightness);
        }

        [Fact]
        public void IncreaseBrightness_WhenAtMax_DoesNotExceed()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(10);
            ecoLamp.IncreaseBrightness();
            Assert.Equal(10, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void IncreaseBrightness_WhenAtEcoMax_DoesNotExceed()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SwitchPowerSaveMode();
            ecoLamp.SetBrightness(5);
            ecoLamp.IncreaseBrightness();
            Assert.Equal(5, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void DecreaseBrightness_WhenAtMin_DoesNotGoLower()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(1);
            ecoLamp.DecreaseBrightness();
            Assert.Equal(1, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetBrightness_AboveMax_ClampsToMax()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(15);
            Assert.Equal(10, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetBrightness_BelowMin_ClampsToMin()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(-5);
            Assert.Equal(1, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void Toggle_TurnsOn_SetsTime()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.Toggle();
            Assert.NotEqual(default(DateTime), ecoLamp.TurnOnHours);
        }

        [Fact]
        public void TurnOff_SetsStatusCorrectly()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.TurnOff();
            Assert.Equal(DeviceStatus.Off, ecoLamp.Status);
        }

        [Fact]
        public void Rename_ChangesProperty()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.Rename("LampadaEco");
            Assert.Equal("LampadaEco", ecoLamp.Name);
        }

        [Fact]
        public void IsEco_IsInitiallyFalseByCostruttoreBase()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.False(ecoLamp.IsEco); 
        }

        [Fact]
        public void MinBrightness_IsAlwaysOne()
        {
            Assert.Equal(1, AbstractLamp.MinBrightness);
        }

        [Fact]
        public void LastModified_UpdatesOnPowerSaveSwitch()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            DateTime marker = ecoLamp.LastModifiedAtUtc;
            ecoLamp.SwitchPowerSaveMode();
            Assert.NotEqual(marker, ecoLamp.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnIncrease()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            DateTime marker = ecoLamp.LastModifiedAtUtc;
            ecoLamp.IncreaseBrightness();
            Assert.NotEqual(marker, ecoLamp.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnDecrease()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            DateTime marker = ecoLamp.LastModifiedAtUtc;
            ecoLamp.DecreaseBrightness();
            Assert.NotEqual(marker, ecoLamp.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_UpdatesOnSetBrightness()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            DateTime marker = ecoLamp.LastModifiedAtUtc;
            ecoLamp.SetBrightness(7);
            Assert.NotEqual(marker, ecoLamp.LastModifiedAtUtc);
        }

        [Fact]
        public void TurnOn_WhenAlreadyOn_Throws()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            Assert.Throws<InvalidOperationException>(() => ecoLamp.TurnOn());
        }

        [Fact]
        public void TurnOff_WhenAlreadyOff_Throws()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.Throws<InvalidOperationException>(() => ecoLamp.TurnOff());
        }

        [Fact]
        public void GetId_ReturnsCorrectGuid()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.Equal(ecoLamp.Id, ecoLamp.GetId());
        }

        [Fact]
        public void GetName_ReturnsCorrectString()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.Equal("EcoLamp", ecoLamp.GetName());
        }

        [Fact]
        public void CurrentBrightness_StartsAtOne()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.Equal(1, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void SetBrightness_WhenOff_DoesNotChangeValue()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.SetBrightness(9);
            Assert.Equal(1, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void IncreaseBrightness_WhenOff_DoesNotChangeValue()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.IncreaseBrightness();
            Assert.Equal(1, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void DecreaseBrightness_WhenOff_DoesNotChangeValue()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(5);
            ecoLamp.TurnOff();
            ecoLamp.DecreaseBrightness();
            Assert.Equal(5, ecoLamp.CurrentBrightness.Value);
        }

        [Fact]
        public void Id_IsAutomaticallyGenerated()
        {
            EcoLamp ecoLamp = new EcoLamp("EcoLamp");
            Assert.NotEqual(Guid.Empty, ecoLamp.Id);
        }
    }
}
