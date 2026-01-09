using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.domain.Devices.LouminousDevices
{
    public interface ILampRow
    {
        void AddLamp();
        void AddEcoLamp();
        void AddLampByType(bool IsLamp);
        void TurnLampOnByPosition(int Position);
        void TurnLampOffByPosition(int Position);
        void TurnOnAll();
        void TurnOffAll();
        void TurnLampOffById(Guid id);
        void TurnLampOffByName(string name);
        void RemoveLampByPositionAndId(Guid id, int position);
        void RemoveLampByPositionAndName(string name, int position);
        void SetIntensityForAllLamps(int brightness);
        void SetIntensityLampById(Guid id, int brightness);
        LampModel FindLampWithMaxIntensity();
        LampModel FindLampWithMinIntensity();
        List<LampModel> FindLampsByIntensityRange(int min, int max);
        List<LampModel> FindAllLampOn();
        List<LampModel> FindAllLampOff();
        LampModel? FindLampById(Guid id);
        List<LampModel> SortByBrightness(bool descending);

    }
}
