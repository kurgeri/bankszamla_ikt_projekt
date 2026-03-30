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
            foreach (Account a in list)
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
                if (bennevan == false)
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
                        Befiztes(list, user);
                        break;
                    case 'K':
                        Console.Clear();
                        Kivetel(list, user);
                        break;
                    case 'U':
                        Console.Clear();
                        Utalas(list, user);
                        break;
                    case 'A':
                        Adatok_Kiir(list, user);
                        break;
                    case 'H':
                        Console.Clear();
                        Hitelkeretmod(list,user);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Rossz adat");
                        break;
                }

            } while (opcio != 'B' && opcio != 'K' && opcio != 'A' && opcio != 'H' && opcio != 'U');


        }
        static void Befiztes(List<Account> list, string user)
        {
            decimal befizetett = 0;
            bool sikeresbefiz = false;
            do
            {
                Console.Write("Mennyit szeretne befizetni?: ");
                string bekert = Console.ReadLine();
                if (!DecConverter(bekert))
                {
                    Console.WriteLine("Nem megfelelő adat típust adott meg!");
                }
                else
                {
                    befizetett = Convert.ToDecimal(bekert);



                    foreach (Account a in list)
                    {
                        if (user == a.getTulajdonos() && a.DepositSuccesfull(befizetett) == true)
                        {
                            sikeresbefiz = true;
                        }
                        else if (user == a.getTulajdonos() && a.DepositSuccesfull(befizetett) == false)
                        {

                            Console.WriteLine("Negatív összeget nem adhat hozzá a számlájához!");

                        }
                    }
                }
            } while (sikeresbefiz == false);

            Console.WriteLine("Sikeres befizetés! Nyomjon meg egy gombot, hogy vissza térjen a menübe");
            Console.ReadKey();
            Menu(list, user);
        }
        static void Kivetel(List<Account> list, string user)
        {
            decimal kivett = 0;
            bool sikereskivet = false;
            do
            {

                Console.Write("Mennyit szeretne kivenni?: ");
                string bekert = Console.ReadLine();


                if (!DecConverter(bekert))
                {
                    Console.WriteLine("Nem megfelelő adat típust adott meg!");
                }
                else
                {
                    kivett = Convert.ToDecimal(bekert);

                    foreach (Account a in list)
                    {
                        if (user == a.getTulajdonos() && a.WithDrawSuccesfull(kivett) == true)
                        {
                            sikereskivet = true;
                        }
                        else if (user == a.getTulajdonos() && a.WithDrawSuccesfull(kivett) == false)
                        {

                            Console.WriteLine("Nem vehet ki többet a számlájáról mint amennyi pénz van rajta!");

                        }
                    }
                }
            } while (sikereskivet == false);
            Console.WriteLine("Sikeres kivétel! Nyomjon meg egy gombot, hogy vissza térjen a menübe");
            Console.ReadKey();
            Menu(list, user);

        }
        static void Utalas(List<Account> list, string user)
        {

            List<string> szemelyek = new List<string>();

            foreach (Account a in list)
            {

                if (user == a.getTulajdonos() && a.getEgyenleg() <= 0)
                {

                }
                else if (user != a.getTulajdonos())
                {
                    szemelyek.Add(a.getTulajdonos());
                }
            }

            Console.WriteLine("Személyek akiknek tud utalni");
            foreach (string s in szemelyek)
            {
                Console.WriteLine(s);
            }
            bool goodinput = false;
            string utaltszemely = string.Empty;

            do
            {


                Console.WriteLine("Kinek szeretne utalni?");
                utaltszemely = Console.ReadLine();
                foreach (string s in szemelyek)
                {
                    if (utaltszemely == s)
                    {

                        goodinput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Nincs ilyen személy a listában!");
                    }

                }
            } while (goodinput == false);
            goodinput = false;
            decimal utalando = 0;
            do
            {

                Console.WriteLine("Mennyit szeretne utalni?:");
                string bekert = Console.ReadLine();
                if (!DecConverter(bekert))
                {

                    Console.WriteLine("Nem megfelelő adat típust adott meg!");
                }
                else
                {
                    utalando = Convert.ToDecimal(bekert);

                    foreach (Account a in list)
                    {

                    }

                }

            } while (goodinput == false);

        }
        static void Adatok_Kiir(List<Account> list, string user)
        {
            Console.Clear();
            Console.WriteLine("Adatok:");
            foreach (Account a in list)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("Nyomjon meg egy gombot, hogy vissza térjen a menübe!");
            Console.ReadKey();
            Menu(list, user);

        }
        static void Hitelkeretmod(List<Account> list,string user)
        {
            decimal keret = 0;
            string bekert = string.Empty;
            bool ervenyeshitelkeret = false;

            do
            {
                Console.WriteLine("Adja meg a hitelkeret méretét(A nyitóegyenlegének max 20%-a:");
                bekert = Console.ReadLine();
                if (!DecConverter(bekert))
                {

                    Console.WriteLine("Nem megfelelő adat típust adott meg!");
                }
                else
                {
                    keret = Convert.ToDecimal(bekert);
                    foreach (Account a in list)
                    {
                        if (a.getTulajdonos() == user &&  a.HitelKeretChange(keret) == true)
                        {
                            ervenyeshitelkeret = true;
                        }
                        else if(a.getTulajdonos() == user && a.HitelKeretChange(keret) == false)
                        {
                            Console.WriteLine("Több mint a 20%-a!");
                        }
                    }
                }

            } while (DecConverter(bekert) == false || ervenyeshitelkeret == false);
            Console.WriteLine("Sikeres módosítás, nyomjon meg egy gombot, hogy visszatérjen a menübe");
            Console.ReadKey();
            Menu(list, user);


        }

        static bool DecConverter(string bekert)
        {
            try
            {
                Convert.ToDecimal(bekert);
                return true;
            }
            catch (Exception ex)

            { return false; }
        }

    }
}




