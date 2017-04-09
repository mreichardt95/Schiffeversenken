using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    public class SchiffeVersenken
    {
        Account Spieler1;
        Account Spieler2;
        int aktuellerSpieler;
        Random rnd = new Random();
        private int[] tip = { 0, 0 };
        public SchiffeVersenken(Account Spieler1, Account Spieler2)
        {
            this.Spieler1 = Spieler1;
            this.Spieler2 = Spieler2;
        }
        //Menschlichen Tip einlesen
        public int TipMensch(string spieler, string[,] spielfeld)
        {
            Console.Write("\nAngriff " + spieler + ": ");
            tip[0] = Convert.ToInt32(Console.ReadLine());
            tip[1] = Convert.ToInt32(Console.ReadLine());
            return Versenken(spieler, spielfeld, tip);
        }///Ende
        //Maschinellen Tip generieren
        public int TipMaschine(string spieler, string[,] spielfeld)
        {
            //do
            //{
                tip[0] = rnd.Next(0, 3);
                tip[1] = rnd.Next(0, 3);
            //} while ();


            Console.WriteLine("\nAngriff " + spieler + ": " + tip);


           return Versenken(spieler, spielfeld, tip);
        }
        ///Ende
        //Versenken
        public int Versenken(string spieler, string[,] spielfeld, int[] temp)
        {
            int punkt = 0;
            //Spieler 1 kein Treffer
            if ((spielfeld[(temp[0]), (temp[1])] == "o") && (spieler == Spieler1.name))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 1 Treffer
            else if ((spielfeld[(temp[0]), (temp[1])] == "x") && (spieler == Spieler1.name))
            {
                punkt = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treffer");
                Console.ResetColor();
                Spieler1.gesamtPunkte++;
                spielfeld[temp[0], temp[1]] = "o";
            }
            //Spieler 2 kein Treffer
            if ((spielfeld[(temp[0]), (temp[1])] == "o") && (spieler == Spieler2.name))
            {
                punkt = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 2 Treffer
            else if ((spielfeld[(temp[0]), (temp[1])] == "x") && (spieler == Spieler2.name))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treffer");
                Console.ResetColor();
                Spieler2.gesamtPunkte++;
                spielfeld[temp[0], temp[1]] = "o";
            }
            return punkt;
        }///Ende
    }
}
