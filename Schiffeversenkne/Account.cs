﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    class Account
    {
        public string name;
        public bool[] spielfeld = { false, false, false, false, false, false, false, false, false };
        public int[] ram = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] genram = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int gesamtPunkte = 0;

    }
}
