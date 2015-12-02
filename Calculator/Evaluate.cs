using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Evaluate
    {
        public string Expression { get; set; }
        public string Result { get; set; }
        
        private Stack _stack { get; set; }
        private Constant _constant { get; set; }

        public string LastIn { get { return _stack.LastIn; } }
        public string LastOut { get { return _stack.LastOut; } }

        private static Regex equal = new Regex(@"[=]{1}");
        private static Regex operators = new Regex(@"(?<=\b\d+\b\s*)[-+*/]");

        public Evaluate()
        {
            _constant = new Constant();
            _stack = new Stack();
        }

        public void Input(string input)
        {
            CheckInputType(input);  
        }

        public void CheckInputType(string input)
        {
            bool isConstantDefinition = equal.IsMatch(input);
            bool isEvaluateExpression = operators.IsMatch(input);
            if (isConstantDefinition)
            {
                _constant.StoreConstant(input);
            }
            else
            {
                input = RetrieveConstant(input);
                Parse data = new Parse();
                data.ParseInput(input);
                Expression = data.Expression;
                DataTable table = new DataTable();
                Result = table.Compute(Expression, null).ToString();
                _stack.Update(Expression, Result);
            }
        }

        public string RetrieveConstant(string input)
        {
            Regex key = new Regex(@"[a-z|A-Z]{1}");
            string currentKey = key.Match(input).ToString();
            string value = null;
            if (currentKey != "")
            {
                value = _constant[currentKey];
                input = input.Replace(currentKey, value);
            }
            return input;
        }
    }
}
