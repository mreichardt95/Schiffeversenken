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
        static string eingabe;
        static string name1;
        static string name2;
        static string spieler1;
        static string spieler2;

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


            
            //do
            //{
            Console.Write("\nEingabe: ");
            string eingabe = Console.ReadLine();
            //}
            //while (eingabe != "1" || eingabe != "2" || eingabe !="3");

            Console.Write("\nErster Name: ");
            string name1 = Console.ReadLine();

            //do
            //{
            Console.Write("\nZweiter Name: ");
            string name2 = Console.ReadLine();
            //}
            //while (name1 == name2);

            Random rnd = new Random();
            if ((rnd.Next(0, 2)) == 0)
            {
                string spieler1 = name1; Console.WriteLine("\n" + name1 + " darf beginnen.");
                string spieler2 = name2;
            }
            else
            {
                string spieler1 = name2; Console.WriteLine("\n" + name2 + " darf beginnen.");
                string spieler2 = name1;
            }

            switch (eingabe)
            {
                case "1":

                    Console.WriteLine("\nSwitch 1");
                    break;
                case "2":
                    Console.WriteLine("\nSwitch 2");
                    break;
                case "3":
                    Console.WriteLine("\nSwitch 3");
                    break;
                default:
                    break;
            }


            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }//End of Main

        //Schiffe vor dem Platzieren einlesen
        int[] PlatzierungEinlesen(string spieler)
        {
            Console.Clear();
            Console.WriteLine("Platziere Schiffe " + spieler);
            int[] einlesen = { 0, 0, 0, 0 };
            for(int i = 3; i <= 3; i++)
            {
                Console.Write("\nPlatziere Schiff " + i);
                int temp = Convert.ToInt32(Console.ReadLine());

                
            }
        }
         
        //Schiffe werden Platziert
        void SchiffePlatzieren(string spieler,bool[] spielfeld, int[] temp)
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
        }
    }
}
