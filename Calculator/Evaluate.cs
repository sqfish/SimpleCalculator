using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Calculator
{
    public class Evaluate
    {
        public string Expression;
        public string Result;
        private Stack _stack;

        public Evaluate(string input)
        {
            Parse data = new Parse();
            data.ParseInput(input);
            Expression = data.Expression;
 
            DataTable table = new DataTable();
            Result = table.Compute(data.Expression, null).ToString();

            Stack stack = new Stack(Expression, Result);
            _stack = stack;
        }

        public string LastIn { get { return _stack.LastIn; } }
        public string LastOut { get { return _stack.LastOut;  } }
    }
}
