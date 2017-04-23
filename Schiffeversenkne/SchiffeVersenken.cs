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
        private ZeigeFeld zeige = new ZeigeFeld();
        Random rnd = new Random();
        private int[] tip = { 0, 0 };
        public SchiffeVersenken(Account Spieler1, Account Spieler2)
        {
            this.Spieler1 = Spieler1;
            this.Spieler2 = Spieler2;
        }
        //Menschlichen Tip einlesen
        public int TipMensch(string spieler, string[,] spielfeld, string[,] beschuss)
        {
            Console.Write("\nAngriff " + spieler + " auf x: ");
            tip[0] = (Convert.ToInt32(Console.ReadLine()) - 1);
            Console.Write("Angriff " + spieler + " auf y: ");
            tip[1] = (Convert.ToInt32(Console.ReadLine()) - 1);
            return Versenken(spieler, spielfeld, tip, beschuss);
        }///Ende
        //Maschinellen Tip generieren
        public int TipMaschine(string spieler, string[,] spielfeld, string[,] beschuss)
        {
            //do {
                tip[0] = rnd.Next(0, 3);
                tip[1] = rnd.Next(0, 3);
            //} while ();


            Console.WriteLine("\nAngriff " + spieler + ": " + (tip[0] + 1) + " , " + (tip[1] + 1) );

            if (spieler == Spieler1.name) Spieler1.beschuss[tip[0], tip[1]] = "x";
            else if (spieler == Spieler2.name) Spieler2.beschuss[tip[0], tip[1]] = "x";

            return Versenken(spieler, spielfeld, tip, beschuss);
        }
        ///Ende
        //Versenken
        public int Versenken(string spieler, string[,] spielfeld, int[] temp, string[,] beschuss)
        {
            int punkt = 0;

            zeige.BeschossenesFeld(beschuss);

            // Spieler 1, kein Treffer, Treffer
            if (spieler == Spieler1.name)
            {
                if (spielfeld[(temp[0]), (temp[1])] == "o")
                {
                    punkt = 2;
                    daneben();
                } else if (spielfeld[(temp[0]), (temp[1])] == "x")
                {
                    punkt = 1;
                    treffer();
                    Spieler1.gesamtPunkte++;
                    spielfeld[temp[0], temp[1]] = "o";
                }
            }

            // Spieler 2, kein Treffer, Treffer
            if (spieler == Spieler2.name)
            {
                if (spielfeld[(temp[0]), (temp[1])] == "o")
                {
                    punkt = 1;
                    daneben();
                }
                else if (spielfeld[(temp[0]), (temp[1])] == "x")
                {
                    punkt = 2;
                    treffer();
                    Spieler2.gesamtPunkte++;
                    spielfeld[temp[0], temp[1]] = "o";
                }
            }
            return punkt;
        }///Ende
        private void daneben()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Daneben");
            Console.ResetColor();
        }
        private void treffer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Treffer");
            Console.ResetColor();
        }
    }
}
