using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    class Program
    {
        //Definition
        static int eingabe;
        static string name1;
        static string name2;
        static int aktuellerSpieler;
        static Account Spieler1 = new Account();
        static Account Spieler2 = new Account();
        static Random rnd = new Random();


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Mensch gegen Mensch:     1");
            Console.WriteLine("Mensch gegen Maschine:   2");
            Console.WriteLine("Maschine gegen Maschine: 3");
            Console.ResetColor();

            do
            {
                Console.Write("\nEingabe: ");
                eingabe = Convert.ToInt32(Console.ReadLine());

            }
            while (eingabe < 1 || eingabe > 3);

            Console.Write("\nErster Name: ");
            name1 = Console.ReadLine();

            do
            {
                Console.Write("\nZweiter Name: ");
                name2 = Console.ReadLine();
            }
            while (name1 == name2);

            switch (eingabe)
            {
                case 1: // Case 1 //////////////////////////////////////////////////////////////////
                    if ((rnd.Next(0, 2)) == 0)
                    {
                        Spieler1.name = name1;
                        Spieler2.name = name2;
                        Console.WriteLine("\n" + name1 + " darf beginnen.");
                    }
                    else
                    {
                        Spieler2.name = name2;
                        Spieler2.name = name1;
                        Console.WriteLine("\n" + name2 + " darf beginnen.");
                    }
                    //Schiffe setzen Spieler 1
                    SchiffePlatzieren(Spieler1.name, Spieler1.spielfeld, PlatzierungEinlesen(Spieler1.name));
                    //Schiffe setzen Spieler 2
                    SchiffePlatzieren(Spieler2.name, Spieler2.spielfeld, PlatzierungEinlesen(Spieler2.name));
                    //Schiffe versenken
                    Console.Clear();
                    TipMensch(Spieler1.name, Spieler2.spielfeld);
                    while (Spieler1.gesamtPunkte < 3 && Spieler2.gesamtPunkte < 3)
                    {
                        switch (aktuellerSpieler)
                        {
                            case 1:
                                Console.WriteLine("Punkte: "+ Spieler1.gesamtPunkte);
                                TipMensch(Spieler1.name, Spieler2.spielfeld);
                                break;
                            case 2:
                                Console.WriteLine("Punkte: " + Spieler2.gesamtPunkte);
                                TipMensch(Spieler2.name, Spieler1.spielfeld);
                                break;
                            default:
                                break;
                        }
                    }
                    break; ///End of Case 1
                case 2: // Case 2 //////////////////////////////////////////////////////////////////
                    Spieler1.name = name1;
                    Spieler2.name = name2;
                    //Schiffe setzen Spieler 1
                    SchiffePlatzieren(Spieler1.name, Spieler1.spielfeld, PlatzierungEinlesen(Spieler1.name));
                    //Schiffe generieren Maschine 2
                    SchiffePlatzieren(Spieler2.name, Spieler2.spielfeld, PlatzierungGenerieren(Spieler2.name, Spieler2.genram));
                    Console.WriteLine(Spieler1.gesamtPunkte);
                    Console.WriteLine(Spieler2.gesamtPunkte);
                    TipMensch(Spieler1.name, Spieler2.spielfeld);
                    while (Spieler1.gesamtPunkte < 3 && Spieler2.gesamtPunkte < 3)
                    {
                        switch (aktuellerSpieler)
                        {
                            case 1:
                                Console.WriteLine("Punkte: " + Spieler1.gesamtPunkte);
                                TipMensch(Spieler1.name, Spieler2.spielfeld);
                                break;
                            case 2:
                                Console.WriteLine("Punkte: " + Spieler2.gesamtPunkte);
                                System.Threading.Thread.Sleep(500);
                                TipMaschine(Spieler2.name, Spieler1.spielfeld, Spieler2.ram);
                                break;
                            default:
                                break;
                        }
                    }
                    break;///End of Case 2
                case 3: // Case 3 //////////////////////////////////////////////////////////////////
                    Spieler1.name = name1;
                    Spieler2.name = name2;
                    Console.WriteLine("\nSwitch 3");
                    break;
                default:
                    break;
            }
            
            //Auswertung
            if(Spieler1.gesamtPunkte == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSieger: " + Spieler1.name);
                Console.ResetColor();
            }
            else if(Spieler2.gesamtPunkte == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSieger: " + Spieler2.name);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }
/// End of Main //////////////////////////////////////
/// End of Main //////////////////////////////////////
/// End of Main //////////////////////////////////////

        //Schiffe vor dem Platzieren einlesen
        static int[] PlatzierungEinlesen(string spieler)
        {
            Console.Clear();
            Console.WriteLine("Platziere Schiffe " + spieler);
            Console.WriteLine();
            int[] einlesen = { 0, 0, 0, 0 };
            for(int i = 1; i <= 3; i++)
            {
                Console.Write("Platziere Schiff " + i +": ");
                int temp = Convert.ToInt32(Console.ReadLine());
                if(temp < 1 || temp > 9)
                {
                    Console.WriteLine("Wert muss  zwischen 1 und 9 liegen!");
                    i--;
                }
                else if(einlesen.Contains(temp))
                {
                    Console.WriteLine("Feld bereits belegt.");
                    i--;
                }
                else
                {
                    einlesen[i] = temp;
                }
            }
            return einlesen;
        }///Ende
        //Schiffe vor dem Platzieren generieren
        static int[] PlatzierungGenerieren(string spieler, int[] genram)
        {
            Console.Clear();
            Console.WriteLine("Platziere Schiffe " + spieler + "...");
            Console.WriteLine();
            int[] generieren = { 0, 0, 0, 0 };
            int s = 9;
            for (int i = 1; i <= 3; i++)
            {
                int t = rnd.Next(0, s);
                int temp = genram[t];
                genram = genram.Where(w => w != genram[t]).ToArray();
                s--;
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("Platziere Schiff " + i);
                generieren[i] = temp;
            }
            return generieren;
        }///Ende
        //Schiffe werden Platziert
        static void SchiffePlatzieren(string spieler,bool[] spielfeld, int[] temp)
        {
            for(int i = 1; i <= 3; i++)
            {
                if(spieler == Spieler1.name)
                {
                    Spieler1.spielfeld[(temp[i]) - 1] = true;
                }
                else if(spieler == Spieler2.name)
                {
                    Spieler2.spielfeld[(temp[i]) - 1] = true;
                }
            }
        }///Ende
        //Menschlichen Tip einlesen
        static void TipMensch(string spieler, bool[] spielfeld)
        {
            Console.Write("\nAngriff " + spieler + ": ");
            int tip = Convert.ToInt32(Console.ReadLine());
            aktuellerSpieler = Versenken(spieler, spielfeld, tip);
        }///Ende
        //Maschinellen Tip generieren
        static void TipMaschine(string spieler, bool[] spielfeld, int[] ram)
        {
            int s = 9;
            int t = rnd.Next(0, s);
            int tip = ram[t];
            ram = ram.Where(w => w != ram[t]).ToArray();
            s--;
            Console.WriteLine("\nAngriff " + spieler + ": " + tip);
            aktuellerSpieler = Versenken(spieler, spielfeld, tip);
        }
        ///Ende
        //Versenken
        static int Versenken(string spieler, bool[]spielfeld, int temp)
        {
            int punkt = 0;
            //Spieler 1 kein Treffer
            if ((spielfeld[temp-1] == false) && (spieler == Spieler1.name))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 1 Treffer
            else if ((spielfeld[temp-1] == true) && (spieler == Spieler1.name))
            {
                punkt = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treffer");
                Console.ResetColor();
                Spieler1.gesamtPunkte++;
                spielfeld[temp - 1] = false;
            }
            //Spieler 2 kein Treffer
            if ((spielfeld[temp - 1] == false) && (spieler == Spieler2.name))
            {
                punkt = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 2 Treffer
            else if ((spielfeld[temp - 1] == true) && (spieler == Spieler2.name))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treffer");
                Console.ResetColor();
                Spieler2.gesamtPunkte++;
                spielfeld[temp - 1] = false;
            }
            return punkt;
        }///Ende
    }
}
