using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static Evaluate calculator = new Evaluate();
        static int counter = 0;

        static void Main(string[] args)
        {
            string input = null;
            string output;
            string prompt;
            string welcome = "Welcome to Simple Calculator";
            
            Console.WriteLine(welcome);
            while (input != "exit")
            {
                prompt = "[" + counter + "]> ";
                Console.Write(prompt);
                input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                output = Handler(input);
                Console.WriteLine("    = " + output);
            }
        }

        static string Handler(string input)
        {
            int InputType = calculator.Input(input);
            if (InputType == 0)
            {
                return null;
            }
            else if (InputType == 1)
            {
                counter++;
                return calculator.Result;
            } else
            {
                return null;
            }
        }
    }
}