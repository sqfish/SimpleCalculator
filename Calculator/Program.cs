using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string prompt = "[" + counter + "]> ";
            Console.Write(prompt);
            string input = Console.ReadLine();
        }
    }
}
