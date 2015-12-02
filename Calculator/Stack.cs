using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Stack
    {
        public string LastIn { get; set; }
        public string LastOut { get; set; }

        public void Update(string input, string output)
        {
            LastIn = input;
            LastOut = output;
        }
    }
}
