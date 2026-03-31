using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankolas
{
    internal class Account
    {
        private string szamlaszam;
        private string tulajdonos;
        private decimal egyenleg;
        private decimal nyitoegyenleg;
        private decimal hitelkeret;
        private bool hitelkeretmodositva;
        private string muvelet;
        private List<string> naplo;


        public Account(string invnum, string owner, decimal balance)
        {
            szamlaszam = invnum;
            tulajdonos = owner;
            egyenleg = balance;
            nyitoegyenleg = balance;
            hitelkeretmodositva = false;
            naplo = new List<string>();

        
  
        }
        public string getSzamlaszam()
        {
            return szamlaszam;
        }
        public string getTulajdonos()
        { return tulajdonos; }

        public decimal getEgyenleg()
        {
            return egyenleg;
        }
        public decimal getHitelkeret()
        {
            return hitelkeret;
        }
        public bool getHitelMod()
        {
            return hitelkeretmodositva;
        }
        public bool HitelKeretChange(decimal input)
        {
            if (input <= (nyitoegyenleg / 100) * 20)
            {
                hitelkeretmodositva = true;
                muvelet = "Hitelkeret módosítása";
                hitelkeret = input;
                return true;
            }
            else
            {
                return false;
            }
            
        }

      
    

        public bool DepositSuccesfull(decimal osszeg)
        {
      
            if (osszeg > 0)
            {
                egyenleg += osszeg;
                muvelet = "Befizetés";
                return true;
               
            }
            else
            {
                return false;
            
            }
            
            
        }

        public bool WithDrawSuccesfull(decimal osszeg)
        {
            if (egyenleg - osszeg >= 0)
            {
                egyenleg = egyenleg - osszeg;
                muvelet = "Kifizetés";
                return true;
            }
            else
            {
                return false;
            }

           
        }
        public bool Utalas()
        {
            muvelet = "Utalás";
            return true;
        }

        

        public List<string> Naplozas()
        {
            DateTime date = DateTime.Now;
            naplo.Add($"Adatok:\nTulajdonos:{tulajdonos};Egyenleg:{egyenleg};Számlaszám:{szamlaszam};Hitelkeret: {hitelkeret}\nMódosítás:{muvelet}\nDátum:{date}\n");
            return naplo;
        }

        public override string ToString()
        {
            return $"Tulajdonos:{tulajdonos};Egyenleg:{egyenleg};Számlaszám:{szamlaszam};Hitelkeret: {hitelkeret}";
        }
    }
}
