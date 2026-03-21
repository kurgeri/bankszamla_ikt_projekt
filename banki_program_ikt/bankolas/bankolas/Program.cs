using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;

namespace bankolas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("szamlak.txt", Encoding.UTF8);
            List<Account> list = new List<Account>();
            while (!file.EndOfStream)
            {
                string[] splits = file.ReadLine().Split(';');
                Account a = new Account(splits[0], splits[1], Convert.ToDecimal(splits[2]));
                list.Add(a);
            }

            Felhasznalo(list);
        }

        static void Felhasznalo(List<Account> list)
        {
            string user = string.Empty;
            Console.WriteLine("Tulajdonsok:");
            foreach(Account a in list)
            {
                Console.WriteLine(a.getTulajdonos());
             
            }

            bool bennevan = false;
            do
            {
                Console.Write("Válasza ki a felhasználót az adott listából:");
                user = Console.ReadLine();

                foreach (Account a in list)
                {
                    if (user == a.getTulajdonos())
                    {
                        bennevan = true;
                    }
                }
                if(bennevan == false)
                {
                    Console.WriteLine("Adja meg újra!");
                }


            } while (bennevan == false);

            Menu(list, user);
      
           
        }
        static void Menu(List<Account> list, string user)
        {
            Console.Clear();
            char opcio;

            do
            {
                Console.WriteLine($"Szép napot {user}! ");
                Console.Write($"B: Befiztés\nK: Kivétel\nU: Utalás\nA: Adatok kiírása\nH: Hitelkeret módosítása\nVálasszon a kívánt opciók közül: ");
                opcio = Convert.ToChar(Console.ReadLine().ToUpper());


                switch (opcio)
                {
                    case 'B':
                        Console.Clear();
                        Befiztes(list);
                        break;
                    case 'K':
                        Kivetel(list);
                        break;
                    case 'A':
                        Adatok_Kiir(list);
                        break;
                    case 'H':
                        Hitelkeretmod(list);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Rossz adat");
                        break;
                }

            } while (opcio != 'N' && opcio != 'Ú' && opcio != 'L' && opcio != 'K' && opcio != 'F');


        }
        static void Befiztes(List<Account> list)
        {

     
        }
        static void Kivetel(List<Account> list)
        {


        }
        static void Adatok_Kiir(List<Account> list)
        {
            Console.Clear();
            Console.WriteLine("Adatok:");
            foreach (Account a in list)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("Nyomjon meg egy gombot, hogy vissza térjen a menübe!");
            Console.ReadKey();
        
        }
        static void Hitelkeretmod(List<Account> list)
        {


        }
        


    }
}




