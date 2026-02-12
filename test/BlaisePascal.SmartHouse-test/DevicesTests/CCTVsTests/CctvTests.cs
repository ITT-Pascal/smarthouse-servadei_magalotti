using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DevicesTests.CCTVsTests
{
    public class CctvTests
    {
        [Fact]
        public void Constructor_ShouldSetCorrectName()
        {
            Cctv cctv = new Cctv("Cctv");
            Assert.Equal("Cctv", cctv.Name);
        }

        [Fact]
        public void Constructor_EmptyName_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => new Cctv(""));
        }

        [Fact]
        public void TurnOn_WhenUnknown_ShouldSetStatusOn()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.TurnOn();
            Assert.Equal(DeviceStatus.On, cctv.Status);
        }

        [Fact]
        public void TurnOn_WhenAlreadyOn_ShouldThrowException()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.TurnOn();
            Assert.Throws<InvalidOperationException>(() => cctv.TurnOn());
        }

        [Fact]
        public void TurnOff_WhenOn_ShouldSetStatusOff()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.TurnOn();
            cctv.TurnOff();
            Assert.Equal(DeviceStatus.Off, cctv.Status);
        }

        [Fact]
        public void Toggle_WhenOff_ShouldTurnOn()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.Toggle();
            Assert.Equal(DeviceStatus.On, cctv.Status);
        }

        [Fact]
        public void Toggle_WhenOn_ShouldTurnOff()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.TurnOn();
            cctv.Toggle();
            Assert.Equal(DeviceStatus.Off, cctv.Status);
        }

        [Fact]
        public void Rename_ToValidName_ShouldUpdateName()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.Rename("CctvNuovo");
            Assert.Equal("CctvNuovo", cctv.Name);
        }

        [Fact]
        public void SetCctvStatus_WhenOff_ShouldThrowException()
        {
            Cctv cctv = new Cctv("Cctv");
            Assert.Throws<InvalidOperationException>(() => cctv.SetMode(CctvMode.Termic));
        }

        [Fact]
        public void Lock_ShouldSetStatusToOff()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.Lock();
            Assert.Equal(DeviceStatus.Off, cctv.Status);
        }

        [Fact]
        public void CreatedAtUtc_ShouldBeInitialized()
        {
            Cctv cctv = new Cctv("Cctv");
            Assert.NotEqual(default(DateTime), cctv.CreatedAtUtc);
        }

        [Fact]
        public void LastModified_ShouldUpdateOnRename()
        {
            Cctv cctv = new Cctv("Cctv");
            DateTime initial = cctv.LastModifiedAtUtc;
            cctv.Rename("Nuovo");
            Assert.NotEqual(initial, cctv.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_ShouldUpdateOnTurnOn()
        {
            Cctv cctv = new Cctv("Cctv");
            DateTime initial = cctv.LastModifiedAtUtc;
            cctv.TurnOn();
            Assert.NotEqual(initial, cctv.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_ShouldUpdateOnTurnOff()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.TurnOn();
            DateTime marker = cctv.LastModifiedAtUtc;
            cctv.TurnOff();
            Assert.NotEqual(marker, cctv.LastModifiedAtUtc);
        }

        [Fact]
        public void LastModified_ShouldUpdateOnSetStatus()
        {
            Cctv cctv = new Cctv("Cctv");
            cctv.TurnOn();
            DateTime marker = cctv.LastModifiedAtUtc;
            cctv.SetMode(CctvMode.NightVision);
            Assert.NotEqual(marker, cctv.LastModifiedAtUtc);
        }

        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            Cctv cctv = new Cctv("Cctv");
            Assert.NotEqual(Guid.Empty, cctv.Id);
        }
    }
}