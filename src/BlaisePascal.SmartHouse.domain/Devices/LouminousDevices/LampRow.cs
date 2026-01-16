using SmartHouse.domain.Devices;
using SmartHouse.domain.Devices.Abstractions;
using SmartHouse.domain.Devices.LouminousDevices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.domain.Devices.LouminousDevices
{
    public class LampRow: LampModel
    {
        public List<LampModel> LampsTot { get; private set; }
        //Costructor
        public LampRow()
        {
            LampsTot = new List<LampModel>();
            CreatedAtUtc = DateTime.UtcNow;
        }
        //Methods
        public void AddLamp()
        {
            Lamp Lamp1 = new Lamp("Lampada");
            LampsTot.Add(new Lamp("Lampada"));
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void AddEcoLamp()
        {
            EcoLamp EcoLamp1 = new EcoLamp("EcoLampada");
            LampsTot.Add(new EcoLamp("EcoLampada"));
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void AddLampByType(bool IsLamp)
        {
            LastModifiedAtUtc = DateTime.UtcNow;
            if (IsLamp == true)
                AddLamp();
            AddEcoLamp();
        }

        public void TurnLampOnByPosition(int Position)
        {
            if (Position < 0) throw new ArgumentOutOfRangeException("position");
            LastModifiedAtUtc = DateTime.UtcNow;
            if (LampsTot[Position].IsOn == false)
                LampsTot[Position].TurnOn();
        }
        public void TurnLampOffByPosition(int Position)
        {
            if (Position < 0) throw new ArgumentOutOfRangeException("position");
            LastModifiedAtUtc = DateTime.UtcNow;
            if (LampsTot[Position].Status == DeviceStatus.On)
                LampsTot[Position].TurnOff();  
        }
        public void TurnOnAll()
        {
            LastModifiedAtUtc = DateTime.UtcNow;
            for (int i = 0; i < LampsTot.Count(); i++)
                if (LampsTot[i].Status != DeviceStatus.On)
                    LampsTot[i].TurnOn();  
        }
        public void TurnOffAll()
        {
            LastModifiedAtUtc = DateTime.UtcNow;
            for (int i = 0; i < LampsTot.Count(); i++)
                if (LampsTot[i].Status == DeviceStatus.On)
                    LampsTot[i].TurnOff();    
        }
        public void TurnLampOffById(Guid id)
        {
            LastModifiedAtUtc = DateTime.UtcNow;
            for (int i = 0; i < LampsTot.Count(); i++)
            
                if (LampsTot[i].GetId() == id)
                    if (LampsTot[i].Status == DeviceStatus.On)
                        LampsTot[i].TurnOff(); 
        }
        public void TurnLampOffByName(string name)
        {
            LastModifiedAtUtc = DateTime.UtcNow;
            for (int i = 0; i < LampsTot.Count(); i++)
            
                if (LampsTot[i].GetName() == name)
                    if (LampsTot[i].Status == DeviceStatus.On)
                        LampsTot[i].TurnOff();  
        }
        public void RemoveLampByPositionAndId(Guid id, int position)
        {
                if (position < 0) throw new ArgumentOutOfRangeException("position");
                for (int i = 0; i < LampsTot.Count(); i++)
                     if (LampsTot[i].GetId() == id)
                     {
                        LampsTot.Remove(LampsTot[position]);
                        LastModifiedAtUtc = DateTime.UtcNow;
                     }
                        
                
        }
        public void RemoveLampByPositionAndName(string name, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetName() == name) 
                {
                    LampsTot.Remove(LampsTot[position]);
                    LastModifiedAtUtc = DateTime.UtcNow;
                }
                    
        }
        public void SetIntensityForAllLamps(int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++) 
            {
                LampsTot[i].Brightness = brightness;
                LastModifiedAtUtc = DateTime.UtcNow;
            }
               
        }
        public void SetIntensityLampById(Guid id, int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetId() == id) 
                 {
                    LampsTot[i].Brightness = brightness;
                    LastModifiedAtUtc = DateTime.UtcNow;
                 }               
        }
        public void SetIntensityByLampName(string name, int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetName() == name)
                 {
                    LampsTot[i].Brightness = brightness;
                    LastModifiedAtUtc = DateTime.UtcNow;
                 }                   
        }
        public LampModel FindLampWithMaxIntensity()
        {
            LampModel model = null;
            int highestBrightness = 0;
            for (int i = 0; i < LampsTot.Count(); i++) 
                 if (LampsTot[i].Brightness > highestBrightness)
                    highestBrightness = LampsTot[i].Brightness;
                 else
                    model = LampsTot[i];
            return model;
        }
        public LampModel FindLampWithMinIntensity()
        {
            LampModel model = null;
            int lowestBrightness = 10;
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].Brightness < lowestBrightness)
                     lowestBrightness = LampsTot[i].Brightness;
                 else
                    model = LampsTot[i]; 
            return model;
        }
        public List<LampModel> FindLampsByIntensityRange(int min, int max)
        {
            List<LampModel> brightnessLampFinder = new List<LampModel>();
            if (min > max) throw new ArgumentException("the min value cannot be higher than the max value");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].Brightness >= min && LampsTot[i].Brightness <= max)
                     brightnessLampFinder.Add(LampsTot[i]);        
            return brightnessLampFinder;
        }
        public List<LampModel> FindAllLampOn()
        {
            List<LampModel> IsOnLampList = new List<LampModel>();
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].IsOn == true)
                     IsOnLampList.Add(LampsTot[i]);
            return IsOnLampList;
        }
        public List<LampModel> FindAllLampOff()
        {
            List<LampModel> IsOffLampList = new List<LampModel>();
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].IsOn == false)
                     IsOffLampList.Add(LampsTot[i]);   
            return IsOffLampList;
        }
        public LampModel? FindLampById(Guid id)
        {
            LampModel model = null;
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetId() == id)
                     model = LampsTot[i];
            return model;
        }
        public List<LampModel> SortByBrightness(bool descending)
        {
            List<LampModel> anotherLampModelList = new List<LampModel>();
            List<LampModel> order = new List<LampModel>();
            if (LampsTot.Count != 0)
            {
                if (descending == true)
                {
                    for (int i = 0; i < LampsTot.Count; i++)
                         anotherLampModelList.Add(LampsTot[i]);
                    for (int i = 0; i < anotherLampModelList.Count; i++)
                    {
                        FindLampWithMaxIntensity();
                        order.Add(anotherLampModelList[i]);
                        anotherLampModelList.Remove(anotherLampModelList[i]);
                    }
                    return order;
                }
                LampsTot.Sort();
                return LampsTot;               
            }
            throw new Exception("the list is empty!");
        }      
    }
}
