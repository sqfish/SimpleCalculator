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
        private static Regex _operators = new Regex(@"(?<=\b\d+\b\s*)[-+*/]");
        private static Regex invalidSign = new Regex(@"(?<!\d\s*)[-+]\s+\d");

        private static Regex key = new Regex(@"[a-z|A-Z]{1}");
        private static Regex equal = new Regex(@"[=]{1}");
        private static Regex value = new Regex(@"[0-9]");
        private static List<Regex> reqConstant = new List<Regex> { key, equal, value };

        public string Expression;
        public string[] Terms;
        public string Operator;

        public void ParseInput(string input)
        {
            if(!ValidateInput(input))
            {
                throw new FormatException();
            }
            Regex whitespace = new Regex(@"\s");
            Terms = _operators.Split(input);
            Terms[0] = whitespace.Replace(Terms[0], "");
            Terms[1] = whitespace.Replace(Terms[1], "");
            Operator = _operators.Match(input).ToString();
            Expression = Terms[0] + " " + Operator + " " +Terms[1];
        }

        public bool ValidateInput(string input)
        {
            Regex invalidSign = new Regex(@"(?<!\d\s*)[-+]\s+\d");
            MatchCollection invalidChars = invalidSign.Matches(input);
            int count = invalidChars.Count;
            bool valid = true;
            if (count > 0)
            {
                valid = false;
            }
            return valid;
        }

        
    }
}