using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parse
    {
        public string ParsedData;
        public string[] Terms;
        public char Operator;
        public void ParseInput(string input)
        {
            string output = input.ToLower();
            Regex whitespace = new Regex(@"\s");
            output = whitespace.Replace(output, "");
            ParsedData = output;
            Terms = new string[] { output.Substring(0, 1), output.Substring(2, 1) };
            Operator = output[1];
        }
    }
}
