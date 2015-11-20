using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Stack
    {
        private string lastIn;
        private string lastOut;

        public Stack(string input, string output)
        {
            lastIn = input;
            lastOut = output;
        }

        public string LastIn
        {
            get { return lastIn; }

        }

        public string LastOut
        {
            get { return lastOut; }
        }
    }
}
