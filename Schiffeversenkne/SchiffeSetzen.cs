using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    public class SchiffeSetzen
    {
        Random rnd = new Random();
        Account Spieler1;
        Account Spieler2;
        private ZeigeFeld zeige = new ZeigeFeld();

        public SchiffeSetzen (Account Spieler1, Account Spieler2)
        {
            this.Spieler1 = Spieler1;
            this.Spieler2 = Spieler2;
        }

        //Schiffe vor dem Platzieren einlesen
        public void PlatzierungEinlesen(string spieler, string[,] spielfeld)
        {
            Console.Clear();
            Console.WriteLine("Platziere Schiffe " + spieler);
            Console.WriteLine();
            int[] einlesen = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine();
                Console.Write("Platziere Schiff " + ( i + 1 ) + " auf x Coordinate: ");
                int tempx = Convert.ToInt32(Console.ReadLine());
                Console.Write("Platziere Schiff " + ( i + 1 ) + " auf y Coordinate: ");
                int tempy = Convert.ToInt32(Console.ReadLine());

                if ((tempx < 1 || tempx > 3) | (tempy < 1 || tempy > 3))
                {
                    Console.WriteLine("Wert muss  zwischen 1 und 3 liegen!");
                    i--;
                }
                else
                {
                    einlesen[i] = (tempx - 1);
                    einlesen[i + 3] = (tempy - 1);
                }
                SchiffePlatzieren(spieler, spielfeld, einlesen, i);
            }
        }///Ende
        //Schiffe vor dem Platzieren generieren
        public void PlatzierungGenerieren(string spieler, string[,] spielfeld)
        {
            Console.Clear();
            int[] generieren = new int[6];
            for (int i = 0; i <= 2; i++)
            {
                int tempx = rnd.Next(0, 3);
                int tempy = rnd.Next(0, 3);

                generieren[i] = tempx;
                generieren[i + 3] = tempy;

                if (spielfeld[tempx, tempy] == "x") i--;

                SchiffePlatzieren(spieler, spielfeld, generieren, i);

                /// Console
                Console.WriteLine("Platziere Schiffe " + spieler + "...");
                if (spieler == Spieler1.name) zeige.AktuellesFeld(Spieler1.spielfeld);
                else if (spieler == Spieler2.name) zeige.AktuellesFeld(Spieler2.spielfeld);
                Console.WriteLine("Platziere Schiff " + (i + 1));
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                ///Console


            }
        }///Ende
        //Schiffe werden Platziert
        public void SchiffePlatzieren(string spieler, string[,] spielfeld, int[] temp, int r)
        {
            if (spieler == Spieler1.name)
            {
                Spieler1.spielfeld[temp[r], temp[r + 3]] = "x";
            }
            else if (spieler == Spieler2.name)
            {
                Spieler2.spielfeld[temp[r], temp[r + 3]] = "x";
            }
        }///Ende
    }
}
