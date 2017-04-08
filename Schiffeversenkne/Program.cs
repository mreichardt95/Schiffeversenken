using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    class Program
    {
        ///Definition
        static bool[] spielfeld1 = { false, false, false, false, false, false, false, false, false };
        static bool[] spielfeld2 = { false, false, false, false, false, false, false, false, false };
        static int[] ram1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int[] ram2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int gesamtPunkte1 = 0;
        static int gesamtPunkte2 = 0;
        static int eingabe;
        static string name1;
        static string name2;
        static string spieler1;
        static string spieler2;
        static int aktuellerSpieler;

        static void Main(string[] args)
        {
            //for(int i = 0; i < 8; i++)
            //{
            //    Console.WriteLine("Spielfeld 1: "+spielfeld1[i]);
            //    Console.WriteLine("Spielfeld 2: "+spielfeld2[i]);
            //}
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

            Random rnd = new Random();
            if ((rnd.Next(0, 2)) == 0)
            {
                spieler1 = name1;
                spieler2 = name2;
                Console.WriteLine("\n" + name1 + " darf beginnen.");
            }
            else
            {
                spieler1 = name2;
                spieler2 = name1;
                Console.WriteLine("\n" + name2 + " darf beginnen.");
            }

            switch (eingabe)
            {
                case 1:
                    Console.WriteLine("\nSwitch 1");
                    //Schiffe setzen Spieler 1
                    SchiffePlatzieren(spieler1, spielfeld1, PlatzierungEinlesen(spieler1));
                    //Schiffe setzen Spieler 2
                    SchiffePlatzieren(spieler2, spielfeld2, PlatzierungEinlesen(spieler2));

                    //Schiffe versenken
                    Console.Clear();
                    TipMensch(spieler1, spielfeld2);
                    while (gesamtPunkte1 < 3 && gesamtPunkte2 < 3)
                    {
                        switch (aktuellerSpieler)
                        {
                            case 1:
                                Console.WriteLine("Punkte: "+ gesamtPunkte1);
                                TipMensch(spieler1, spielfeld2);
                                break;
                            case 2:
                                Console.WriteLine("Punkte: " + gesamtPunkte2);
                                TipMensch(spieler2, spielfeld1);
                                break;
                            default:
                                break;
                        }
                    }

                    //for (int i = 0; i < 8; i++)
                    //{
                    //    Console.WriteLine("Spielfeld 1: " + spielfeld1[i]);
                    //    Console.WriteLine("Spielfeld 2: " + spielfeld2[i]);
                    //}
                    break;
                case 2:
                    Console.WriteLine("\nSwitch 2");
                    break;
                case 3:
                    Console.WriteLine("\nSwitch 3");
                    break;
                default:
                    break;
            }
            
            if(gesamtPunkte1 == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSieger: " + spieler1);
                Console.ResetColor();
            }
            else if(gesamtPunkte2 == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSieger: " + spieler2);
                Console.ResetColor();
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }//End of Main

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
        }//End
         
        //Schiffe werden Platziert
        static void SchiffePlatzieren(string spieler,bool[] spielfeld, int[] temp)
        {
            for(int i = 1; i <= 3; i++)
            {
                if(spieler == spieler1)
                {
                    spielfeld1[(temp[i]) - 1] = true;
                }
                else if(spieler == spieler2)
                {
                    spielfeld2[(temp[i]) - 1] = true;
                }
            }
        }//End
        
        //Menschlichen Tip einlesen
        static void TipMensch(string spieler, bool[] spielfeld)
        {
            Console.Write("\nAngriff " + spieler + ": ");
            int tip = Convert.ToInt32(Console.ReadLine());
            aktuellerSpieler = Versenken(spieler, spielfeld, tip);
        }//End

        //Versenken
        static int Versenken(string spieler, bool[]spielfeld, int temp)
        {
            int punkt = 0;

            //Spieler 1 kein Treffer
            if ((spielfeld[temp-1] == false) && (spieler == spieler1))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 1 Treffer
            else if ((spielfeld[temp-1] == true) && (spieler == spieler1))
            {
                punkt = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treffer");
                Console.ResetColor();
                gesamtPunkte1++;
                spielfeld[temp - 1] = false;
            }
            //Spieler 2 kein Treffer
            if ((spielfeld[temp - 1] == false) && (spieler == spieler2))
            {
                punkt = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 2 Treffer
            else if ((spielfeld[temp - 1] == true) && (spieler == spieler2))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treffer");
                Console.ResetColor();
                gesamtPunkte2++;
                spielfeld[temp - 1] = false;
            }

            return punkt;
        }

    }
}
