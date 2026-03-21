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

        public List<string> Naplozas(string muvelet)
        {
            DateTime date = DateTime.Now;
            naplo.Add(Convert.ToString(date));
            naplo.Add(Convert.ToString(egyenleg));
            naplo.Add(muvelet);
            return naplo;
        }

        public override string ToString()
        {
            return $"Tulajdonos:{tulajdonos}, Egyenleg:{egyenleg}, Számlaszám:{szamlaszam}";
        }
    }
}
