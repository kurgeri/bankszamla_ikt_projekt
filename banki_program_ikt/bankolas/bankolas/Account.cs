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
        private decimal hitelkeret;
        private List<string> naplo;


        public Account(string invnum, string owner, decimal balance)
        {
            szamlaszam = invnum;
            tulajdonos = owner;
            egyenleg = balance;

        
  
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
        public bool HitelKeretChange(decimal input)
        {
            if (input <= (egyenleg / 100) * 20)
            {
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
                return true;
            }
            else
            {
                return false;
            }

           
        }

        

        public List<string> Naplozas(string muvelet)
        {
            DateTime date = DateTime.Now;
            naplo.Add(Convert.ToString(date));
            naplo.Add(Convert.ToString(egyenleg));
            naplo.Add(muvelet);
            return naplo;
            // Minden adatot kikéne naplózni, ki mit mikor 
        }

        public override string ToString()
        {
            return $"Tulajdonos:{tulajdonos}, Egyenleg:{egyenleg}, Számlaszám:{szamlaszam} Hitelkeret: {hitelkeret}";
        }
    }
}
