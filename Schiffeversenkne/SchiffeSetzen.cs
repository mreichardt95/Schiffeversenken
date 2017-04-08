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
            int[] einlesen = { 0, 0, 0, 0 };
            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Platziere Schiff " + i + ": ");
                int temp = Convert.ToInt32(Console.ReadLine());
                if (temp < 1 || temp > 9)
                {
                    Console.WriteLine("Wert muss  zwischen 1 und 9 liegen!");
                    i--;
                }
                else if (einlesen.Contains(temp))
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
        public int[] PlatzierungGenerieren(string spieler, int[] genram)
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
        public void SchiffePlatzieren(string spieler, bool[] spielfeld, int[] temp)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (spieler == Spieler1.name)
                {
                    Spieler1.spielfeld[(temp[i]) - 1] = true;
                }
                else if (spieler == Spieler2.name)
                {
                    Spieler2.spielfeld[(temp[i]) - 1] = true;
                }
            }
        }///Ende
    }
}
