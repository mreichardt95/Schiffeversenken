using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    public class ZeigeFeld
    {
        public void AktuellesFeld(string[,] spielfeld)
        {
            Console.WriteLine();

            for (int b = 0; b < spielfeld.GetLength(0); b++)
            {
                for (int h   = 0; h < spielfeld.GetLength(1); h++)
                {
                    if (spielfeld[b, h] == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + spielfeld[b, h]);
                        Console.ResetColor();
                    }
                    else Console.Write(" " + spielfeld[b, h]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void BeschossenesFeld(string[,] spielfeld)
        {
            Console.WriteLine();

            for (int b = 0; b < spielfeld.GetLength(0); b++)
            {
                for (int h = 0; h < spielfeld.GetLength(1); h++)
                {
                    if (spielfeld[b, h] == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" " + spielfeld[b, h]);
                        Console.ResetColor();
                    }
                    else Console.Write(" " + spielfeld[b, h]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
