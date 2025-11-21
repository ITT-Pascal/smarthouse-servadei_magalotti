using System;
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
        /*

        AbstractLamp? FindLampWithMinIntensity() -> return della lampada con minima intensità
        List<AbstractLamp> FindLampsByIntensityRange(int min, int max) -> return delle lampade con intensità in un certo range
        List<AbstractLamp> FindAllOn() -> return delle lampade che si trovano in stato acceso
        List<AbstractLamp> FindAllOff() -> return delle lampade che sono trovano in stato spento
        AbstractLamp? FindLampById(Guid id) -> return della lampada con Guid specificato
        List<AbstractLamp> SortByIntensity(bool descending) -> return delle lampade
        */


        /*public List<Lamp> Lamps = new List<Lamp> { }; 
        public List<Ecolamp> Ecolamps = new List<Ecolamp> { };   
        */
        //Properties
        public List<LampModel> LampsTot { get; private set; }
        //Costructor
        public LampRow() 
        { 
            List<LampModel> LampsTotT = new List<LampModel>();   
        }
        //methods
        public void AggiungiLamp() 
        {
            Lamp Lamp1 = new Lamp("Lampada",false);
            LampsTot.Add(new Lamp("Lampada", false));
        }
        public void AggiungiEcoLamp() 
        { 
            Ecolamp EcoLamp1 = new Ecolamp("EcoLampada",true);
            LampsTot.Add(new Ecolamp("EcoLampada",true));
        }
        public void aggiungiLampadeDaltipo(bool IsLamp)
        {
            if(IsLamp== true)
            {
                AggiungiLamp();
            }
            AggiungiEcoLamp();
        }
        public void AccendiLampInBaseAllaPosizione(int Position)
        {
            if (Position < 0) throw new ArgumentOutOfRangeException("position");
                if (LampsTot[Position].IsOn == false)
                {
                LampsTot[Position].SwitchOnOff();
                }
        }
        public void SpegniLampInBaseAllaPosizione(int Position)
        {
            if (Position < 0) throw new ArgumentOutOfRangeException("position");
            if (LampsTot[Position].IsOn == true)
            {
                LampsTot[Position].SwitchOnOff();
            }
        }
        public void AccendiTutte()
        {
            for (int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].IsOn == false)
                {
                    LampsTot[i].SwitchOnOff();
                }
            }
        }
        public void SpegniTutte()
        {
            for (int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].IsOn == true)
                {
                    LampsTot[i].SwitchOnOff();
                }
            }
        }
        public void SwitchOff(Guid id)
        {
            
            for (int i = 0; i< LampsTot.Count(); i++)
            {
                if (LampsTot[i].GetId() == id)
                {
                    if (LampsTot[i].IsOn == true)
                        LampsTot[i].SwitchOnOff();
                }                  
            }
        }
        public void SwitchOff(string name)
        {
            for (int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].GetName() == name)
                {
                    if (LampsTot[i].IsOn == true)
                        LampsTot[i].SwitchOnOff();
                }
            }
        }
        public void RemoveLampInPosition(Guid id, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position");
            for (int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].GetId() == id)
                {
                    LampsTot.Remove(LampsTot[position]);
                }
            }
        }
        public void RemoveLampInPosition(string name, int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position");
            for (int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].GetName() == name)
                {
                    LampsTot.Remove(LampsTot[position]);
                }
            }
        }
        public void SetIntensityForAllLamps(int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i<LampsTot.Count(); i++)
            {
                LampsTot[i].Brightness = brightness;                  
            }
        }
        public void SetIntensityForLamp(Guid id, int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].GetId() == id)
                    LampsTot[i].Brightness = brightness;                                  
            }
        }
        public void SetIntensityForLamp(string name, int brightness)
        {
            if (brightness > 10 && brightness < 0) throw new ArgumentOutOfRangeException("cannot exced max brightness, ");
            for (int i = 0; i < LampsTot.Count(); i++)            
            {
                if (LampsTot[i].GetName() == name)
                        LampsTot[i].Brightness = brightness;
            }
        }
        public LampModel FindLampWithMaxIntensity()
        {
            LampModel model = null;
            int highestBrightness = 0;
            for(int i = 0; i < LampsTot.Count(); i++)
            {
                if (LampsTot[i].Brightness > highestBrightness)
                    highestBrightness = LampsTot[i].Brightness;
                    model = LampsTot[i];
            }
            return model;
        }


        //TODO 
        public void SpegniLamp(bool isLamp)
            
        { 
            if(isLamp == true)
            {
                throw new NotImplementedException();    
            }
        
        
        }    
    }
}
