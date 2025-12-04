using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.domain
{
    public class LampRow
    {
        //Properties
        public List<LampModel> LampsTot { get; private set; }
        //Costructor
        public LampRow()
        {
            LampsTot = new List<LampModel>();
        }
        //Methods
        public void AddLamp()
        {
            Lamp Lamp1 = new Lamp("Lampada");
            LampsTot.Add(new Lamp("Lampada"));
        }
        public void AddEcoLamp()
        {
            EcoLamp EcoLamp1 = new EcoLamp("EcoLampada");
            LampsTot.Add(new EcoLamp("EcoLampada"));
        }
        public void AddLampByType(bool IsLamp)
        {
            if (IsLamp == true)
                AddLamp();
            AddEcoLamp();
        }
        public void TurnLampOnByPosition(int Position)
        {
            if (Position < 0) throw new ArgumentOutOfRangeException("position");
            if (LampsTot[Position].IsOn == false)
                LampsTot[Position].Toggle();    
        }
        public void TurnLampOffByPosition(int Position)
        {
            if (Position < 0) throw new ArgumentOutOfRangeException("position");
            if (LampsTot[Position].IsOn == true)
                LampsTot[Position].Toggle();   
        }
        public void TurnOnAll()
        {
            for (int i = 0; i < LampsTot.Count(); i++)
                if (LampsTot[i].IsOn == false)
                    LampsTot[i].Toggle();  
        }
        public void TurnOffAll()
        {
            for (int i = 0; i < LampsTot.Count(); i++)
                if (LampsTot[i].IsOn == true)
                    LampsTot[i].Toggle();    
        }
        public void TurnLampOffById(Guid id)
        {
            for (int i = 0; i < LampsTot.Count(); i++)
            
                if (LampsTot[i].GetId() == id)
                    if (LampsTot[i].IsOn == true)
                        LampsTot[i].Toggle(); 
        }
        public void TurnLampOffByName(string name)
        {
            for (int i = 0; i < LampsTot.Count(); i++)
            
                if (LampsTot[i].GetName() == name)
                    if (LampsTot[i].IsOn == true)
                        LampsTot[i].Toggle();  
        }
        public void RemoveLampByPositionAndId(Guid id, int position)
        {
                if (position < 0) throw new ArgumentOutOfRangeException("position");
                    for (int i = 0; i < LampsTot.Count(); i++)
                         if (LampsTot[i].GetId() == id)
                            LampsTot.Remove(LampsTot[position]);                             
        }
        public void RemoveLampByPositionAndName(string name, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetName() == name)
                     LampsTot.Remove(LampsTot[position]);  
        }
        public void SetIntensityForAllLamps(int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)
                 LampsTot[i].Brightness = brightness;       
        }
        public void SetIntensityLampById(Guid id, int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetId() == id)
                    LampsTot[i].Brightness = brightness;    
        }
        public void SetIntensityByLampName(string name, int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)
                 if (LampsTot[i].GetName() == name)
                     LampsTot[i].Brightness = brightness;    
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
