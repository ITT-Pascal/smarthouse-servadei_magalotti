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

        /* FUNZIONI DA FARE PER LAMPS ROW
        SwitchOff(Guid id) -> spegne solo la lampada con il Guid specificato
        SwitchOff(string name) -> spegne solo la lampada con il name specificato
        RemoveLampInPosition(Guid id, int position) -> rimuove una nuova lampada in una posizione specifica
        RemoveLampInPosition(string name, int position) -> rimuove una nuova lampada in una posizione specifica
        SetIntensityForAllLamps(int intensity) -> setta l'intensità di ogni lampada ad una intensità specifica
        SetIntensityForLamp(Guid id, int intensity) -> setta l'intensità di una lampada specifica ad una intensità specifica
        SetIntensityForLamp(string name, int intensity) -> setta l'intensità di una lampada specifica ad una intensità specifica
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
