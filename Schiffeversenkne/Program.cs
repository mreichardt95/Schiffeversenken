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
        static SchiffeSetzen setzen = new SchiffeSetzen(Spieler1, Spieler2);
        static SchiffeVersenken versenken = new SchiffeVersenken(Spieler1, Spieler2);
        static void Main(string[] args)
        {
            Init();
            Game();
            Result();
        }
/// End of Main //////////////////////////////////////
        static void Init ()
        {
        for (int i = 0; i <= 2; i++)
        {
                for (int s = 0; s <= 2; s++)
                {
                    Spieler1.spielfeld[i, s] = "o";
                    Spieler2.spielfeld[i, s] = "o";
                }
        }
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
        }

        static void Game ()
        {

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
                    setzen.SchiffePlatzieren(Spieler1.name, Spieler1.spielfeld, setzen.PlatzierungEinlesen(Spieler1.name));
                    //Schiffe setzen Spieler 2
                    setzen.SchiffePlatzieren(Spieler2.name, Spieler2.spielfeld, setzen.PlatzierungEinlesen(Spieler2.name));
                    //Schiffe versenken
                    Console.Clear();
                    Console.WriteLine("Schiffe versenken...");
                    Console.WriteLine();
                    aktuellerSpieler = versenken.TipMensch(Spieler1.name, Spieler2.spielfeld);
                    while (Spieler1.gesamtPunkte < 3 && Spieler2.gesamtPunkte < 3)
                    {
                        switch (aktuellerSpieler)
                        {
                            case 1:
                                Console.WriteLine("Punkte: " + Spieler1.gesamtPunkte);
                                aktuellerSpieler = versenken.TipMensch(Spieler1.name, Spieler2.spielfeld);
                                break;
                            case 2:
                                Console.WriteLine("Punkte: " + Spieler2.gesamtPunkte);
                                aktuellerSpieler = versenken.TipMensch(Spieler2.name, Spieler1.spielfeld);
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
                    setzen.SchiffePlatzieren(Spieler1.name, Spieler1.spielfeld, setzen.PlatzierungEinlesen(Spieler1.name));
                    //Schiffe generieren Maschine 2
                    setzen.SchiffePlatzieren(Spieler2.name, Spieler2.spielfeld, setzen.PlatzierungGenerieren(Spieler2.name));
                    System.Threading.Thread.Sleep(500);
                    //Versenken
                    Console.Clear();
                    Console.WriteLine("Schiffe versenken...");
                    Console.WriteLine();
                    aktuellerSpieler = versenken.TipMensch(Spieler1.name, Spieler2.spielfeld);
                    while (Spieler1.gesamtPunkte < 3 && Spieler2.gesamtPunkte < 3)
                    {
                        switch (aktuellerSpieler)
                        {
                            case 1:
                                Console.WriteLine("Punkte: " + Spieler1.gesamtPunkte);
                                aktuellerSpieler = versenken.TipMensch(Spieler1.name, Spieler2.spielfeld);
                                break;
                            case 2:
                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine("Punkte: " + Spieler2.gesamtPunkte);
                                aktuellerSpieler = versenken.TipMaschine(Spieler2.name, Spieler1.spielfeld);
                                break;
                            default:
                                break;
                        }
                    }
                    break;///End of Case 2
                case 3: // Case 3 //////////////////////////////////////////////////////////////////
                    Spieler1.name = name1;
                    Spieler2.name = name2;
                    //Schiffe setzen Maschine 1
                    setzen.SchiffePlatzieren(Spieler1.name, Spieler1.spielfeld, setzen.PlatzierungGenerieren(Spieler1.name));
                    System.Threading.Thread.Sleep(500);
                    //Schiffe setzen Maschine 2
                    setzen.SchiffePlatzieren(Spieler2.name, Spieler2.spielfeld, setzen.PlatzierungGenerieren(Spieler2.name));
                    System.Threading.Thread.Sleep(500);
                    //Versenken
                    Console.Clear();
                    Console.WriteLine("Schiffe versenken...");
                    Console.WriteLine();
                    aktuellerSpieler = versenken.TipMaschine(Spieler1.name, Spieler2.spielfeld);
                    while (Spieler1.gesamtPunkte < 3 && Spieler2.gesamtPunkte < 3)
                    {
                        switch (aktuellerSpieler)
                        {
                            case 1:
                                //foreach (int i in Spieler1.ram) Console.Write("{0} ", i);
                                System.Threading.Thread.Sleep(750);
                                aktuellerSpieler = versenken.TipMaschine(Spieler1.name, Spieler2.spielfeld);
                                break;
                            case 2:
                                //foreach (int i in Spieler2.ram) Console.Write("{0} ", i);
                                System.Threading.Thread.Sleep(750);
                                aktuellerSpieler = versenken.TipMaschine(Spieler2.name, Spieler1.spielfeld);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        static void Result ()
        {
            //Auswertung
            if (Spieler1.gesamtPunkte == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSieger: " + Spieler1.name);
                Console.ResetColor();
            }
            else if (Spieler2.gesamtPunkte == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSieger: " + Spieler2.name);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }
    
    }
}
