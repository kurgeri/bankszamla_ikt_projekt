using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bankolas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("szamlak.txt", Encoding.UTF8);
            List<Account> list = new List<Account>();
            while(!file.EndOfStream)
            {
                string[] splits = file.ReadLine().Split(';');
                Account a = new Account(splits[0], splits[1], Convert.ToDecimal(splits[2]));
                list.Add(a);
            }
            foreach(Account a  in list)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}
