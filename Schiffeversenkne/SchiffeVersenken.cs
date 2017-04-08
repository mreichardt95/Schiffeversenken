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
        public SchiffeVersenken(Account Spieler1, Account Spieler2)
        {
            this.Spieler1 = Spieler1;
            this.Spieler2 = Spieler2;
        }
        //Menschlichen Tip einlesen
        public int TipMensch(string spieler, bool[] spielfeld)
        {
            Console.Write("\nAngriff " + spieler + ": ");
            int tip = Convert.ToInt32(Console.ReadLine());
           return Versenken(spieler, spielfeld, tip);
        }///Ende
        //Maschinellen Tip generieren
        public int TipMaschine(string spieler, bool[] spielfeld, int[] ram, int runde)
        {
            int t = rnd.Next(0, runde);
            int tip = ram[t];
            if (spieler == Spieler1.name)
            {
                Spieler1.runde--;
                Spieler1.ram = Spieler1.ram.Where(w => w != ram[t]).ToArray();
            }
            else if (spieler == Spieler2.name)
            {
                Spieler2.runde--;
                Spieler2.ram = Spieler2.ram.Where(w => w != ram[t]).ToArray();
            }
            Console.WriteLine("\nAngriff " + spieler + ": " + tip);
           return Versenken(spieler, spielfeld, tip);
        }
        ///Ende
        //Versenken
        public int Versenken(string spieler, bool[] spielfeld, int temp)
        {
            int punkt = 0;
            //Spieler 1 kein Treffer
            if ((spielfeld[temp - 1] == false) && (spieler == Spieler1.name))
            {
                punkt = 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Daneben");
                Console.ResetColor();
            }
            //spieler 1 Treffer
            else if ((spielfeld[temp - 1] == true) && (spieler == Spieler1.name))
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
