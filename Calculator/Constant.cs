using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Constant
    {
        private SortedDictionary<string, string> constants;

        public Constant(string input)
        {
            if (!(constants != null))
            {
                constants = new SortedDictionary<string, string>();
            }
            if (ValidateInput(input))
            {
                StoreConstant(input);
            }
        }

        public string this[string key]
        {
            get { return constants[key.ToLower()]; }
            set { StoreConstant(key + "=" + value); }
        }

        private void StoreConstant(string input)
        {
            string[] data = ParseInput(input);
            string key = data[0];
            string value;
            bool keyNotEmpty = constants.TryGetValue(key, out value);
            var result = (keyNotEmpty) ? value : data[1];
            if (keyNotEmpty)
            {
                throw new InvalidOperationException("Key already in use.");
            }
            else
            {
                constants.Add(key, result);
            }
        }

        private string[] ParseInput(string input)
        {
            input = input.ToLower();
            string[] output = Regex.Replace(input, @"\s", "").Split('=');
            return output;
        }

        private bool ValidateInput(string input)
        {
            Regex key = new Regex(@"[a-z|A-Z]{1}");
            Regex equal = new Regex(@"[=]{1}");
            Regex value = new Regex(@"[0-9]");
            List<Regex> requirements = new List<Regex> { key, equal, value };
            bool valid = true;
            foreach (Regex item in requirements)
            {
                valid = item.IsMatch(input);
                if (!valid) { return false; }
            }
            return valid;
        }       
    }
}
