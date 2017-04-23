using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenkne
{
    public class Account
    {
        public string name;
        public string[,] spielfeld = new string[3, 3] { {"o", "o", "o"}, {"o", "o", "o"}, { "o", "o", "o" } };
        public string[,] beschuss = new string[3, 3] { { "o", "o", "o" }, { "o", "o", "o" }, { "o", "o", "o" } };
        public int gesamtPunkte = 0;

    }
}
