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
        private int tempx;
        private int tempy;
        private int tempx1;
        private int tempy1;
        private int tempx2;
        private int tempy2;

        public SchiffeSetzen (Account Spieler1, Account Spieler2)
        {
            this.Spieler1 = Spieler1;
            this.Spieler2 = Spieler2;
        }

        //Schiffe vor dem Platzieren einlesen
        public int[] PlatzierungEinlesen(string spieler)
        {
            Console.Clear();
            Console.WriteLine("Platziere Schiffe " + spieler);
            Console.WriteLine();
            int[] einlesen = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i <= 2; i++)
            {
                Console.Write("Platziere Schiff " + i + " auf x Coordinate: ");
                int tempx = Convert.ToInt32(Console.ReadLine());
                Console.Write("Platziere Schiff " + i + " auf y Coordinate: ");
                int tempy = Convert.ToInt32(Console.ReadLine());
                if ((tempx < 1 || tempx > 9) | (tempy < 1 || tempy > 9))
                {
                    Console.WriteLine("Wert muss  zwischen 1 und 9 liegen!");
                    i--;
                }
                else if (einlesen.Contains(tempx) | einlesen.Contains(tempy))
                {
                    Console.WriteLine("Feld bereits belegt.");
                    i--;
                }
                else
                {
                    einlesen[i] = tempx;
                    einlesen[i + 3] = tempy;
                }
            }
            return einlesen;
        }///Ende
        //Schiffe vor dem Platzieren generieren
        public int[] PlatzierungGenerieren(string spieler)
        {
            Console.Clear();
            Console.WriteLine("Platziere Schiffe " + spieler + "...");
            Console.WriteLine();
            int[] generieren = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i <= 2; i++)
            {
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("Platziere Schiff " + i);
                do
                {
                    int tempx = rnd.Next(0, 3);
                    int tempy = rnd.Next(0, 3);
                } while ((tempx == tempx1 && tempy == tempy1) | (tempx == tempx2 && tempy == tempy2));
                if (i == 0)
                {
                    int tempx1 = tempx;
                    int tempy1 = tempy;
                }
                else if(i == 1)
                {
                    int tempx2 = tempx;
                    int tempy2 = tempy;
                }
                generieren[i] = tempx;
                generieren[i + 3] = tempy;
            }
            return generieren;
        }///Ende
        //Schiffe werden Platziert
        public void SchiffePlatzieren(string spieler, string[,] spielfeld, int[] temp)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (spieler == Spieler1.name)
                {
                    Spieler1.spielfeld[temp[i] - 1, temp[i + 3] - 1] = "x";
                }
                else if (spieler == Spieler2.name)
                {
                    Spieler2.spielfeld[temp[i] - 1, temp[i + 3] - 1] = "x";
                }
            }
        }///Ende
    }
}
