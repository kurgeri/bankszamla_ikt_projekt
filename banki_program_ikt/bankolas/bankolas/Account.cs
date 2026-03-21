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


        public Account(string invnum, string owner, decimal balance)
        {
            szamlaszam = invnum;
            tulajdonos = owner;
            egyenleg = balance;
  
        }

        public override string ToString()
        {
            return $"Tulajdonos:{tulajdonos}, Egyenleg:{egyenleg}, Számlaszám:{szamlaszam}";
        }
    }
}
