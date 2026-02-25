using BlaisePascal.SmartHouse.Domain.Devices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices
{
    public class LampRow : AbstractDevice
    {
        private List<AbstractLamp> _lamps;

        public LampRow(Name name) : base(name)
        {
            _lamps = new List<AbstractLamp>();
        }

        public LampRow(Name name, Guid id)
            : base(name, id)
        {
            _lamps = new List<AbstractLamp>();
        }

        public void SwitchOn()
        {
            TurnOn();
            for (int i = 0; i < _lamps.Count; i++)
            {
                _lamps[i].TurnOn();
            }
            UpdateLastModified();
        }

        public void SwitchOn(Guid id)
        {
            var lamp = FindLampById(id);
            if (lamp != null)
            {
                lamp.TurnOn();
                UpdateLastModified();
            }
        }

        public void SwitchOn(Name name)
        {
            if (name == null) return;
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Name == name)
                {
                    _lamps[i].TurnOn();
                    UpdateLastModified();
                    break;
                }
            }
        }

        public void SwitchOff()
        {
            TurnOff();
            for (int i = 0; i < _lamps.Count; i++)
            {
                _lamps[i].TurnOff();
            }
            UpdateLastModified();
        }

        public void SwitchOff(Guid id)
        {
            var lamp = FindLampById(id);
            if (lamp != null)
            {
                lamp.TurnOff();
                UpdateLastModified();
            }
        }

        public void SwitchOff(Name name)
        {
            if (name == null) return;
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Name == name)
                {
                    _lamps[i].TurnOff();
                    UpdateLastModified();
                    break;
                }
            }
        }

        public void AddLamp(AbstractLamp lamp)
        {
            if (lamp == null) return;
            if (FindLampById(lamp.Id) == null)
            {
                _lamps.Add(lamp);
                UpdateLastModified();
            }
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            if (lamp != null && position >= 0 && position <= _lamps.Count)
            {
                _lamps.Insert(position, lamp);
                UpdateLastModified();
            }
        }

        public void RemoveLamp(Guid id)
        {
            var lamp = FindLampById(id);
            if (lamp != null)
            {
                _lamps.Remove(lamp);
                UpdateLastModified();
            }
        }

        public void RemoveLamp(Name name)
        {
            if (name == null) return;
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Name == name)
                {
                    _lamps.RemoveAt(i);
                    UpdateLastModified();
                    break;
                }
            }
        }

        public void RemoveLampInPosition(int position)
        {
            if (position >= 0 && position < _lamps.Count)
            {
                _lamps.RemoveAt(position);
                UpdateLastModified();
            }
        }

        public void SetIntensityForAllLamps(Brightness intensity)
        {
            for (int i = 0; i < _lamps.Count; i++)
            {
                _lamps[i].SetBrightness(intensity);
            }
            UpdateLastModified();
        }

        public void SetIntensityForLamp(Guid id, Brightness intensity)
        {
            var lamp = FindLampById(id);
            if (lamp != null)
            {
                lamp.SetBrightness(intensity);
                UpdateLastModified();
            }
        }

        public void SetIntensityForLamp(Name name, Brightness intensity)
        {
            if (name == null) return;
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Name == name)
                {
                    _lamps[i].SetBrightness(intensity);
                    UpdateLastModified();
                    break;
                }
            }
        }

        public AbstractLamp? FindLampWithMaxIntensity()
        {
            if (_lamps.Count == 0) return null;
            AbstractLamp max = _lamps[0];
            for (int i = 1; i < _lamps.Count; i++)
            {
                if (_lamps[i].CurrentBrightness.Value > max.CurrentBrightness.Value)
                {
                    max = _lamps[i];
                }
            }
            return max;
        }

        public AbstractLamp? FindLampWithMinIntensity()
        {
            if (_lamps.Count == 0) return null;
            AbstractLamp min = _lamps[0];
            for (int i = 1; i < _lamps.Count; i++)
            {
                if (_lamps[i].CurrentBrightness.Value < min.CurrentBrightness.Value)
                {
                    min = _lamps[i];
                }
            }
            return min;
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> result = new List<AbstractLamp>();
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].CurrentBrightness.Value >= min && _lamps[i].CurrentBrightness.Value <= max)
                {
                    result.Add(_lamps[i]);
                }
            }
            return result;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> result = new List<AbstractLamp>();
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Status == DeviceStatus.On)
                {
                    result.Add(_lamps[i]);
                }
            }
            return result;
        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> result = new List<AbstractLamp>();
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Status == DeviceStatus.Off)
                {
                    result.Add(_lamps[i]);
                }
            }
            return result;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            for (int i = 0; i < _lamps.Count; i++)
            {
                if (_lamps[i].Id == id)
                {
                    return _lamps[i];
                }
            }
            return null;
        }

        public List<AbstractLamp> SortByIntensity(bool descending)
        {
            List<AbstractLamp> sorted = new List<AbstractLamp>();
            for (int i = 0; i < _lamps.Count; i++)
            {
                sorted.Add(_lamps[i]);
            }

            int n = sorted.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    bool condition;
                    if (descending)
                    {
                        condition = sorted[j].CurrentBrightness.Value < sorted[j + 1].CurrentBrightness.Value;
                    }
                    else
                    {
                        condition = sorted[j].CurrentBrightness.Value > sorted[j + 1].CurrentBrightness.Value;
                    }

                    if (condition)
                    {
                        AbstractLamp temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }
            return sorted;
        }
    }
}